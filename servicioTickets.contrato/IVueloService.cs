using servicioTickets.dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Web;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace servicioTickets.contrato
{
    [ServiceContract]

    public interface IVueloService
    {   //MANDAR COMO POST
        [OperationContract]
        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "" +
            "/SearchFlights/{origin}/{destination}/{date}", BodyStyle = WebMessageBodyStyle.Bare)]
        Vuelo[] SearchFlights(string origin, string destination, string date);

        [OperationContract]
        [WebInvoke(Method = "OPTIONS", UriTemplate = "*")]
        void HandleHttpOptionsRequest();
    }

}
