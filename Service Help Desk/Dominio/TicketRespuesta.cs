using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class TicketRespuesta
    {
        public int Id { get; set; }
        public int TicketId { get; set; }
        public string Respuesta { get; set; }
        public DateTime Fecha { get; set; }
        public int Emisor { get; set; }
        public bool EsAgente { get; set; }
        public bool Leido { get; set; }

    }
}
