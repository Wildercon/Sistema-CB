using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;

namespace CapaDatos
{
    public class CD_PendCobrarBs
    {
        private Conexion conexionBD = new Conexion();
        private MySqlCommand comando = new MySqlCommand();
        private MySqlDataReader LeerFilas;

        public string agregarDeuda(PendCobrarBs Deuda)
        {
            string error = string.Empty;
            try
            {
                comando.Connection = conexionBD.abrirconexion();
                comando.CommandText = "INSERT INTO pendcobrarbs(IdCliente,MontoDeuda,Total,Detalle,Op) VALUES(@idcliente,@montodeuda, @total, @detalle, @op) ";
                comando.CommandType = CommandType.Text;
                comando.Parameters.AddWithValue("@idcliente", Deuda.oCliente.Id);
                comando.Parameters.AddWithValue("@montodeuda", Deuda.MontoDeuda);
                comando.Parameters.AddWithValue("@total", Deuda.Total);
                comando.Parameters.AddWithValue("@detalle", Deuda.Detalle);
                comando.Parameters.AddWithValue("@op", Deuda.Op);
                comando.ExecuteNonQuery();
            }
            catch(MySqlException e)
            {
                error = e.Number.ToString();
            }
            conexionBD.cerrarConexion();
            comando.Parameters.Clear();
            return error;
        }

        public List<PendCobrarBs> ConsultarDeuda()
        {
            List<PendCobrarBs> lista = new List<PendCobrarBs>();
            try
            {  
                comando.Connection = conexionBD.abrirconexion();
                comando.CommandText = "select * from pendcobrarbs order by Id desc";
                comando.CommandType = CommandType.Text;
                LeerFilas = comando.ExecuteReader();
                
                while (LeerFilas.Read())
                {
                    lista.Add(new PendCobrarBs
                    {
                        oCliente = new Cliente(){Id = Convert.ToInt32(LeerFilas[1])},
                        Fecha = LeerFilas[5].ToString(),
                        MontoDeuda = Convert.ToDouble(LeerFilas[2]),
                        Total = Convert.ToDouble(LeerFilas[3]),
                        Op = LeerFilas[6].ToString(),
                        Detalle = LeerFilas[4].ToString(),
                    }) ;
                }    

            }
            catch 
            {
                
            }
            LeerFilas.Close();
            conexionBD.cerrarConexion();
            return lista;
        }

    }
}
