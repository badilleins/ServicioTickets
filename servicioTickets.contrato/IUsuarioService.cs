using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Configuration;
using System.ServiceModel.Web;
using servicioTickets.dominio;

namespace servicioTickets.contrato
{
    [ServiceContract]

    public interface IUsuarioService
    {

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "" +
            "/RegisterUser", BodyStyle = WebMessageBodyStyle.Bare)]
        String RegisterUser(Usuario user);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "" +
            "/Login", BodyStyle = WebMessageBodyStyle.Wrapped)]
        bool Login(string username, string password);
        [OperationContract]
        [WebInvoke(Method = "OPTIONS", UriTemplate = "*")]
        void HandleHttpOptionsRequest();


    }
 

}
