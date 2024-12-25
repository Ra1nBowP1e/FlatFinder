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
    public partial class LoginAsAdmin : Form
    {
        private UserPanel _userPanel;
        private Form activeForm;
        public LoginAsAdmin(UserPanel userPanel)
        {
            InitializeComponent();
            _userPanel = userPanel;
        }

        private void OpenAdminPanel(Form childForm, object btnSender)
        {
            if (activeForm != null)
                activeForm.Close();
            _userPanel.ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            _userPanel.panelDesktopPane.Controls.Add(childForm);
            _userPanel.panelDesktopPane.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            _userPanel.lblTitle.Text = childForm.Text;
        }

        string username = "admin";
        string password = "root";
        private void button2_Click(object sender, EventArgs e)
        {
            string Input_UserName = textBox1.Text;
            string Input_Password = textBox2.Text;

            if (username == Input_UserName && password == Input_Password)
            {
                this.Close();
                OpenAdminPanel(new AdminPanel(), sender);
            }   
            else
            {
                MessageBox.Show("Неверный логин или пароль", "Ошибка !");
            }
        }
    }
}
