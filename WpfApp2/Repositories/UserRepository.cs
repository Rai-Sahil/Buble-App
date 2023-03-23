using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.CustomControls;
using WpfApp2.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace WpfApp2.Repositories
{
    public class UserRepository : RepositoryBase, IUserRepository
    {
        public void Add(UserModel userModel)
        {
            throw new NotImplementedException();
        }

        public bool AuthenticateUser(NetworkCredential credential)
        {
            bool validUser;

            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                Console.WriteLine("Database name: " + connection.Database);
                command.Connection = connection;
                command.CommandText = "select * from [User] where username=@username and password=@password";
                command.Parameters.Add("@username", SqlDbType.NVarChar).Value = credential.UserName;
                command.Parameters.Add("@password", SqlDbType.NVarChar).Value = credential.Password;
                validUser = command.ExecuteScalar() == null ? false : true;

                connection.Close();
                connection.Dispose();
                command.Dispose();
            }
            return validUser;
        }

        public void Edit(UserModel userModel)
        {
            throw new NotImplementedException();
        }

        public List<UserRow> GetByAll()
        {
            List<UserRow> users = new List<UserRow>();
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select * from [User]";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        UserRow user = new UserRow();

                        user.Title = reader[0].ToString();
                        user.Description = reader[1].ToString();

                        users.Add(user);
                        
                    }
                }

                connection.Close();
                connection.Dispose();
                command.Dispose();
            }

            return users;
        }

        public UserModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public UserModel GetByUsername(string username)
        {
            UserModel user = null;
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select * from [User] where username=@username";
                command.Parameters.Add("@username", SqlDbType.NVarChar).Value = username;
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        user = new UserModel()
                        {
                            Id = reader[0].ToString(),
                            Username = reader[1].ToString(),
                            Password = string.Empty,
                            Name = reader[3].ToString(),
                            LastName = reader[4].ToString(),
                            Email = reader[5].ToString(),
                        };
                    }
                }

                connection.Close();
                connection.Dispose();
                command.Dispose ();
            }
            return user;
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void ChangeUserPassword(string username, string Password)
        {
            string updateQuery = "UPDATE [User] SET Password = @Password WHERE Username = @Username";

            using (SqlConnection connection = GetConnection())
            {
                connection.Open();

                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    using (SqlCommand command = new SqlCommand(updateQuery, connection, transaction))
                    {
                        command.Parameters.AddWithValue("@Password", SqlDbType.NVarChar).Value = Password;
                        command.Parameters.AddWithValue("@Username", SqlDbType.NVarChar).Value = username;

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected == 0)
                        {
                            transaction.Rollback();
                            Console.WriteLine("User not found");
                        }
                        else
                        {
                            // Commit transaction if rows were affected
                            transaction.Commit();
                            Console.WriteLine("Password updated successfully.");
                        }
                        command.Dispose();
                    }
                }
                catch (Exception ex)
                {
                    // Roll back transaction on exception
                    transaction.Rollback();
                    Console.WriteLine("Error updating password: " + ex.Message);
                }

                connection.Close();
                connection.Dispose();

            }

        }
    }
}
