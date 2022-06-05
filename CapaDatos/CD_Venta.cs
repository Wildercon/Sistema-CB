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
    public class CD_Venta
    {
        private Conexion conexionBD = new Conexion();
        private MySqlCommand comando = new MySqlCommand();
        private MySqlDataReader LeerFilas;
        public void AgregarVenta(Venta datos)
        {
            try
            {
                comando.Connection = conexionBD.abrirconexion();
                comando.CommandText = "AgregarVenta";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("idvendedo", datos.Vendedor.Idvendedor);
                comando.Parameters.AddWithValue("fech", datos.Fecha);
                comando.Parameters.AddWithValue("mont", datos.Monto);
                comando.Parameters.AddWithValue("bauch", datos.Bauche.Idbauche);
                comando.Parameters.AddWithValue("o", datos.Estado);
                comando.Parameters.AddWithValue("tota", datos.Total);
                comando.ExecuteNonQuery();

            }
            catch (MySqlException e)
            {
                //messagebox.Show(e.ToString());
            }

            comando.Parameters.Clear();
            conexionBD.cerrarConexion();
        }
        public DataTable CargarDetalleVendedor(Venta datos)
        {
            DataTable tabla = new DataTable();
            try
            {
                comando.Connection = conexionBD.abrirconexion();
                comando.CommandText = "CargarDetalleVendedor";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("idvendedo", datos.Vendedor.Idvendedor);
                LeerFilas = comando.ExecuteReader();
                tabla.Load(LeerFilas);
            }
            catch (MySqlException e)
            {
                //messagebox.Show(e.ToString());
            }
            LeerFilas.Close();
            comando.Parameters.Clear();
            conexionBD.cerrarConexion();
            return tabla;
        }
        public DataTable CargarVentas()
        {
            DataTable tabla = new DataTable();
            try
            {
                comando.Connection = conexionBD.abrirconexion();
                comando.CommandText = "CargarVentas";
                comando.CommandType = CommandType.StoredProcedure;
                LeerFilas = comando.ExecuteReader();
                tabla.Load(LeerFilas);
            }
            catch (MySqlException e)
            {
                //messagebox.Show(e.ToString());
            }
            LeerFilas.Close();
            conexionBD.cerrarConexion();
            return tabla;
        }
    }
}
