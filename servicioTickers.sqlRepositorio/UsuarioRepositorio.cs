using System;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using Dapper;
using servicioTickets.contratoRepositorio;
using servicioTickets.dominio;

namespace servicioTickets.sqlRepositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly string _connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public string RegisterUser(Usuario user)
        {
            var hashedPassword = ComputeSha256Hash(user.Contrasena);
            var newUser = new Usuario
            {
                NombreUsuario = user.NombreUsuario,
                Contrasena = HA,
                Nombre = user.Nombre,
                Apellido = user.Apellido,
                Email = user.Email,
                Telefono = user.Telefono
            };

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    var query = "INSERT INTO Usuarios (NombreUsuario, Contrasena, Nombre, Apellido, Email, Telefono)" +
                                " VALUES (@NombreUsuario, @Contrasena, @Nombre, @Apellido, @Email, @Telefono)";
                    var result = connection.Execute(query, newUser);
                    return result.ToString();
                }
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine($"Error: {sqlEx.Message}");
                Console.WriteLine($"Stack Trace: {sqlEx.StackTrace}");
                return sqlEx.ToString();
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        public bool Login(string username, string password)
        {
            var hashedPassword = ComputeSha256Hash(password);

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    var query = "SELECT COUNT(1) FROM Usuarios WHERE NombreUsuario = @NombreUsuario AND Contrasena = @Contrasena";
                    var result = connection.ExecuteScalar<int>(query, new { NombreUsuario = username, Contrasena = hashedPassword });
                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        private string ComputeSha256Hash(string rawData)
        {
            if (string.IsNullOrEmpty(rawData))
            {
                throw new ArgumentNullException(nameof(rawData), "La cadena de entrada no puede ser nula o vacía.");
            }

            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
