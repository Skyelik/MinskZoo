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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string login = textBox1.Text, password = textBox2.Text;
            using (var context = new Datab())
            {
                    var user = context.Users.FirstOrDefault(u => u.Login == login);
                if (user == null)
                {
                    MessageBox.Show("Пользователь не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (password != user.Password)
                {
                    MessageBox.Show("Неправильный пароль.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Успешный вход!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Catalouge cat = new Catalouge();
                cat.Show();
                this.Close();
            }
        }
    }
}
