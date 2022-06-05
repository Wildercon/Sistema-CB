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
    public class CD_Vendedor
    {
        private Conexion conexionBD = new Conexion();
        private MySqlCommand comando = new MySqlCommand();
        private MySqlDataReader LeerFilas;
        public void AgregarVendedor(Vendedor datos)
        {
            try
            {
                comando.Connection = conexionBD.abrirconexion();
                comando.CommandText = "AgregarVendedor";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("vendedo", datos.vendedor);
                comando.Parameters.AddWithValue("mont", datos.Monto);
                comando.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                //messagebox.Show(e.ToString());
            }

            comando.Parameters.Clear();
            conexionBD.cerrarConexion();
        }
        public void AumentarMontoVendedor(Venta datos)
        {

            try
            {
                comando.Connection = conexionBD.abrirconexion();
                comando.CommandText = "AumentarMontoVendedor";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("mont", datos.Monto);
                comando.Parameters.AddWithValue("Idvendedo", datos.Vendedor.Idvendedor);
                comando.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                //messagebox.Show(e.ToString());
            }

            comando.Parameters.Clear();
            conexionBD.cerrarConexion();

        }
        public double ControlMontoV(Venta dato)
        {
            double montoO = 0;
            try
            {
                comando.Connection = conexionBD.abrirconexion();
                comando.CommandText = "ControlMontoV";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("idvendedo", dato.Vendedor.Idvendedor);
                LeerFilas = comando.ExecuteReader();
                
                if (LeerFilas.Read())
                {
                    montoO = Convert.ToDouble(LeerFilas[0]);
                }
            }
            catch (MySqlException e)
            {
                //messagebox.Show(e.ToString());
            }
            LeerFilas.Close();
            comando.Parameters.Clear();
            conexionBD.cerrarConexion();
            return montoO;
        }
        public void DisminuirMontoVendedor(Venta datos)
        {
            try
            {
                comando.Connection = conexionBD.abrirconexion();
                comando.CommandText = "DisminuirMontoVendedor";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("mont", datos.Monto);
                comando.Parameters.AddWithValue("Idvendedo", datos.Vendedor.Idvendedor);
                comando.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                //messagebox.Show(e.ToString());
            }

            comando.Parameters.Clear();
            conexionBD.cerrarConexion();
        }

        public void EditarMontoVendedor(Vendedor datos)
        {
            try
            {
                comando.Connection = conexionBD.abrirconexion();
                comando.CommandText = "EditarMontoVendedor";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("mont", datos.Monto);
                comando.Parameters.AddWithValue("Idvendedo", datos.Idvendedor);
                comando.ExecuteNonQuery();
                //messagebox.Show("Se Edito Correctamente");
            }
            catch (MySqlException e)
            {
                //messagebox.Show(e.ToString());
            }

            comando.Parameters.Clear();
            conexionBD.cerrarConexion();
        }
        public void EliminarVendedor(Vendedor datos)
        {
            try
            {
                comando.Connection = conexionBD.abrirconexion();
                comando.CommandText = "EliminarVendedor";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("Idvendedo", datos.Idvendedor);
                comando.ExecuteNonQuery();
                //messagebox.Show("Se Elimino el Vendedor");
            }
            catch (MySqlException e)
            {
                //messagebox.Show(e.ToString());
            }
            comando.Parameters.Clear();
            conexionBD.cerrarConexion();
        }
        public DataTable ListarVendedores()
        {
            DataTable tabla = new DataTable();
            try
            {
                comando.Connection = conexionBD.abrirconexion();
                comando.CommandText = "ListarVendedores";
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
