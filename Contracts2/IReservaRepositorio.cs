using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using servicioTickets.dominio;

namespace servicioTickets.contratoRepositorio
{
    [ServiceContract]

    public interface IReservaRepositorio
    {
        [OperationContract]
        bool BookFlight(int vueloID, int userID, int asientos);

        [OperationContract]
        Reserva[] GetReservations(string userID);

        [OperationContract]
        bool CancelReservation(int reservaID, int userID);
        
        [OperationContract]
        String ModifyReserva(Reserva reserva);
    }
}
