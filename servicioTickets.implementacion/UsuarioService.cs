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
    public class UsuarioService : IUsuarioService
    {
        public bool Login(string username, string password)
        {
            using (var obj = new UsuarioFachada())
            {
                return obj.Login(username, password);
            }
        }

        public String RegisterUser(Usuario user)
        {
            using (var obj = new UsuarioFachada())
            {
                return obj.RegisterUser(user).ToString();
            }
        }
        public void HandleHttpOptionsRequest()
        {
            // Método vacío para manejar solicitudes OPTIONS
        }
    }
}
