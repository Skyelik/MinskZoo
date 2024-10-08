using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TastyTravels
{
    public partial class RegForm : Form
    {
        public RegForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string login = textBox2.Text, password = textBox3.Text;
            using (var context = new Datab())
            {
                if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
                {
                    MessageBox.Show("Все поля должны быть заполнены.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (login.Length < 4)
                {
                    MessageBox.Show("Логин должен быть не менее 4 символов.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (password.Length < 8)
                {
                    MessageBox.Show("Пароль должен быть не менее 8 символов.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                else
                {

                    User user = new User(login, password);
                    var us = context.Users.FirstOrDefault(u => u.Login == user.Login);
                    var adm = context.Admins.FirstOrDefault(u => u.Login == user.Login);
                    if (us == null && adm == null)
                    {
                        context.Users.Add(user);
                        context.SaveChanges();
                        MessageBox.Show("Регистрация успешна!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close(); // Закрытие формы

                    }
                    else
                    {
                        MessageBox.Show("Пользователь с таким логином уже числится в системе", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                
            }
        }
    }
}
