using CapaEntidad;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Credito
    {
        private Conexion conexionBD = new Conexion();
        private MySqlCommand comando = new MySqlCommand();
        private MySqlDataReader LeerFilas;
        public void AgregarProCre(Credito datos)
        {
            try
            {
                comando.Connection = conexionBD.abrirconexion();
                comando.CommandText = "AgregarProCre";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("CLiente", datos.Cliente.Id);
                comando.Parameters.AddWithValue("fech", datos.Fecha);
                comando.Parameters.AddWithValue("cantida", datos.Cantidad);
                comando.Parameters.AddWithValue("product", datos.Producto.Idproducto);
                comando.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                //messagebox.Show(e.ToString());
            }
            comando.Parameters.Clear();
            conexionBD.cerrarConexion();
        }
        public DataTable CargarProCre(Credito datos)
        {
            DataTable tabla = new DataTable();
            try
            {
                comando.Connection = conexionBD.abrirconexion();
                comando.CommandText = "CargarProCre";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("CLiente", datos.Cliente.Id);
                LeerFilas = comando.ExecuteReader();
                tabla.Load(LeerFilas);
            }
            catch (MySqlException e)
            {
                //messagebox.Show(e.ToString());
            }

            LeerFilas.Close();
            conexionBD.cerrarConexion();
            comando.Parameters.Clear();
            return tabla;
        }
        public void QuitarProCre(Credito datos)
        {
            try
            {
                comando.Connection = conexionBD.abrirconexion();
                comando.CommandText = "QuitarProCre";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("IdCredit", datos.Idcredito);
                comando.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                //messagebox.Show(e.ToString());
            }
            comando.Parameters.Clear();
            conexionBD.cerrarConexion();
        }
    }
}
