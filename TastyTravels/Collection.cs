using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
//using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace TastyTravels
{
    public partial class Collection : Form
    {
        private int currentPage = 1;
        private int itemsPerPage = 9;
        List<AnimalInfo> animalsInfo = new List<AnimalInfo>();

        private User user;
        private Admin admin;
        string role;

        public Collection(User us)
        {
            InitializeComponent();
            LoadAnimalFromDatabase();
            user = us;
            role = "user";
            button5.Visible = false;
            button6.Visible= true;
            button7.Visible = false;

        }
        public Collection(Admin adm)
        {
            InitializeComponent();
            LoadAnimalFromDatabase();
            role = "admin"; 
            button5.Visible = true;
            button6.Visible = false;
            button7.Visible = true;
        }



        public Collection()
        {
            InitializeComponent();
            LoadAnimalFromDatabase();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            Application.Exit(); // Завершаем приложение при закрытии формы
        }


        private void Catalouge_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Род");
            comboBox1.SelectedIndex = 0;
            comboBox2.Items.Add("Класс");
            comboBox2.SelectedIndex = 0;
            comboBox3.Items.Add("Отряд");
            comboBox3.SelectedIndex = 0;
            comboBox4.Items.Add("Семейство");
            comboBox4.SelectedIndex = 0;
        }



        private void comboBox1_Click(object sender, EventArgs e)
        {
            using (var context = new Datab())
            {
                var unique = context.AnimalInfo
                .Select(i => i.AnimalGenus)
                .Distinct()
                .ToList();
                comboBox1.Items.Clear();
                comboBox1.Items.Add("Все");
                comboBox1.Items.AddRange(unique.ToArray());
            }
        }


        private void comboBox2_Click(object sender, EventArgs e)
        {
            using (var context = new Datab())
            {
                var unique = context.AnimalInfo
                .Select(i => i.AnimalClass)
                .Distinct()
                .ToList();
                comboBox2.Items.Clear();
                comboBox2.Items.Add("Все");
                comboBox2.Items.AddRange(unique.ToArray());
            }
        }

        private void comboBox3_Click(object sender, EventArgs e)
        {
            using (var context = new Datab())
            {
                var unique = context.AnimalInfo
                .Select(i => i.AnimalSquad)
                .Distinct()
                .ToList();
                comboBox3.Items.Clear();
                comboBox3.Items.Add("Все");
                comboBox3.Items.AddRange(unique.ToArray());
            }
        }

        private void comboBox4_Click(object sender, EventArgs e)
        {
            using (var context = new Datab())
            {
                var unique = context.AnimalInfo
                .Select(i => i.AnimalFamily)
                .Distinct()
                .ToList();
                comboBox4.Items.Clear();
                comboBox4.Items.Add("Все");
                comboBox4.Items.AddRange(unique.ToArray());
            }
        }


        private void LoadAnimalFromDatabase()
        {
            // Здесь загрузите данные из базы данных
            using (var context = new Datab())
            {
                if (context.AnimalInfo != null)
                {
                    foreach (AnimalInfo animalInfo in context.AnimalInfo)
                    {
                        animalsInfo.Add(animalInfo);
                    }
                    DisplayPage(currentPage);
                    button3.Enabled = true;
                    button4.Enabled = true;
                }
                else
                {
                    button3.Enabled = false;
                    button4.Enabled = false;
                }
            }
        }


        private Image ByteArrayToImage(byte[] byteArray)
        {
            using (MemoryStream ms = new MemoryStream(byteArray))
            {
                return Image.FromStream(ms);
            }
        }



        private void PageAnimalInfo_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            var animals = button.Tag as AnimalInfo;
            var animalForm = new AboutInfo(animals, user);
            animalForm.Show();
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
                var anim = animalsInfo[i];
                Panel panel;
                if (role == "user")
                {
                    panel = CreateAnimalPanel(anim);
                }
                else if (role == "admin")
                {
                    panel = CreateAdminPanel(anim);
                }
                else
                {
                    panel = CreateAnimalPanel(anim);
                }


                panel.Location = new Point(x * (itemWidth + margin * 2), y * (itemHeight + margin));
                panel1.Controls.Add(panel);
                x++;
                if (x >= 3)
                {
                    x = 0;
                    y++;
                }
            }

            button3.Enabled = pageNumber > 1;
            button4.Enabled = endIndex < animalsInfo.Count;
        }


        private Panel CreateAnimalPanel(AnimalInfo animal)
        {
            var panel = new Panel
            {
                Width = 270,
                Height = 150, // Увеличим высоту, чтобы вместить больше информации
                BorderStyle = BorderStyle.FixedSingle
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
                MaximumSize = new Size(100,50),
                AutoSize = true
            };
            
            var button = new Button
            {
                Text = "Подробнее",
                Location = new Point(140, 110),
                Tag = animal,
                Width = 100
            };

            button.Click += PageAnimalInfo_Click;

            panel.Controls.Add(pictureBox);
            panel.Controls.Add(nameLabel);
            panel.Controls.Add(button);

            return panel;
        }

        private Panel CreateAdminPanel(AnimalInfo animal)
        {
            var panel = new Panel
            {
                Width = 270,
                Height = 150, // Увеличим высоту, чтобы вместить больше информации
                BorderStyle = BorderStyle.FixedSingle
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
                Text = "Изменить",
                Location = new Point(140, 110),
                Tag = animal,
                Width = 70
            };

            var button2 = new Button
            {
                Text = "Удалить",
                Location = new Point(210, 110),
                Tag = animal,
                Width = 60
            };

            button.Click += ChangeRecipeButton_Click;
            button2.Click += DeleteRecipeButton_Click;

            panel.Controls.Add(pictureBox);
            panel.Controls.Add(nameLabel);

            panel.Controls.Add(button);
            panel.Controls.Add(button2);


            return panel;
        }


        private void DeleteRecipeButton_Click(object sender, EventArgs e)
        {
            if (sender is Button button && button.Tag is AnimalInfo animal)
            {
                var result = MessageBox.Show("Вы уверены что хотите удалить животного?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    using (var context = new Datab())
                    {
                        
                        // Удаление из избранного
                        var favorites = context.Favorites.Where(f => f.Id == animal.Id).ToList();
                        context.Favorites.RemoveRange(favorites);

                        var imgs = context.AnimalImg.Where(f => f.AnimalId == animal.Id).ToList();
                        context.AnimalImg.RemoveRange(imgs);

                        // Удаление самого животного
                        var anim = context.AnimalInfo.Find(animal.Id);
                        context.AnimalInfo.Remove(anim);

                        context.SaveChanges();
                    }

                    // Удаление панели из интерфейса
                    var panel = (Panel)button.Parent;
                    var parent = panel.Parent;
                    parent.Controls.Remove(panel);
                    panel.Dispose();
                }
            }
        }

        private void ChangeRecipeButton_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            var anm = button.Tag as AnimalInfo;
            var anmForm = new CreateForm(anm);
            anmForm.Owner = this;
            anmForm.Show();
        }

        

        private void reloadCatalog()
        {
            animalsInfo.Clear();
            using (var context = new Datab())
            {
                if (context.AnimalInfo != null)
                {
                    foreach (AnimalInfo animalInf in context.AnimalInfo)
                    {
                        animalsInfo.Add(animalInf);
                    }
                    DisplayPage(currentPage);
                }

                if (!string.IsNullOrEmpty(textBox1.Text))
                {
                    animalsInfo = animalsInfo.Where(x => x.Name.StartsWith(textBox1.Text)).ToList();
                    
                }

                if (comboBox1.Text != "Род" && comboBox1.Text != "Все")
                {
                    animalsInfo = animalsInfo.Where(a => a.AnimalGenus == comboBox1.Text).ToList();
                }
                if (comboBox2.Text != "Класс" && comboBox2.Text != "Все")
                {
                    animalsInfo = animalsInfo.Where(a => a.AnimalClass == comboBox2.Text).ToList();
                }
                if (comboBox3.Text != "Отряд" && comboBox3.Text != "Все")
                {
                    animalsInfo = animalsInfo.Where(a => a.AnimalSquad == comboBox3.Text).ToList();
                }
                if(comboBox4.Text != "Семейство" && comboBox4.Text != "Все")
                {
                    animalsInfo = animalsInfo.Where(a => a.AnimalFamily == comboBox4.Text).ToList();
                }    

            }
            DisplayPage(currentPage);
        }


        private void textBox_TextChanged(object sender, EventArgs e)
        {
            reloadCatalog();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            reloadCatalog();
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            reloadCatalog();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            reloadCatalog();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            reloadCatalog();
        }


        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.DodgerBlue;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.DeepSkyBlue;
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.BackColor = Color.Gold;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.FromArgb(237, 226, 14);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                DisplayPage(currentPage);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if ((currentPage * itemsPerPage) < animalsInfo.Count)
            {
                currentPage++;
                DisplayPage(currentPage);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            CreateForm adminRecipeForm = new CreateForm();
            adminRecipeForm.FormClosed += (s, args) => this.Show(); // Показать основную форму, когда регистрационная форма закрыта
            adminRecipeForm.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FavoritesForm fav = new FavoritesForm(user);
            fav.FormClosed += (s, args) => this.Show(); // Показать основную форму, когда регистрационная форма закрыта
            fav.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ZooContact zooContact = new ZooContact();
            zooContact.FormClosed += (s, args) => this.Show();
            zooContact.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
           CreateService service = new CreateService();
            service.FormClosed += (s, args) => this.Show();
            service.Show();
            this.Hide();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if(role == "admin")
            {
                ServiceForm serviceForm = new ServiceForm(admin);
                serviceForm.FormClosed += (s, args) => this.Show();
                serviceForm.Show();
                this.Hide();
            }
            else
            {
                ServiceForm serviceForm = new ServiceForm();
                serviceForm.FormClosed += (s, args) => this.Show();
                serviceForm.Show();
                this.Hide();
            }
            
        }
    }
}
