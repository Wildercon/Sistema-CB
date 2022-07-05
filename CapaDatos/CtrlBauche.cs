using CapaDatos;
using CapaEntidad;
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


namespace CapaDatos
{
    public class CtrlBauche 
    {
        private Conexion conexionBD = new Conexion();
        private MySqlCommand comando = new MySqlCommand();
        private MySqlDataReader LeerFilas;


        public string CompletarTxtDireccion(int dato)
        {
            string mensaje = string.Empty;
            try
            {
                comando.Connection = conexionBD.abrirconexion();
                comando.CommandText = "llenarTxtDireccion";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("IdCliente", dato);
                LeerFilas = comando.ExecuteReader();
                if (LeerFilas.Read() == true)
                {
                    mensaje = LeerFilas[0].ToString();
                    
                }
            }catch(MySqlException e)
            {
                //messagebox.Show(e.ToString());
            }
            LeerFilas.Close();
            comando.Parameters.Clear();
            conexionBD.cerrarConexion();
            return mensaje;
        }
        

        

        public string MostrarPreciodolar()
        {
            string mensaje = string.Empty;
            try
            {
                comando.Connection = conexionBD.abrirconexion();
                comando.CommandText = "MostrarPreciodolar";
                comando.CommandType = CommandType.StoredProcedure;                
                LeerFilas = comando.ExecuteReader();
                if (LeerFilas.Read() == true)
                {
                    mensaje = LeerFilas[0].ToString();                   
                }
            }
            catch (MySqlException e)
            {
                //messagebox.Show(e.ToString());
            }
            LeerFilas.Close();
            comando.Parameters.Clear();
            conexionBD.cerrarConexion();
            return mensaje;
        }

        

        

        public string VerificarBaucheDeuda(int dato)
        {
            string mensaje = string.Empty;
            string Bauche = string.Empty;
            try
            {
                comando.Connection = conexionBD.abrirconexion();
                comando.CommandText = "VerificarBaucheDeuda";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("Idclient", dato);
                LeerFilas = comando.ExecuteReader();
                if (LeerFilas.Read() == true)
                {
                    Bauche = LeerFilas[0].ToString();
                    mensaje = "Bauche con estado debe codigo " + Bauche;

                }

            }
            catch (MySqlException e)
            {
                mensaje = e.ToString();
            }
            LeerFilas.Close();
            comando.Parameters.Clear();
            conexionBD.cerrarConexion();
            return mensaje;    
        }

        public string VerificarBaucheVentaD(Bauche dato)
        {
            string Mensaje = String.Empty;
            string Nvendedor = string.Empty;
            try
            {
                comando.Connection = conexionBD.abrirconexion();
                comando.CommandText = "VerificarBaucheVentaD";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("idbauche", dato.Idbauche);
                LeerFilas = comando.ExecuteReader();
                if (LeerFilas.Read() == true)
                {
                    Nvendedor = LeerFilas[0].ToString();
                    Mensaje ="Bauche Utilizado Por Vendedor" + Nvendedor;
                }

            }
            catch (MySqlException e)
            {
                Mensaje = e.Number.ToString();
            }
            LeerFilas.Close();
            comando.Parameters.Clear();
            conexionBD.cerrarConexion();
            return Mensaje;
        }

        public bool VerificarClienteCredito(int dato)
        {
            bool Verificador = false;
            try
            {
                comando.Connection = conexionBD.abrirconexion();
                comando.CommandText = "VerificarClienteCredito";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("CLiente", dato);
                LeerFilas = comando.ExecuteReader();
                if (LeerFilas.Read() == true)
                {
                    Verificador = true;
                }                
            }
            catch (MySqlException e)
            {
                e.ToString();
            }
            LeerFilas.Close();
            comando.Parameters.Clear();
            conexionBD.cerrarConexion();
            return Verificador; 
        }
        public string SumarRecibidoDia(string dato)
        {
            string mensaje = string.Empty;
            try
            {
                comando.Connection = conexionBD.abrirconexion();
                comando.CommandText = "SumarRecibidoDia";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("fech", dato);
                LeerFilas = comando.ExecuteReader();
                if (LeerFilas.Read() == true)
                {
                    mensaje = LeerFilas[0].ToString();  
                }
            }
            catch (MySqlException e)
            {
                mensaje = e.Number.ToString();
            }
            LeerFilas.Close();
            comando.Parameters.Clear();
            conexionBD.cerrarConexion();
            return mensaje;
        }

        public string SumarVendidoD(string dato)
        {
            string mensaje = string.Empty;
            try
            {
                comando.Connection = conexionBD.abrirconexion();
                comando.CommandText = "SumarVendidoD";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("fech", dato);
                LeerFilas = comando.ExecuteReader();
                if (LeerFilas.Read() == true)
                {
                    mensaje = LeerFilas[0].ToString();

                }
            }
            catch (MySqlException e)
            {
                mensaje = e.ToString();
            }
            LeerFilas.Close();
            comando.Parameters.Clear();
            conexionBD.cerrarConexion();
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
                //messagebox.Show(e.ToString());
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
                //messagebox.Show(e.ToString());
            }
            finally
            {
                LeerFilas.Close();
                comando.Parameters.Clear();
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
                //messagebox.Show(e.ToString());
            }
            finally
            {
                LeerFilas.Close();
                conexionBD.cerrarConexion();
                comando.Parameters.Clear();
            }
            return tabla;   
        }

        public DataTable BuscarBauCliente(string NombreCliente)
        {
            DataTable tabla = new DataTable();
            try
            {
                comando.Connection = conexionBD.abrirconexion();
                comando.CommandText = "BuscarBauCliente";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("Cliente", NombreCliente);
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
                //messagebox.Show(e.ToString());
            }
            finally
            {
                LeerFilas.Close();
                conexionBD.cerrarConexion();
                comando.Parameters.Clear();
            }
            return tabla;
        }
        

        

        
        public string AgregarBauche(Bauche datos)
        {
            string mensaje = string.Empty;
            try
            {
                comando.Connection = conexionBD.abrirconexion();
                comando.CommandText = "AgregarBauche";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("Codig", datos.Codigo);
                comando.Parameters.AddWithValue("Fech", datos.Fecha);
                comando.Parameters.AddWithValue("Mont", datos.Monto);
                comando.Parameters.AddWithValue("Banc", datos.Banco);
                comando.Parameters.AddWithValue("Idclient", datos.cliente.Id);
                comando.Parameters.AddWithValue("Estad", datos.Estado);
                comando.Parameters.AddWithValue("Observacione", datos.Observacion);
                comando.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                switch (e.Number)
                {
                    case 1452:
                        mensaje = "Cliente no esta Registrado";
                        break;
                    default:
                        mensaje = e.Number.ToString();
                        break;
                }

            }

            comando.Parameters.Clear();
            conexionBD.cerrarConexion();
            return mensaje;
        }
        
        

        

        /*public void AumentarMontoBanco(Bauche datos)
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
                //messagebox.Show(e.ToString());
            }

            comando.Parameters.Clear();
            conexionBD.cerrarConexion();
        }*/

       /* public void DisminuirMontoBanco(Bauche datos)
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
                //messagebox.Show(e.ToString());
            }

            comando.Parameters.Clear();
            conexionBD.cerrarConexion();
        }*/

        

        public void EditarBauche(Bauche datos)
        {
            try
            {
                comando.Connection = conexionBD.abrirconexion();
                comando.CommandText = "EditarBauche";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("Idbauch", datos.Idbauche);
                comando.Parameters.AddWithValue("Idclient", datos.cliente.Id);
                comando.Parameters.AddWithValue("Estad", datos.Estado);
                comando.Parameters.AddWithValue("Observacione", datos.Observacion);
                comando.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                //messagebox.Show(e.ToString());
            }
            comando.Parameters.Clear();
            conexionBD.cerrarConexion();
        }        

        public string CrearPdf()
        {
            string mensaje = string.Empty;
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
                mensaje = "Se Genero el reporte";
            }
            catch(MySqlException e)
            {
                mensaje = e.Number.ToString();
            }

            documento.Add(tabla);
            documento.Close();
            LeerFilas.Close();
            conexionBD.cerrarConexion();
            return mensaje;
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
                //messagebox.Show(e.ToString());
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
                //messagebox.Show(e.ToString());
            }

            LeerFilas.Close();
            conexionBD.cerrarConexion();
            return tabla;
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
                //messagebox.Show(e.ToString());
            }

            LeerFilas.Close();
            conexionBD.cerrarConexion();
            return tabla;


        }
    }
}
