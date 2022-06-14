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
    public partial class CompraVenta : Form
    {
        string fecha = DateTime.Now.ToShortDateString();

        CtrlBauche objCtrlBauche = new CtrlBauche();
        CD_Vendedor objVendedor = new CD_Vendedor();
        CD_Venta objVenta = new CD_Venta();
        CD_Cliente objCliente = new CD_Cliente();
        CD_Pendientexcobrar objPenxcobrar = new CD_Pendientexcobrar();
        CD_Compra objCompra = new CD_Compra();
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
            cbVendedor.DataSource = objVendedor.ListarVendedores();
            cbVendedor.DisplayMember = "Vendedor";
            cbVendedor.ValueMember = "idvendedor";
            cbEntrega.DataSource = objVendedor.ListarVendedores();
            cbEntrega.DisplayMember = "Vendedor";
            cbEntrega.ValueMember = "idvendedor";
        }



        private void CargarVendedores()
        {
            dataGridVentas.DataSource = objVendedor.ListarVendedores();
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
            dataGridVentas.DataSource = objVenta.CargarVentas();
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
            bool Verificar = objVenta.verificarBaucheRepetidoVenta(Convert.ToInt32(txtBauche.Text));
            if (Verificar)
            {
                MessageBox.Show("Ya se Registro este Codigo");
            }
            else
            {
                CapaEntidad.Venta oVenta = new CapaEntidad.Venta()
                {
                    Bauche = new Bauche() { Idbauche = Convert.ToInt32(txtBauche.Text) },
                    Vendedor = new Vendedor() { Idvendedor = Convert.ToInt32(cbVendedor.SelectedValue) },
                    Monto = Convert.ToDouble(txtMonto.Text),
                    Fecha = fecha,
                    Estado = "+",

                };

                objVendedor.AumentarMontoVendedor(oVenta);
                oVenta.Total = objVendedor.ControlMontoV(oVenta);
                objVenta.AgregarVenta(oVenta);
                CargarVendedores();
            }                                   
        }

        private void btnEntrega_Click(object sender, EventArgs e)
        {
            CapaEntidad.Venta oVenta = new CapaEntidad.Venta()
            {
                Fecha = fecha,
                Monto = Convert.ToDouble(txtMontoEntrega.Text),
                Vendedor = new Vendedor() { Idvendedor = Convert.ToInt32(cbEntrega.SelectedValue) },
                Estado = "-",
                Bauche = new Bauche(){ Idbauche = 1 }
            };
            //bau.Idcuenta = 1;
            objVendedor.DisminuirMontoVendedor(oVenta);
            oVenta.Total = objVendedor.ControlMontoV(oVenta);
            objVenta.AgregarVenta(oVenta);
            CargarVendedores();
            cbEntrega.SelectedIndex = -1;
            txtMontoEntrega.Text = "";
            //objCtrlBauche.DisminuirMontoBanco(bau);
        }

        private void ListarClientes()
        {
            cbCliente.DataSource = objCliente.ListarCliente();
            cbCliente.DisplayMember = "cliente";
            cbCliente.ValueMember = "id";
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

        private void btnAgregarCompra_Click(object sender, EventArgs e)
        {
            Compra oCompra = new Compra()
            {
                Refencia = txt_BancoRef.Text,
                Fecha = fecha,
                Cliente = new Cliente() { Id = Convert.ToInt32(cbCliente.SelectedValue) },
                Monto = Convert.ToDouble(txtMontoCompra.Text)
            };
            //bau.Idcuenta = 1;                     
            if (checkPorCobrar.Checked)
            {
                objPenxcobrar.AgregarCuentaXCobrar(oCompra);
                oCompra.Estado = "Pendiente";
            }else
            {
                //objCtrlBauche.AumentarMontoBanco(oCompra);
                oCompra.Estado = "Cancelado";
            }
            objCompra.AgregarCompra(oCompra);
            CargarCuentaXCobrar();
        }

        private void CargarCuentaXCobrar()
        {
            dataGridCompras.DataSource = objPenxcobrar.CargarCuentasXCobrar();
            dataGridCompras.Columns["Cliente"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridCompras.Columns["Monto"].Width = 80;
            dataGridCompras.Columns["id"].Visible = false;
        }

        private void btnRecibir_Click(object sender, EventArgs e)
        {
            Compra oCompra = new Compra()
            {
                Fecha = fecha,
                Refencia = "",
                Cliente = new Cliente() { Id = Convert.ToInt32(cbClientexCobrar.SelectedValue) },
                Monto = Convert.ToDouble(txtMontoxCobrar.Text),
                Estado = "Deuda"
            };
            //bau.Idcuenta = 1;

            objPenxcobrar.DisminuirMontoCliente(oCompra);
            objCompra.AgregarCompra(oCompra);
            CargarCuentaXCobrar();
            //objCtrlBauche.AumentarMontoBanco(bau);
        }

        private void ListarClienteXCobrar()
        {
            cbClientexCobrar.DataSource = objPenxcobrar.CargarCuentasXCobrar();
            cbClientexCobrar.DisplayMember = "cliente";
            cbClientexCobrar.ValueMember = "id";
        }

        private void btnMostrarCompras_Click(object sender, EventArgs e)
        {
            dataGridCompras.DataSource = objCompra.CargarCompras();
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
            if (dataGridVentas.Columns.Contains("idBauche"))
            {
                txtBauche.Text = dataGridVentas.CurrentRow.Cells["idBauche"].Value.ToString();
            }
            
        }

        private void btn_Cstavendedor_Click(object sender, EventArgs e)
        {
            CapaEntidad.Venta oVenta = new CapaEntidad.Venta() { Vendedor = new Vendedor() { Idvendedor = Convert.ToInt32(cbVendedor.SelectedValue) } };
            dataGridVentas.DataSource = objVenta.CargarDetalleVendedor(oVenta);
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
            Compra oCompra = new Compra() { Cliente = new Cliente() { Id = Convert.ToInt32(cbCliente.SelectedValue) } };
            dataGridCompras.DataSource = objCompra.DetalleCompraCliente(oCompra);
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

        private void btn_Cstavendedor_Click_1(object sender, EventArgs e)
        {

        }
    }
}
