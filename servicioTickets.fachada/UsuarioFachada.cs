using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using servicioTickets.dominio;
using servicioTickets.contratoRepositorio;
using servicioTickets.sqlRepositorio;

namespace servicioTickets.fachada
{
    public class UsuarioFachada : IUsuarioRepositorio, IDisposable
    {

        public String RegisterUser(Usuario user)
        {
            IUsuarioRepositorio obj = new UsuarioRepositorio();
            return obj.RegisterUser(user).ToString();
        }

        public bool Login(string username, string password)
        {
            IUsuarioRepositorio obj = new UsuarioRepositorio();
            return obj.Login(username, password);
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

     
    }
}
