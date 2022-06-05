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
    public class CD_Transferencia
    {
        private Conexion conexionBD = new Conexion();
        private MySqlCommand comando = new MySqlCommand();
        private MySqlDataReader LeerFilas;
        public void AgregarTransferencia(Transferencia datos)
        {
            try
            {
                comando.Connection = conexionBD.abrirconexion();
                comando.CommandText = "AgregarTransferencia";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("fech", datos.Fecha);
                comando.Parameters.AddWithValue("beneficiari", datos.Beneficiario);
                comando.Parameters.AddWithValue("cuent", datos.Cuenta);
                comando.Parameters.AddWithValue("cedul", datos.Cedula);
                comando.Parameters.AddWithValue("banc", datos.Banco);
                comando.Parameters.AddWithValue("mont", datos.Monto);
                comando.Parameters.AddWithValue("cliente", datos.Cliente.Id);
                comando.Parameters.AddWithValue("refe", datos.Referencia);
                comando.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                //messagebox.Show(e.ToString());
            }

            comando.Parameters.Clear();
            conexionBD.cerrarConexion();
        }
        public DataTable BuscarTransferencia(Transferencia datos)
        {
            DataTable tabla = new DataTable();
            try
            {
                comando.Connection = conexionBD.abrirconexion();
                comando.CommandText = "BuscarTransferencia";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("bus", datos.Beneficiario);
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
        public DataTable CargarTransferencia()
        {
            DataTable tabla = new DataTable();
            try
            {
                comando.Connection = conexionBD.abrirconexion();
                comando.CommandText = "CargarTransferencia";
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
        public void EditarTransferencia(Transferencia datos)
        {
            try
            {
                comando.Connection = conexionBD.abrirconexion();
                comando.CommandText = "EditarTransferencia";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("beneficiari", datos.Beneficiario);
                comando.Parameters.AddWithValue("cuent", datos.Cuenta);
                comando.Parameters.AddWithValue("cedul", datos.Cedula);
                comando.Parameters.AddWithValue("banc", datos.Banco);
                comando.Parameters.AddWithValue("mont", datos.Monto);
                comando.Parameters.AddWithValue("id", datos.Idtransferencia);
                comando.Parameters.AddWithValue("cliente", datos.Cliente.Id);
                comando.Parameters.AddWithValue("refe", datos.Referencia);
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
