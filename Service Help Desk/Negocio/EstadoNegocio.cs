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

                datos.setearQuery("Select Id, Nombre from Estados");
                datos.ejecutarReader();
                while (datos.Reader.Read())
                {
                    estados.Add(new Estado
                    {
                        IdEstado =(int)datos.Reader["Id"],
                        Nombre = datos.Reader["Nombre"].ToString()
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

    }
}
