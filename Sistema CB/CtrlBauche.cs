using iText.IO.Font.Constants;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_CB
{
    class CtrlBauche 
    {
        private Conexion conexionBD = new Conexion();
        private MySqlCommand comando = new MySqlCommand();
        private MySqlDataReader LeerFilas;
        private string datos ;
        private string mensaje = "";
        private double montoO;

        public string CompletarTxtDireccion(int dato)
        {
            try
            {
                comando.Connection = conexionBD.abrirconexion();
                comando.CommandText = "llenarTxtDireccion";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("IdCliente", dato);
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
            }catch(MySqlException e)
            {
                MessageBox.Show(e.ToString());
            }
            
            return mensaje;
        }
        public string LLenartxtPrecio(int dato)
        {
            try
            {
                comando.Connection = conexionBD.abrirconexion();
                comando.CommandText = "LLenartxtPrecio";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("IdProduct", dato);
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
                MessageBox.Show(e.ToString());
            }

            return mensaje;
        }

        public string LlenarTxtCodBillete(int dato)
        {
            try
            {
                comando.Connection = conexionBD.abrirconexion();
                comando.CommandText = "LlenarTxtCodBillete";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("grup", dato);
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
                MessageBox.Show(e.ToString());
            }
           return mensaje;
        }

        public string MostrarPreciodolar()
        {
            try
            {
                comando.Connection = conexionBD.abrirconexion();
                comando.CommandText = "MostrarPreciodolar";
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
                MessageBox.Show(e.ToString());
            }
            return mensaje;
        }

        public string SumarCuentasXCobrar()
        {
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
                MessageBox.Show(e.ToString());
            }
            return mensaje;
        }

        public double ControlMontoV(Bauche dato)
        {
            try
            {
                comando.Connection = conexionBD.abrirconexion();
                comando.CommandText = "ControlMontoV";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("idvendedo", dato.Idvendedor);
                LeerFilas = comando.ExecuteReader();
                if (LeerFilas.Read())
                {
                    montoO = Convert.ToDouble(LeerFilas[0]);
                }
            }catch(MySqlException e)
            {
                MessageBox.Show(e.ToString());
            }
            LeerFilas.Close();
            comando.Parameters.Clear();
            conexionBD.cerrarConexion();
            return montoO;
        }

        public void VerificarBaucheDeuda(int dato)
        {
            try
            {
                comando.Connection = conexionBD.abrirconexion();
                comando.CommandText = "VerificarBaucheDeuda";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("Idclient", dato);
                LeerFilas = comando.ExecuteReader();
                if (LeerFilas.Read() == true)
                {
                    datos = LeerFilas[0].ToString();
                    mensaje = string.Format(datos);
                    MessageBox.Show("Bauche con estado debe codigo "+ mensaje);
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
                MessageBox.Show(e.ToString());
            }
            
        }

        public void VerificarBaucheVentaD(Bauche dato)
        {
            try
            {
                comando.Connection = conexionBD.abrirconexion();
                comando.CommandText = "VerificarBaucheVentaD";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("idbauche", dato.IdBauche);
                LeerFilas = comando.ExecuteReader();
                if (LeerFilas.Read() == true)
                {
                    mensaje = LeerFilas[0].ToString();
                    MessageBox.Show("Bauche Utilizado Por Vendedor" + mensaje);
                }

            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.ToString());
            }
            LeerFilas.Close();
            comando.Parameters.Clear();
            conexionBD.cerrarConexion();

        }

        public void VerificarClienteCredito(int dato)
        {
            try
            {
                comando.Connection = conexionBD.abrirconexion();
                comando.CommandText = "VerificarClienteCredito";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("CLiente", dato);
                LeerFilas = comando.ExecuteReader();
                if (LeerFilas.Read() == true)
                {
                    datos = LeerFilas[0].ToString();
                    mensaje = string.Format(datos);
                    MessageBox.Show("Cliente con Deuda en Credito");
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
                MessageBox.Show(e.ToString());
            }

        }
        public string SumarRecibidoDia(string dato)
        {
            try
            {
                comando.Connection = conexionBD.abrirconexion();
                comando.CommandText = "SumarRecibidoDia";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("fech", dato);
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
                MessageBox.Show(e.ToString());
            }
            return mensaje;
        }

        public string SumarVendidoD(string dato)
        {
            try
            {
                comando.Connection = conexionBD.abrirconexion();
                comando.CommandText = "SumarVendidoD";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("fech", dato);
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
                MessageBox.Show(e.ToString());
            }
            return mensaje;
        }
        public DataTable CargarBauche()
        {
            DataTable tabla = new DataTable();
            try
            {
                
                comando.Connection = conexionBD.abrirconexion();
                comando.CommandText = "CargarBauche";
                comando.CommandType = CommandType.StoredProcedure;
                LeerFilas = comando.ExecuteReader();
                tabla.Load(LeerFilas);
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                LeerFilas.Close();
                conexionBD.cerrarConexion();
            }           
            return tabla;
        }

        public DataTable BuscarBauEstado(Bauche datos)
        {
            DataTable tabla = new DataTable();
            try
            {

                comando.Connection = conexionBD.abrirconexion();
                comando.CommandText = "BuscarBauEstado";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("Estad", datos.Estado);
                LeerFilas = comando.ExecuteReader();
                tabla.Load(LeerFilas);
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                LeerFilas.Close();
                comando.Parameters.Clear();
                conexionBD.cerrarConexion();
            }
            return tabla;
        }
        public void AgregarVendedor(Bauche datos)
        {
            try
            {
                comando.Connection = conexionBD.abrirconexion();
                comando.CommandText = "AgregarVendedor";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("vendedo", datos.Vendedor);
                comando.Parameters.AddWithValue("mont", datos.Montovendedor);
                comando.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.ToString());
            }

            comando.Parameters.Clear();
            conexionBD.cerrarConexion();
        }
        public void EliminarCausa(Bauche datos)
        {
            try
            {
                comando.Connection = conexionBD.abrirconexion();
                comando.CommandText = "EliminarCausa";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("Idclient", datos.IdCliente);
                comando.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.ToString());
            }

            comando.Parameters.Clear();
            conexionBD.cerrarConexion();
        }

        public void QuitarGrupoCausa(Bauche datos)
        {
            try
            {
                comando.Connection = conexionBD.abrirconexion();
                comando.CommandText = "QuitarGrupoCausa";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("Idclient", datos.IdCliente);
                comando.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.ToString());
            }

            comando.Parameters.Clear();
            conexionBD.cerrarConexion();
        }
        public void CambiarPrecioDolar(Bauche datos)
        {
            try
            {
                comando.Connection = conexionBD.abrirconexion();
                comando.CommandText = "CambiarPrecioDolar";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("preci", datos.Preciodolar);
                comando.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.ToString());
            }

            comando.Parameters.Clear();
            conexionBD.cerrarConexion();
        }

        public DataTable CargarCausa()
        {
            DataTable tabla = new DataTable();
            try
            {
                comando.Connection = conexionBD.abrirconexion();
                comando.CommandText = "CargarCausa";
                comando.CommandType = CommandType.StoredProcedure;
                LeerFilas = comando.ExecuteReader();
                tabla.Load(LeerFilas);
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                LeerFilas.Close();
                conexionBD.cerrarConexion();
            }
            return tabla;
        }

        public DataTable BuscarBauCodigo(Bauche datos)
        {
            DataTable tabla = new DataTable();
            try
            {
                comando.Connection = conexionBD.abrirconexion();
                comando.CommandText = "BuscarBauCodigo";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("Codig", datos.Codigo);
                LeerFilas = comando.ExecuteReader();
                tabla.Load(LeerFilas);
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                LeerFilas.Close();
                conexionBD.cerrarConexion();
                comando.Parameters.Clear();
            }
            return tabla;   
        }

        public DataTable BuscarBauCliente(Bauche datos)
        {
            DataTable tabla = new DataTable();
            try
            {
                comando.Connection = conexionBD.abrirconexion();
                comando.CommandText = "BuscarBauCliente";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("Cliente", datos.Cliente);
                LeerFilas = comando.ExecuteReader();
                tabla.Load(LeerFilas);
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                LeerFilas.Close();
                conexionBD.cerrarConexion();
                comando.Parameters.Clear();
            }
            return tabla;
        }

        public DataTable BuscarBauMonto(Bauche datos)
        {
            DataTable tabla = new DataTable();
            try
            {
                comando.Connection = conexionBD.abrirconexion();
                comando.CommandText = "BuscarBauMonto";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("Monto", datos.Monto);
                LeerFilas = comando.ExecuteReader();
                tabla.Load(LeerFilas);
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                LeerFilas.Close();
                conexionBD.cerrarConexion();
                comando.Parameters.Clear();
            }
            return tabla;
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
                MessageBox.Show(e.ToString());
            }
            finally
            {
                LeerFilas.Close();
                conexionBD.cerrarConexion();
            }
            return tabla;
        }

        public DataTable ListarGrupoC()
        {
            DataTable tabla = new DataTable();
            try
            {
                comando.Connection = conexionBD.abrirconexion();
                comando.CommandText = "ListarGrupoC";
                comando.CommandType = CommandType.StoredProcedure;
                LeerFilas = comando.ExecuteReader();
                tabla.Load(LeerFilas);
            }catch(MySqlException e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                LeerFilas.Close();
                conexionBD.cerrarConexion();
            }
            return tabla;
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
                MessageBox.Show(e.ToString());
            }                     
                LeerFilas.Close();
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
                MessageBox.Show(e.ToString());
            }
            LeerFilas.Close();
            conexionBD.cerrarConexion();
            return tabla;
        }

        public DataTable BuscarCausa(Bauche datos)
        {
            DataTable tabla = new DataTable();
            try
            {
                comando.Connection = conexionBD.abrirconexion();
                comando.CommandText = "BuscarCausa";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("Idclient", datos.IdCliente);
                LeerFilas = comando.ExecuteReader();
                tabla.Load(LeerFilas);
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.ToString());
            }
            LeerFilas.Close();
            conexionBD.cerrarConexion();
            return tabla;
        }

        public DataTable CargarDetalleVendedor(Bauche datos)
        {
            DataTable tabla = new DataTable();
            try
            {
                comando.Connection = conexionBD.abrirconexion();
                comando.CommandText = "CargarDetalleVendedor";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("idvendedo", datos.Idvendedor);
                LeerFilas = comando.ExecuteReader();
                tabla.Load(LeerFilas);
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.ToString());
            }
            LeerFilas.Close();
            comando.Parameters.Clear();
            conexionBD.cerrarConexion();
            return tabla;
        }
        public DataTable CargarGananciaVentas(Bauche datos)
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
                MessageBox.Show(e.ToString());
            }
            LeerFilas.Close();
            comando.Parameters.Clear();
            conexionBD.cerrarConexion();
            return tabla;
        }

        public DataTable DetalleCompraCliente(Bauche datos)
        {
            DataTable tabla = new DataTable();
            try
            {
                comando.Connection = conexionBD.abrirconexion();
                comando.CommandText = "DetalleCompraCliente";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("idcliente", datos.IdCliente);
                LeerFilas = comando.ExecuteReader();
                tabla.Load(LeerFilas);
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.ToString());
            }
            LeerFilas.Close();
            comando.Parameters.Clear();
            conexionBD.cerrarConexion();
            return tabla;
        }
        public void AgregarBauche(Bauche datos)
        {
            try
            {
                comando.Connection = conexionBD.abrirconexion();
                comando.CommandText = "AgregarBauche";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("Codig", datos.Codigo);
                comando.Parameters.AddWithValue("Fech", datos.Fecha);
                comando.Parameters.AddWithValue("Mont", datos.Monto);
                comando.Parameters.AddWithValue("Banc", datos.Idcuenta);
                comando.Parameters.AddWithValue("Idclient", datos.IdCliente);
                comando.Parameters.AddWithValue("Estad", datos.Estado);
                comando.Parameters.AddWithValue("Observacione", datos.Observaciones);
                comando.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                switch (e.Number)
                {
                    case 1452:
                        MessageBox.Show("Cliente no esta Registrado");
                        break;
                    default:
                        MessageBox.Show(e.Number.ToString());
                        break;
                }

            }

            comando.Parameters.Clear();
            conexionBD.cerrarConexion();
        }

        public void AgregarVenta(Bauche datos)
        {
            try
            {
                comando.Connection = conexionBD.abrirconexion();
                comando.CommandText = "AgregarVenta";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("idvendedo", datos.Idvendedor);
                comando.Parameters.AddWithValue("fech", datos.Fecha);
                comando.Parameters.AddWithValue("mont", datos.Monto);
                comando.Parameters.AddWithValue("bauch", datos.IdBauche);
                comando.Parameters.AddWithValue("o", datos.Estado);
                comando.Parameters.AddWithValue("tota", datos.Total);
                comando.ExecuteNonQuery();
                
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.ToString());
            }

            comando.Parameters.Clear();
            conexionBD.cerrarConexion();
        }
        public void EditarMontoVendedor(Bauche datos)
        {
            try
            {
                comando.Connection = conexionBD.abrirconexion();
                comando.CommandText = "EditarMontoVendedor";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("mont", datos.Montovendedor);
                comando.Parameters.AddWithValue("Idvendedo", datos.Idvendedor);               
                comando.ExecuteNonQuery();
                MessageBox.Show("Se Edito Correctamente");
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.ToString());
            }

            comando.Parameters.Clear();
            conexionBD.cerrarConexion();
        }

        public void AumentarMontoVendedor(Bauche datos)
        {

            try
            {
                comando.Connection = conexionBD.abrirconexion();
                comando.CommandText = "AumentarMontoVendedor";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("mont", datos.Monto);
                comando.Parameters.AddWithValue("Idvendedo", datos.Idvendedor);
                comando.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.ToString());
            }
            
            comando.Parameters.Clear();
            conexionBD.cerrarConexion();
            
        }
        public void DisminuirMontoVendedor(Bauche datos)
        {
            try
            {
                comando.Connection = conexionBD.abrirconexion();
                comando.CommandText = "DisminuirMontoVendedor";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("mont", datos.Monto);
                comando.Parameters.AddWithValue("Idvendedo", datos.Idvendedor);
                comando.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.ToString());
            }

            comando.Parameters.Clear();
            conexionBD.cerrarConexion();
        }

        public void AgregarCompra(Bauche datos)
        {
            try
            {
                comando.Connection = conexionBD.abrirconexion();
                comando.CommandText = "AgregarCompra";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("mont", datos.Monto);
                comando.Parameters.AddWithValue("refe", datos.Banco);
                comando.Parameters.AddWithValue("Idclient", datos.IdCliente);
                comando.Parameters.AddWithValue("fech", datos.Fecha);
                comando.Parameters.AddWithValue("op", datos.Estado);
                comando.ExecuteNonQuery();
                MessageBox.Show("Se Registro la compra");
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.ToString());
            }

            comando.Parameters.Clear();
            conexionBD.cerrarConexion();
        }

        public void AumentarMontoBanco(Bauche datos)
        {
            try
            {
                comando.Connection = conexionBD.abrirconexion();
                comando.CommandText = "AumentarMontoBanco";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("mont", datos.Monto);
                comando.Parameters.AddWithValue("Idcuent", datos.Idcuenta);
                comando.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.ToString());
            }

            comando.Parameters.Clear();
            conexionBD.cerrarConexion();
        }

        public void DisminuirMontoBanco(Bauche datos)
        {
            try
            {
                comando.Connection = conexionBD.abrirconexion();
                comando.CommandText = "DisminuirMontoBanco";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("mont", datos.Monto);
                comando.Parameters.AddWithValue("Idcuent", datos.Idcuenta);
                comando.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.ToString());
            }

            comando.Parameters.Clear();
            conexionBD.cerrarConexion();
        }
        public void AgregarProducto(Bauche datos)
        {
            try
            {
                comando.Connection = conexionBD.abrirconexion();
                comando.CommandText = "AgregarProducto";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("Product", datos.Producto1);
                comando.Parameters.AddWithValue("Preci", datos.PrecioProducto1);
                comando.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.ToString());
            }

            comando.Parameters.Clear();
            conexionBD.cerrarConexion();
        }

        public void AgregarCausa(Bauche datos)
        {
            try
            {
                comando.Connection = conexionBD.abrirconexion();
                comando.CommandText = "AgregarCausa";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("IdClient", datos.IdCliente);
                comando.Parameters.AddWithValue("observacio", datos.Observaciones);
                comando.Parameters.AddWithValue("grup", datos.Grupo);
                comando.ExecuteNonQuery();
            }catch (MySqlException e)
            {
                switch (e.Number)
                {
                    case 1062:
                        MessageBox.Show("Ya esta Registrado en la Causa");
                        break;
                    default:
                        MessageBox.Show(e.Number.ToString());
                        break;
                }
            }
            comando.Parameters.Clear();
            conexionBD.cerrarConexion();
        }

        public void AgregarGrupoCausa(Bauche datos)
        {
            try
            {
                comando.Connection = conexionBD.abrirconexion();
                comando.CommandText = "AgregarGrupoCausa";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("Idclient", datos.IdCliente);
                comando.Parameters.AddWithValue("codbillet", datos.Codbillete);
                comando.Parameters.AddWithValue("grup", datos.Grupo);
                comando.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.ToString());
            }
            comando.Parameters.Clear();
            conexionBD.cerrarConexion();
        }

        public void EditarProducto(Bauche datos)
        {
            try
            {
                comando.Connection = conexionBD.abrirconexion();
                comando.CommandText = "EditarProducto";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("IdProduct", datos.IdProducto);
                comando.Parameters.AddWithValue("Preci", datos.PrecioProducto1);
                comando.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.ToString());
            }
            comando.Parameters.Clear();
            conexionBD.cerrarConexion();
        }

        public void EditarBauche(Bauche datos)
        {
            try
            {
                comando.Connection = conexionBD.abrirconexion();
                comando.CommandText = "EditarBauche";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("Idbauch", datos.IdBauche);
                comando.Parameters.AddWithValue("Idclient", datos.IdCliente);
                comando.Parameters.AddWithValue("Estad", datos.Estado);
                comando.Parameters.AddWithValue("Observacione", datos.Observaciones);
                comando.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.ToString());
            }
            comando.Parameters.Clear();
            conexionBD.cerrarConexion();
        }

        public void AgregarCliente(Bauche datos)
        {
            try
            {
                comando.Connection = conexionBD.abrirconexion();
                comando.CommandText = "AgregarCliente";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("Cliente", datos.Cliente);
                comando.Parameters.AddWithValue("Direccio", datos.Direccion);
                comando.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {

                switch (e.Number)
                {
                    case 1062:
                        MessageBox.Show("Ya esta Registrado");
                        break;
                    default:
                        MessageBox.Show(e.Number.ToString());
                        break;
                }
            }

            comando.Parameters.Clear();
            conexionBD.cerrarConexion();
        }
        public void AgregarCuentaXCobrar(Bauche datos)
        {
            try
            {
                comando.Connection = conexionBD.abrirconexion();
                comando.CommandText = "AgregarCuentaXCobrar";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("Idclient", datos.IdCliente);
                comando.Parameters.AddWithValue("mont", datos.Monto);
                comando.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.ToString());
            }

            comando.Parameters.Clear();
            conexionBD.cerrarConexion();
        }

        public void DisminuirMontoCliente(Bauche datos)
        {
            try
            {
                comando.Connection = conexionBD.abrirconexion();
                comando.CommandText = "DisminuirMontoCliente";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("Idclient", datos.IdCliente);
                comando.Parameters.AddWithValue("mont", datos.Monto);
                comando.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.ToString());
            }

            comando.Parameters.Clear();
            conexionBD.cerrarConexion();
        }

        public void BorrarProFactura(Bauche datos)
        {
            try
            {
                comando.Connection = conexionBD.abrirconexion();
                comando.CommandText = "BorrarProFactura";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("Idfactur", datos.IdFactura1);
                comando.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.ToString());
            }
            comando.Parameters.Clear();
            conexionBD.cerrarConexion();
        }

        public void QuitarProCre(Bauche datos)
        {
            try
            {
                comando.Connection = conexionBD.abrirconexion();
                comando.CommandText = "QuitarProCre";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("IdCredit", datos.IdFactura1);
                comando.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.ToString());
            }
            comando.Parameters.Clear();
            conexionBD.cerrarConexion();
        }
        public void EliminarProducto(Bauche datos)
        {
            try
            {
                comando.Connection = conexionBD.abrirconexion();
                comando.CommandText = "EliminarProducto";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("Idproduct", datos.IdProducto);
                comando.ExecuteNonQuery();
                MessageBox.Show("Se Elimino el Producto");
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.ToString());
            }
            comando.Parameters.Clear();
            conexionBD.cerrarConexion();
        }

        public void EditarCuenta(Bauche datos)
        {
            try
            {
                comando.Connection = conexionBD.abrirconexion();
                comando.CommandText = "EditarCuenta";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("mont", datos.Monto);
                comando.Parameters.AddWithValue("Idcuent", datos.Idcuenta);
                comando.ExecuteNonQuery();
                MessageBox.Show("Se Edito el Monto");
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.ToString());
            }
            comando.Parameters.Clear();
            conexionBD.cerrarConexion();
        }

        public void EliminarVendedor(Bauche datos)
        {
            try
            {
                comando.Connection = conexionBD.abrirconexion();
                comando.CommandText = "EliminarVendedor";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("Idvendedo", datos.Idvendedor);
                comando.ExecuteNonQuery();
                MessageBox.Show("Se Elimino el Vendedor");
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.ToString());
            }
            comando.Parameters.Clear();
            conexionBD.cerrarConexion();
        }

        public void EliminarCuenta(Bauche datos)
        {
            try
            {
                comando.Connection = conexionBD.abrirconexion();
                comando.CommandText = "EliminarCuenta";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("Idcuent", datos.Idcuenta);
                comando.ExecuteNonQuery();
                MessageBox.Show("Se Elimino la cuenta");
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.ToString());
            }
            comando.Parameters.Clear();
            conexionBD.cerrarConexion();
        }

        public void LimpiarCausa()
        {
            try
            {
                comando.Connection = conexionBD.abrirconexion();
                comando.CommandText = "LimpiarCausa";
                comando.CommandType = CommandType.StoredProcedure;
                comando.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.ToString());
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
                MessageBox.Show(e.ToString());
            }
            LeerFilas.Close();
            conexionBD.cerrarConexion();
            return tabla;
        }

        

        public void CrearPdf()
        {
            PdfWriter pdfwriter = new PdfWriter(@"C:\Users\Cb\Documents\Reporte.pdf");
            PdfDocument pdf = new PdfDocument(pdfwriter);
            Document documento = new Document(pdf, PageSize.LETTER);

            documento.SetMargins(60, 20, 55, 20);

            PdfFont fontcolumnas = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
            PdfFont fontcontenido = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);

            string[] columnas = { "cliente", "direccion", "Grupo", "Cod_Billete", "Observacion" };

            float[] tamanios = { 4, 4, 2, 2, 4 };
            Table tabla = new Table(UnitValue.CreatePercentArray(tamanios));
            tabla.SetWidth(UnitValue.CreatePercentValue(100));

            foreach (string columna in columnas)
            {
                tabla.AddHeaderCell(new Cell().Add(new Paragraph(columna).SetFont(fontcolumnas)));
            }
            try
            {
                comando.Connection = conexionBD.abrirconexion();
                comando.CommandText = "ListaCausa";
                comando.CommandType = CommandType.StoredProcedure;
                LeerFilas = comando.ExecuteReader();

                while (LeerFilas.Read())
                {
                    tabla.AddCell(new Cell().Add(new Paragraph(LeerFilas["cliente"].ToString()).SetFont(fontcontenido)));
                    tabla.AddCell(new Cell().Add(new Paragraph(LeerFilas["direccion"].ToString()).SetFont(fontcontenido)));
                    tabla.AddCell(new Cell().Add(new Paragraph(LeerFilas["Grupo"].ToString()).SetFont(fontcontenido)));
                    tabla.AddCell(new Cell().Add(new Paragraph(LeerFilas["Cod_Billete"].ToString()).SetFont(fontcontenido)));
                    tabla.AddCell(new Cell().Add(new Paragraph(LeerFilas["Observacion"].ToString()).SetFont(fontcontenido)));
                }
            }catch(MySqlException e)
            {
                MessageBox.Show(e.ToString());
            }

            documento.Add(tabla);
            documento.Close();
            MessageBox.Show("Se Genero el reporte");
            LeerFilas.Close();
            conexionBD.cerrarConexion();
        }

        public void CrearPdfGrupo(Bauche dato)
        {
            int grupo = dato.Grupo;
            string codbillete = dato.Codbillete;
            string portador = dato.Cliente;
            PdfWriter pdfwriter = new PdfWriter(@"C:\Users\Wilcon\Documents\grupo'"+grupo+"'.pdf");
            PdfDocument pdf = new PdfDocument(pdfwriter);
            Document documento = new Document(pdf, PageSize.LETTER);

            documento.SetMargins(30, 20, 30, 20);

            PdfFont fontcolumnas = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
            PdfFont fontcontenido = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);

            string[] columnas = { "Cant" ,"cliente", "direccion", };

            float[] tamanios = { 2, 4, 4, };
            Table tabla = new Table(UnitValue.CreatePercentArray(tamanios));
            tabla.SetWidth(UnitValue.CreatePercentValue(100));
            

            foreach (string columna in columnas)
            {
                tabla.AddHeaderCell(new Cell().Add(new Paragraph(columna).SetFont(fontcolumnas)));
            }
            try
            {
                comando.Connection = conexionBD.abrirconexion();
                comando.CommandText = "CargarGrupoCausa";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("grup",dato.Grupo);
                LeerFilas = comando.ExecuteReader();
                int contador = 1;
                documento.Add(new Paragraph(@"Codigo de Billete: "+ codbillete+"        Portador: "+portador));
                while (LeerFilas.Read())
                {
                    
                    tabla.AddCell(new Cell().Add(new Paragraph(Convert.ToString (contador))));
                    tabla.AddCell(new Cell().Add(new Paragraph(LeerFilas["cliente"].ToString()).SetFont(fontcontenido)));
                    tabla.AddCell(new Cell().Add(new Paragraph(LeerFilas["direccion"].ToString()).SetFont(fontcontenido)));
                    //tabla.AddCell(new Cell().Add(new Paragraph(LeerFilas["Grupo"].ToString()).SetFont(fontcontenido)));
                    contador++;
                }
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.ToString());
            }

            
            documento.Add(tabla);
            documento.Close();
            MessageBox.Show("Se Genero el reporte");
            LeerFilas.Close();
            comando.Parameters.Clear();
            conexionBD.cerrarConexion();
        }

        public DataTable ListarCuentas()
        {
            DataTable tabla = new DataTable();
            try
            {
                comando.Connection = conexionBD.abrirconexion();
                comando.CommandText = "ListarCuentas";
                comando.CommandType = CommandType.StoredProcedure;
                LeerFilas = comando.ExecuteReader();
                tabla.Load(LeerFilas);
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.ToString());
            }
            LeerFilas.Close();
            conexionBD.cerrarConexion();
            return tabla;
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
                MessageBox.Show(e.ToString());
            }
            LeerFilas.Close();
            conexionBD.cerrarConexion();
            return tabla;
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
                MessageBox.Show(e.ToString());
            }
            LeerFilas.Close();
            conexionBD.cerrarConexion();
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
                MessageBox.Show(e.ToString());
            }
            LeerFilas.Close();
            conexionBD.cerrarConexion();
            return tabla;
        }

        public DataTable TodasTransferencia()
        {
            DataTable tabla = new DataTable();
            try
            {
                comando.Connection = conexionBD.abrirconexion();
                comando.CommandText = "TodasTransferencia";
                comando.CommandType = CommandType.StoredProcedure;
                LeerFilas = comando.ExecuteReader();
                tabla.Load(LeerFilas);
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.ToString());
            }

            LeerFilas.Close();
            conexionBD.cerrarConexion();
            return tabla;
        }

        public DataTable BuscarTransferencia(Bauche datos)
        {
            DataTable tabla = new DataTable();
            try
            {
                comando.Connection = conexionBD.abrirconexion();
                comando.CommandText = "BuscarTransferencia";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("bus", datos.Idtxt);
                LeerFilas = comando.ExecuteReader();
                tabla.Load(LeerFilas);
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.ToString());
            }

            LeerFilas.Close();
            conexionBD.cerrarConexion();
            comando.Parameters.Clear();
            return tabla;           
        }

        public DataTable CargarGrupoCausa(Bauche datos)
        {
            DataTable tabla = new DataTable();
            try
            {
                comando.Connection = conexionBD.abrirconexion();
                comando.CommandText = "CargarGrupoCausa";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("grup", datos.Grupo);
                LeerFilas = comando.ExecuteReader();
                tabla.Load(LeerFilas);
                
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.ToString());
            }

            LeerFilas.Close();
            conexionBD.cerrarConexion();
            comando.Parameters.Clear();
            return tabla;
        }
        public int ContarGrupoCausa(Bauche datos)
        {
            int cont = 0;
            try
            {
                comando.Connection = conexionBD.abrirconexion();
                comando.CommandText = "CargarGrupoCausa";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("grup", datos.Grupo);
                LeerFilas = comando.ExecuteReader();
                
                while (LeerFilas.Read())
                {
                    cont++;
                }
                 

            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.ToString());
            }

            LeerFilas.Close();
            conexionBD.cerrarConexion();
            comando.Parameters.Clear();
            return cont;
        }

        public DataTable CargarProCre(Bauche datos)
        {
            DataTable tabla = new DataTable();
            try
            {
                comando.Connection = conexionBD.abrirconexion();
                comando.CommandText = "CargarProCre";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("CLiente", datos.IdCliente);
                LeerFilas = comando.ExecuteReader();
                tabla.Load(LeerFilas);
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.ToString());
            }

            LeerFilas.Close();
            conexionBD.cerrarConexion();
            comando.Parameters.Clear();
            return tabla;
        }

        public void AgregarTransferencia(Bauche datos)
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
                comando.Parameters.AddWithValue("cliente", datos.IdCliente);
                comando.Parameters.AddWithValue("refe", datos.Referencia);
                comando.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.ToString());
            }

            comando.Parameters.Clear();
            conexionBD.cerrarConexion();
        }
        public void AgregarProFactura(Bauche datos)
        {
            try
            {
                comando.Connection = conexionBD.abrirconexion();
                comando.CommandText = "AgregarProFactura";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("Idbauch", datos.IdBauche);
                comando.Parameters.AddWithValue("Cantida", datos.Cantidad);
                comando.Parameters.AddWithValue("Idproduct", datos.IdProducto);
                comando.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.ToString());
            }
            comando.Parameters.Clear();
            conexionBD.cerrarConexion();
        }
            public void AgregarProCre(Bauche datos)
            {
                try
                {
                    comando.Connection = conexionBD.abrirconexion();
                    comando.CommandText = "AgregarProCre";
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("CLiente", datos.IdCliente);
                    comando.Parameters.AddWithValue("fech", datos.Fecha);
                    comando.Parameters.AddWithValue("cantida", datos.Cantidad);
                    comando.Parameters.AddWithValue("product", datos.IdProducto);
                    comando.ExecuteNonQuery();
                }
                catch (MySqlException e)
                {
                    MessageBox.Show(e.ToString());
                }
                comando.Parameters.Clear();
                conexionBD.cerrarConexion();
            }

        public DataTable CargarDeudores()
        {
            DataTable tabla = new DataTable();
            try
            {
                comando.Connection = conexionBD.abrirconexion();
                comando.CommandText = "CargarDeudores";
                comando.CommandType = CommandType.StoredProcedure;
                LeerFilas = comando.ExecuteReader();
                tabla.Load(LeerFilas);
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.ToString());
            }

            LeerFilas.Close();
            conexionBD.cerrarConexion();
            return tabla;


        }

        public void AgregarCuenta(Bauche datos)
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
                MessageBox.Show(e.ToString());
            }
            comando.Parameters.Clear();
            conexionBD.cerrarConexion();
        }
        public void EditarTransferencia(Bauche datos)
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
                comando.Parameters.AddWithValue("cliente", datos.IdCliente);
                comando.Parameters.AddWithValue("refe", datos.Referencia);
                comando.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.ToString());
            }

            comando.Parameters.Clear();
            conexionBD.cerrarConexion();
        }

        public DataTable CargarProductos(Bauche datos)
        {           
            DataTable tabla = new DataTable();
            try
            {
                comando.Connection = conexionBD.abrirconexion();
                comando.CommandText = "CargarProductos";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("IdBauch", datos.IdBauche);
                LeerFilas = comando.ExecuteReader();
                tabla.Load(LeerFilas);
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.ToString());
            }

            LeerFilas.Close();
            conexionBD.cerrarConexion();
            comando.Parameters.Clear();
            return tabla;
   
        }


    }
}
