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



        private void CargarVendedores()
        {
            dataGridVentas.DataSource = objCtrlBauche.ListarVendedores();
            dataGridVentas.Columns["idvendedor"].Visible = false;
            dataGridVentas.Columns["Vendedor"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void BtnBauche_Click(object sender, EventArgs e)
        {
            Bauche bau = new Bauche();
            if(txtCodigo.Text == "")
            {
                MessageBox.Show("Introducir Codigo");
                return;
            }
            bau.Codigo = Convert.ToInt32(txtCodigo.Text);
            dataGridVentas.DataSource = objCtrlBauche.BuscarBauCodigo(bau);
            dataGridVentas.Columns["idBauche"].Visible = false;
            dataGridVentas.Columns["cliente"].Visible = false;
            dataGridVentas.Columns["estado"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridVentas.Columns["observaciones"].Visible = false;
            dataGridVentas.Columns["codigo"].Width = 50;
            dataGridVentas.Columns["monto"].Width = 50;
            dataGridVentas.Columns["Fecha"].Width = 72;

        }

        private void btnVendedores_Click(object sender, EventArgs e)
        {
            CargarVendedores();
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            dataGridVentas.DataSource = objCtrlBauche.CargarVentas();
            dataGridVentas.Columns["Monto"].Width = 55;
            dataGridVentas.Columns["Bauche"].Width = 55;
            dataGridVentas.Columns["Fecha"].Width = 75;
            dataGridVentas.Columns["Op"].Width = 25;
            dataGridVentas.Columns["Total"].Width = 55;
            dataGridVentas.Columns["Vendedor"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            foreach (DataGridViewRow row in dataGridVentas.Rows)
            {
                if (row.Cells["op"].Value.ToString() == "-")
                    row.DefaultCellStyle.BackColor = Color.FromArgb(229,50,50);


            }
        }

        private void btnAgregarVenta_Click(object sender, EventArgs e)
        {
            
            Bauche bau = new Bauche();
            bau.IdBauche = Convert.ToInt32(txtBauche.Text);
            bau.Idvendedor = Convert.ToInt32(cbVendedor.SelectedValue);
            bau.Monto = Convert.ToDouble(txtMonto.Text);
            bau.Fecha = fecha;
            bau.Estado = "+";
            objCtrlBauche.AumentarMontoVendedor(bau);
            bau.Total = objCtrlBauche.ControlMontoV(bau);
            objCtrlBauche.AgregarVenta(bau);
            CargarVendedores();
        }

        private void btnEntrega_Click(object sender, EventArgs e)
        {
            Bauche bau = new Bauche();
            bau.Fecha = fecha;
            bau.Idcuenta = 1;
            bau.Monto = Convert.ToDouble(txtMontoEntrega.Text);
            bau.Idvendedor = Convert.ToInt32(cbEntrega.SelectedValue);
            bau.Estado = "-";
            bau.IdBauche = 1;
            objCtrlBauche.DisminuirMontoVendedor(bau);
            bau.Total = objCtrlBauche.ControlMontoV(bau);
            objCtrlBauche.AgregarVenta(bau);
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
            if (checkPorCobrar.Checked)
            {
                objCtrlBauche.AgregarCuentaXCobrar(bau);
                bau.Estado = "Pendiente";
            }else
            {
                objCtrlBauche.AumentarMontoBanco(bau);
                bau.Estado = "Cancelado";
            }
            objCtrlBauche.AgregarCompra(bau);
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
            bau.Fecha = fecha;
            bau.Idcuenta = 1;
            bau.Banco = "";
            bau.IdCliente = Convert.ToInt32(cbClientexCobrar.SelectedValue);
            bau.Monto = Convert.ToDouble(txtMontoxCobrar.Text);
            bau.Estado = "Deuda";
            objCtrlBauche.DisminuirMontoCliente(bau);
            objCtrlBauche.AgregarCompra(bau);
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
            dataGridCompras.Columns["Monto"].Width = 47;
            dataGridCompras.Columns["Fecha"].Width = 70;
            dataGridCompras.Columns["Operacion"].Width = 75;
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

        private void dataGridVentas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtBauche.Text = dataGridVentas.CurrentRow.Cells["idBauche"].Value.ToString();
        }

        private void btn_Cstavendedor_Click(object sender, EventArgs e)
        {
            Bauche bau = new Bauche();
            bau.Idvendedor = Convert.ToInt32(cbVendedor.SelectedValue);
            dataGridVentas.DataSource = objCtrlBauche.CargarDetalleVendedor(bau);
            dataGridVentas.Columns["Monto"].Width = 55;
            dataGridVentas.Columns["Bauche"].Width = 55;
            dataGridVentas.Columns["Fecha"].Width = 75;
            dataGridVentas.Columns["Op"].Width = 25;
            dataGridVentas.Columns["Total"].Width = 55;
            dataGridVentas.Columns["Vendedor"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            foreach (DataGridViewRow row in dataGridVentas.Rows)
            {
                if (row.Cells["op"].Value.ToString() == "-")
                    row.DefaultCellStyle.BackColor = Color.FromArgb(229, 50, 50);
            }
        }

        private void btnConsultaClie_Click(object sender, EventArgs e)
        {
            Bauche bau = new Bauche();
            bau.IdCliente = Convert.ToInt32(cbCliente.SelectedValue);
            dataGridCompras.DataSource = objCtrlBauche.DetalleCompraCliente(bau);
            dataGridCompras.Columns["Monto"].Width = 47;
            dataGridCompras.Columns["Fecha"].Width = 70;
            dataGridCompras.Columns["Operacion"].Width = 75;
            dataGridCompras.Columns["Ref"].Width = 80;
            dataGridCompras.Columns["cliente"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            foreach (DataGridViewRow row in dataGridCompras.Rows)
            {
                if (row.Cells["Operacion"].Value.ToString() == "Pendiente")
                    row.DefaultCellStyle.BackColor = Color.FromArgb(229, 50, 50);
            }
        }
    }
}
