using System;
using System.Collections.Generic;
using System.ComponentModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;

namespace TastyTravels
{
    public partial class Form2 : Form
    {
        private recip recipe;
        private List<string> imagePaths = new List<string>();
        private int currentImageIndex = -1;
        public Form2(recip recipe)
        {
            InitializeComponent();
            this.recipe = recipe;
            LoadRecipeDetails();
            PopulateComboBox();
        }
        private void PopulateComboBox()
        {
            for (int i = 1; i <= 20; i++)
            {
                comboBox1.Items.Add(i);
            }
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList; // Сделать ComboBox только для выбора из списка
        }
        private void LoadRecipeDetails()
        {
            label1.Text = recipe.Name;
            label2.Text = $"Описание: {recipe.Defenition}";
            label3.Text = $"Калорийность: {recipe.Calories}";
            label4.Text = $"Время приготвления: {recipe.CookingTime}";
            label5.Text = $"Белки: {recipe.Proteins}";
            label6.Text = $"Жиры: {recipe.Fats}";
            label7.Text = $"Углеводы: {recipe.Carbs}";
            comboBox1.Text = recipe.PlateCount.ToString(); 
            using (var context = new Datab())
            {
                 var matchedRecipeImgs = context.RecipeImgs.Where(img => img.RecipeId == recipe.Id).ToList();
                 var matchedSteps = context.Steps.Where(st => st.RecipeId == recipe.Id).ToList();
                var matchedIngredients = context.Ingredients.Where(ingr => ingr.RecipeId == recipe.Id).ToList();
            }
        }
        private void NextPictureButton_Click(object sender, EventArgs e)
        {
            if (currentImageIndex < imagePaths.Count - 1)
            {
                currentImageIndex++;
                pictureBox1.ImageLocation = imagePaths[currentImageIndex];
            }
        }

        private void PreviousPictureButton_Click(object sender, EventArgs e)
        {
            if (currentImageIndex > 0)
            {
                currentImageIndex--;
                pictureBox1.ImageLocation = imagePaths[currentImageIndex];
            }
        }

    }
}
