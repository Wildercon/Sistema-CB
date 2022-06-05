using CapaDatos;
using CapaEntidad;
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
    public partial class FormTransferencia : Form
    {
        CtrlBauche ObjCtrlBauche = new CtrlBauche();
        CD_Transferencia objTransferencia = new CD_Transferencia();
        CD_Cliente objCliente = new CD_Cliente();
        string operacion = "Insertar";
        public FormTransferencia()
        {
            InitializeComponent();
        }

        private void FormTransferencia_Load(object sender, EventArgs e)
        {
            lblFecha.Text = DateTime.Now.ToShortDateString();
            CargarTransferencia();
            listarCliente();
            ListarCuentas();
            dataGridTransferencia.Columns["Fecha"].Width = 70;
            dataGridTransferencia.Columns["Cedula"].Width = 70;
            dataGridTransferencia.Columns["Monto"].Width = 60;
            dataGridTransferencia.Columns["Ref"].Width = 40;
            dataGridTransferencia.Columns["Banco"].Width = 80;
            dataGridTransferencia.Columns["Cuenta_Telefono"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridTransferencia.Columns["idtransferencia"].Visible = false;
            cbCuenta.SelectedIndex = -1;
            cbCliente.AutoCompleteCustomSource = AutoListarClientes();
            cbCliente.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbCliente.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void CargarTransferencia()
        {
            dataGridTransferencia.DataSource = objTransferencia.CargarTransferencia();
        }
           
        private void bntGuardar_Click(object sender, EventArgs e)
        {
            
            Transferencia oTransferencia = new Transferencia()
            {
                Fecha = lblFecha.Text,
                Beneficiario = txtBeneficiario.Text,
                Cuenta = txtCuenta.Text,
                Cedula = Convert.ToInt32(txtCedula.Text),
                Banco = txtBanco.Text,
                Monto = Convert.ToDouble(txtMonto.Text),
                Cliente = new Cliente() { Id = Convert.ToInt32(cbCliente.SelectedValue) },
                Referencia = txtReferencia.Text
            };
                       
            if (operacion =="Insertar")
            {
                objTransferencia.AgregarTransferencia(oTransferencia);
            }else if(operacion == "Editar")
            {
                oTransferencia.Idtransferencia = Convert.ToInt32(dataGridTransferencia.CurrentRow.Cells[0].Value.ToString());
                objTransferencia.EditarTransferencia(oTransferencia);
            }
            
            CargarTransferencia();
            Limpiar();
            operacion = "Insertar";
        }

        private void listarCliente()
        {
            cbCliente.DataSource = objCliente.ListarCliente();
            cbCliente.DisplayMember = "cliente";
            cbCliente.ValueMember = "id";
        }

        private void Limpiar()
        {
            txtBanco.Text = "";
            txtBeneficiario.Text = "";
            txtCedula.Text = "";
            txtCuenta.Text = "";
            txtMonto.Text = "";
            txtReferencia.Text = "";
            cbCliente.SelectedIndex = 0;
            cbCliente.Text = "";
            cbCuenta.SelectedIndex = -1;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
            CargarTransferencia();
        }

        private void bntEditar_Click(object sender, EventArgs e)
        {
            txtBeneficiario.Text = dataGridTransferencia.CurrentRow.Cells["Beneficiario"].Value.ToString();
            txtBanco.Text = dataGridTransferencia.CurrentRow.Cells["Banco"].Value.ToString();
            txtCedula.Text = dataGridTransferencia.CurrentRow.Cells["Cedula"].Value.ToString();
            txtCuenta.Text = dataGridTransferencia.CurrentRow.Cells["Cuenta_Telefono"].Value.ToString();
            txtReferencia.Text = dataGridTransferencia.CurrentRow.Cells["Ref"].Value.ToString();
            cbCliente.Text = dataGridTransferencia.CurrentRow.Cells["Cliente"].Value.ToString();
            txtMonto.Text = dataGridTransferencia.CurrentRow.Cells["Monto"].Value.ToString();
            operacion = "Editar";
        }

        private void bntBuscar_Click(object sender, EventArgs e)
        {
            Transferencia oTranferencia = new Transferencia() { Beneficiario = txtBuscar.Text };
            dataGridTransferencia.DataSource = objTransferencia.BuscarTransferencia(oTranferencia);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridTransferencia.DataSource = ObjCtrlBauche.TodasTransferencia();
        }

        private void ListarCuentas()
        {
            cbCuenta.DataSource = ObjCtrlBauche.ListarCuentas();
            cbCuenta.DisplayMember = "Banco";
            cbCuenta.ValueMember = "idcuenta";
        }

        /*private void btnHecha_Click(object sender, EventArgs e)
        {
            Bauche bau = new Bauche();
            bau.Monto = Convert.ToDouble(txtMonto.Text);
            bau.Idcuenta = Convert.ToInt32(cbCuenta.SelectedValue);
            bntGuardar_Click(sender, e);
            ObjCtrlBauche.DisminuirMontoBanco(bau);
        }*/

        private void btnCliente_Click(object sender, EventArgs e)
        {
            AgregarCliente cliente = new AgregarCliente();
            cliente.Show();
        }

        private AutoCompleteStringCollection AutoListarClientes()
        {
            CtrlBauche objCtrl = new CtrlBauche();
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
    }

}
