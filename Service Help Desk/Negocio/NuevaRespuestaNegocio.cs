using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Datos;

namespace Negocio
{
    public class NuevaRespuestaNegocio
    {
        public void Insertar(NuevaRespuesta respuestaLeida)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearQuery("insert into nuevas_respuestas (IdTicket, Leido, EsAgente) values (@IdTicket, @Leido, @EsAgente)");
                datos.setearParametros("@Idticket", respuestaLeida.IdTicket);
                datos.setearParametros("@Leido", respuestaLeida.Leido);
                datos.setearParametros("@EsAgente", respuestaLeida.EsAgente);

                datos.ejecutarQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.close();
            }

        }

        public List<NuevaRespuesta> listar()
        {
            AccesoDatos datos = new AccesoDatos();
            List<NuevaRespuesta> lista = new List<NuevaRespuesta>();

            try
            {
                datos.setearQuery("Select IdTicket, Leido, EsAgente from nuevas_respuestas");
                datos.ejecutarReader();
                while (datos.Reader.Read())
                {
                    lista.Add(new NuevaRespuesta
                    {
                        IdTicket = (int)datos.Reader["IdTicket"],
                        Leido = (bool)datos.Reader["Leido"],
                        EsAgente = (bool)datos.Reader["EsAgente"]

                    });
                }

                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.close(); }
        }

        public void LeerTicket(int idTicket, int esAgente)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearQuery("Update nuevas_respuestas set Leido = 1 where IdTicket = @IdTicket and EsAgente = @EsAgente");
                datos.setearParametros("@IdTicket", idTicket);
                datos.setearParametros("@EsAgente", esAgente);

                datos.ejecutarQuery();


            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.close(); }
        }
    }
}
