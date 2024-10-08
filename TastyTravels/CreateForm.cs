using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace TastyTravels
{
    public partial class CreateForm : Form
    {
        private List<byte[]> imagePaths = new List<byte[]>();
        private AnimalInfo animals;
        public CreateForm()
        {
            InitializeComponent();
        }

        public CreateForm(AnimalInfo animal)
        {
            InitializeComponent();
            animals = animal;
            FillForm();
        }

        private void FillForm()
        {
            string name = textBox1.Text;
            string scinceName = textBox2.Text;
            string animalClass = textBox3.Text;
            string animalSquad = textBox4.Text;
            string animalFamily = textBox5.Text;
            string animalGen = textBox6.Text;
            string animalKind = textBox7.Text;
            string animalInfo = textBox8.Text;

            textBox1.Text = animals.Name;
            textBox2.Text = animals.ScienceName;
            textBox3.Text = animals.AnimalClass;
            textBox4.Text = animals.AnimalSquad;
            textBox5.Text = animals.AnimalFamily;
            textBox6.Text = animals.AnimalGenus;
            textBox7.Text = animals.KindAnimal;
            textBox8.Text = animals.InfoAnimal;
            
        }

        private byte[] imagePath;
        private int currentImageIndex = -1, selectedNumber;
        //private string imgDirectory = Path.Combine(Application.StartupPath, "Imgs");

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {

                openFileDialog.Filter = "Image files (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg|All files (*.*)|*.*";
                openFileDialog.Multiselect = true;


                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (string fileName in openFileDialog.FileNames)
                    {
                        byte[] imageBytes = File.ReadAllBytes(fileName);
                        imagePath = imageBytes;
                        pictureBox1.Image = ByteArrayToImage(imagePath);
                        
                    }
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
        private int index = 0;
         
        private List<byte[]> imagePaths2 = new List<byte[]>();
        private void button4_Click(object sender, EventArgs e)
        {

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image files (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg|All files (*.*)|*.*";
                openFileDialog.Multiselect = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (string fileName in openFileDialog.FileNames)
                    {
                        byte[] imageBytes = File.ReadAllBytes(fileName);
                        imagePaths.Add(imageBytes);
                    }

                    // Update the current image index to the last added image
                    if (imagePaths.Count > 0)
                    {
                        currentImageIndex = imagePaths.Count - 1;
                        pictureBox2.Image = ByteArrayToImage(imagePaths[currentImageIndex]);
                    }
                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (currentImageIndex > 0)
            {
                currentImageIndex--;
                pictureBox2.Image = ByteArrayToImage(imagePaths[currentImageIndex]);
            }
        }
        private List<AnimalImg> animalImg = new List<AnimalImg>();

        private void button5_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Укажите название животного", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Укажите научное имя животного", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("Укажите класс животного", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBox4.Text))
            {
                MessageBox.Show("Укажите отряд животного", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBox5.Text))
            {
                MessageBox.Show("Укажите семейство животного", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBox6.Text))
            {
                MessageBox.Show("Укажите род животного", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBox7.Text))
            {
                MessageBox.Show("Укажите вид животного", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBox8.Text))
            {
                MessageBox.Show("Напишите описание животного", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string name = textBox1.Text;
            string scinceName = textBox2.Text;
            string animalClass = textBox3.Text;
            string animalSquad = textBox4.Text;
            string animalFamily = textBox5.Text;
            string animalGen = textBox6.Text;
            string animalKind = textBox7.Text;
            string animalInfo = textBox8.Text;



            using (var context = new Datab())
            {
                byte[] firstImagePath = imagePaths.FirstOrDefault() ?? null;
                AnimalInfo animal = new AnimalInfo(name, scinceName, animalClass, animalSquad, animalFamily, animalGen, animalKind, animalInfo, imagePath);

                
                context.AnimalInfo.Add(animal);
                context.SaveChanges();
                animal = context.AnimalInfo.FirstOrDefault(r => r.Name == name);
                int aniId = animal.Id;
                foreach (var img in imagePaths)
                {

                    animalImg.Add(new AnimalImg(aniId, img));
                }

                //Сохранение животного, инфы и в базу данных

                context.AnimalImg.AddRange(animalImg);
                context.SaveChanges();
            }
            MessageBox.Show("Животное успешно добавлено!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (currentImageIndex < imagePaths.Count - 1)
            {
                currentImageIndex++;
                pictureBox2.Image = ByteArrayToImage(imagePaths[currentImageIndex]);
            }
        }
    }
}
