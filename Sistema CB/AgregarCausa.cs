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
    public partial class AgregarCausa : Form
    {
        CtrlBauche objCtrlBauche = new CtrlBauche();
        public AgregarCausa()
        {
            InitializeComponent();
        }

        private void AgregarCausa_Load(object sender, EventArgs e)
        {
            ListarClientes();
            cbCliente.AutoCompleteCustomSource = AutoListarClientes();
            cbCliente.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbCliente.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void ListarClientes()
        {
            cbCliente.DataSource = objCtrlBauche.ListarCliente();
            cbCliente.DisplayMember = "cliente";
            cbCliente.ValueMember = "id";

        }
        private AutoCompleteStringCollection AutoListarClientes()
        {
            DataTable tabla = new DataTable();
            tabla = objCtrlBauche.ListarCliente();
            AutoCompleteStringCollection dato = new AutoCompleteStringCollection();

            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                string dator;
                dator = tabla.Rows[i]["cliente"].ToString();
                dato.Add(dator);
            }
            return dato;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Bauche bau = new Bauche();           
            if (cbCliente.SelectedValue == null)
            {
                DialogResult resultado = MessageBox.Show( "Registrar Cliente?", "Cliente No Esta Registrado", MessageBoxButtons.OKCancel);

                if (resultado == DialogResult.OK)
                {
                    bau.Direccion = txtDireccion.Text;
                    bau.Cliente = cbCliente.Text;
                    string dato = cbCliente.Text;
                    objCtrlBauche.AgregarCliente(bau);
                    ListarClientes();
                    cbCliente.Text = dato;
                }
            }
            bau.IdCliente = Convert.ToInt32(cbCliente.SelectedValue);
            bau.Observaciones = txtObservaciones.Text;
            objCtrlBauche.AgregarCausa(bau);
            cbCliente.SelectedValue = -1;
            txtObservaciones.Text = "";
            txtDireccion.Text = "";
        }

        private void cbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCliente.SelectedIndex > 0)
            {
                int dato = Convert.ToInt32(cbCliente.SelectedValue);
                txtDireccion.Text = objCtrlBauche.CompletarTxtDireccion(dato);
                objCtrlBauche.VerificarBaucheDeuda(dato);
            }
        }
    }
}
