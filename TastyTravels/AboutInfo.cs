using GMap.NET.MapProviders;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TastyTravels
{
    public partial class AboutInfo : Form
    {
        private bool isFavorite = false;
        private AnimalInfo animal;
        private int currentImageIndex = -1;
        private List<byte[]> imagePaths = new List<byte[]>();
        private User user;
        private Admin admin;
        string role;

        public AboutInfo(AnimalInfo animalInfo, User currentUser)
        {
            InitializeComponent();
            
            this.Load += new EventHandler(AboutInfo_Load);
            this.Shown += new EventHandler(AboutInfo_Shown);

            this .animal = animalInfo;
            this.user = currentUser; // Передача текущего пользователя
            
            LoadAnimalDetails();
            InitializeFavoriteButton();
            isFavorite = CheckIfFavorite(animal.Id);
        }

        private void InitializeFavoriteButton()
        {
            var favoriteButton = new Button
            {
                Width = 30,
                Height = 30,
                Location = new Point(540, 43), // Примерное расположение, отрегулируйте по необходимости
                FlatStyle = FlatStyle.Flat
            };
            favoriteButton.FlatAppearance.BorderSize = 0;
            favoriteButton.FlatAppearance.MouseDownBackColor = Color.Transparent;
            favoriteButton.FlatAppearance.MouseOverBackColor = Color.Transparent;
            favoriteButton.Paint += FavoriteButton_Paint;
            favoriteButton.Click += FavoriteButton_Click;
            favoriteButton.Tag = animal;
            this.Controls.Add(favoriteButton);

            isFavorite = CheckIfFavorite(animal.Id); // Проверка статуса избранного
            favoriteButton.Invalidate(); // Перерисовка кнопки
        }

        private void FavoriteButton_Paint(object sender, PaintEventArgs e)
        {
            var button = sender as Button;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Центр и радиус звезды
            float centerX = button.Width / 2;
            float centerY = button.Height / 2;
            float outerRadius = button.Width / 2 - 3; // Размер звезды
            float innerRadius = outerRadius / 2.5f; // Внутренний радиус

            // Координаты вершин звезды
            PointF[] starPoints = GetStarPoints(centerX, centerY, outerRadius, innerRadius);

            // Цвет звезды
            Color starColor = isFavorite ? Color.Yellow : Color.Transparent;

            // Рисуем звезду
            using (Brush brush = new SolidBrush(starColor))
            {
                e.Graphics.FillPolygon(brush, starPoints);
            }

            using (Pen pen = new Pen(Color.Black, 1))
            {
                e.Graphics.DrawPolygon(pen, starPoints);
            }
        }

        private void FavoriteButton_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            var anim = button?.Tag as AnimalInfo;

            if (anim != null)
            {
                ToggleFavoriteStatus(anim.Id);
                isFavorite = !isFavorite;
                button.Invalidate(); // Redraw button
            }






        }


        private void ToggleFavoriteStatus(int animId)
        {
            using (var context = new Datab())
            {
                var favorite = context.Favorites.SingleOrDefault(f => f.AnimalId == animId && f.UserId == user.Id);

                if (favorite == null)
                {
                    // Если животное не в избранном, добавляем его
                    var newFavorite = new Favorites { AnimalId = animId, UserId = user.Id };
                    context.Favorites.Add(newFavorite);
                }
                else
                {
                    // Если животное уже в избранном, удаляем его
                    context.Favorites.Remove(favorite);
                }

                context.SaveChanges();
            }
        }


        private bool CheckIfFavorite(int animId)
        {
            using (var context = new Datab())
            {
                if (user == null)
                {
                    MessageBox.Show("Ошибка: текущий пользователь не установлен.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                return context.Favorites.Any(f => f.AnimalId == animId && f.UserId == user.Id);
            }
        }



        private PointF[] GetStarPoints(float centerX, float centerY, float outerRadius, float innerRadius)
        {
            PointF[] pts = new PointF[10];
            double theta = -Math.PI / 2; // Начнем с вершины звезды
            double dtheta = Math.PI / 5; // Угол между вершинами

            for (int i = 0; i < 10; i++)
            {
                float r = (i % 2 == 0) ? outerRadius : innerRadius;
                pts[i] = new PointF(
                    centerX + (float)(r * Math.Cos(theta)),
                    centerY + (float)(r * Math.Sin(theta))
                );
                theta += dtheta;
            }

            return pts;
        }



        private void LoadAnimalDetails()//Загружаем инфу 
        {
            
            label1.Text = animal.Name;
            label2.Text = $"Lat: {animal.ScienceName}";
            textBox1.Text = $"Класс: {animal.AnimalClass}";
            textBox2.Text = $"Отряд: {animal.AnimalSquad}";
            textBox3.Text = $"Семейство: {animal.AnimalFamily}";
            textBox4.Text = $"Род: {animal.AnimalGenus}";
            textBox5.Text = $"Вид: {animal.KindAnimal}";
            textBox6.Text = animal.InfoAnimal;
            pictureBox1.Image = ByteArrayToImage(animal.ImagePath);

            using (var context = new Datab())
            {
                var matchedAnimalImgs = context.AnimalImg.Where(img => img.AnimalId == animal.Id).ToList();

                foreach (var img in matchedAnimalImgs)
                {
                    imagePaths.Add(img.ImagePath);
                }
            }





        }


        private void NextPictureButton_Click(object sender, EventArgs e)
        {
            if (currentImageIndex < imagePaths.Count - 1)
            {
                currentImageIndex++;
                pictureBox2.Image = ByteArrayToImage(imagePaths[currentImageIndex]);
            }

        }

        private void PreviousPictureButton_Click(object sender, EventArgs e)
        {
            if (currentImageIndex > 0)
            {
                currentImageIndex--;
                pictureBox2.Image = ByteArrayToImage(imagePaths[currentImageIndex]);
            }



        }


        private Image ByteArrayToImage(byte[] byteArray)
        {
            try
            {
                using (MemoryStream ms = new MemoryStream(byteArray))
                {
                    return Image.FromStream(ms);
                }
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Байтовый массив не является допустимым изображением.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }


        private void AboutInfo_Load(object sender, EventArgs e)
        {
            // Установите фокус на метку или другой неактивный элемент
            this.ActiveControl = label1;
        }

        private void AboutInfo_Shown(object sender, EventArgs e)
        {
            // Снимите выделение текста в текстовом поле
            textBox1.SelectionStart = textBox1.Text.Length;
            textBox1.SelectionLength = 0;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            textBox1.TabStop = false;
        }

       
    }
}
