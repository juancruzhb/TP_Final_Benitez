using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Datos;

namespace Negocio
{
    public class TicketNegocio
    {
        public int InsertarNuevo(Ticket ticket)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearSP("sp_InsertarTicket");
                datos.setearParametros("@Asunto", ticket.Asunto);
                datos.setearParametros("@Mensaje", ticket.Mensaje);
                datos.setearParametros("@IdCategoria", ticket.oCategoria.IdCategoria);
                datos.setearParametros("@IdPrioridad", ticket.oPrioridad.IdPrioridad);
                datos.setearParametros("@FechaCreacion", ticket.FechaCreacion);
                datos.setearParametros("@IdEstado", 1);
                datos.setearParametros("@IdUsuario", ticket.User.IdUsuario);
                datos.setearParametros("@Celular", ticket.Contacto);

                return datos.ejecutarScalar();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.close(); }

        }



    }
}
