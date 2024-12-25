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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.IO;

namespace Курсач.Forms
{
    public partial class Account : Form
    {
        public Account()
        {
            InitializeComponent();
            LoadUserAvatar();
        }

        private void LoadUserAvatar()
        {
            string avatarsFolder = Path.Combine(Application.StartupPath, "Avatars");
            string placeholderPath = Path.Combine(avatarsFolder, "placeholder.png");

            if (Session.LoggedInUser != null && !string.IsNullOrEmpty(Session.LoggedInUser.Username))
            {
                string avatarPath = GetAvatarPathFromDatabase(Session.LoggedInUser.Username);

                if (!string.IsNullOrEmpty(avatarPath) && File.Exists(avatarPath))
                {
                    pictureBoxAvatar.Image = Image.FromFile(avatarPath);
                }
                else
                {
                    if (!File.Exists(placeholderPath))
                    {
                        MessageBox.Show("Файл заглушки отсутствует в папке Avatars!", "Ошибка");
                    }
                    else
                    {
                        pictureBoxAvatar.Image = Image.FromFile(placeholderPath);
                    }
                }
            }
        }


        private static string GetAvatarPathFromDatabase(string username)
        {
            string connectionString = "provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database.mdb";

            using (var connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT AvatarPath FROM Users WHERE Username = @Username";

                using (var command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);

                    var result = command.ExecuteScalar();
                    return result != null ? result.ToString() : null;
                }
            }
        }

        private void Account_Load(object sender, EventArgs e)
        {
            string connectionString = "provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database.mdb";
            string currentUsername = Session.LoggedInUser.Username;

            using (var connection = new OleDbConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT name, username FROM Users WHERE username = @username";

                    using (var command = new OleDbCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@username", currentUsername);

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                textBoxName.Text = reader["name"].ToString();
                                textBoxLogin.Text = reader["username"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("Данные текущего пользователя не найдены.", "Ошибка");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", "Ошибка");
                }
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            textBoxLogin.UseSystemPasswordChar = !checkBox2.Checked;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedFilePath = openFileDialog.FileName;

                    
                    string avatarsFolder = Path.Combine(Application.StartupPath, "Avatars");
                    Directory.CreateDirectory(avatarsFolder);
                    string fileName = $"{Session.LoggedInUser.Username}_avatar{Path.GetExtension(selectedFilePath)}";
                    string newFilePath = Path.Combine(avatarsFolder, fileName);

                    try
                    {
                        
                        File.Copy(selectedFilePath, newFilePath, true);

                        
                        SaveAvatarPathToDatabase(Session.LoggedInUser.Username, newFilePath);

                        
                        pictureBoxAvatar.Image = Image.FromFile(newFilePath);

                        MessageBox.Show("Аватар успешно установлен!", "Успех");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при установке аватара: {ex.Message}", "Ошибка");
                    }
                }
            }
        }

        private static void SaveAvatarPathToDatabase(string username, string avatarPath)
        {
            string connectionString = "provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database.mdb";

            using (var connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE Users SET AvatarPath = @AvatarPath WHERE Username = @Username";

                using (var command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@AvatarPath", avatarPath);
                    command.Parameters.AddWithValue("@Username", username);

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}

