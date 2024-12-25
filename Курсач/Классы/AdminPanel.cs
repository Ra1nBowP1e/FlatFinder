using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Курсач
{
    public partial class AdminPanel : Form
    {
        public AdminPanel()
        {
            InitializeComponent();
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Самая шикарная курсовая работа в мире", "Курсач");
        }

        private void button_download_Click(object sender, EventArgs e)
        {
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
                    dataGridView1.Rows.Add(dbReader["id"], dbReader["cost"], dbReader["adress"], dbReader["count"], dbReader["createdbyusername"], dbReader["author"], dbReader["authornumber"]);
                }
            }

            button_download.Enabled = false;
            dbReader.Close();
            dbconnection.Close();
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count != 1)
            {
                MessageBox.Show("Выберите одну строку !", "Ошибка !");
                return;
            }

            int index = dataGridView1.SelectedRows[0].Index;

            if (dataGridView1.Rows[index].Cells[0].Value == null || 
                dataGridView1.Rows[index].Cells[1].Value == null ||
                dataGridView1.Rows[index].Cells[2].Value == null ||
                dataGridView1.Rows[index].Cells[3].Value == null)
            {
                MessageBox.Show("Не все данные были введены", "Ошибка");
                return;
            }

            string id = dataGridView1.Rows[index].Cells[0].Value.ToString();
            string cost = dataGridView1.Rows[index].Cells[1].Value.ToString();
            string adress = dataGridView1.Rows[index].Cells[2].Value.ToString();
            string count = dataGridView1.Rows[index].Cells[3].Value.ToString();

            string createdbyusername = "Рокси";
            string connectionString = "provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database.mdb";
            OleDbConnection dbconnection = new OleDbConnection(connectionString);

            dbconnection.Open();
            string query = "INSERT INTO Appartments VALUES (" + id + ", '" + cost + "', '" + adress + "', " + count + ", '" + createdbyusername + "')";
            OleDbCommand dbCommand = new OleDbCommand(query, dbconnection);

            if(dbCommand.ExecuteNonQuery() != 1)
            {
                MessageBox.Show("Ошибка выполнения запроса", "Ошибка выполнения запроса");
            }
            else
            {
                MessageBox.Show("Данные добавлены", "Внимание");
            }

            dbconnection.Close();
        }

        private void button_update_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 1)
            {
                MessageBox.Show("Выберите одну строку !", "Ошибка !");
                return;
            }

            int index = dataGridView1.SelectedRows[0].Index;

            if (dataGridView1.Rows[index].Cells[0].Value == null ||
                dataGridView1.Rows[index].Cells[1].Value == null ||
                dataGridView1.Rows[index].Cells[2].Value == null ||
                dataGridView1.Rows[index].Cells[3].Value == null)
            {
                MessageBox.Show("Не все данные были введены", "Ошибка");
                return;
            }

            int id = Convert.ToInt32(dataGridView1.Rows[index].Cells[0].Value);
            decimal cost = Convert.ToDecimal(dataGridView1.Rows[index].Cells[1].Value);
            string adress = dataGridView1.Rows[index].Cells[2].Value.ToString();
            int count = Convert.ToInt32(dataGridView1.Rows[index].Cells[3].Value);

            string connectionString = "provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database.mdb";
            using (OleDbConnection dbconnection = new OleDbConnection(connectionString))
            {
              
                string query = "UPDATE Appartments SET cost = ?, adress = ?, [count] = ? WHERE id = ?";
                OleDbCommand dbCommand = new OleDbCommand(query, dbconnection);

              
                dbCommand.Parameters.AddWithValue("?", cost);
                dbCommand.Parameters.AddWithValue("?", adress);
                dbCommand.Parameters.AddWithValue("?", count);
                dbCommand.Parameters.AddWithValue("?", id);

                dbconnection.Open();

                if (dbCommand.ExecuteNonQuery() != 1)
                {
                    MessageBox.Show("Ошибка выполнения запроса", "Ошибка");
                }
                else
                {
                    MessageBox.Show("Данные изменены", "Внимание");
                }
            }
        }


        private void button_delete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 1)
            {
                MessageBox.Show("Выберите одну строку !", "Ошибка !");
                return;
            }

            int index = dataGridView1.SelectedRows[0].Index;

            string id = dataGridView1.Rows[index].Cells[0].Value.ToString();
            string cost = dataGridView1.Rows[index].Cells[1].Value.ToString();
            string adress = dataGridView1.Rows[index].Cells[2].Value.ToString();
            string count = dataGridView1.Rows[index].Cells[3].Value.ToString();

            string connectionString = "provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database.mdb";
            OleDbConnection dbconnection = new OleDbConnection(connectionString);

            dbconnection.Open();
            string query = "DELETE FROM Appartments WHERE id = " + id;
            OleDbCommand dbCommand = new OleDbCommand(query, dbconnection);

            if (dbCommand.ExecuteNonQuery() != 1)
            {
                MessageBox.Show("Ошибка выполнения запроса", "Ошибка выполнения запроса");
            }
            else
            {
                MessageBox.Show("Данные удалены", "Внимание");
                dataGridView1.Rows.RemoveAt(index);
            }

            dbconnection.Close();
        }
    }
}
