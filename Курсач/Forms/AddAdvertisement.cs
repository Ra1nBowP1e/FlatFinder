using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Курсач
{
    public partial class AddAdvertisement : Form
    {
        private UserPanel _userPanel;
        public AddAdvertisement(UserPanel userPanel)
        {
            InitializeComponent();
            _userPanel = userPanel;
        }

        private void buttonSelectImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Изображения (*.jpg;*.png;*.bmp)|*.jpg;*.png;*.bmp";
                openFileDialog.Title = "Выберите изображение";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    labelmagePath.Text = openFileDialog.FileName;
                }
            }
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            if (textbox_cost == null ||
                textBox_adress == null ||
                textBox_count == null ||
                textBox_authornumber == null ||
                textBox_author == null ||
                textBoxDescription == null ||
                labelmagePath == null ||
                labelmagePath.Text == "Путь к изображению")
            {
                MessageBox.Show("Не все данные были введены", "Ошибка");
                return;
            }

            string cost = textbox_cost.Text;
            string adress = textBox_adress.Text;
            string count = textBox_count.Text;
            string authornumber = textBox_authornumber.Text;
            string author = textBox_author.Text;
            string imagepath = labelmagePath.Text;
            string description = textBoxDescription.Text;


            string createdbyusername = Session.LoggedInUser.Username;


            string connectionString = "provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database.mdb";
            using (OleDbConnection dbconnection = new OleDbConnection(connectionString))
            {
                try
                {
                    dbconnection.Open();


                    string query = "INSERT INTO Appartments (cost, adress, [count], author, authornumber, createdbyusername, imagepath, description) " +
                                   "VALUES (@cost, @adress, @count, @author, @authornumber,@createdbyusername, @imagepath, @description)";

                    using (OleDbCommand dbCommand = new OleDbCommand(query, dbconnection))
                    {
                        dbCommand.Parameters.AddWithValue("@cost", decimal.Parse(cost));
                        dbCommand.Parameters.AddWithValue("@adress", adress);
                        dbCommand.Parameters.AddWithValue("@count", int.Parse(count));
                        dbCommand.Parameters.AddWithValue("@authornumber", authornumber);
                        dbCommand.Parameters.AddWithValue("@author", author);
                        dbCommand.Parameters.AddWithValue("@createdbyusername", createdbyusername);
                        dbCommand.Parameters.AddWithValue("@imagepath", imagepath);
                        dbCommand.Parameters.AddWithValue("@description", description);

                        if (dbCommand.ExecuteNonQuery() == 1)
                        {
                            MessageBox.Show("Данные добавлены", "Внимание");
                            _userPanel.Reset();
                            this.Close();
                            _userPanel.IsLogged();
                        }
                        else
                        {
                            MessageBox.Show("Ошибка выполнения запроса", "Ошибка выполнения запроса");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка");
                }
            }
        }
    }
}

