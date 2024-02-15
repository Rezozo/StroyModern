using Npgsql;

namespace StroyModern.provider
{
    public class UserProvider
    {
        private NpgsqlConnection connection = new NpgsqlConnection("Server=localhost;Port=5432;Database=mdb;User Id=postgres;Password=0987");

        public bool isValidUser(string username, string password)
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
                    return false;
                }
                return true;
            }
            else
            {
                connection.Close();
                reader.Close();
                return false;
            }
        }

    }
}
