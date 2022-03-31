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
    public partial class Cuentas : Form
    {
        CtrlBauche objCtrlbauche = new CtrlBauche();
        string fecha = DateTime.Now.ToShortDateString();
        public Cuentas()
        {
            InitializeComponent();
        }

        private void Cuentas_Load(object sender, EventArgs e)
        {
            MostrarCuentas();
            lblMontoXCobrar.Text = objCtrlbauche.SumarCuentasXCobrar();
            lblRecibidobs.Text = objCtrlbauche.SumarRecibidoDia(fecha);
            lblVendidoD.Text = objCtrlbauche.SumarVendidoD(fecha);
            txtFecha.Text = fecha;
        }

        private void MostrarCuentas()
        {
            Bauche bau = new Bauche();
            bau.Fecha = txtFecha.Text;
            dataGridCuentas.DataSource = objCtrlbauche.CargarGananciaVentas(bau);
            dataGridCuentas.Columns["cantidad"].Width = 70;
            dataGridCuentas.Columns["Ganancia"].Width = 70;
            dataGridCuentas.Columns["precio"].Width = 70;
            dataGridCuentas.Columns["producto"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            double suma = 0 ;
            foreach (DataGridViewRow row in dataGridCuentas.Rows)
            {
                if (row.Cells["Ganancia"].Value != null)
                    suma += (double)row.Cells["Ganancia"].Value;
                lblGanBs.Text = Convert.ToString(suma);
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            MostrarCuentas();
        }
    }
}
