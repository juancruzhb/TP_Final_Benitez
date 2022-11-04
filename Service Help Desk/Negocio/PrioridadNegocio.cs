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
                            Nombre = (string)reader["Nombre"]
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
    }
}

