using System;
using System.Web;

namespace servicioTickets.wcf
{
    public class CorsModule : IHttpModule
    {
        public void Dispose() { }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += Context_BeginRequest;
            context.EndRequest += Context_EndRequest;
        }

        private void Context_BeginRequest(object sender, EventArgs e)
        {
            var context = HttpContext.Current;
            var origin = context.Request.Headers["Origin"];
            if (!string.IsNullOrEmpty(origin))
            {
                context.Response.Headers.Set("Access-Control-Allow-Origin", origin);
            }

            context.Response.Headers.Set("Access-Control-Allow-Headers", "X-API-KEY, Origin, X-Requested-With, Content-Type, Accept, Access-Control-Request-Method");
            context.Response.Headers.Set("Access-Control-Allow-Methods", "GET, POST, OPTIONS, PUT, DELETE");
        }

        private void Context_EndRequest(object sender, EventArgs e)
        {
            var context = HttpContext.Current;
            if (context.Request.HttpMethod == "OPTIONS")
            {
                context.Response.StatusCode = 200;
                context.Response.End();
            }
        }
    }
}