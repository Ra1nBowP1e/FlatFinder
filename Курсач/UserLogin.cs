using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Курсач
{
    public class UserLogin : PasswordHash
    {
        static string connectionString = "provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database.mdb";
        public static CurrentUser LoginUser(string username, string password)
        {
            string hashedPassword = HashPassword(password);

            using (var connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Id, Username FROM Users WHERE Username = @Username AND PasswordHash = @PasswordHash";
                using (var command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@PasswordHash", hashedPassword);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new CurrentUser
                            {
                                Username = reader.GetString(1),
                            };
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }
    }
}
