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
    public class CD_Cuentas
    {
        private Conexion conexionBD = new Conexion();
        private MySqlCommand comando = new MySqlCommand();
        private MySqlDataReader LeerFilas;

        public void AgregarCuenta(Cuentas datos)
        {
            try
            {
                comando.Connection = conexionBD.abrirconexion();
                comando.CommandText = "AgregarCuenta";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("banc", datos.Banco);
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
        public void EditarCuenta(Cuentas datos)
        {
            try
            {
                comando.Connection = conexionBD.abrirconexion();
                comando.CommandText = "EditarCuenta";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("mont", datos.Monto);
                comando.Parameters.AddWithValue("Idcuent", datos.Idcuenta);
                comando.ExecuteNonQuery();
                //messagebox.Show("Se Edito el Monto");
            }
            catch (MySqlException e)
            {
                //messagebox.Show(e.ToString());
            }
            comando.Parameters.Clear();
            conexionBD.cerrarConexion();
        }
        public void EliminarCuenta(Cuentas datos)
        {
            try
            {
                comando.Connection = conexionBD.abrirconexion();
                comando.CommandText = "EliminarCuenta";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("Idcuent", datos.Idcuenta);
                comando.ExecuteNonQuery();
                //messagebox.Show("Se Elimino la cuenta");
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
