using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Курсач.Forms;

namespace Курсач
{
    public partial class Login : Form
    {
        private UserPanel _userPanel;
        public Login(UserPanel userPanel)
        {
            LoadTheme();
            InitializeComponent();
            _userPanel = userPanel;
        }

        private void LoadTheme()
        {
            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    btn.BackColor = ThemeColor.PrimaryColor;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }
                button_login.BackColor = ThemeColor.PrimaryColor;
            }
        }
        private void button_login_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Заполните все поля.");
                return;
            }

            var user = UserLogin.LoginUser(username, password);

            if (user != null)
            {
                Session.LoggedInUser = user;

                MessageBox.Show($"Вход выполнен успешно! Добро пожаловать, {user.Username}.");
                _userPanel.IsLogged();
                this.Close();
                _userPanel.Reset();
            }
            else
            {
                MessageBox.Show("Неверное имя пользователя или пароль.");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = !checkBox1.Checked;
        }
    }
}
