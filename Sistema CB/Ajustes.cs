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
    public partial class Ajustes : Form
    {
        CtrlBauche objCtrlBauche = new CtrlBauche();
        public Ajustes()
        {
            InitializeComponent();
        }

        private void Ajustes_Load(object sender, EventArgs e)
        {
            ListarCuentas();
            ListarProductos();
            ListarVendedores();
            cbProducto.SelectedIndex = -1;
            cbVendedor.SelectedIndex = -1;
            cbCuentas.SelectedIndex = -1;
        }


        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            if (cbProducto.SelectedIndex >= 0)
            {
                Bauche bau = new Bauche();
                bau.IdProducto = Convert.ToInt32(cbProducto.SelectedValue);
                bau.PrecioProducto1 = Convert.ToDouble(txtPrecio.Text);
                objCtrlBauche.EditarProducto(bau);
                MessageBox.Show("Se Edito Correctamente");

            }
            else
            {
                Bauche bau = new Bauche();
                bau.Producto1 = cbProducto.Text;
                bau.PrecioProducto1 = Convert.ToDouble(txtPrecio.Text);
                objCtrlBauche.AgregarProducto(bau);
                MessageBox.Show("Registro Exitoso");
            }
            ListarProductos();
        }

        private void ListarProductos()
        {
            cbProducto.DataSource = objCtrlBauche.ListarProductos();
            cbProducto.DisplayMember = "producto";
            cbProducto.ValueMember = "idproducto";
        }

        private void cbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbProducto.SelectedIndex > 0)
            {
                int dato = Convert.ToInt32(cbProducto.SelectedValue);
                txtPrecio.Text = objCtrlBauche.LLenartxtPrecio(dato);
            }
            else
            {
                txtPrecio.Text = "";
            }           
        }

        private void btnEliminarVendedor_Click(object sender, EventArgs e)
        {
            Bauche bau = new Bauche();
            bau.Idvendedor = Convert.ToInt32(cbVendedor.SelectedValue);
            objCtrlBauche.EliminarVendedor(bau);
            ListarVendedores();
        }

        private void btnEliminarProducto_Click(object sender, EventArgs e)
        {
            Bauche bau = new Bauche();
            bau.IdProducto = Convert.ToInt32(cbProducto.SelectedValue);
            objCtrlBauche.EliminarProducto(bau);
            ListarProductos();
        }

        private void btnGuardarVendedor_Click(object sender, EventArgs e)
        {
            if(cbVendedor.SelectedIndex >= 0)
            {
                Bauche bau = new Bauche();
                bau.Idvendedor = Convert.ToInt32(cbVendedor.SelectedValue);
                bau.Montovendedor = Convert.ToDouble(txtMontoVendedor.Text);
                objCtrlBauche.EditarMontoVendedor(bau);
            }
            else
            {
                Bauche bau = new Bauche();
                bau.Vendedor = cbVendedor.Text;
                bau.Montovendedor = Convert.ToDouble(txtMontoVendedor.Text);
                objCtrlBauche.AgregarVendedor(bau);
            }
            ListarVendedores();
        }

        private void ListarVendedores()
        {
            cbVendedor.DataSource = objCtrlBauche.ListarVendedores();
            cbVendedor.DisplayMember = "Vendedor";
            cbVendedor.ValueMember = "idvendedor";
        }

        private void btnGuardarCuenta_Click(object sender, EventArgs e)
        {
            Bauche bau = new Bauche();
            bau.Idcuenta = Convert.ToInt32(cbCuentas.SelectedValue);
            bau.Monto = Convert.ToDouble(txtMontoCuenta.Text);
            bau.Banco = cbCuentas.Text;
            if (cbCuentas.SelectedIndex >= 0)
            {
                objCtrlBauche.EditarCuenta(bau);
            }
            else
            {
                objCtrlBauche.AgregarCuenta(bau);
            }
            ListarCuentas();
        }

        private void ListarCuentas()
        {
            cbCuentas.DataSource = objCtrlBauche.ListarCuentas();
            cbCuentas.DisplayMember = "Banco";
            cbCuentas.ValueMember = "idcuenta";
        }

        private void btnEliminarCuenta_Click(object sender, EventArgs e)
        {
            Bauche bau = new Bauche();
            bau.Idcuenta = Convert.ToInt32(cbCuentas.SelectedValue);
            objCtrlBauche.EliminarCuenta(bau);
            ListarCuentas();
        }
    }  
}
