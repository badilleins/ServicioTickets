using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Configuration;
using System.Runtime.Serialization;


namespace servicioTickets.dominio
{
    [DataContract]
    public class Usuario
    {
        [DataMember]
        public int UsuarioID { get; set; }

        [DataMember]
        public string NombreUsuario { get; set; }

        [DataMember]
        public string Contrasena { get; set; }

        [DataMember]
        public string Nombre { get; set; }

        [DataMember]
        public string Apellido { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string Telefono { get; set; }
    }
}
