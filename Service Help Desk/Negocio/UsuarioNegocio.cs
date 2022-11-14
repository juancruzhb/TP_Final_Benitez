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
        public int InsertarNuevo(Usuario nuevo)
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

        public bool Loguear(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearQuery("Select Id, Nombre, Apellido from usuarios where Email = @Email and Contraseña = @Pass");
                datos.setearParametros("@Email", usuario.Email);
                datos.setearParametros("@Pass", usuario.Password);

                datos.ejecutarReader();
                while (datos.Reader.Read())
                {
                    usuario.IdUsuario =(int)datos.Reader["Id"];
                    return true;
                }
                return false;

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

        public Usuario ObtenerUsuario(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            Usuario aux = new Usuario();
            try
            {
                datos.setearQuery("Select Id, Nombre, Apellido, Email, Contraseña from usuarios where Email = @Email and Contraseña = @Pass");
                datos.setearParametros("@Email", usuario.Email);
                datos.setearParametros("@Pass", usuario.Password);

                datos.ejecutarReader();
                while (datos.Reader.Read())
                {
                    aux.IdUsuario = (int)datos.Reader["Id"];
                    aux.Apellido = datos.Reader["Apellido"].ToString();
                    aux.Nombre = datos.Reader["Nombre"].ToString();
                    aux.Email = datos.Reader["Email"].ToString();
                    aux.Password = datos.Reader["Contraseña"].ToString();
                    return aux ;
                }
                return aux;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.close(); }
        }
    }
}
