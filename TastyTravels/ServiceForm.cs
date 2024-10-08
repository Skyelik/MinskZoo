using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TastyTravels
{
    public partial class ServiceForm : Form
    {

        private Admin admin;

        private List<Services> service = new List<Services>();


        

        public ServiceForm()
        {
            InitializeComponent();
            button1.Visible = false;
            
            using (var context = new Datab())
            {
                service.AddRange(context.Services);
            }
            
        }

        public ServiceForm(Admin ad)
        {
            InitializeComponent();
            admin = ad;
            button1.Visible = true;
            using (var context = new Datab())
            {
                service.AddRange(context.Services);
            }
            
        }





        private void Service_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Тип услуги");
            comboBox1.SelectedIndex = 0;
            comboBox2.Items.Add("Место проведения");
            comboBox2.SelectedIndex = 0;
            comboBox3.Items.Add("Дата проведения");
            comboBox3.SelectedIndex = 0;
            comboBox4.Items.Add("Цена");
            comboBox4.SelectedIndex = 0;

           


        }


        private void UpdateGridView()//Загружаем ингридиент
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("id", "№");
            dataGridView1.Columns.Add("name", "Название");
            dataGridView1.Columns.Add("servicesType", "Тип услуги");
            dataGridView1.Columns.Add("location", "Место проведения");
            dataGridView1.Columns.Add("date", "Дата проведения");
            dataGridView1.Columns.Add("price", "Цена");
            dataGridView1.Columns["id"].Visible = false;
            
            using (var context = new Datab())
            {
                var matchService = service;
                foreach (var ingr in matchService)
                {
                    dataGridView1.Rows.Add(ingr.Id,ingr.NameServices, ingr.ServicesType, ingr.Location, ingr.EventDate, ingr.Price);
                }
            }
        }


        private void reloadCatalog()
        {
            service.Clear();
            using (var context = new Datab())
            {
                if (context.Services != null)
                {
                    foreach (Services services in context.Services)
                    {
                        service.Add(services);
                    }
                    UpdateGridView();
                }

                if (comboBox1.Text != "Тип услуги" && comboBox1.Text != "Все")
                {
                    service = service.Where(s => s.ServicesType == comboBox1.Text).ToList();
                }
                if (comboBox2.Text != "Место проведения" && comboBox2.Text != "Все")
                {
                    service = service.Where(s => s.Location == comboBox2.Text).ToList();
                }
                if (comboBox3.Text != "Дата проведения" && comboBox3.Text != "Все")
                {
                    service = service.Where(s => s.EventDate == comboBox3.Text).ToList();
                }

                if (comboBox4.Text != "Цена" && comboBox4.Text != "Все")
                {

                    

                    if (float.TryParse(comboBox4.Text, out float price))
                    {
                        service = service.Where(s => s.Price == price).ToList();
                    }
                }

            }
            UpdateGridView();

        }



        private void comboBox1_Click(object sender, EventArgs e)
        {
            using (var context = new Datab())
            {
                var uniqService = context.Services
                .Select(i => i.ServicesType)
                .Distinct()
                .ToList();
                comboBox1.Items.Clear();
                comboBox1.Items.Add("Все");
                comboBox1.Items.AddRange(uniqService.ToArray());
            }
        }

        private void comboBox2_Click(object sender, EventArgs e)
        {
            using (var context = new Datab())
            {
                var uniqService = context.Services
                .Select(i => i.Location)
                .Distinct()
                .ToList();
                comboBox2.Items.Clear();
                comboBox2.Items.Add("Все");
                comboBox2.Items.AddRange(uniqService.ToArray());
            }
        }

        private void comboBox3_Click(object sender, EventArgs e)
        {
            using (var context = new Datab())
            {
                var uniqService = context.Services
                .Select(i => i.EventDate)
                .Distinct()
                .ToList();
                comboBox3.Items.Clear();
                comboBox3.Items.Add("Все");
                comboBox3.Items.AddRange(uniqService.ToArray());
            }
        }

        private void comboBox4_Click(object sender, EventArgs e)
        {
            using (var context = new Datab())
            {
                var uniqService = context.Services
                .Select(i => i.Price)
                .Distinct()
                .ToList();
                comboBox4.Items.Clear();
                comboBox4.Items.Add("Все");
                comboBox4.Items.AddRange(uniqService.Cast<object>().ToArray());
            }
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

        private void button1_Click(object sender, EventArgs e)
        {
            // Проверяем, что есть выделенная строка
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Извлекаем значение ID из первой ячейки выбранной строки
                var selectedId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);

                using (var context = new Datab())
                {
                    // Находим сервис по извлеченному ID
                    var service = context.Services.FirstOrDefault(s => s.Id == selectedId);
                    if (service != null)
                    {
                        // Удаляем найденный сервис
                        context.Services.Remove(service);
                        context.SaveChanges();

                        // Обновляем отображение данных
                        reloadCatalog();
                    }
                }
            }
        }
    }
}
