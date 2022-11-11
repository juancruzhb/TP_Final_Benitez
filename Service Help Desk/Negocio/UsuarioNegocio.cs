using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Datos;
using System.Data.SqlClient;

namespace Negocio
{
    public class UsuarioNegocio
    {
        public int insertarNuevo(Usuario nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearSP("sp_InsertarUsuario");
                datos.setearParametros("@Apellido", nuevo.Apellido);
                datos.setearParametros("@Nombre", nuevo.Nombre);
                datos.setearParametros("@Email", nuevo.Email);
                datos.setearParametros("@Contraseña", nuevo.Password);
               return datos.ejecutarScalar();


            }
            catch (Exception)
            {

                throw;
            }
            finally { datos.close(); }
            
        }


    }
}
