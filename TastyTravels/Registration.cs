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
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string login=textBox1.Text,password=textBox3.Text,repPass= textBox4.Text;
            using (var context = new Datab())
            {
                //if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(repPass))
                //{
                //    MessageBox.Show("Все поля должны быть заполнены.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
                //else if (login.Length < 4)
                //{
                //    MessageBox.Show("Логин должен быть не менее 4 символов.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
                //else if (password.Length < 8)
                //{
                //    MessageBox.Show("Пароль должен быть не менее 8 символов.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
                //else if (!HasUpperCase(password) || !HasLowerCase(password) || !HasDigit(password) || !HasSpecialChar(password))
                //{
                //    MessageBox.Show("Пароль должен содержать заглавные и строчные буквы, цифры и специальные символы.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
                //else if (password != repPass)
                //{
                //    MessageBox.Show("Пароли не совпадают.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
                //else
                //{

                    User user = new User(login, password);
                    var us = context.Users.FirstOrDefault(u => u.Login == user.Login);
                    if (us==null)
                    {
                        context.Users.Add(user);
                        context.SaveChanges();
                        MessageBox.Show("Регистрация успешна!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Login login1 = new Login();
                        login1.Show();
                        this.Close();

                    }
                    else
                    {
                        MessageBox.Show("Пользователь с таким логином уже числится в системе", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    
                //}   
            }
        }
        private bool HasUpperCase(string str)
        {
            return str.Any(c => char.IsUpper(c));
        }

        private bool HasLowerCase(string str)
        {
            return str.Any(c => char.IsLower(c));
        }

        private bool HasDigit(string str)
        {
            return str.Any(c => char.IsDigit(c));
        }

        private bool HasSpecialChar(string str)
        {
            return str.Any(c => !char.IsLetterOrDigit(c));
        }
    }
}
