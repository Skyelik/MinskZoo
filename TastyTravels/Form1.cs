using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TastyTravels;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private List<string> names = new List<string>();
        private List<int> amounts = new List<int>();
        private List<string> measures = new List<string>();
        private List<string> imagePaths = new List<string>();
        private int currentImageIndex = -1,selectedNumber;
        public Form1()
        {
            InitializeComponent();
            InitializeDataGridView();
            labels.Add(StepLabel);
            textBoxes.Add(DefenitionTB);
            pictureBoxes.Add(pictureBox2);
            PopulateComboBox();
        }
        private void InitializeDataGridView()
        {
            dataGridView1.Columns.Add("names", "Название");
            dataGridView1.Columns.Add("amounts", "Кол-во");
            dataGridView1.Columns.Add("measures", "Единица измерения");
        }

        private void PopulateComboBox()
        {
            for (int i = 1; i <= 20; i++)
            {
                comboBox1.Items.Add(i);
            }
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList; // Сделать ComboBox только для выбора из списка
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                selectedNumber = (int)comboBox1.SelectedItem;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image files (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg|All files (*.*)|*.*";
                openFileDialog.Multiselect = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string imgDirectory = Path.Combine(Application.StartupPath, "Imgs");

                    if (!Directory.Exists(imgDirectory))
                    {
                        Directory.CreateDirectory(imgDirectory);
                    }

                    foreach (string fileName in openFileDialog.FileNames)
                    {

                        string destinationFileName = Path.Combine(imgDirectory, Path.GetFileName(fileName));
                        imagePaths.Add(destinationFileName);
                        File.Copy(fileName, destinationFileName, true);
                    }
                    pictureBox1.ImageLocation = imagePaths[imagePaths.Count - 1];
                }
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

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            int columnIndex = e.ColumnIndex;

            if (rowIndex >= 0 && rowIndex < dataGridView1.Rows.Count - 1) // Проверяем, что строка с данными, а не строка для добавления новой записи
            {
                string name = dataGridView1.Rows[rowIndex].Cells[0].Value?.ToString(); // Название
                int amount = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells[1].Value); // Кол-во
                string measure = dataGridView1.Rows[rowIndex].Cells[2].Value?.ToString(); // Единица измерения

                // Сохраняем данные в массивы
                names.Add(name);
                amounts.Add(amount);
                measures.Add(measure);
            }
        }

        List<Step> steps = new List<Step>();
        List<System.Windows.Forms.Label> labels = new List<System.Windows.Forms.Label>();
        List<TextBox> textBoxes = new List<TextBox>();
        List<PictureBox> pictureBoxes = new List<PictureBox>();
        private List<string> imagePaths2 = new List<string>();
        private int index = 0;

        private void NextButton_Click(object sender, EventArgs e)
        {
            if (index + 1 == labels.Count)
            {
                this.Controls.Remove(labels[index]);
                this.Controls.Remove(textBoxes[index]);
                this.Controls.Remove(pictureBoxes[index]);
                index += 1;
                System.Windows.Forms.Label stepLabel = new System.Windows.Forms.Label();
                stepLabel.Location = StepLabel.Location;
                stepLabel.Text = "Шаг: "+(index + 1).ToString();
                stepLabel.Font = StepLabel.Font;
                TextBox stepBox = new TextBox();
                stepBox.Multiline = true;
                stepBox.Location = DefenitionTB.Location;
                stepBox.Size = DefenitionTB.Size;
                stepBox.Text = DefenitionTB.Text;
                PictureBox pictureBox = new PictureBox();
                pictureBox.Size = pictureBox2.Size;
                pictureBox.Location = pictureBox2.Location;
                pictureBox.BackColor = pictureBox2.BackColor;

                labels.Add(stepLabel);
                textBoxes.Add(stepBox);
                pictureBoxes.Add(pictureBox);
                this.Controls.Add(pictureBox);
                this.Controls.Add(stepBox);
                this.Controls.Add(stepLabel);
            }
            else
            {
                this.Controls.Remove(labels[index]);
                this.Controls.Remove(textBoxes[index]);
                this.Controls.Remove(pictureBoxes[index]);
                index += 1;
                this.Controls.Add(pictureBoxes[index]);
                this.Controls.Add(textBoxes[index]);
                this.Controls.Add(labels[index]);
            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string name = RNameTB.Text, defenition = RDefinitionTB.Text, cookingTime = RCookingTimeTB.Text, calories = RCcalTB.Text, fats = RFatsTB.Text, proteins = RProteinTB.Text, carbs = RCarbsTB.Text;
            int plateCount = (int)comboBox1.SelectedItem;

            // Проверка на заполненность всех полей
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(defenition) || string.IsNullOrEmpty(cookingTime) || string.IsNullOrEmpty(calories) || string.IsNullOrEmpty(fats) || string.IsNullOrEmpty(proteins) || string.IsNullOrEmpty(carbs))
            {
                MessageBox.Show("Заполните все поля описания рецепта", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["Name"].Value == null || row.Cells["Amount"].Value == null || row.Cells["Measure"].Value == null)
                {
                    MessageBox.Show("Заполните все столбцы в таблице ингредиентов", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // Создание объекта Recipe
            string firstImagePath = imagePaths2.FirstOrDefault() ?? string.Empty;
            recip recipe = new recip(name, defenition, DateTime.Now.ToString(), cookingTime, plateCount, proteins, fats, carbs, calories, firstImagePath);

            // Создание объектов Ingredient
            List<Ingredient> ingredients = new List<Ingredient>();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["Name"].Value != null && row.Cells["Amount"].Value != null && row.Cells["Measure"].Value != null)
                {
                    string ingredientName = row.Cells["Name"].Value.ToString();
                    float amount = float.Parse(row.Cells["Amount"].Value.ToString());
                    string measure = row.Cells["Measure"].Value.ToString();
                    ingredients.Add(new Ingredient(recipe.Id, ingredientName, amount, measure));
                }
            }

            // Добавление шагов
            for (int i = 0; i < labels.Count; i++)
            {
                string stepDefinition = textBoxes[i].Text;
                string stepImagePath = pictureBoxes[i].ImageLocation ?? string.Empty;
                steps.Add(new Step(recipe.Id,i + 1, stepDefinition, stepImagePath));
            }

            // Сохранение рецепта, ингредиентов и шагов в базу данных
            using (var context = new Datab())
            {
                context.Recipes.Add(recipe);
                context.Ingredients.AddRange(ingredients);
                context.Steps.AddRange(steps);
                context.SaveChanges();
            }

            MessageBox.Show("Рецепт успешно сохранен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image files (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg|All files (*.*)|*.*";
                openFileDialog.Multiselect = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string imgDirectory = Path.Combine(Application.StartupPath, "Imgs");

                    if (!Directory.Exists(imgDirectory))
                    {
                        Directory.CreateDirectory(imgDirectory);
                    }

                    foreach (string fileName in openFileDialog.FileNames)
                    {

                        string destinationFileName = Path.Combine(imgDirectory, Path.GetFileName(fileName));
                        imagePaths2.Add(destinationFileName);
                        File.Copy(fileName, destinationFileName, true);
                    }
                    pictureBoxes[index].ImageLocation = imagePaths2[imagePaths2.Count - 1];
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void PreviousButton_Click(object sender, EventArgs e)
        {
            if (index - 1 != -1)
            {
                this.Controls.Remove(labels[index]);
                this.Controls.Remove(textBoxes[index]);
                this.Controls.Remove(pictureBoxes[index]);
                index -= 1;
                this.Controls.Add(labels[index]);
                this.Controls.Add(textBoxes[index]);
                this.Controls.Add(pictureBoxes[index]);

            }
        }
    }
}
