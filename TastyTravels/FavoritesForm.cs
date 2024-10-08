using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xceed.Document.NET;
using Xceed.Words.NET;


namespace TastyTravels
{
    public partial class FavoritesForm : Form
    {
        private User user;
        private int currentPage = 1;
        private int itemsPerPage = 9;
        List<AnimalInfo> animalsInfo = new List<AnimalInfo>();
        public FavoritesForm(User us)
        {
            user = us;
            InitializeComponent();
            LoadFavoritesFromDatabase();
            InitializeExportButton();
        }


        private void InitializeExportButton()
        {
            Button exportToWordButton = new Button
            {
                Text = "Экспортировать в MS Word",
                Location = new Point(828, 26), // Установите необходимое положение
                Size = new Size(174, 55), // Установите необходимый размер
                Font = new System.Drawing.Font("Century Gothic", 14)
            };
            exportToWordButton.Click += ExportToWordButton_Click; // Привязка обработчика события
            Controls.Add(exportToWordButton); // Добавление кнопки в форму
        }


        private void ExportToWordButton_Click(object sender, EventArgs e)
        {
            CreateAnimalDocument(animalsInfo);
        }

        private void LoadFavoritesFromDatabase()
        {
            // Загрузка данных из базы данных
            using (var context = new Datab())
            {
                var likedAnm = context.Favorites.Where(p => p.UserId == user.Id).ToList();
                foreach (var lr in likedAnm)
                {
                    var ANim = context.AnimalInfo.FirstOrDefault(p => p.Id == lr.AnimalId);

                    animalsInfo.Add(ANim);
                }
                DisplayPage(currentPage);
            }
        }

        private void DisplayPage(int pageNumber)
        {
            panel1.Controls.Clear();
            int startIndex = (pageNumber - 1) * itemsPerPage;
            int endIndex = Math.Min(startIndex + itemsPerPage, animalsInfo.Count);

            int x = 0, y = 0;
            int itemWidth = 250;
            int itemHeight = 150;
            int margin = 15;


            for (int i = startIndex; i < endIndex; i++)
            {
                var animal = animalsInfo[i];
                Panel panel = CreateFavoritePanel(animal);
                panel.Location = new Point(x * (itemWidth + margin * 2), y * (itemHeight + margin));
                panel1.Controls.Add(panel);
                x++;
                if (x >= 3)
                {
                    x = 0;
                    y++;
                }
            }

            button2.Enabled = pageNumber > 1;
            button3.Enabled = endIndex < animalsInfo.Count;

        }

        private System.Drawing.Image ByteArrayToImage(byte[] byteArray)
        {
            using (MemoryStream ms = new MemoryStream(byteArray))
            {
                return System.Drawing.Image.FromStream(ms);
            }
        }


        private Panel CreateFavoritePanel(AnimalInfo animal)
        {
            var panel = new Panel
            {
                Width = 270,
                Height = 150,
                BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            };

            var pictureBox = new PictureBox
            {
                Image = ByteArrayToImage(animal.ImagePath),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Width = 130,
                Height = 130,
                Location = new Point(7, 10)
            };

            var nameLabel = new Label
            {
                Text = animal.Name,
                Location = new Point(140, 10),
                MaximumSize = new Size(100, 50),
                AutoSize = true
            };

            

            var button = new Button
            {
                Text = "Подробнее",
                Location = new Point(140, 110),
                Tag = animal
            };

            button.Click += PageAnimalButton_Click;

            panel.Controls.Add(pictureBox);
            panel.Controls.Add(nameLabel);
          

            return panel;
        }

        private void PageAnimalButton_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            var animal = button.Tag as AnimalInfo;
            var recipeForm = new AboutInfo(animal, user);
            recipeForm.Show();
        }


        private void BtnPrevious_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                DisplayPage(currentPage);
            }
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            if ((currentPage * itemsPerPage) < animalsInfo.Count)
            {
                currentPage++;
                DisplayPage(currentPage);
            }
        }

        
        private void CreateAnimalDocument(List<AnimalInfo> animals)
        {
            string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "Animals.docx");
            using (DocX document = DocX.Create(fileName))
            {
                foreach (var animal in animals)
                {
                    // Заголовок животного
                    document.InsertParagraph(animal.Name)
                        .FontSize(20)
                        .Bold()
                        .Alignment = Alignment.center;

                    // Изображение животного
                    if (animal.ImagePath != null && animal.ImagePath.Length > 0)
                    {
                        string tempImagePath = Path.Combine(Path.GetTempPath(), $"{animal.Id}_img.png");
                        File.WriteAllBytes(tempImagePath, animal.ImagePath);

                        var image = document.AddImage(tempImagePath);
                        var picture = image.CreatePicture();
                        picture.Width = 500;
                        picture.Height = 300;
                        document.InsertParagraph().AppendPicture(picture).Alignment = Alignment.center;

                        File.Delete(tempImagePath); // Удаление временного файла после добавления в документ
                    }

                    // Научное имя
                    document.InsertParagraph("Научное имя: " + animal.ScienceName)
                        .FontSize(12);

                    // Класс
                    document.InsertParagraph("Класс: " + animal.AnimalClass)
                        .FontSize(12);

                    // Отряд
                    document.InsertParagraph("Отряд: " + animal.AnimalSquad)
                        .FontSize(12);

                    // Семейство
                    document.InsertParagraph("Семейство: " + animal.AnimalFamily)
                        .FontSize(12);

                    // Род
                    document.InsertParagraph("Род: " + animal.AnimalGenus)
                        .FontSize(12);

                    // Вид
                    document.InsertParagraph("Вид: " + animal.KindAnimal)
                        .FontSize(12);

                    // Описание
                    document.InsertParagraph("Описание:")
                        .FontSize(12)
                        .Bold();
                    document.InsertParagraph(animal.InfoAnimal)
                        .FontSize(12);

                    document.InsertParagraph().InsertPageBreakAfterSelf();
                }
                document.Save();
            }

            // Открытие файла в Word
            Process.Start(new ProcessStartInfo(fileName) { UseShellExecute = true });
        }




    }
}
