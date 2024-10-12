using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.ServiceModel;
using servicioTickets.dominio;

namespace servicioTickets.contratoRepositorio
{

        [ServiceContract]
        public interface IUsuarioRepositorio
        {
            [OperationContract]
            String RegisterUser(Usuario user);

            [OperationContract]
            bool Login(string username, string password);

      
        }
}
