using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Datos
{
    public class AccesoDatos
    {
        public static string cadenaConexion = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=HelpDesk_DB;Data Source=.\\SQLEXPRESS";

        private SqlCommand cmd;
        private SqlConnection conexion;
        private SqlDataReader reader;
        public AccesoDatos()
        {
            conexion = new SqlConnection(cadenaConexion);
            cmd = new SqlCommand();
        }
        public SqlDataReader Reader

        {
            get { return reader; }
        }
        public SqlCommand Cmd
        {
            get { return cmd; }
        }

        public void ejecutarReader()
        {
            cmd.Connection = conexion;
            try
            {
                conexion.Open();
                reader = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void ejecutarQuery()
        {
            cmd.Connection = conexion;
            try
            {
                conexion.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //Setear las consultas

        public void setearQuery(string query)
        {
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = query;
        }
         //Setear SP

        public void setearSP(string sp)
        {
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = sp;

        }
         public void setearParametros(string parametro, object valor)
        {
    
            cmd.Parameters.AddWithValue(parametro, valor);
        }

        public void open()
        {
            try
            {
                conexion.Open();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void close()
        {
            try
            {
                conexion.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
   

        public void ejecutarConsulta()
        {
            cmd.Connection = conexion;
            try
            {
                cmd.Connection = conexion;
                reader = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int ejecutarScalar()
        {
            cmd.Connection = conexion;
            try
            {
                conexion.Open();
                return int.Parse(cmd.ExecuteScalar().ToString());
            }
            catch (Exception ex)
            {

                throw ex; 
            }
        }

    }
}
