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
    public partial class LogForm : Form
    {
        public User LoggedInUser { get; private set; }
        public Admin LoggedAdmin { get; private set; }

        public LogForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string login = textBox1.Text, password = textBox2.Text;
            using (var context = new Datab())
            {
                var user = context.Users.FirstOrDefault(u => u.Login == login && u.Password == password);
                var admin = context.Admins.FirstOrDefault(u => u.Login == login && u.Password == password);
                if (user == null && admin == null)
                {
                    MessageBox.Show("Пользователь не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if (user == null)
                    {
                        if (password != admin.Password)
                        {
                            MessageBox.Show("Неправильный пароль.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            MessageBox.Show("Успешный вход!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoggedAdmin = admin;
                            this.DialogResult = DialogResult.OK;
                            
                            Collection colec = new Collection(admin);
                            colec.Show();
                            this.Hide();
                        }
                    }
                    else
                    {
                        if (password != user.Password)
                        {
                            MessageBox.Show("Неправильный пароль.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            MessageBox.Show("Успешный вход!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoggedInUser = user;
                            this.DialogResult = DialogResult.OK;

                            Collection colec = new Collection(user);
                            colec.Show();
                            this.Hide();
                        }
                    }
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegForm regForm = new RegForm();
            regForm.FormClosed += RegForm_FormClosed; // Подписываемся на событие закрытия формы
            regForm.Show();
            this.Hide();
        }
        private void RegForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show(); // Показываем форму при закрытии RegForm
        }
    }
}
