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
    public partial class AgregarCliente : Form
    {
        CD_Cliente objCliente= new CD_Cliente();
        public AgregarCliente()
        {
            InitializeComponent();
        }

        private void AgregarCliente_Load(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Cliente oCliente = new Cliente()
            {
                NombreCliente = txtCliente.Text ,
                Direccion = txtDireccion.Text
            };
            objCliente.AgregarCliente(oCliente);
            txtCliente.Text = "";
            txtDireccion.Text = "";
        }
    }
}
