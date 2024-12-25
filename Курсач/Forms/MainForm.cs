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
using System.Reflection.Emit;

namespace Курсач.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
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
            }
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadTheme();
            string connectionString = "provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database.mdb";
            OleDbConnection dbconnection = new OleDbConnection(connectionString);

            dbconnection.Open();
            string query = "SELECT * FROM Appartments";
            OleDbCommand dbCommand = new OleDbCommand(query, dbconnection);
            OleDbDataReader dbReader = dbCommand.ExecuteReader();

            if (dbReader.HasRows == false)
            {
                MessageBox.Show("Данные не найдены !", "Ошибка");
            }
            else
            {
                while (dbReader.Read())
                {
                    dataGridView1.Rows.Add(dbReader["id"], dbReader["cost"], dbReader["adress"], dbReader["count"], dbReader["author"], dbReader["authornumber"], dbReader["imagepath"], dbReader["description"]);
                }
            }

            dbReader.Close();
            dbconnection.Close();
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 1)
            {
                MessageBox.Show("Выберите одну строку!", "Ошибка!");
                return;
            }

            int index = dataGridView1.SelectedRows[0].Index;

            if (dataGridView1.Rows[index].Cells[0].Value == null)
            {
                MessageBox.Show("ID записи отсутствует!", "Ошибка!");
                return;
            }

            string id = dataGridView1.Rows[index].Cells[0].Value.ToString();

            if (Session.LoggedInUser == null || string.IsNullOrEmpty(Session.LoggedInUser.Username))
            {
                MessageBox.Show("Вы не авторизованы. Пожалуйста, войдите в систему!", "Ошибка!");
                return;
            }

            string loggedInUser = Session.LoggedInUser.Username;

            string connectionString = "provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database.mdb";
            using (OleDbConnection dbconnection = new OleDbConnection(connectionString))
            {
                try
                {
                    dbconnection.Open();

                    string checkQuery = "SELECT createdbyusername FROM Appartments WHERE id = ?";
                    using (OleDbCommand checkCommand = new OleDbCommand(checkQuery, dbconnection))
                    {
                        checkCommand.Parameters.AddWithValue("?", id);

                        object result = checkCommand.ExecuteScalar();
                        if (result == null)
                        {
                            MessageBox.Show("Запись не найдена в базе данных.", "Ошибка");
                            return;
                        }

                        string recordOwner = result.ToString();
                        if (recordOwner != loggedInUser)
                        {
                            MessageBox.Show("Вы не можете удалить чужую запись!", "Ошибка!");
                            return;
                        }
                    }


                    string query = "DELETE FROM Appartments WHERE id = ? AND createdbyusername = ?";
                    using (OleDbCommand dbCommand = new OleDbCommand(query, dbconnection))
                    {
                        dbCommand.Parameters.AddWithValue("?", id);
                        dbCommand.Parameters.AddWithValue("?", loggedInUser);

                        int rowsAffected = dbCommand.ExecuteNonQuery();

                        if (rowsAffected != 1)
                        {
                            MessageBox.Show("Ошибка выполнения запроса или запись не найдена!", "Ошибка выполнения запроса");
                        }
                        else
                        {
                            MessageBox.Show("Данные удалены", "Внимание");
                            dataGridView1.Rows.RemoveAt(index);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при удалении данных: {ex.Message}", "Ошибка");
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

            if (dataGridView1.Rows[index].Cells["imagePath"].Value != null && dataGridView1.Rows[index].Cells["description"].Value != null)
            {
                string imagePath = dataGridView1.Rows[index].Cells["imagePath"].Value.ToString();
                string description = dataGridView1.Rows[index].Cells["description"].Value.ToString();

                if (File.Exists(imagePath))
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            using (ImageViewer viewer = new ImageViewer(pictureBox1.Image))
            {
                viewer.ShowDialog();
            }
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = textBoxSearch.Text.Trim();

            string connectionString = "provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database.mdb";
            using (OleDbConnection dbconnection = new OleDbConnection(connectionString))
            {
                try
                {
                    dbconnection.Open();

                    string query = "SELECT * FROM Appartments WHERE adress LIKE ? OR cost LIKE ?";
                    using (OleDbCommand command = new OleDbCommand(query, dbconnection))
                    {
                        command.Parameters.AddWithValue("?", $"%{searchText}%");
                        command.Parameters.AddWithValue("?", $"%{searchText}%");

                        using (OleDbDataReader reader = command.ExecuteReader())
                        {
                            dataGridView1.Rows.Clear(); 

                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    dataGridView1.Rows.Add(
                                        reader["id"],
                                        reader["cost"],
                                        reader["adress"],
                                        reader["count"],
                                        reader["author"],
                                        reader["authornumber"],
                                        reader["imagepath"],
                                        reader["description"]
                                    );
                                }
                            }
                            else
                            {
                                dataGridView1.Rows.Clear();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при выполнении поиска: {ex.Message}", "Ошибка");
                }
            }
        }
    }
}
