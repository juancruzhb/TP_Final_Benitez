using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Datos;

namespace Negocio
{
    public class TicketRespuestaNegocio
    {
        public int InsertarNueva(TicketRespuesta respuesta)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearSP("Sp_InsertarRespuesta");
                datos.setearParametros("@Fecha", DateTime.Now);
                datos.setearParametros("@IdTicket", respuesta.TicketId);
                datos.setearParametros("@Respuesta", respuesta.Respuesta);
                datos.setearParametros("@Emisor", respuesta.Agente.IdAgente);

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
