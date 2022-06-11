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
    public class CD_Factura
    {
        private Conexion conexionBD = new Conexion();
        private MySqlCommand comando = new MySqlCommand();
        private MySqlDataReader LeerFilas;
        private string datos;
        private string mensaje = "";
        public void AgregarProFactura(Factura datos)
        {
            try
            {
                comando.Connection = conexionBD.abrirconexion();
                comando.CommandText = "AgregarProFactura";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("Idbauch", datos.bauche.Idbauche);
                comando.Parameters.AddWithValue("Cantida", datos.Cantidad);
                comando.Parameters.AddWithValue("Idproduct", datos.producto.Idproducto);
                comando.Parameters.AddWithValue("Precio", datos.PrecioP);
                comando.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                //messagebox.Show(e.ToString());
            }
            comando.Parameters.Clear();
            conexionBD.cerrarConexion();
        }

        public void BorrarProFactura(Factura datos)
        {
            try
            {
                comando.Connection = conexionBD.abrirconexion();
                comando.CommandText = "BorrarProFactura";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("Idfactur", datos.Idfactura);
                comando.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                //messagebox.Show(e.ToString());
            }
            comando.Parameters.Clear();
            conexionBD.cerrarConexion();
        }
        public DataTable CargarGananciaVentas(Factura datos)
        {
            DataTable tabla = new DataTable();
            try
            {
                comando.Connection = conexionBD.abrirconexion();
                comando.CommandText = "CargarGananciaVentas";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("fech", datos.Fecha);
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
        public DataTable CargarProductos(Factura datos)
        {
            DataTable tabla = new DataTable();
            try
            {
                comando.Connection = conexionBD.abrirconexion();
                comando.CommandText = "CargarProductos";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("IdBauch", datos.bauche.Idbauche);
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
    }
}
