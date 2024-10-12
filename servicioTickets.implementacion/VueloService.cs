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
    public class VueloService : IVueloService
    {
        public Vuelo[] SearchFlights(string origin, string destination, string date)
        {
            DateTime newDate;
            DateTime.TryParse(date, out newDate);
            using (var obj = new VueloFachada())
            {
                return obj.SearchFlights(origin, destination, newDate);
            }
        }
        public void HandleHttpOptionsRequest()
        {
            // Método vacío para manejar solicitudes OPTIONS
        }
    }

}
