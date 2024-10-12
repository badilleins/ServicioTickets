using servicioTickets.dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace servicioTickets.contratoRepositorio
{
    [ServiceContract]
    public interface IVueloRepositorio
    {
        [OperationContract]
        Vuelo[] SearchFlights(string origin, string destination, DateTime date);

    }
}
