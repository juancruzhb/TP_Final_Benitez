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
        public List<TicketRespuesta> listar(int idTicket)
        {
            List<TicketRespuesta> respuestas = new List<TicketRespuesta>();

            AccesoDatos datos = new AccesoDatos();

            try
            {

                datos.setearQuery("  select Id, Fecha, IdTicket, Respuesta, Emisor, tipo from Tickets_Respuestas where IdTicket = @IdTicket");
                datos.setearParametros("@IdTicket", idTicket);

                datos.ejecutarReader();

                while (datos.Reader.Read())
                {
                    respuestas.Add(new TicketRespuesta
                    {
                        Id = (int)datos.Reader["Id"],
                        TicketId = (int)datos.Reader["IdTicket"],
                        Respuesta = datos.Reader["Respuesta"].ToString(),
                        Fecha = (DateTime)datos.Reader["Fecha"],
                        Tipo =(int) datos.Reader["Tipo"],
                        Emisor = (int)datos.Reader["Emisor"],
                    }) ;

                }
                return respuestas;



            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.close(); }
        }
        public int InsertarNueva(TicketRespuesta respuesta)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearSP("Sp_InsertarRespuesta");
                datos.setearParametros("@Fecha", DateTime.Now);
                datos.setearParametros("@IdTicket", respuesta.TicketId);
                datos.setearParametros("@Respuesta", respuesta.Respuesta);
                datos.setearParametros("@Emisor", respuesta.Emisor);
                datos.setearParametros("@Tipo", respuesta.Tipo);

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
