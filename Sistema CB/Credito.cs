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
    public partial class Credito : Form
    {
        CtrlBauche objCtrl = new CtrlBauche();
        CD_Cliente objCliente = new CD_Cliente();
        CD_Credito objCredito = new CD_Credito();
        CD_Producto objProducto = new CD_Producto();
        string fecha = DateTime.Now.ToShortDateString();
        public Credito()
        {
            InitializeComponent();
            ListarProducto();
            ListarClientes();
            CargarDeudores();
            cbCliente.AutoCompleteCustomSource = AutoListarClientes();
            cbCliente.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbCliente.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cbProducto.AutoCompleteCustomSource = AutoListarProductos();
            cbProducto.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbProducto.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtCantProd.Text = "1";
        }

        private void ListarClientes()
        {
            
            cbCliente.DataSource = objCliente.ListarCliente();
            cbCliente.DisplayMember = "cliente";
            cbCliente.ValueMember = "id";
        }

        private void ListarProducto()
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

        private void CargarProCre()
        {
            CapaEntidad.Credito oCredito = new CapaEntidad.Credito(){ Cliente = new Cliente(){Id = Convert.ToInt32(cbCliente.SelectedValue) } };
            dataGridProductos.DataSource = objCredito.CargarProCre(oCredito);
            dataGridProductos.Columns["idcredito"].Visible = false;
            dataGridProductos.Columns["Fecha"].Width = 70;
            dataGridProductos.Columns["cantidad"].Width = 70;
            dataGridProductos.Columns["precio"].Width = 50;
            dataGridProductos.Columns["total"].Width = 50;
            dataGridProductos.Columns["producto"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            double suma = 0;
            foreach (DataGridViewRow row in dataGridProductos.Rows)
            {
                if (row.Cells["Total"].Value != null)
                    suma += (double)row.Cells["Total"].Value;
            }
            lblTotal.Text = Convert.ToString(suma);
        }
            
        private void CargarDeudores()
        {
            dataGridListaD.DataSource = objCtrl.CargarDeudores();
            dataGridListaD.Columns["cliente"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }


        private void bntAgregarP_Click(object sender, EventArgs e)
        {
            CapaEntidad.Credito oCredito = new CapaEntidad.Credito()
            {
                Fecha = fecha,
                Cliente = new Cliente() { Id = Convert.ToInt32(cbCliente.SelectedValue) },
                Producto = new Producto() { Idproducto = Convert.ToInt32(cbProducto.SelectedValue) },
                Cantidad = Convert.ToDouble(txtCantProd.Text)
            };
            objCredito.AgregarProCre(oCredito);
            CargarProCre();
            txtCantProd.Text = "1";
            CargarDeudores();
        }


        private void cbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbCliente.SelectedIndex > 0)
            {
                CargarProCre();
            }
        }

        private void txtCantProd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                bntAgregarP_Click(sender, e);
            }
        }

        private void BtnEliminarPro_Click(object sender, EventArgs e)
        {
            if (dataGridProductos.SelectedRows.Count > 0)
            {
                CapaEntidad.Credito oCredito = new CapaEntidad.Credito() { Idcredito = Convert.ToInt32(dataGridProductos.CurrentRow.Cells[0].Value) };
                objCredito.QuitarProCre(oCredito);
                CargarProCre();
            }
        }


    }
}
