using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using servicioTickets.contrato;
using servicioTickets.dominio;
using servicioTickets.fachada;
using servicioTickets.contratoRepositorio;

namespace servicioTickets.implementacion
{
    public class ReservaService : IReservaService
    {
        public bool BookFlight(int vueloID, int userID, int asientos)
        {
            using (var obj = new ReservaFachada())
            {
                return obj.BookFlight(vueloID, userID, asientos);
            }
        }

        public bool CancelReservation(int reservaID, int userID)
        {
            using (var obj = new ReservaFachada())
            {
                return obj.CancelReservation(reservaID, userID);
            }
        }

        public Reserva[] GetReservations(string userID)
        {
            using (var obj = new ReservaFachada())
            {
                return obj.GetReservations(userID);
            }
        }

        public String ModifyReserva(Reserva reserva)
        {
            using (var obj = new ReservaFachada())
            {
                return obj.ModifyReserva(reserva);
            }
        }
        public void HandleHttpOptionsRequest()
        {
            // Método vacío para manejar solicitudes OPTIONS
        }
    }
}
