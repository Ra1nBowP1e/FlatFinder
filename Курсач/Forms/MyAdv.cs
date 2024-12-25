using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace Курсач.Forms
{
    public partial class MyAdv : Form
    {
        private UserPanel _userPanel;
        public MyAdv(UserPanel userPanel)
        {
            InitializeComponent();
            _userPanel = userPanel;
        }

        private void MyAdv_Load(object sender, EventArgs e)
        {
            if (Session.LoggedInUser == null || string.IsNullOrEmpty(Session.LoggedInUser.Username))
            {
                _userPanel.Reset();
                this.Close();
                return;
            }

            string createdbyusername = Session.LoggedInUser.Username;

            string connectionString = "provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database.mdb";
            using (OleDbConnection dbconnection = new OleDbConnection(connectionString))
            {
                try
                {
                    dbconnection.Open();

                    string query = "SELECT * FROM Appartments WHERE createdbyusername = ?";
                    using (OleDbCommand dbCommand = new OleDbCommand(query, dbconnection))
                    {
                        dbCommand.Parameters.AddWithValue("?", createdbyusername);

                        using (OleDbDataReader dbReader = dbCommand.ExecuteReader())
                        {
                            if (!dbReader.HasRows)
                            {
                                MessageBox.Show("Данные не найдены!", "Ошибка");
                            }
                            else
                            {
                                dataGridView1.Rows.Clear();
                                while (dbReader.Read())
                                {
                                    dataGridView1.Rows.Add(dbReader["id"], dbReader["cost"], dbReader["adress"], dbReader["count"], dbReader["author"], dbReader["authornumber"], dbReader["imagepath"], dbReader["description"]);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка");
                }
            }

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 1)
            {
                pictureBox1.Visible = false;
                return;
            }

            int index = dataGridView1.SelectedRows[0].Index;

            if (dataGridView1.Rows[index].Cells["imagePath"].Value != null)
            {
                string imagePath = dataGridView1.Rows[index].Cells["imagePath"].Value.ToString();
                string description = dataGridView1.Rows[index].Cells["description"].Value.ToString();

                if (File.Exists(imagePath) || string.IsNullOrWhiteSpace(description))
                {
                    pictureBox1.Image = Image.FromFile(imagePath);
                    pictureBox1.Visible = true;
                    lblDescription.Text = description;
                }
                else
                {
                    MessageBox.Show($"Изображение по пути {imagePath} не найдено.", "Ошибка");
                    pictureBox1.Visible = false;
                }
            }
            else
            {
                pictureBox1.Visible = false;
            }
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            string connectionString = "provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database.mdb";
            
            int index = dataGridView1.SelectedRows[0].Index;
            string currentUsername = Session.LoggedInUser.Username;
            string id = dataGridView1.Rows[index].Cells[0].Value.ToString();

            using (var connection = new OleDbConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "DELETE FROM Appartments WHERE id = @id AND createdbyusername = @createdbyusername";

                    using (var command = new OleDbCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        command.Parameters.AddWithValue("@createdbyusername", currentUsername);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Объявление успешно удалено.", "Успех");
                            dataGridView1.Rows.RemoveAt(index);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при удалении объявления: {ex.Message}", "Ошибка");
                }
            }
        }
    }
}

