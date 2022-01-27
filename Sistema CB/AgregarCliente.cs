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
    public partial class AgregarCliente : Form
    {
        CtrlBauche objCtrlBauche = new CtrlBauche();
        public AgregarCliente()
        {
            InitializeComponent();
        }

        private void AgregarCliente_Load(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Bauche bau = new Bauche();
            bau.Cliente = txtCliente.Text;
            bau.Direccion = txtDireccion.Text;
            objCtrlBauche.AgregarCliente(bau);
            txtCliente.Text = "";
            txtDireccion.Text = "";
        }
    }
}
