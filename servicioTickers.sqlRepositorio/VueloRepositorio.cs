using servicioTickets.contratoRepositorio;
using servicioTickets.dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace servicioTickets.sqlRepositorio
{
    public class VueloRepositorio : IVueloRepositorio
    {
        private readonly string _connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public Vuelo[] SearchFlights(string origin, string destination, DateTime date)
        {

            using (var connection = new SqlConnection(_connectionString))
            {
                //MANDAR COMO PARAMETRO EN SOLICITUD POST
                var query = "SELECT * FROM Vuelos WHERE Origen = @Origen AND Destino = @Destino AND CAST(FechaSalida AS DATE) = CAST(@Fecha AS DATE)";
                var flights = connection.Query<Vuelo>(query, new { Origen = origin, Destino = destination, Fecha = date }).ToArray();
                return flights;
            }
        }
    }
}
