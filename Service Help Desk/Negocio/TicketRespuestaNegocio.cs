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
        public List<TicketRespuesta> listar(int idTicket = 0)
        {
            List<TicketRespuesta> respuestas = new List<TicketRespuesta>();

            AccesoDatos datos = new AccesoDatos();

            try
            {

                datos.setearQuery("  select Id, Fecha, IdTicket, Respuesta, Emisor, EsAgente, Leido from Tickets_Respuestas where IdTicket = @IdTicket");

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
                        Emisor = (int)datos.Reader["Emisor"],
                        EsAgente =(bool)datos.Reader["EsAgente"],
                        Leido = (bool)datos.Reader["Leido"]
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
                datos.setearParametros("@EsAgente", respuesta.EsAgente);
                datos.setearParametros("Leido", respuesta.Leido);


                return datos.ejecutarScalar();
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.close(); }
        }

        public void LeerRespuesta(int idTicket, int esUsuario)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearSP("SP_LeerRespuesta");
                datos.setearParametros("@IdTicket", idTicket);
                datos.setearParametros("@EsAgente", esUsuario);
                datos.ejecutarQuery();

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public bool VerificaLectura(int IdTicket, bool esAgente)
        {
            List<TicketRespuesta> lista = new List<TicketRespuesta>();

            lista = listar(IdTicket);

            foreach (var respuestas in lista)
            {
                if(respuestas.Leido == false && respuestas.EsAgente != esAgente)
                {
                    return false;
                }
            }

            return true;
            
        }
    }
}
