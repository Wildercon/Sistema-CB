using CapaDatos;
using iText.IO.Font.Constants;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_CB
{
    public partial class Causa : Form
    {
        CtrlBauche objCtrlBauche = new CtrlBauche();
        CD_Causa objCausa = new CD_Causa();
        CD_Cliente objCliente = new CD_Cliente();
        CapaEntidad.Causa oCausa;
        public Causa()
        {
            InitializeComponent();
        }

        private void Causa_Load(object sender, EventArgs e)
        {
            CargarCausa();
            ListarClientes();
            CargarGrupoCausa();
            ListarGrupo();
            cbCliente.SelectedIndex = -1;
            int dato = Convert.ToInt32(numGrupoCausa.Value);
            txtBillete.Text = objCausa.LlenarTxtCodBillete(dato);
            cbCliente.AutoCompleteCustomSource = AutoListarClientes();
            cbCliente.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbCliente.AutoCompleteSource = AutoCompleteSource.CustomSource;
            CbPortador.SelectedIndex = -1;
            CbPortador.AutoCompleteCustomSource = AutoListarClientes();
            CbPortador.AutoCompleteMode = AutoCompleteMode.Suggest;
            CbPortador.AutoCompleteSource = AutoCompleteSource.CustomSource;

        }

        private void CargarCausa()
        {
            dataGridCausa.DataSource = objCausa.CargarCausa();
            dataGridCausa.Columns["direccion"].Width = 150;
            dataGridCausa.Columns["cliente"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

 

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            int dato = Convert.ToInt32(numGrupoCausa.Value);
            txtBillete.Text = objCausa.LlenarTxtCodBillete(dato);

            CbPortador.Text = objCausa.PortadorGrupo(dato);
            CargarGrupoCausa();
            if(dataGridGrupoC.Rows.Count < 1)
            {
                txtBillete.Text = "";
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            oCausa = new CapaEntidad.Causa()
            {
                Idcliente = Convert.ToInt32(cbCliente.SelectedValue),
                Observacion = txtObservacion.Text,
                Grupo = Convert.ToInt32(CbGrupo.SelectedValue.ToString())
            };
            
            string error = objCausa.AgregarCausa(oCausa);
            if (error == string.Empty)
            {
                CargarCausa();
                txtDireccion.Text = "";
                txtObservacion.Text = "";
                cbCliente.SelectedIndex = -1;
            }
            else
            {
                MessageBox.Show(error);
            }
            
        }

        private void ListarClientes()
        {
            
            cbCliente.DataSource = objCliente.ListarCliente();
            cbCliente.DisplayMember = "cliente";
            cbCliente.ValueMember = "id";
            CbPortador.DataSource = objCliente.ListarCliente();
            CbPortador.DisplayMember = "cliente";
            CbPortador.ValueMember = "id";
        }

        public void ListarGrupo()
        {
            CbGrupo.DataSource = objCausa.ListarGrupoC();
            CbGrupo.DisplayMember = "Grupo";
            CbGrupo.ValueMember = "id";
        }


        private void AgregarGrupo_Click(object sender, EventArgs e)
        {
            oCausa = new CapaEntidad.Causa()
            {
                Idcliente = Convert.ToInt32(cbCliente.SelectedValue),
                Grupo = Convert.ToInt32(numGrupoCausa.Value),
                Cod_Billete = txtBillete.Text,            
             };
            
            objCausa.AgregarGrupoCausa(oCausa);
            CargarCausa();
            CargarGrupoCausa();
            txtDireccion.Text = "";
            txtObservacion.Text = "";
            cbCliente.SelectedIndex = -1;
        }

        private void CargarGrupoCausa()
        {
            oCausa = new CapaEntidad.Causa()
            {
                Grupo = Convert.ToInt32(numGrupoCausa.Value)
            };
            
            dataGridGrupoC.DataSource = objCausa.CargarGrupoCausa(oCausa);
            dataGridGrupoC.Columns["direccion"].Width = 150;
            dataGridGrupoC.Columns["Observacion"].Width = 150;
            dataGridGrupoC.Columns["cliente"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridGrupoC.Columns["idcliente"].Visible = false;
            txtCanCauGrup.Text = Convert.ToString(dataGridGrupoC.Rows.Count);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if(dataGridCausa.SelectedRows.Count > 0)
            {
                cbCliente.Text = dataGridCausa.CurrentRow.Cells["cliente"].Value.ToString();
                txtObservacion.Text = dataGridCausa.CurrentRow.Cells["Observacion"].Value.ToString();
            }
            else
            {
                MessageBox.Show("Seleccione un Resgitro");
            }
        }

        private void cbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCliente.SelectedIndex > 0)
            {
                int dato = Convert.ToInt32(cbCliente.SelectedValue);
                txtDireccion.Text = objCtrlBauche.CompletarTxtDireccion(dato);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            oCausa  = new CapaEntidad.Causa()
            {
                Idcliente = Convert.ToInt32(cbCliente.SelectedValue)
            };
            objCausa.EliminarCausa(oCausa);
            CargarGrupoCausa();
            CargarCausa();
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (dataGridGrupoC.SelectedRows.Count > 0)
            {
                oCausa = new CapaEntidad.Causa()
                {
                    Idcliente = Convert.ToInt32(dataGridGrupoC.CurrentRow.Cells["idcliente"].Value)
                };
                ;
                objCausa.QuitarGrupoCausa(oCausa);
            }
            else
            {
                MessageBox.Show("Seleccione un Resgitro");
            }
            CargarCausa();
            CargarGrupoCausa();
        }

       

        private void btnPdf_Click(object sender, EventArgs e)
        {           
            string mensaje = objCtrlBauche.CrearPdf();
            MessageBox.Show(mensaje);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("Se Borrara Toda la lista", "Eliminar Lista?", MessageBoxButtons.OKCancel);

            if(resultado == DialogResult.OK)
            {
                objCausa.LimpiarCausa();
                CargarCausa();
                CargarGrupoCausa();
            }
        }

        private AutoCompleteStringCollection AutoListarClientes()
        {
            DataTable tabla = new DataTable();
            tabla = objCliente.ListarCliente();
            AutoCompleteStringCollection dato = new AutoCompleteStringCollection();

            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                string dator;
                dator = tabla.Rows[i]["cliente"].ToString();
                dato.Add(dator);
            }
            return dato;
        }


        private void btnBuscar_Click(object sender, EventArgs e)
        {
            oCausa = new CapaEntidad.Causa()
            {
                Idcliente = Convert.ToInt32(cbCliente.SelectedValue)
            };
            ;
            dataGridCausa.DataSource = objCausa.BuscarCausa(oCausa);
            dataGridCausa.Columns["Grupo"].Width = 50;
        }

        private void btnPendientes_Click(object sender, EventArgs e)
        {
            CargarCausa();
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            AgregarCliente form = new AgregarCliente();
            form.Show();
        }

        private void btnPdfGrupo_Click(object sender, EventArgs e)
        {
            oCausa = new CapaEntidad.Causa()
            {
                Grupo = Convert.ToInt32(numGrupoCausa.Value),
                Cod_Billete = txtBillete.Text
                
            };
            string portador = CbPortador.Text;
            
            objCausa.CrearPdfGrupo(oCausa,portador);
        
        }

        private void c(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}

