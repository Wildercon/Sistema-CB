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
    public partial class CompraVenta : Form
    {
        string fecha = DateTime.Now.ToShortDateString();

        CtrlBauche objCtrlBauche = new CtrlBauche();
        public CompraVenta()
        {
            InitializeComponent();
        }

        private void CompraVenta_Load(object sender, EventArgs e)
        {
            CargarCuentaXCobrar();
            ListarVendedores();
            CargarVendedores();
            ListarClientes();
            ListarClienteXCobrar();
            cbVendedor.SelectedIndex = -1;
            cbEntrega.SelectedIndex = -1;
            cbCliente.SelectedIndex = -1;
            cbCliente.AutoCompleteCustomSource = AutoListarClientes();
            cbCliente.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbCliente.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void ListarVendedores()
        {
            cbVendedor.DataSource = objCtrlBauche.ListarVendedores();
            cbVendedor.DisplayMember = "Vendedor";
            cbVendedor.ValueMember = "idvendedor";
            cbEntrega.DataSource = objCtrlBauche.ListarVendedores();
            cbEntrega.DisplayMember = "Vendedor";
            cbEntrega.ValueMember = "idvendedor";
        }

        private void CargarBauche()
        {
            dataGridVentas.DataSource = objCtrlBauche.CargarBauche();
            dataGridVentas.Columns["idBauche"].Visible = false;
            dataGridVentas.Columns["cliente"].Visible = false;
            dataGridVentas.Columns["fecha"].Visible = false;
            dataGridVentas.Columns["observaciones"].Visible = false;
            dataGridVentas.Columns["codigo"].Width = 50;
            dataGridVentas.Columns["monto"].Width = 70;
        }

        private void CargarVendedores()
        {
            dataGridVentas.DataSource = objCtrlBauche.ListarVendedores();
            dataGridVentas.Columns["idvendedor"].Visible = false;
            dataGridVentas.Columns["Vendedor"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void BtnBauche_Click(object sender, EventArgs e)
        {
            CargarBauche();
        }

        private void btnVendedores_Click(object sender, EventArgs e)
        {
            CargarVendedores();
        }

        private void CargarVentas()
        {
            dataGridVentas.DataSource = objCtrlBauche.CargarVentas();
            dataGridVentas.Columns["Monto"].Width = 55;
            dataGridVentas.Columns["Bauche"].Width = 55;
            dataGridVentas.Columns["Fecha"].Width = 75;
            dataGridVentas.Columns["Vendedor"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            CargarVentas();
        }

        private void btnAgregarVenta_Click(object sender, EventArgs e)
        {
            Bauche bau = new Bauche();
            bau.Codigo = Convert.ToInt32(txtBauche.Text);
            bau.Idvendedor = Convert.ToInt32(cbVendedor.SelectedValue);
            bau.Monto = Convert.ToDouble(txtMonto.Text);
            bau.Fecha = fecha;
            objCtrlBauche.AgregarVenta(bau);
            objCtrlBauche.AumentarMontoVendedor(bau);
            CargarVendedores();
        }

        private void btnEntrega_Click(object sender, EventArgs e)
        {
            Bauche bau = new Bauche();
            bau.Idcuenta = 1;
            bau.Monto = Convert.ToDouble(txtMontoEntrega.Text);
            bau.Idvendedor = Convert.ToInt32(cbEntrega.SelectedValue);
            objCtrlBauche.DisminuirMontoVendedor(bau);
            CargarVendedores();
            cbEntrega.SelectedIndex = -1;
            txtMontoEntrega.Text = "";
            objCtrlBauche.DisminuirMontoBanco(bau);
        }

        private void ListarClientes()
        {
            cbCliente.DataSource = objCtrlBauche.ListarCliente();
            cbCliente.DisplayMember = "cliente";
            cbCliente.ValueMember = "id";
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

        private void btnAgregarCompra_Click(object sender, EventArgs e)
        {
            Bauche bau = new Bauche();
            bau.Idcuenta = 1;
            bau.Banco = txt_BancoRef.Text;
            bau.Fecha = fecha;
            bau.IdCliente = Convert.ToInt32(cbCliente.SelectedValue);
            bau.Monto = Convert.ToDouble(txtMontoCompra.Text);
            objCtrlBauche.AgregarCompra(bau);           
            if (checkPorCobrar.Checked)
            {
                objCtrlBauche.AgregarCuentaXCobrar(bau);
            }else
            {
                objCtrlBauche.AumentarMontoBanco(bau);
            }
            CargarCuentaXCobrar();
        }

        private void CargarCuentaXCobrar()
        {
            dataGridCompras.DataSource = objCtrlBauche.CargarCuentasXCobrar();
            dataGridCompras.Columns["Cliente"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridCompras.Columns["Monto"].Width = 80;
            dataGridCompras.Columns["id"].Visible = false;
        }

        private void btnRecibir_Click(object sender, EventArgs e)
        {
            Bauche bau = new Bauche();
            bau.Idcuenta = 1;
            bau.IdCliente = Convert.ToInt32(cbClientexCobrar.SelectedValue);
            bau.Monto = Convert.ToDouble(txtMontoxCobrar.Text);
            objCtrlBauche.DisminuirMontoCliente(bau);
            CargarCuentaXCobrar();
            objCtrlBauche.AumentarMontoBanco(bau);
        }

        private void ListarClienteXCobrar()
        {
            cbClientexCobrar.DataSource = objCtrlBauche.CargarCuentasXCobrar();
            cbClientexCobrar.DisplayMember = "cliente";
            cbClientexCobrar.ValueMember = "id";
        }

        private void btnMostrarCompras_Click(object sender, EventArgs e)
        {
            dataGridCompras.DataSource = objCtrlBauche.CargarCompras();
            dataGridCompras.Columns["Monto"].Width = 50;
            dataGridCompras.Columns["Fecha"].Width = 67;
            dataGridCompras.Columns["Ref"].Width = 80;
            dataGridCompras.Columns["cliente"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; 
        }

        private void btnMostrarXcobrar_Click(object sender, EventArgs e)
        {
            CargarCuentaXCobrar();
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            AgregarCliente cliente = new AgregarCliente();
            cliente.Show();
            ListarClientes();
        }

    }
}
