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
            CtrlBauche objCtrl = new CtrlBauche();
            cbCliente.DataSource = objCtrl.ListarCliente();
            cbCliente.DisplayMember = "cliente";
            cbCliente.ValueMember = "id";
        }

        private void ListarProducto()
        {
            cbProducto.DataSource = objCtrl.ListarProductos();
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

        private void CargarProCre()
        {
            Bauche bau = new Bauche();
            bau.IdCliente = Convert.ToInt32(cbCliente.SelectedValue);
            dataGridProductos.DataSource = objCtrl.CargarProCre(bau);
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
            Bauche bau = new Bauche();
            bau.Fecha = fecha;
            bau.IdCliente = Convert.ToInt32(cbCliente.SelectedValue);
            bau.IdProducto = Convert.ToInt32(cbProducto.SelectedValue);
            bau.Cantidad = Convert.ToDouble(txtCantProd.Text);
            objCtrl.AgregarProCre(bau);
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
                Bauche bau = new Bauche();
                bau.IdFactura1 = Convert.ToInt32(dataGridProductos.CurrentRow.Cells[0].Value);
                objCtrl.QuitarProCre(bau);
                CargarProCre();
            }
        }

    

      
    }
}
