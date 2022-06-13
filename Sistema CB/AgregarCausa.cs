using CapaDatos;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidad;

namespace Sistema_CB
{
    public partial class AgregarCausa : Form
    {
        CtrlBauche objCtrlBauche = new CtrlBauche();
        CD_Cliente objCliente = new CD_Cliente();
        CD_Causa objCausa = new CD_Causa();

        
        public AgregarCausa()
        {
            InitializeComponent();
        }

        private void AgregarCausa_Load(object sender, EventArgs e)
        {
            ListarClientes();
            ListarGrupo();
            cbCliente.AutoCompleteCustomSource = AutoListarClientes();
            cbCliente.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbCliente.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void ListarClientes()
        {
            cbCliente.DataSource = objCliente.ListarCliente();
            cbCliente.DisplayMember = "cliente";
            cbCliente.ValueMember = "id";

        }

        private void ListarGrupo()
        {
            cbGrupo.DataSource = objCausa.ListarGrupoC();
            cbGrupo.DisplayMember = "Grupo";
            cbGrupo.ValueMember = "id";

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

        private void btnAgregar_Click(object sender, EventArgs e)
        {            
            if (cbCliente.SelectedValue == null)
            {
                DialogResult resultado = MessageBox.Show( "Registrar Cliente?", "Cliente No Esta Registrado", MessageBoxButtons.OKCancel);

                if (resultado == DialogResult.OK)
                {
                    Cliente oCliente = new Cliente()
                    {
                        Direccion = txtDireccion.Text,
                        NombreCliente = cbCliente.Text
                    };
                    
                    
                    string dato = cbCliente.Text;
                    objCliente.AgregarCliente(oCliente);
                    ListarClientes();
                    cbCliente.Text = dato;
                }
            }
            CapaEntidad.Causa oCausa = new CapaEntidad.Causa()
            {
                Idcliente = Convert.ToInt32(cbCliente.SelectedValue),
                Grupo = Convert.ToInt32(cbGrupo.SelectedValue),
                Observacion = txtObservaciones.Text
            };
            string error = objCausa.AgregarCausa(oCausa);
            if (error == string.Empty)
            {
                cbCliente.SelectedValue = -1;
                txtObservaciones.Text = "";
                txtDireccion.Text = "";
            }
            else
            {
                MessageBox.Show(error);
            }
            
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


        private void txtGrupo_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            //Para obligar a que sólo se introduzcan números
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
              if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso
            {
                e.Handled = false;
            }
            else
            {
                //el resto de teclas pulsadas se desactivan
                e.Handled = true;
            }
        }

        private void cbGrupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbGrupo.SelectedIndex > 0)
            {
                CapaEntidad.Causa oCausa = new CapaEntidad.Causa()
                {
                    Grupo = Convert.ToInt32(cbGrupo.SelectedValue)
                }; 
                int CantGrupo = objCausa.ContarGrupoCausa(oCausa);
                lblCantGrupo.Text = CantGrupo.ToString();
               
            }
            
        }
    }
}
