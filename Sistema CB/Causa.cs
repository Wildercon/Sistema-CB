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
        public Causa()
        {
            InitializeComponent();
        }

        private void Causa_Load(object sender, EventArgs e)
        {
            CargarCausa();
            ListarClientes();
            CargarGrupoCausa();
            cbCliente.SelectedIndex = -1;
            int dato = Convert.ToInt32(numGrupoCausa.Value);
            txtBillete.Text = objCtrlBauche.LlenarTxtCodBillete(dato);
            cbCliente.AutoCompleteCustomSource = AutoListarClientes();
            cbCliente.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbCliente.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void CargarCausa()
        {
            dataGridCausa.DataSource = objCtrlBauche.CargarCausa();
            dataGridCausa.Columns["direccion"].Width = 150;
            dataGridCausa.Columns["cliente"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

 

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            int dato = Convert.ToInt32(numGrupoCausa.Value);
            txtBillete.Text = objCtrlBauche.LlenarTxtCodBillete(dato);
            CargarGrupoCausa();
            if(dataGridGrupoC.Rows.Count < 1)
            {
                txtBillete.Text = "";
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Bauche bau = new Bauche();
            bau.IdCliente = Convert.ToInt32(cbCliente.SelectedValue);
            bau.Observaciones = txtObservacion.Text;
            objCtrlBauche.AgregarCausa(bau);
            CargarCausa();
            txtDireccion.Text = "";
            txtObservacion.Text = "";
            cbCliente.SelectedIndex = -1; 
        }

        private void ListarClientes()
        {
            CtrlBauche objCtrl = new CtrlBauche();
            cbCliente.DataSource = objCtrl.ListarCliente();
            cbCliente.DisplayMember = "cliente";
            cbCliente.ValueMember = "id";

        }

        private void AgregarGrupo_Click(object sender, EventArgs e)
        {
            Bauche bau = new Bauche();
            bau.IdCliente = Convert.ToInt32(cbCliente.SelectedValue);
            bau.Grupo = Convert.ToInt32(numGrupoCausa.Value);
            bau.Codbillete = txtBillete.Text;
            objCtrlBauche.AgregarGrupoCausa(bau);
            CargarCausa();
            CargarGrupoCausa();
            txtDireccion.Text = "";
            txtObservacion.Text = "";
            cbCliente.SelectedIndex = -1;
        }

        private void CargarGrupoCausa()
        {
            Bauche bau = new Bauche();
            bau.Grupo = Convert.ToInt32(numGrupoCausa.Value);
            dataGridGrupoC.DataSource = objCtrlBauche.CargarGrupoCausa(bau);
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
            Bauche bau = new Bauche();
            bau.IdCliente = Convert.ToInt32(cbCliente.SelectedValue);
            objCtrlBauche.EliminarCausa(bau);
            CargarGrupoCausa();
            CargarCausa();
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (dataGridGrupoC.SelectedRows.Count > 0)
            {
                Bauche bau = new Bauche();
                bau.IdCliente = Convert.ToInt32(dataGridGrupoC.CurrentRow.Cells["idcliente"].Value);
                objCtrlBauche.QuitarGrupoCausa(bau);
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
            objCtrlBauche.CrearPdf();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("Se Borrara Toda la lista", "Eliminar Lista?", MessageBoxButtons.OKCancel);

            if(resultado == DialogResult.OK)
            {
                objCtrlBauche.LimpiarCausa();
                CargarCausa();
                CargarGrupoCausa();
            }
        }

        private AutoCompleteStringCollection AutoListarClientes()
        {
            CtrlBauche objCtrl = new CtrlBauche();
            DataTable tabla = new DataTable();
            tabla = objCtrl.ListarCliente();
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
            Bauche bau = new Bauche();
            bau.IdCliente = Convert.ToInt32(cbCliente.SelectedValue);
            dataGridCausa.DataSource = objCtrlBauche.BuscarCausa(bau);
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
            Bauche bau = new Bauche();
            bau.Grupo = Convert.ToInt32(numGrupoCausa.Value);
            objCtrlBauche.CrearPdfGrupo(bau);
        
        }
    }
}

