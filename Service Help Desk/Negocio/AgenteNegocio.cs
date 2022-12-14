using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Datos;

namespace Negocio
{
    public class AgenteNegocio
    {
        public bool Loguear(Agente agente)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearQuery("Select Id, Apellido, Nombre, Email, Contraseña, Tipo from Agentes where Email = @Email and Contraseña = @Pass");
                datos.setearParametros("@Email", agente.Email);
                datos.setearParametros("@Pass", agente.Password);

                datos.ejecutarReader();
                while (datos.Reader.Read())
                {
                    agente.IdAgente = (int)datos.Reader["Id"];
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

        public List<Agente> listar()
        {
            List<Tipo> tipos = new List<Tipo>();
            List<Agente> aux = new List<Agente>();
            TipoNegocio tNegocio = new TipoNegocio();
            tipos = tNegocio.listar();

            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearQuery("Select Id, Apellido, Nombre, Email, Contraseña, Tipo, Estado from Agentes");
                datos.ejecutarReader();
                while (datos.Reader.Read())
                {
                    aux.Add(new Agente
                    {
                        IdAgente = (int)datos.Reader["Id"],
                        Apellido = datos.Reader["Apellido"].ToString(),
                        Nombre = datos.Reader["Nombre"].ToString(),
                        Email = datos.Reader["Email"].ToString(),
                        Password = datos.Reader["Contraseña"].ToString(),
                        Tipo = tipos.Find(x => x.IdTipo.Equals((int)datos.Reader["Tipo"])),
                        Estado = (bool)datos.Reader["Estado"]

                    });
                }
                return aux;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.close(); }
        }

        public Agente ObtenerAgente(Agente agente)
        {
            List<Tipo> tipos = new List<Tipo>();
            TipoNegocio tNegocio = new TipoNegocio();
            tipos = tNegocio.listar();

            AccesoDatos datos = new AccesoDatos();
            Agente aux = new Agente();
            try
            {
                datos.setearQuery("Select Id, Apellido, Nombre, Email, Contraseña, Tipo, Estado from Agentes where Email = @Email and Contraseña = @Pass");
                datos.setearParametros("@Email", agente.Email);
                datos.setearParametros("@Pass", agente.Password);

                datos.ejecutarReader();
                while (datos.Reader.Read())
                {
                    aux.IdAgente = (int)datos.Reader["Id"];
                    aux.Apellido = datos.Reader["Apellido"].ToString();
                    aux.Nombre = datos.Reader["Nombre"].ToString();
                    aux.Email = datos.Reader["Email"].ToString();
                    aux.Password = datos.Reader["Contraseña"].ToString();
                    aux.Tipo = tipos.Find(x => x.IdTipo.Equals((int)datos.Reader["Tipo"]));
                    aux.Estado = (bool)datos.Reader["Estado"];
                }
                return aux;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.close(); }
        }

        public int InsertarNuevo(Agente agente)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearSP("Sp_InsertarAgente");
                datos.setearParametros("@Apellido", agente.Apellido);
                datos.setearParametros("@Nombre", agente.Nombre);
                datos.setearParametros("@Email", agente.Email);
                datos.setearParametros("@Contraseña", agente.Password);
                datos.setearParametros("@Tipo", agente.Tipo.IdTipo);

                return datos.ejecutarScalar();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.close(); }
        }

        public void ActivarDesactivarAgente(int idAgente, bool estado)
        {
            AccesoDatos datos = new AccesoDatos();
            int aux = 0;
            if (estado)
            {
                aux = 1;
            }

            try
            {
                datos.setearQuery("Update Agentes set Estado = @Estado where Id = @IdAgente");
                datos.setearParametros("@Estado",aux);
                datos.setearParametros("@IdAgente", idAgente);
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
    }
}
