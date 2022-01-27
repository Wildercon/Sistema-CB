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

namespace Sistema_CB
{
    public partial class Venta : Form
    {
        CtrlBauche objCtrlBauche = new CtrlBauche();
        string operacion = "Insertar";
        public Venta()
        {
            InitializeComponent();

        }
        private void FormBauche_Load(object sender, EventArgs e)
        {
            txtFecha.Text = DateTime.Now.ToShortDateString();
            ListarClientes();
            CargarBauche();
            ListarProductos();
            ListarCuentas();
            cbProducto.AutoCompleteCustomSource = AutoListarProductos();
            cbProducto.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbProducto.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cbCliente.AutoCompleteCustomSource = AutoListarClientes();
            cbCliente.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbCliente.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cbProducto.SelectedIndex = -1;
            cbBanco.SelectedIndex = -1;
            txtPrecioDolar.Text = objCtrlBauche.MostrarPreciodolar();
            txtCantProd.Text = "1";
        }

        private void CargarBauche()
        {
            CtrlBauche objCtrl = new CtrlBauche();
            dataGridBauche.DataSource = objCtrl.CargarBauche();
            dataGridBauche.Columns["idBauche"].Visible = false;
            dataGridBauche.Columns["codigo"].Width = 50;
            dataGridBauche.Columns["monto"].Width = 60;
            dataGridBauche.Columns["observaciones"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void CargarProductos()
        {
            Bauche bau = new Bauche();
            bau.IdBauche = Convert.ToInt32(lbIdFactura.Text);
            dataGridProductos.DataSource = objCtrlBauche.CargarProductos(bau);
            dataGridProductos.Columns["idfactura"].Visible = false;
            dataGridProductos.Columns["cantidad"].Width = 80;
            dataGridProductos.Columns["producto"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Bauche bau = new Bauche();
            if (rdbCodigo.Checked)
            {               
                bau.Codigo = Convert.ToInt32(txtBuscar.Text);
                dataGridBauche.DataSource = objCtrlBauche.BuscarBauCodigo(bau);
            }else if (rdbCliente.Checked)
            {
                bau.Cliente = txtBuscar.Text;
                dataGridBauche.DataSource = objCtrlBauche.BuscarBauCliente(bau);
            }else if (rdbMonto.Checked)
            {
                bau.Monto = Convert.ToDouble(txtBuscar.Text);
                dataGridBauche.DataSource = objCtrlBauche.BuscarBauMonto(bau);
            }
           
        }

        private void bntGuardar_Click(object sender, EventArgs e)
        {
            Bauche bau = new Bauche();
            bau.Codigo = Convert.ToInt32(txtCodigo.Text);
            bau.Fecha = txtFecha.Text;
            bau.Monto = Convert.ToDouble(txtMonto.Text);
            bau.Idcuenta =Convert.ToInt32(cbBanco.SelectedValue);
            bau.IdCliente = Convert.ToInt32(cbCliente.SelectedValue);
            bau.Estado = cbEstado.Text;
            bau.Observaciones = txtObervaciones.Text;           
            if (operacion == "Insertar")
            {   
                if(cbCliente.SelectedValue == null)
                {
                    DialogResult resultado = MessageBox.Show("Cliente No Esta Registrado", "Registrar Cliente?", MessageBoxButtons.OKCancel);

                    if (resultado == DialogResult.OK)
                    {
                        btnCliente_Click(sender, e);
                        bau.IdCliente = Convert.ToInt32(cbCliente.SelectedValue);
                    }
                }              
                
                objCtrlBauche.AgregarBauche(bau);
                objCtrlBauche.AumentarMontoBanco(bau);
                               
            }
            else if (operacion == "Editar")
            {
                bau.IdBauche = Convert.ToInt32(lbIdFactura.Text);
                objCtrlBauche.EditarBauche(bau);
                operacion = "Insertar";
                txtCodigo.Enabled = true;
                txtFecha.Enabled = true;
                txtMonto.Enabled = true;
            }
            limpiar();
        }

        private void limpiar()
        {
            txtBuscar.Text = "";
            txtCodigo.Text = "";
            txtFecha.Text = DateTime.Now.ToShortDateString();
            txtMonto.Text = "";           
            cbBanco.SelectedIndex = -1;
            cbEstado.SelectedIndex = -1;           
            cbBanco.Text = "";
            cbEstado.Text = "";
            txtObervaciones.Text = "";
            ListarClientes();
            cbCliente.AutoCompleteCustomSource = AutoListarClientes();
            cbCliente.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbCliente.AutoCompleteSource = AutoCompleteSource.CustomSource;
            CargarBauche();
            cbCliente.SelectedIndex = 0;
            txtDireccion.Text = "";
            dataGridProductos.DataSource = null;
            dataGridProductos.Columns.Clear();
            lbIdFactura.Text = "";
            lblBauche.Text = "";
            lblDisponible.Text = "";
            lblMontoDivisas.Text = "";
            lblTotalFactura.Text = "";
            lblMontoEfectivo.Text = "";
            operacion = "Insertar";
            txtCodigo.Enabled = true;
            txtFecha.Enabled = true;
            txtMonto.Enabled = true;
            rdbCodigo.Checked = true;
        }

        private void ListarClientes()
        {
            CtrlBauche objCtrl = new CtrlBauche();
            cbCliente.DataSource = objCtrl.ListarCliente();
            cbCliente.DisplayMember = "cliente";
            cbCliente.ValueMember = "id";
        }

        private void ListarCuentas()
        {
            cbBanco.DataSource = objCtrlBauche.ListarCuentas();
            cbBanco.DisplayMember = "Banco";
            cbBanco.ValueMember = "idcuenta";
        }

        private void ListarProductos()
        {
            cbProducto.DataSource = objCtrlBauche.ListarProductos();
            cbProducto.DisplayMember = "producto";
            cbProducto.ValueMember = "idproducto";
        }

        private AutoCompleteStringCollection AutoListarProductos()
        {
            CtrlBauche objCtrl = new CtrlBauche();
            DataTable tabla = new DataTable();
            tabla = objCtrl.ListarProductos();
            AutoCompleteStringCollection dato = new AutoCompleteStringCollection();

            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                string dator;
                dator = tabla.Rows[i]["producto"].ToString();
                dato.Add(dator);
            }
            return dato;
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

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridBauche.SelectedRows.Count > 0)
            {
                operacion = "Editar";
                lbIdFactura.Text = dataGridBauche.CurrentRow.Cells["idBauche"].Value.ToString();
                txtCodigo.Text = dataGridBauche.CurrentRow.Cells["codigo"].Value.ToString();
                txtFecha.Text = dataGridBauche.CurrentRow.Cells["fecha"].Value.ToString();
                txtMonto.Text = dataGridBauche.CurrentRow.Cells["monto"].Value.ToString();
                txtObervaciones.Text = dataGridBauche.CurrentRow.Cells["observaciones"].Value.ToString();
                cbBanco.Text = dataGridBauche.CurrentRow.Cells["banco"].Value.ToString();
                cbCliente.Text = dataGridBauche.CurrentRow.Cells["cliente"].Value.ToString();
                cbEstado.Text = dataGridBauche.CurrentRow.Cells["estado"].Value.ToString();
                txtCodigo.Enabled = false;
                txtFecha.Enabled = false;
                txtMonto.Enabled = false;
                lblBauche.Text = txtMonto.Text;
                CargarProductos();
                calcularFactura();                             
            }
            else
            {
                MessageBox.Show("Seleccione un Registro");
            }
            
          
        }

        private void bntLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            Bauche bau = new Bauche();
            string dato;
            bau.Cliente = cbCliente.Text;
            dato = cbCliente.Text;
            bau.Direccion = txtDireccion.Text;
            objCtrlBauche.AgregarCliente(bau);
            ListarClientes();
            cbCliente.Text = dato;
        }

        private void bntAgregarP_Click(object sender, EventArgs e)
        {
            if (operacion == "Editar")
            {
                int idproducto = Convert.ToInt32(cbProducto.SelectedValue);
                Bauche bau = new Bauche();
                bau.IdBauche = Convert.ToInt32(lbIdFactura.Text);
                bau.IdProducto = Convert.ToInt32(cbProducto.SelectedValue);
                bau.Cantidad = Convert.ToDouble(txtCantProd.Text);
                objCtrlBauche.AgregarProFactura(bau);
                CargarProductos();
                calcularFactura();
                if (idproducto == 4)
                {
                    AgregarCausa Acausa = new AgregarCausa();
                    Acausa.ShowDialog();
                }
                else if (idproducto == 5)
                {
                    AgregarCausa Acausa = new AgregarCausa();
                    Acausa.ShowDialog();
                }
                else if (idproducto == 6)
                {
                    AgregarCausa Acausa = new AgregarCausa();
                    Acausa.ShowDialog();
                }
                if (idproducto == 7)
                {
                    bau.Idcuenta = 1;
                    bau.Monto = Convert.ToDouble(txtCantProd.Text);
                    objCtrlBauche.DisminuirMontoBanco(bau);
                }
            }else
            {
                MessageBox.Show("Selecione un Bauche");
            }
            txtCantProd.Text = "1";
            cbProducto.Focus();
        }

        private void calcularFactura()
        {
            double montodivisas;
            double montoEfectivo;
            double montobauche = Convert.ToDouble(lblBauche.Text);
            double montodisponible;
            double suma = 0;
            foreach (DataGridViewRow row in dataGridProductos.Rows)
            {
                if (row.Cells["Total"].Value != null)
                    suma += (double)row.Cells["Total"].Value;
            }

            montodisponible = montobauche - suma;
            lblTotalFactura.Text = suma.ToString();
            lblDisponible.Text = montodisponible.ToString();
            montoEfectivo = (Convert.ToDouble(lblDisponible.Text) * 20) / 100 ;
            lblMontoEfectivo.Text = Convert.ToString(Convert.ToDouble(lblDisponible.Text) - montoEfectivo);
            montodivisas = (Convert.ToDouble(lblDisponible.Text) * 10) / 100;
            lblMontoDivisas.Text =Convert.ToString((Convert.ToDouble(lblDisponible.Text) - montodivisas) / Convert.ToDouble(txtPrecioDolar.Text));
        }
            

        private void rdbCliente_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbCliente.Checked)
            {
                txtBuscar.AutoCompleteCustomSource = AutoListarClientes();
                txtBuscar.AutoCompleteMode = AutoCompleteMode.Suggest;
                txtBuscar.AutoCompleteSource = AutoCompleteSource.CustomSource;
            }
            else
            {
                txtBuscar.AutoCompleteMode = AutoCompleteMode.None;
                txtBuscar.AutoCompleteSource = AutoCompleteSource.None;
            }
            
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtMonto.Focus();
            }
        }

        private void txtMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                cbBanco.Focus();
            }
        }

        private void cbBanco_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                cbEstado.Focus();
            }
        }

        private void cbEstado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtObervaciones.Focus();
            }
        }

        private void txtObervaciones_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                cbCliente.Focus();
            }
        }

        

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                btnBuscar_Click(sender, e);
            }
        }

       

        private void cbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {                      
             txtCantProd.Focus();           
        }


        private void cbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            if(cbCliente.SelectedIndex > 0)
            {
                int dato = Convert.ToInt32(cbCliente.SelectedValue);
                txtDireccion.Text = objCtrlBauche.CompletarTxtDireccion(dato);
                objCtrlBauche.VerificarBaucheDeuda(dato);
                objCtrlBauche.VerificarClienteCredito(dato);
            }
            
        }

        private void txtPrecioDolar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                Bauche bau = new Bauche();
                bau.Preciodolar = Convert.ToDouble(txtPrecioDolar.Text);
                objCtrlBauche.CambiarPrecioDolar(bau);
            }
        }

        private void btnEstado_Click(object sender, EventArgs e)
        {
            Bauche bau = new Bauche();
            bau.Estado = cbEstado.Text;
            dataGridBauche.DataSource = objCtrlBauche.BuscarBauEstado(bau);
        }

        private void btnEliminarPro_Click(object sender, EventArgs e)
        {
            if (dataGridBauche.SelectedRows.Count > 0)
            {
                Bauche bau = new Bauche();
                bau.IdFactura1 = Convert.ToInt32(dataGridProductos.CurrentRow.Cells[0].Value);
                objCtrlBauche.BorrarProFactura(bau);              
                CargarProductos();
                calcularFactura();
            }
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCantProd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                bntAgregarP_Click(sender, e);
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }   

}
