using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace servicioTickets.dominio
{

    [DataContract]
    public class Reserva
    {
        [DataMember]
        public int ReservaID { get; set; }

        [DataMember]
        public int UsuarioID { get; set; }

        [DataMember]
        public int VueloID { get; set; }

        [DataMember]
        public DateTime FechaReserva { get; set; }

        [DataMember]
        public string Estado { get; set; }

        [DataMember]
        public int AsientosReservados { get; set; }
    }
}
