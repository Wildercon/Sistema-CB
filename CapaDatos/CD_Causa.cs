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
    public class CD_Causa
    {
        private Conexion conexionBD = new Conexion();
        private MySqlCommand comando = new MySqlCommand();
        private MySqlDataReader LeerFilas;
        private string datos;
        private string mensaje = "";
        private double montoO;
        public void AgregarCausa(Causa datos)
        {
            try
            {
                comando.Connection = conexionBD.abrirconexion();
                comando.CommandText = "AgregarCausa";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("IdClient", datos.Idcliente);
                comando.Parameters.AddWithValue("observacio", datos.Observacion);
                comando.Parameters.AddWithValue("grup", datos.Grupo);
                comando.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                switch (e.Number)
                {
                    case 1062:
                        //messagebox.Show("Ya esta Registrado en la Causa");
                        break;
                    default:
                        //messagebox.Show(e.Number.ToString());
                        break;
                }
            }
            comando.Parameters.Clear();
            conexionBD.cerrarConexion();
        }
        public void AgregarGrupoCausa(Causa datos)
        {
            try
            {
                comando.Connection = conexionBD.abrirconexion();
                comando.CommandText = "AgregarGrupoCausa";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("Idclient", datos.Idcliente);
                comando.Parameters.AddWithValue("codbillet", datos.Cod_Billete);
                comando.Parameters.AddWithValue("grup", datos.Grupo);
                comando.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                //messagebox.Show(e.ToString());
            }
            comando.Parameters.Clear();
            conexionBD.cerrarConexion();
        }

        public DataTable BuscarCausa(Causa datos)
        {
            DataTable tabla = new DataTable();
            try
            {
                comando.Connection = conexionBD.abrirconexion();
                comando.CommandText = "BuscarCausa";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("Idclient", datos.Idcliente);
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

        public int ContarGrupoCausa(Causa datos)
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
                //messagebox.Show(e.ToString());
            }

            LeerFilas.Close();
            conexionBD.cerrarConexion();
            comando.Parameters.Clear();
            return cont;
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
                //messagebox.Show(e.ToString());
            }
            finally
            {
                LeerFilas.Close();
                conexionBD.cerrarConexion();
            }
            return tabla;
        }
        public DataTable CargarGrupoCausa(Causa datos)
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
                //messagebox.Show(e.ToString());
            }

            LeerFilas.Close();
            conexionBD.cerrarConexion();
            comando.Parameters.Clear();
            return tabla;
        }

        public void CrearPdfGrupo(Causa dato , string Portador)
        {
            int grupo = dato.Grupo;
            string codbillete = dato.Cod_Billete;
            string portador = Portador;
            PdfWriter pdfwriter = new PdfWriter(@"C:\Users\Wilcon\Documents\grupo'" + grupo + "'.pdf");
            PdfDocument pdf = new PdfDocument(pdfwriter);
            Document documento = new Document(pdf, PageSize.LETTER);

            documento.SetMargins(30, 20, 30, 20);

            PdfFont fontcolumnas = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
            PdfFont fontcontenido = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);

            string[] columnas = { "Cant", "cliente", "direccion", };

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
                comando.Parameters.AddWithValue("grup", dato.Grupo);
                LeerFilas = comando.ExecuteReader();
                int contador = 1;
                documento.Add(new Paragraph(@"Codigo de Billete: " + codbillete + "        Portador: " + portador));
                while (LeerFilas.Read())
                {

                    tabla.AddCell(new Cell().Add(new Paragraph(Convert.ToString(contador))));
                    tabla.AddCell(new Cell().Add(new Paragraph(LeerFilas["cliente"].ToString()).SetFont(fontcontenido)));
                    tabla.AddCell(new Cell().Add(new Paragraph(LeerFilas["direccion"].ToString()).SetFont(fontcontenido)));
                    //tabla.AddCell(new Cell().Add(new Paragraph(LeerFilas["Grupo"].ToString()).SetFont(fontcontenido)));
                    contador++;
                }
            }
            catch (MySqlException e)
            {
                //messagebox.Show(e.ToString());
            }


            documento.Add(tabla);
            documento.Close();
            //messagebox.Show("Se Genero el reporte");
            LeerFilas.Close();
            comando.Parameters.Clear();
            conexionBD.cerrarConexion();
        }
        public void EliminarCausa(Causa datos)
        {
            try
            {
                comando.Connection = conexionBD.abrirconexion();
                comando.CommandText = "EliminarCausa";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("Idclient", datos.Idcliente);
                comando.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                //messagebox.Show(e.ToString());
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
                //messagebox.Show(e.ToString());
            }
            comando.Parameters.Clear();
            conexionBD.cerrarConexion();
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
                //messagebox.Show(e.ToString());
            }
            return mensaje;
        }

        public void QuitarGrupoCausa(Causa datos)
        {
            try
            {
                comando.Connection = conexionBD.abrirconexion();
                comando.CommandText = "QuitarGrupoCausa";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("Idclient", datos.Idcliente);
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
