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
    public class CD_Cliente
    {
        private Conexion conexionBD = new Conexion();
        private MySqlCommand comando = new MySqlCommand();
        private MySqlDataReader LeerFilas;
        private string datos;
        private string mensaje = "";
        private double montoO;
        public void AgregarCliente(Cliente datos)
        {
            try
            {
                comando.Connection = conexionBD.abrirconexion();
                comando.CommandText = "AgregarCliente";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("Cliente", datos.NombreCliente);
                comando.Parameters.AddWithValue("Direccio", datos.Direccion);
                comando.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {

                switch (e.Number)
                {
                    case 1062:
                        //messagebox.Show("Ya esta Registrado");
                        break;
                    default:
                        //messagebox.Show(e.Number.ToString());
                        break;
                }
            }

            comando.Parameters.Clear();
            conexionBD.cerrarConexion();
        }

        public DataTable ListarCliente()
        {
            DataTable tabla = new DataTable();
            try
            {
                comando.Connection = conexionBD.abrirconexion();
                comando.CommandText = "ListarClientes";
                comando.CommandType = CommandType.StoredProcedure;
                LeerFilas = comando.ExecuteReader();
                tabla.Load(LeerFilas);
            }
            catch (MySqlException e)
            {
                //messagebox.Show(e.ToString());
            }
            finally
            {
                LeerFilas.Close();
                conexionBD.cerrarConexion();
            }
            return tabla;
        }

    }
}
