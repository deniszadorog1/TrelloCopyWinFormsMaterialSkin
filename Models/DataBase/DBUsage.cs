using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dotenv.net;

using TrelloCopyWinForms.Models.UserModel;

namespace TrelloCopyWinForms.Models.DataBase
{
    public static class DBUsage
    {
        private static string _connectionString = "";

        public static void InitConnectionString()
        {
            DotEnv.Load();        
            _connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");
        }

        public static void InserUser(User user)
        {
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "INSERT INTO [Users]([Login], [Password], [Email]) VALUES(@login, @password, @email)";

                string passHash = BCrypt.Net.BCrypt.HashPassword(user.Password);

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@login", user.Login);
                command.Parameters.AddWithValue("@password", passHash);
                command.Parameters.AddWithValue("@email", user.Password);

                command.ExecuteNonQuery();

                connection.Close();
            }
        }
        public static bool IfUserParamsExistInDB(string login, string email)
        {
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "SELECT [Login], [Email] FROM [Users] us " +
                    "WHERE EXISTS(SELECT[Login], [Email] FROM[Users] users " +
                    "WHERE us.Login = @login OR us.Email = @email)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@login", login);
                command.Parameters.AddWithValue("@email", email);

                SqlDataReader reader = command.ExecuteReader();
                bool check = reader.Read();

                connection.Close();

                return check;
            }
        }

        public static User GetUserInAuthorization(string login, string password)
        {
            User res = null;
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM [Users] WHERE [Users].Login = @login";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@login", login);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    if (BCrypt.Net.BCrypt.Verify(password, reader["Password"].ToString()))
                    {
                        res = new User(reader["Login"].ToString(),
                            reader["Email"].ToString(), int.Parse(reader["Id"].ToString()));
                        return res;
                    }
                }
                connection.Close();
            }
            return res;
        }

        public static bool ComparePassHashes(string login, string oldPassword)
        {
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM [Users] WHERE [Users].Login = @login";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@login", login);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    if (BCrypt.Net.BCrypt.Verify(oldPassword, reader["Password"].ToString()))
                    {
                        return true;
                    }
                }
                connection.Close();
            }
            return false;
        }

        public static void UpdateUser(string oldUserLogin, User userParams)
        {
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "UPDATE [Users] SET [Login] = @login, [Password] = @password, [Email] = @email WHERE [Login] = @oldLogin";

                string passHash = BCrypt.Net.BCrypt.HashPassword(userParams.Password);

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@login", userParams.Login);
                command.Parameters.AddWithValue("@password", passHash);
                command.Parameters.AddWithValue("@email", userParams.Email);
                command.Parameters.AddWithValue("@oldLogin", oldUserLogin);

                command.ExecuteNonQuery();

                connection.Close();
            }
        } 


    }
}
