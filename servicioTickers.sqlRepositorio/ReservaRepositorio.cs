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
    public class ReservaRepositorio : IReservaRepositorio
    {
        private readonly string _connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection" +
            ""].ConnectionString;

        public bool BookFlight(int vueloID, int userID, int asientos)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "INSERT INTO Reservas (VueloID, UsuarioID, FechaReserva, Estado, AsientosReservados) " +
                    "VALUES (@VueloID, @UsuarioID, GETDATE(), 'Booked', @AsientosReservados)";
                var result = connection.Execute(query, new { VueloID = vueloID, UsuarioID = userID, AsientosReservados = asientos });

                if (result > 0)
                {
                    var updateQuery = "UPDATE Vuelos SET Disponibilidad = Disponibilidad - @AsientosReservados WHERE" +
                        " VueloID = @VueloID";
                    connection.Execute(updateQuery, new { VueloID = vueloID, AsientosReservados = asientos });
                    return true;
                }
                return false;
            }
        }

        public bool CancelReservation(int reservaID, int userID)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "UPDATE Reservas SET Estado = 'Cancelled' WHERE ReservaID = @ReservaID AND UsuarioID = @UsuarioID";
                var result = connection.Execute(query, new { ReservaID = reservaID, UsuarioID = userID });

                if (result > 0)
                {
                    var selectQuery = "SELECT AsientosReservados, VueloID FROM Reservas WHERE ReservaID = @ReservaID";
                    var reserva = connection.QuerySingle<Reserva>(selectQuery, new { ReservaID = reservaID });

                    var updateQuery = "UPDATE Vuelos SET Disponibilidad = Disponibilidad + @AsientosReservados WHERE VueloID = " +
                        "@VueloID";
                    connection.Execute(updateQuery, new { VueloID = reserva.VueloID, AsientosReservados = reserva.AsientosReservados });
                    return true;
                }
                return false;
            }
        }

        public Reserva[] GetReservations(string userID)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "SELECT * FROM Reservas WHERE UsuarioID = @UsuarioID";
                var reservations = connection.Query<Reserva>(query, new { UsuarioID = userID }).ToArray();
                return reservations;
            }
        }

        public String ModifyReserva(Reserva reserva)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        var updateQuery = @"
                    UPDATE Reservas SET 
                        VueloID = @VueloID,
                        Estado = @Estado,
                        FechaReserva = @FechaReserva,
                        AsientosReservados = @AsientosReservados 
                    WHERE 
                        ReservaID = @ReservaID AND 
                        UsuarioID = @UsuarioID";

                        var result = connection.Execute(updateQuery, new
                        {
                            VueloID = reserva.VueloID,
                            Estado = reserva.Estado,
                            FechaReserva = reserva.FechaReserva,
                            AsientosReservados = reserva.AsientosReservados,
                            ReservaID = reserva.ReservaID,
                            UsuarioID = reserva.UsuarioID
                        }, transaction);

                        if (result > 0)
                        {
                            var selectQuery = "SELECT AsientosReservados, VueloID FROM Reservas WHERE ReservaID = @ReservaID";
                            var reservaActual = connection.QuerySingle<Reserva>(selectQuery, new { ReservaID = reserva.ReservaID }, transaction);

                            var updateFlightQuery = "UPDATE Vuelos SET Disponibilidad = Disponibilidad + @AsientosReservados" +
                                " WHERE VueloID = @VueloID";
                            connection.Execute(updateFlightQuery, new
                            {
                                VueloID = reservaActual.VueloID,
                                AsientosReservados = reservaActual.AsientosReservados
                            }, transaction);

                            transaction.Commit();
                            return "Todo correcto";
                        }
                        else
                        {
                            transaction.Rollback();
                            return "No se actualizaron filas";
                        }
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Console.WriteLine(ex.Message);
                        return ex.ToString();
                    }
                }
            }
        }

    }
}
