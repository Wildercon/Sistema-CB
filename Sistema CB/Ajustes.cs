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
    public partial class Ajustes : Form
    {
        CtrlBauche objCtrlBauche = new CtrlBauche();
        CD_Producto objProducto = new CD_Producto();
        CD_Vendedor objVendedor = new CD_Vendedor();
        CD_Cuentas objCuentas = new CD_Cuentas();
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
                Producto oProducto = new Producto()
                {
                    Idproducto = Convert.ToInt32(cbProducto.SelectedValue),
                    Precio = Convert.ToDouble(txtPrecio.Text)
                };
                objProducto.EditarProducto(oProducto);
                MessageBox.Show("Se Edito Correctamente");

            }
            else
            {
                Producto oProducto = new Producto()
                {
                    producto = cbProducto.Text,
                    Precio = Convert.ToDouble(txtPrecio.Text)
                };
                objProducto.AgregarProducto(oProducto);
                MessageBox.Show("Registro Exitoso");
            }
            ListarProductos();
        }

        private void ListarProductos()
        {
            cbProducto.DataSource = objProducto.ListarProductos();
            cbProducto.DisplayMember = "producto";
            cbProducto.ValueMember = "idproducto";
        }

        private void cbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbProducto.SelectedIndex > 0)
            {
                int dato = Convert.ToInt32(cbProducto.SelectedValue);
                txtPrecio.Text = objProducto.LLenartxtPrecio(dato);
            }
            else
            {
                txtPrecio.Text = "";
            }           
        }

        private void btnEliminarVendedor_Click(object sender, EventArgs e)
        {
            Vendedor oVendedor = new Vendedor() { Idvendedor = Convert.ToInt32(cbVendedor.SelectedValue) };
            objVendedor.EliminarVendedor(oVendedor);
            ListarVendedores();
        }

        private void btnEliminarProducto_Click(object sender, EventArgs e)
        {
            Producto oProducto = new Producto() { Idproducto = Convert.ToInt32(cbProducto.SelectedValue) };
            objProducto.EliminarProducto(oProducto);
            ListarProductos();
        }

        private void btnGuardarVendedor_Click(object sender, EventArgs e)
        {
            if(cbVendedor.SelectedIndex >= 0)
            {
                Vendedor oVendedor = new Vendedor()
                {
                    Idvendedor = Convert.ToInt32(cbVendedor.SelectedValue),
                    Monto = Convert.ToDouble(txtMontoVendedor.Text)
                };
                objVendedor.EditarMontoVendedor(oVendedor);
            }
            else
            {
                Vendedor oVendedor = new Vendedor()
                {
                    vendedor = cbVendedor.Text,
                    Monto = Convert.ToDouble(txtMontoVendedor.Text)
                };
                objVendedor.AgregarVendedor(oVendedor);
            }
            ListarVendedores();
        }

        private void ListarVendedores()
        {
            cbVendedor.DataSource = objVendedor.ListarVendedores();
            cbVendedor.DisplayMember = "Vendedor";
            cbVendedor.ValueMember = "idvendedor";
        }

        private void btnGuardarCuenta_Click(object sender, EventArgs e)
        {
            CapaEntidad.Cuentas oCuentas = new CapaEntidad.Cuentas()
            {
                Idcuenta = Convert.ToInt32(cbCuentas.SelectedValue),
                Monto = Convert.ToDouble(txtMontoCuenta.Text),
                Banco = cbCuentas.Text
            };
            if (cbCuentas.SelectedIndex >= 0)
            {
                objCuentas.EditarCuenta(oCuentas);
            }
            else
            {
                objCuentas.AgregarCuenta(oCuentas);
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
            CapaEntidad.Cuentas oCuentas = new CapaEntidad.Cuentas() { Idcuenta = Convert.ToInt32(cbCuentas.SelectedValue) };
            objCuentas.EliminarCuenta(oCuentas);
            ListarCuentas();
        }
    }  
}
