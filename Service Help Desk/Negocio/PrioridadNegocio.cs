using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Datos;

namespace Negocio
{
    public class PrioridadNegocio
    {

        public List<Prioridad> listar()
        {
            List<Prioridad> prioridades = new List<Prioridad>();

            using (SqlConnection conexion = new SqlConnection(Conexion.CN))
            {
                SqlCommand cmd = new SqlCommand("sp_obtenerPrioridades", conexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                try
                {
                    conexion.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        prioridades.Add(new Prioridad()
                        {
                            IdPrioridad = (int)reader["ID"],
                            Nombre = (string)reader["Nombre"],
                            Activo= (bool)reader["Activo"]
                        });

                    }


                }
                catch (Exception)
                {

                    throw;
                }
                finally { conexion.Close(); }
            }
            return prioridades;
        }
        public void  ActivarDesactivarPrioridad(int idPrioridad, bool activo)
        {
                AccesoDatos datos = new AccesoDatos();
                int aux = 0;
                if (activo)
                {
                    aux = 1;
                }

                try
                {
                    datos.setearQuery("Update Prioridades set Activo = @Activo where Id = @IdPrioridad");
                    datos.setearParametros("@Activo", aux);
                    datos.setearParametros("@IdPrioridad", idPrioridad);
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

        public bool InsertarPrioridad(Prioridad prioridad)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearQuery("insert into Prioridades (Nombre, Activo) Values (@Nombre, 1)");
                datos.setearParametros("@Nombre", prioridad.Nombre);

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

