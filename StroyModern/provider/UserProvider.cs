using Npgsql;
using StroyModern.model;
using System.Collections.Generic;

namespace StroyModern.provider
{
    public class UserProvider
    {
        private NpgsqlConnection connection = new NpgsqlConnection("Server=localhost;Port=5432;Database=mdb;User Id=postgres;Password=0987");

        public string isValidUser(string username, string password)
        {
            connection.Open();
            var command = new NpgsqlCommand("Select * from users u INNER JOIN roles r ON r.id = u.id_roles" +
                " where login_user=@username and pass=@password", connection);
            command.Parameters.AddWithValue("username", username);
            command.Parameters.AddWithValue("password", password);
            var reader = command.ExecuteReader();
            if (reader.Read())
            {
                string role = (string)reader["name_roles"];
                connection.Close();
                reader.Close();
                if (!role.Equals("Администратор") && !role.Equals("Менеджер"))
                {
                    return "";
                }
                return role;
            }
            else
            {
                connection.Close();
                reader.Close();
                return "";
            }
        }

        public List<User> GetAllUsers()
        {
            List<User> allUsers = new List<User>();
            connection.Open();
            var command = new NpgsqlCommand("SELECT id, login_user, pass, id_roles FROM users", connection);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var user = new User();
                user.Id = (int)reader[0];
                user.Login = (string)reader[1];
                user.Password = (string)reader[2];
                switch ((int)reader[3])
                {
                    case 2:
                        user.Role = "Администратор";
                        break;
                    case 1:
                        user.Role = "Менеджер";
                        break;
                }

                allUsers.Add(user);
            }
            reader.Close();
            connection.Close();
            return allUsers;
        }

        public User GetById(int userId)
        {
            User user = new User();
            connection.Open();
            var command = new NpgsqlCommand($"SELECT id, login_user, pass, id_roles FROM users WHERE id = {userId}", connection);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                user.Id = (int)reader[0];
                user.Login = (string)reader[1];
                user.Password = (string)reader[2];
                switch ((int)reader[3])
                {
                    case 2:
                        user.Role = "Администратор";
                        break;
                    case 1:
                        user.Role = "Менеджер";
                        break;
                }

            }
            reader.Close();
            connection.Close();
            return user;
        }

        public void CreateUser (string login, string password, string role)
        {
            connection.Open();

            int roleId = 1;

            if (role.Equals("Администратор"))
            {
                roleId = 2;
            }

            var command = new NpgsqlCommand($"INSERT INTO users VALUES (DEFAULT, {roleId}, '{login}', '{password}')", connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void UpdateUser(int userId, string login, string password, string role)
        {
            connection.Open();
            int roleId = 1;

            if (role.Equals("Администратор"))
            {
                roleId = 2;
            }
            var command = new NpgsqlCommand($"UPDATE users SET id_roles = {roleId}, login_user = '{login}', pass = '{password}' WHERE id = {userId}", connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void DeleteUser(int userId)
        {
            connection.Open();
            var command = new NpgsqlCommand($"DELETE FROM users WHERE id = {userId}", connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

    }
}
