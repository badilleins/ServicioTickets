using servicioTickets.dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Web;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace servicioTickets.contrato
{
    [ServiceContract]

    public interface IReservaService
    {
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "" +
            "/BookFlight", BodyStyle = WebMessageBodyStyle.Wrapped)]
        bool BookFlight(int vueloID, int userID, int asientos);

        [OperationContract]
        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/GetReservations/" +
            "{userID}", BodyStyle = WebMessageBodyStyle.Bare)]
        Reserva[] GetReservations(string userID);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "" +
            "/CancelReservation", BodyStyle = WebMessageBodyStyle.Wrapped)]
        bool CancelReservation(int reservaID, int userID);


        [OperationContract]
        [WebInvoke(Method = "PUT", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "" +
            "/ModifyReserva", BodyStyle = WebMessageBodyStyle.Wrapped)]
        String ModifyReserva(Reserva reserva);

        [OperationContract]
        [WebInvoke(Method = "OPTIONS", UriTemplate = "*")]
        void HandleHttpOptionsRequest();

    }

}
