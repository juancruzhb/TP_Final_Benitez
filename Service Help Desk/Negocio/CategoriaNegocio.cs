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
    public class CategoriaNegocio
    {
        public List<Categoria> listar()
        {
            List<Categoria> categorias = new List<Categoria>();

            using(SqlConnection conexion = new SqlConnection(Conexion.CN))
            {
                SqlCommand cmd = new SqlCommand("sp_obtenerCategorias", conexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                try
                {
                    conexion.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        categorias.Add(new Categoria()
                        {
                            IdCategoria = (int)reader["ID"],
                            Nombre = (string)reader["Nombre"],
                            Activo =(bool)reader["Activo"]
                        });

                    }


                }
                catch (Exception)
                {

                    throw;
                }
                finally { conexion.Close(); }
            }
            return categorias;
        }

        public void ActivarDesactivarCategoria(int IdCategoria, bool activo)
        {
            AccesoDatos datos = new AccesoDatos();
            int aux = 0;
            if (activo)
            {
                aux = 1;
            }

            try
            {
                datos.setearQuery("Update Categorias set Activo = @Activo where Id = @IdCategoria");
                datos.setearParametros("@Activo", aux);
                datos.setearParametros("@IdCategoria", IdCategoria);
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

        public bool InsertarCategoria(Categoria categoria)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearQuery("insert into Categorias (Nombre, Activo) Values (@Nombre, 1)");
                datos.setearParametros("@Nombre", categoria.Nombre);

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
