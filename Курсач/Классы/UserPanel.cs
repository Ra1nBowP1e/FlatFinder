using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Runtime.InteropServices;
using Курсач.Properties;

namespace Курсач
{ 
    public partial class UserPanel : Form
{
        private Button currentButton;
        private Random random;
        private int tempIndex;
        private Form activeForm;
        public UserPanel()
        {
            InitializeComponent();
            random = new Random();
            btnCloseChildForm.Visible = false;
            this.Text = string.Empty;
            this.ControlBox = false;
            btnAcc.Visible = false;
            btnLogout.Visible = false;
            btnMyAdv.Visible = false;  
            btnAdd.Visible = false; 
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private Color SelectThemeColor()
        {
            int index = random.Next(ThemeColor.ColorList.Count);
            while (tempIndex == index)
            {
                index = random.Next(ThemeColor.ColorList.Count);
            }
            tempIndex = index;
            string color = ThemeColor.ColorList[index];
            return ColorTranslator.FromHtml(color);
        }
        public void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    Color color = SelectThemeColor();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    panelTitleBar.BackColor = color;
                    panelLogo.BackColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    ThemeColor.PrimaryColor = color;
                    ThemeColor.SecondaryColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    btnCloseChildForm.Visible = true;
                }
            }
        }

        private void DisableButton()
        {
            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(51, 51, 76);
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }

        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
                activeForm.Close();
            ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktopPane.Controls.Add(childForm);
            this.panelDesktopPane.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitle.Text = childForm.Text;
        }

        public void IsLogged()
        {
            if (Session.LoggedInUser != null && !string.IsNullOrEmpty(Session.LoggedInUser.Username))
            {
                btnAcc.Visible = true;
                btnLogout.Visible = true;
                btnMyAdv.Visible = true;
                btnAdd.Visible = true;

                btnLogin.Visible = false;
                btnRegister.Visible = false;
            }
            else
            {
                btnAcc.Visible=false;
                btnLogout.Visible=false;
                btnMyAdv.Visible=false;
                btnAdd.Visible=false;  

                btnLogin.Visible=true; 
                btnRegister.Visible=true;
            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.MainForm(), sender);
        }


        private void btnMyAdv_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.MyAdv(this), sender);
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.About(), sender);
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            OpenChildForm(new LoginAsAdmin(this), sender);
        }

        private void btnCloseChildForm_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            Reset();
        }

        public void Reset()
        {
            DisableButton();
            lblTitle.Text = "Главная";
            panelTitleBar.BackColor = Color.FromArgb(0, 150, 136);
            panelLogo.BackColor = Color.FromArgb(39, 39, 58);
            currentButton = null;
            btnCloseChildForm.Visible = false;
        }

        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_Maximize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnAcc_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.Account(), sender);
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Login(this), sender);
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Register(this), sender);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Session.LoggedInUser = null;
            if (activeForm != null)
            {
                activeForm.Close();
            }
            Reset();
            IsLogged();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            OpenChildForm(new AddAdvertisement(this), sender);
        }
    }
}





