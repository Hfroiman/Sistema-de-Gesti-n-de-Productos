using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;

namespace Negocio
{
    public class AccesoDatos
    {
        private  SqlConnection Conexion;
        private  SqlCommand Comando;
        public SqlDataReader Lector { get; set;}

        public AccesoDatos()
        {
            Conexion = new SqlConnection("Server=.\\SQLEXPRESS; database=ControlStock; integrated security=true");
            Comando = new SqlCommand();
        }
        public void SetearConsulta( string consulta)
        {
            Comando.CommandType = System.Data.CommandType.Text;
            Comando.CommandText = consulta;
        }
        public void EjecutarLectura()
        {
            Comando.Connection = Conexion;
            try
            {
                Conexion.Open();
                Lector = Comando.ExecuteReader();
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public void CerrarConexion()
        {
            Lector?.Close();
            Conexion.Close();
        }

        public void EjecutarAccion()
        {
            Comando.Connection = Conexion;
            try
            {
                Conexion.Open();
                Comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void SetearParametro (string nombre, object valor)
        {
            Comando.Parameters.AddWithValue(nombre, valor);
        }
    }
}
