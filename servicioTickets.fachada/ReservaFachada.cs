using servicioTickets.contratoRepositorio;
using servicioTickets.dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using servicioTickets.dominio;
using servicioTickets.sqlRepositorio;
using Dapper;

namespace servicioTickets.fachada
{

    public class ReservaFachada : IReservaRepositorio, IDisposable
    {
        public bool BookFlight(int vueloID, int userID, int asientos)
        {
            IReservaRepositorio obj = new ReservaRepositorio();

            return obj.BookFlight(vueloID,userID,asientos);
        }

        public Reserva[] GetReservations(string userID)
        {
            IReservaRepositorio obj = new ReservaRepositorio();
            return obj.GetReservations(userID);
        }

        public bool CancelReservation(int reservaID, int userID)
        {
            IReservaRepositorio obj = new ReservaRepositorio();
            return obj.CancelReservation(reservaID, userID);
        }
        public String ModifyReserva(Reserva reserva)
        {
            IReservaRepositorio obj = new ReservaRepositorio();
            return obj.ModifyReserva(reserva);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
