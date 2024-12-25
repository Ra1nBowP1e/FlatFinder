using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Курсач
{
    public partial class Register : Form
    {
        private UserPanel _userPanel;
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
            }
        }
        public Register(UserPanel userPanel)
        {
            LoadTheme();
            TopMost = true;
            InitializeComponent();
            this.Text = string.Empty;
            this.ControlBox = false;
            _userPanel = userPanel;
        }

        private void checkBox_showPassword_CheckedChanged(object sender, EventArgs e)
        {
            textBoxPassword.UseSystemPasswordChar = !checkBox_showPassword.Checked;
        }

        private void button_register_Click_1(object sender, EventArgs e)
        {
            string username = TextBoxLogin.Text;
            string password = textBoxPassword.Text;
            string name = textBoxName.Text;

            if (UserRegister.RegisterUser(username, password, name))
            {
                MessageBox.Show("Регистрация успешна!");
                this.Close();
                _userPanel.Reset();
            }
            else
            {
                MessageBox.Show("Имя пользователя уже занято.");
            }
        }
    }
}
