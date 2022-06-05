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
    public class CD_Pendientexcobrar
    {
        private Conexion conexionBD = new Conexion();
        private MySqlCommand comando = new MySqlCommand();
        private MySqlDataReader LeerFilas;
        public void AgregarCuentaXCobrar(Compra datos)
        {
            try
            {
                comando.Connection = conexionBD.abrirconexion();
                comando.CommandText = "AgregarCuentaXCobrar";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("Idclient", datos.Cliente.Id);
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
        public DataTable CargarCuentasXCobrar()
        {
            DataTable tabla = new DataTable();
            try
            {
                comando.Connection = conexionBD.abrirconexion();
                comando.CommandText = "CargarCuentasXCobrar";
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
        public void DisminuirMontoCliente(Compra datos)
        {
            try
            {
                comando.Connection = conexionBD.abrirconexion();
                comando.CommandText = "DisminuirMontoCliente";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("Idclient", datos.Cliente.Id);
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
        public string SumarCuentasXCobrar()
        {
            string datos = "";
            string mensaje = "";
            try
            {
                comando.Connection = conexionBD.abrirconexion();
                comando.CommandText = "SumarCuentasXCobrar";
                comando.CommandType = CommandType.StoredProcedure;
                LeerFilas = comando.ExecuteReader();
                if (LeerFilas.Read() == true)
                {
                    datos = LeerFilas[0].ToString();
                    mensaje = string.Format(datos);
                    LeerFilas.Close();
                    comando.Parameters.Clear();
                    conexionBD.cerrarConexion();
                }
                else
                {
                    LeerFilas.Close();
                    comando.Parameters.Clear();
                    conexionBD.cerrarConexion();
                }

            }
            catch (MySqlException e)
            {
                //messagebox.Show(e.ToString());
            }
            return mensaje;
        }
    }
}
