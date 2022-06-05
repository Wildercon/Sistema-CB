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
    public class CD_Producto
    {
        private Conexion conexionBD = new Conexion();
        private MySqlCommand comando = new MySqlCommand();
        private MySqlDataReader LeerFilas;
        public void AgregarProducto(Producto datos)
        {
            try
            {
                comando.Connection = conexionBD.abrirconexion();
                comando.CommandText = "AgregarProducto";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("Product", datos.producto);
                comando.Parameters.AddWithValue("Preci", datos.Precio);
                comando.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                //messagebox.Show(e.ToString());
            }

            comando.Parameters.Clear();
            conexionBD.cerrarConexion();
        }
        public void EditarProducto(Producto datos)
        {
            try
            {
                comando.Connection = conexionBD.abrirconexion();
                comando.CommandText = "EditarProducto";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("IdProduct", datos.Idproducto);
                comando.Parameters.AddWithValue("Preci", datos.Precio);
                comando.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                //messagebox.Show(e.ToString());
            }
            comando.Parameters.Clear();
            conexionBD.cerrarConexion();
        }
        public void EliminarProducto(Producto datos)
        {
            try
            {
                comando.Connection = conexionBD.abrirconexion();
                comando.CommandText = "EliminarProducto";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("Idproduct", datos.Idproducto);
                comando.ExecuteNonQuery();
                //messagebox.Show("Se Elimino el Producto");
            }
            catch (MySqlException e)
            {
                //messagebox.Show(e.ToString());
            }
            comando.Parameters.Clear();
            conexionBD.cerrarConexion();
        }
        public DataTable ListarProductos()
        {
            DataTable tabla = new DataTable();
            try
            {
                comando.Connection = conexionBD.abrirconexion();
                comando.CommandText = "ListarProductos";
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
