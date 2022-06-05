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
    public class CD_Compra
    {
        private Conexion conexionBD = new Conexion();
        private MySqlCommand comando = new MySqlCommand();
        private MySqlDataReader LeerFilas;
        public void AgregarCompra(Compra datos)
        {   

            try
            {
                comando.Connection = conexionBD.abrirconexion();
                comando.CommandText = "AgregarCompra";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("mont", datos.Monto);
                comando.Parameters.AddWithValue("refe", datos.Refencia);
                comando.Parameters.AddWithValue("Idclient", datos.Cliente.Id);
                comando.Parameters.AddWithValue("fech", datos.Fecha);
                comando.Parameters.AddWithValue("op", datos.Estado);
                comando.ExecuteNonQuery();
                //messagebox.Show("Se Registro la compra");
            }
            catch (MySqlException e)
            {
                //messagebox.Show(e.ToString());
            }

            comando.Parameters.Clear();
            conexionBD.cerrarConexion();
        }
        public DataTable CargarCompras()
        {
            DataTable tabla = new DataTable();
            try
            {
                comando.Connection = conexionBD.abrirconexion();
                comando.CommandText = "CargarCompras";
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
        public DataTable DetalleCompraCliente(Compra datos)
        {
            DataTable tabla = new DataTable();
            try
            {
                comando.Connection = conexionBD.abrirconexion();
                comando.CommandText = "DetalleCompraCliente";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("idcliente", datos.Cliente.Id);
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

    }
}
