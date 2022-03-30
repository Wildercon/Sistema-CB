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
        }

        private void MostrarCuentas()
        {
            dataGridCuentas.DataSource = objCtrlbauche.CargarGananciaVentas();
            dataGridCuentas.Columns["cantidad"].Width = 60;
           // dataGridCuentas.Columns["banco"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
