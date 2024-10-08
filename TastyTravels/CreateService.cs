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
    public partial class CreateService : Form
    {
        public CreateService()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Укажите название услуги", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Укажите тип услуги", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("Укажите место проведения", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBox4.Text))
            {
                MessageBox.Show("Укажите дату проведения", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBox5.Text)|| float.Parse(textBox5.Text) <= 0)
            {
                MessageBox.Show("Укажите цену", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            string name = textBox1.Text;
            string type = textBox2.Text;
            string place = textBox3.Text;
            string date = textBox4.Text;
            float price = float.Parse(textBox5.Text);



            using (var context = new Datab())
            {
                Services services = new Services(name, type, place, date, price);
               

                context.Services.Add(services);
                context.SaveChanges();

                services = context.Services.FirstOrDefault(s => s.NameServices == name);
                int servId = services.Id;
                context.SaveChanges();
            }
            MessageBox.Show("Услуга успешно добавлена!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
