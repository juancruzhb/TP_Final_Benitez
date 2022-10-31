using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Ticket
    {
        public int TicketID { get; set; }
        public string Asunto { get; set; }
        public int IdCategoria { get; set; }
        public int IdPrioridad { get; set; }
        public int IdEmpresa { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool Activo { get; set; }
        public int IdEstado { get; set; }
        public int IdTipo { get; set; }

        public string Descripcion { get; set; }
    }
}
