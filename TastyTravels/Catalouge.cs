using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TastyTravels
{
    public partial class Catalouge : Form
    {
        private int currentPage = 1;
        private int itemsPerPage = 9;
        private List<recip> recipes; // Список рецептов из базы данных

        public Catalouge()
        {
            InitializeComponent();
            LoadRecipesFromDatabase();
            DisplayPage(currentPage);
        }

        private void LoadRecipesFromDatabase()
        {
            // Здесь загрузите данные из базы данных
            using (var context = new Datab())
            {
                foreach (var recipe in recipes)
                {
                    recipes.Add(recipe);
                }
            }
        }

        private void DisplayPage(int pageNumber)
        {
            panelCatalog.Controls.Clear();
            int startIndex = (pageNumber - 1) * itemsPerPage;
            int endIndex = Math.Min(startIndex + itemsPerPage, recipes.Count);

            int x = 0, y = 0;
            int itemWidth = 250;
            int itemHeight = 150;
            int margin = 15;

            for (int i = startIndex; i < endIndex; i++)
            {
                var recipe = recipes[i];
                var panel = CreateRecipePanel(recipe);

                panel.Location = new Point(x * (itemWidth + margin*2), y * (itemHeight + margin));
                panelCatalog.Controls.Add(panel);

                x++;
                if (x >= 3)
                {
                    x = 0;
                    y++;
                }
            }

            lblPageNumber.Text = $"Page {pageNumber}";
            button1.Enabled = pageNumber > 1;
            button2.Enabled = endIndex < recipes.Count;
        }

        private Panel CreateRecipePanel(recip recipe)
        {
            var panel = new Panel
            {
                Width = 270,
                Height = 150, // Увеличим высоту, чтобы вместить больше информации
                BorderStyle = BorderStyle.FixedSingle
            };

            var pictureBox = new PictureBox
            {
                ImageLocation = recipe.ImgPath,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Width = 130,
                Height = 130,
                Location = new Point(7, 10)
            };

            var nameLabel = new Label
            {
                Text = recipe.Name,
                Location = new Point(140, 10),
                Width = 150
            };


            var cookingTimeLabel = new Label
            {
                Text = $"Cooking Time: {recipe.CookingTime}",
                Location = new Point(140, 35),
                Width = 150
            };

            var plateCountLabel = new Label
            {
                Text = $"Plates: {recipe.PlateCount}",
                Location = new Point(140, 60),
                Width = 150
            };

            var caloriesLabel = new Label
            {
                Text = $"Calories: {recipe.Calories}",
                Location = new Point(140, 85),
                Width = 150
            };

            var button = new Button
            {
                Text = "Go to recipe",
                Location = new Point(140, 110),
                Tag = recipe
            };

            button.Click += GoToRecipeButton_Click;

            panel.Controls.Add(pictureBox);
            panel.Controls.Add(nameLabel);
            panel.Controls.Add(cookingTimeLabel);
            panel.Controls.Add(plateCountLabel);
            panel.Controls.Add(caloriesLabel);
            panel.Controls.Add(button);

            return panel;
        }
        private void GoToRecipeButton_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            var recipe = button.Tag as recip;
            var recipeForm = new Form2(recipe);
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
            if ((currentPage * itemsPerPage) < recipes.Count)
            {
                currentPage++;
                DisplayPage(currentPage);
            }
        }

        private Panel panelCatalog;
        private Button btnPrevious;
        private Button btnNext;
        private Label lblPageNumber;

        private void label2_Click(object sender, EventArgs e)
        {
            Login loginForm = new Login();
            loginForm.FormClosed += (s, args) => this.Show(); // Показать основную форму, когда форма входа закрыта
            loginForm.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Registration registrationForm = new Registration();
            registrationForm.FormClosed += (s, args) => this.Show(); // Показать основную форму, когда регистрационная форма закрыта
            registrationForm.Show();
            this.Hide();
        }
    }

}

