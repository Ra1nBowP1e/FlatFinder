using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace Курсач
{
    public class UserRegister : PasswordHash
    {
        static string connectionString = "provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database.mdb";

        public static bool RegisterUser(string username, string password, string name)
        {
            string hashedPassword = HashPassword(password);

            using (var connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Users (username, passwordhash, name) VALUES (@username, @passwordhash, @name)";
                using (var command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@passwordhash", hashedPassword);
                    command.Parameters.AddWithValue("@name", name);

                    try
                    {
                        command.ExecuteNonQuery();
                        return true; 
                    }
                    catch (OleDbException ex)
                    {
                        if (ex.Message.Contains("duplicate values"))
                        {
                            
                            return false;
                        }
                        throw;
                    }
                }
            }
        }
    }
}
