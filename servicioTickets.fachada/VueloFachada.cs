using servicioTickets.contratoRepositorio;
using servicioTickets.dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using servicioTickets.contratoRepositorio;
using servicioTickets.sqlRepositorio;

namespace servicioTickets.fachada
{
    public class VueloFachada : IVueloRepositorio, IDisposable
    {
        
        public Vuelo[] SearchFlights(string origin, string destination, DateTime date)
        {
            IVueloRepositorio obj = new VueloRepositorio();
            return obj.SearchFlights(origin,destination,date);
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
