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
        public string Contacto { get; set; }
        public Categoria oCategoria { get; set; }
        public Prioridad oPrioridad { get; set; }
        //public int IdEmpresa { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool Activo { get; set; }
        public Estado Estado { get; set; }
        public string Mensaje { get; set; }
        public Usuario User { get; set; }
        public Agente AgenteAsignado { get; set; }
        public string NombreApellido
        {
  
            get { return User.Nombre + " " + User.Apellido; }
        }
    }
}
