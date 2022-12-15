using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Datos;

namespace Negocio
{
    public class EstadoNegocio
    {
        public List<Estado> listar()
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                List<Estado> estados = new List<Estado>();

                datos.setearQuery("Select Id, Nombre, Activo from Estados");
                datos.ejecutarReader();
                while (datos.Reader.Read())
                {
                    estados.Add(new Estado
                    {
                        IdEstado =(int)datos.Reader["Id"],
                        Nombre = datos.Reader["Nombre"].ToString(),
                        Activo = (bool)datos.Reader["Activo"]
                    });
                }
                return estados;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.close(); }
        }

        public void ActivarDesactivarEstado(int idEstado, bool activo)
        {
            AccesoDatos datos = new AccesoDatos();
            int aux = 0;
            if (activo)
            {
                aux = 1;
            }

            try
            {
                datos.setearQuery("Update Estados set Activo = @Activo where Id = @IdEstado");
                datos.setearParametros("@Activo", aux);
                datos.setearParametros("@IdEstado", idEstado);
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

        public bool InsertarEstado(Estado estado)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearQuery("insert into Estados (Nombre, Activo) Values (@Nombre, 1)");
                datos.setearParametros("@Nombre", estado.Nombre);

                datos.ejecutarQuery();
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.close(); }
        }

    }
}
