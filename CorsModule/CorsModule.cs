using System;
using System.Web;

namespace ServiciosTickets
{
    public class CorsModule : IHttpModule
    {
        public void Dispose()
        {
        }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += Context_BeginRequest;
            context.EndRequest += Context_EndRequest;
        }

        private void Context_BeginRequest(object sender, EventArgs e)
        {
            var context = HttpContext.Current;

            context.Response.Headers.Add("Access-Control-Allow-Origin", "*");

            // Permitir ciertos encabezados (ajusta según tus necesidades)
            context.Response.Headers.Add("Access-Control-Allow-Headers", "X-API-KEY, Origin, X-Requested-With, Content-Type, Accept, Access-Control-Request-Method");

            // Permitir ciertos métodos (ajusta según tus necesidades)
            context.Response.Headers.Add("Access-Control-Allow-Methods", "GET, POST, OPTIONS, PUT, DELETE");
        }

        private void Context_EndRequest(object sender, EventArgs e)
        {
            var context = HttpContext.Current;

            // Manejar las solicitudes OPTIONS de CORS para los preflights
            if (context.Request.HttpMethod == "OPTIONS")
            {
                context.Response.StatusCode = 200;
                context.Response.End();
            }
        }
    }
}