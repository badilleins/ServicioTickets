using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace servicioTickets.dominio
{
    [DataContract]

    public class Vuelo
    {
        [DataMember]
        public int VueloID { get; set; }

        [DataMember]
        public string NumeroVuelo { get; set; }

        [DataMember]
        public string Origen { get; set; }

        [DataMember]
        public string Destino { get; set; }

        [DataMember]
        public DateTime FechaSalida { get; set; }

        [DataMember]
        public DateTime FechaLlegada { get; set; }

        [DataMember]
        public decimal Precio { get; set; }

        [DataMember]
        public string Aerolinea { get; set; }

        [DataMember]
        public int Disponibilidad { get; set; }
    }
}
