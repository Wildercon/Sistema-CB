
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
    public partial class Venta : Form
    {
        CtrlBauche objCtrlBauche = new CtrlBauche();
        CD_Cliente objCliente = new CD_Cliente();
        CD_Factura objFactura = new CD_Factura();
        CD_Datos objDatos = new CD_Datos();
        CD_Producto objProducto = new CD_Producto();
        int idbauche = 0;

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

        public string CargarProductos()
        {
            string uso = string.Empty;
            Factura oFactura = new Factura() { bauche = new Bauche() { Idbauche = Convert.ToInt32(lbIdFactura.Text) } };
            dataGridProductos.DataSource = objFactura.CargarProductos(oFactura);
            dataGridProductos.Columns["idfactura"].Visible = false;
            dataGridProductos.Columns["cantidad"].Width = 80;
            dataGridProductos.Columns["producto"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            return uso;
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtBuscar.Text == "") return;
            Bauche oBauche = new Bauche();
            if (rdbCodigo.Checked)
            {
                oBauche.Codigo = Convert.ToInt32(txtBuscar.Text);
                dataGridBauche.DataSource = objCtrlBauche.BuscarBauCodigo(oBauche);
            }else if (rdbCliente.Checked)
            {
                string NombreCliente = txtBuscar.Text;
                dataGridBauche.DataSource = objCtrlBauche.BuscarBauCliente(NombreCliente);
            }else if (rdbMonto.Checked)
            {
                oBauche.Monto = Convert.ToDouble(txtBuscar.Text);
                dataGridBauche.DataSource = objCtrlBauche.BuscarBauMonto(oBauche);
            }
           
        }

        private void bntGuardar_Click(object sender, EventArgs e)
        {
            Bauche oBauche = new Bauche()
            {
                Codigo = Convert.ToInt32(txtCodigo.Text),
                Fecha = txtFecha.Text,
                Monto = Convert.ToDouble(txtMonto.Text),
                Banco = Convert.ToInt32(cbBanco.SelectedValue),
                cliente = new Cliente(){ Id =Convert.ToInt32(cbCliente.SelectedValue) },
                Estado = cbEstado.Text,
                Observacion = txtObervaciones.Text
            };
                      
            if (operacion == "Insertar")
            {   
                if(cbCliente.SelectedValue == null)
                {
                    DialogResult resultado = MessageBox.Show("Cliente No Esta Registrado", "Registrar Cliente?", MessageBoxButtons.OKCancel);

                    if (resultado == DialogResult.OK)
                    {
                        btnCliente_Click(sender, e);
                        oBauche.cliente.Id = Convert.ToInt32(cbCliente.SelectedValue);
                    }
                }              
                
                string error = objCtrlBauche.AgregarBauche(oBauche);
                if(error != "")
                {
                    MessageBox.Show(error);
                }
                //objCtrlBauche.AumentarMontoBanco(oBauche);
                               
            }
            else if (operacion == "Editar")
            {
                if (cbCliente.SelectedValue == null)
                {
                    DialogResult resultado = MessageBox.Show("Cliente No Esta Registrado", "Registrar Cliente?", MessageBoxButtons.OKCancel);

                    if (resultado == DialogResult.OK)
                    {
                        btnCliente_Click(sender, e);
                        oBauche.cliente.Id = Convert.ToInt32(cbCliente.SelectedValue);
                    }
                }
                oBauche.Idbauche = Convert.ToInt32(lbIdFactura.Text);
                objCtrlBauche.EditarBauche(oBauche);
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
            
            cbCliente.DataSource = objCliente.ListarCliente();
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
            cbProducto.DataSource = objProducto.ListarProductos();
            cbProducto.DisplayMember = "producto";
            cbProducto.ValueMember = "idproducto";
        }

        private AutoCompleteStringCollection AutoListarProductos()
        {
            CtrlBauche objCtrl = new CtrlBauche();
            DataTable tabla = new DataTable();
            tabla = objProducto.ListarProductos();
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
                idbauche = Convert.ToInt32(lbIdFactura.Text);
                Bauche oBauche = new Bauche()
                {
                    Idbauche = Convert.ToInt32(lbIdFactura.Text)
                };
                string error = objCtrlBauche.VerificarBaucheVentaD(oBauche);
                if (error != string.Empty)
                {
                    MessageBox.Show(error);
                }
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
            Cliente oCliente = new Cliente()
            {
                NombreCliente = cbCliente.Text,
                Direccion = txtDireccion.Text
            };
            string dato;
            dato = cbCliente.Text;
            objCliente.AgregarCliente(oCliente);
            ListarClientes();
            cbCliente.Text = dato;
        }

        private void bntAgregarP_Click(object sender, EventArgs e)
        {
            if (operacion == "Editar")
            {
                int idproducto = Convert.ToInt32(cbProducto.SelectedValue);
                Factura oFactura = new Factura()
                {
                    bauche = new Bauche() { Idbauche = Convert.ToInt32(lbIdFactura.Text) },
                    producto = new Producto() { Idproducto = Convert.ToInt32(cbProducto.SelectedValue) } ,
                    Cantidad = Convert.ToDouble(txtCantProd.Text),
                    PrecioP = Convert.ToDouble(txtPrecio.Text)
                };
                
                
                objFactura.AgregarProFactura(oFactura);
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
                else if (idproducto == 9)
                {
                    AgregarCausa Acausa = new AgregarCausa();
                    Acausa.ShowDialog();
                }
                if (idproducto == 7)
                {
                    /*bau.Idcuenta = 1;
                    bau.Monto = Convert.ToDouble(txtCantProd.Text);
                    objCtrlBauche.DisminuirMontoBanco(bau);*/
                }
            }else
            {
                MessageBox.Show("Selecione un Bauche");
            }
            txtCantProd.Text = "1";
            cbProducto.Focus();
            if(Convert.ToDouble(lblDisponible.Text) < 1)
            {
                cbEstado.Text = "Cancelada";
            }
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
            if(cbProducto.SelectedIndex > 0)
            {
                int idProducto = Convert.ToInt32(cbProducto.SelectedValue);
                
                txtPrecio.Text = objProducto.LLenartxtPrecio(idProducto);
            }
            else
            {
                txtPrecio.Text = "1,25";
            }
            txtCantProd.Focus();
        }


        private void cbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (operacion == "Editar")
            {
                if (cbCliente.SelectedIndex > 0)
                {
                    int dato = Convert.ToInt32(cbCliente.SelectedValue);
                    txtDireccion.Text = objCtrlBauche.CompletarTxtDireccion(dato);
                    if (objCtrlBauche.VerificarClienteCredito(dato))
                    {
                        MessageBox.Show("Cliente Tiene Deuda en Credito","Mensaje",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    };
                    string verificar = objCtrlBauche.VerificarBaucheDeuda(dato);
                    if (verificar != string.Empty)
                    {
                     MessageBox.Show(verificar);
                    }
                    List<PendCobrarBs> lista = new CD_PendCobrarBs().ConsultarDeuda();
                    double montoTotalDeuda = (from d in lista where d.oCliente.Id == Convert.ToInt32(cbCliente.SelectedValue) select d.Total).FirstOrDefault();
                    if (montoTotalDeuda > 0)
                    {
                        Form existe = Application.OpenForms.OfType<Form>().Where(pre => pre.Name == "Md_PendCobrar").SingleOrDefault<Form>();
                        if(existe == null)
                        {
                            Form deuda = new Md_PendCobrar(cbCliente.SelectedIndex, Convert.ToInt32(lbIdFactura.Text), Convert.ToDouble(txtMonto.Text));
                            deuda.Show();
                        }

                    }

                    if (operacion == "Editar")
                    {
                        Bauche oBauche = new Bauche()
                        {
                        Codigo = Convert.ToInt32(txtCodigo.Text),
                        Fecha = txtFecha.Text,
                        Monto = Convert.ToDouble(txtMonto.Text),
                        Banco = Convert.ToInt32(cbBanco.SelectedValue),
                        cliente = new Cliente() { Id= Convert.ToInt32(cbCliente.SelectedValue) },
                        Estado = cbEstado.Text,
                        Observacion = txtObervaciones.Text,
                        Idbauche = Convert.ToInt32(lbIdFactura.Text)
                        };
                    objCtrlBauche.EditarBauche(oBauche);

                    }
                }
            }
        }

        private void txtPrecioDolar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                Datos oDatos = new Datos() { PrecioDolar = Convert.ToDouble(txtPrecioDolar.Text) };
                objDatos.CambiarPrecioDolar(oDatos);
            }
        }

        private void btnEstado_Click(object sender, EventArgs e)
        {
            Bauche oBauche = new Bauche() { Estado = cbEstado.Text };
            dataGridBauche.DataSource = objCtrlBauche.BuscarBauEstado(oBauche);
        }

        private void btnEliminarPro_Click(object sender, EventArgs e)
        {
            if (dataGridBauche.SelectedRows.Count > 0)
            {
                DialogResult resultado = MessageBox.Show("Se Borrara El Producto", "Eliminar?", MessageBoxButtons.OKCancel);

                if (resultado == DialogResult.OK)
                {
                    Factura oFactura = new Factura() {Idfactura = Convert.ToInt32(dataGridProductos.CurrentRow.Cells[0].Value) };
                    objFactura.BorrarProFactura(oFactura);
                    CargarProductos();
                    calcularFactura();
                }
               
            }
           
        }

        private void txtCantProd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                bntAgregarP_Click(sender, e);
            }
        }

        private void btnVentaDv_Click(object sender, EventArgs e)
        {
            if (dataGridBauche.SelectedRows.Count > 0)
            {
                int bauche = Convert.ToInt32(dataGridBauche.CurrentRow.Cells["idBauche"].Value);
                double Monto = Convert.ToDouble(dataGridBauche.CurrentRow.Cells["monto"].Value);
                Md_VentaDv Venta = new Md_VentaDv(bauche, Monto);
                Venta.Show();
            }
            else
            {
                MessageBox.Show("Seleccione un Bauche","Informacion",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
            
        }

        private void btnDeuda_Click(object sender, EventArgs e)
        {
            Form Pcbs = new Md_PendCobrar(Convert.ToInt32(cbCliente.SelectedIndex));
            Pcbs.Show();
        }
    }   

}
