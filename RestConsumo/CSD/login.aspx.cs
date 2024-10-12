using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using Newtonsoft.Json;

namespace RestConsumo
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string apiUrl = "http://localhost/servicioTickets.wcf/UsuarioService.svc/rest/Login";

            var loginData = new
            {
                username = username,
                password = password
            };

            Task.Run(async () =>
            {
                using (HttpClient client = new HttpClient())
                {
                    var content = new StringContent(JsonConvert.SerializeObject(loginData), Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                    if (response.IsSuccessStatusCode)
                    {
                        string result = await response.Content.ReadAsStringAsync();
                        if (bool.TryParse(result, out bool loginSuccessful) && loginSuccessful)
                        {
                            lblMessage.Text = "Login successful!";
                        }
                        else
                        {
                            lblMessage.Text = "Invalid username or password.";
                        }
                    }
                    else
                    {
                        lblMessage.Text = "Error contacting the service.";
                    }
                }
            }).GetAwaiter().GetResult();
        }
    }
}
