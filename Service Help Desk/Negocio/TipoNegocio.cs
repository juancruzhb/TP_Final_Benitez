using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Datos;

namespace Negocio
{
    public class TipoNegocio
    {
        public List<Tipo> listar()
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                List<Tipo> tipos = new List<Tipo>();

                datos.setearQuery("Select Id, Tipo from Tipo_Agentes");
                datos.ejecutarReader();
                while (datos.Reader.Read())
                {
                    tipos.Add(new Tipo
                    {
                        IdTipo = (int)datos.Reader["Id"],
                        Nombre = datos.Reader["Tipo"].ToString()
                    });
                }
                return tipos;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.close(); }
        }
    }
}
