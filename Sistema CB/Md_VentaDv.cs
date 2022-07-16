using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDatos;
using CapaEntidad;

namespace Sistema_CB
{
    public partial class Md_VentaDv : Form
    {
        string fecha = DateTime.Now.ToShortDateString();
        int bauche = 0;
        double Monto = 0;
        CtrlBauche objCtrlBauche = new CtrlBauche();
        CD_Venta objVenta = new CD_Venta();
        CD_Vendedor objVendedor = new CD_Vendedor();
        public Md_VentaDv(int Bauche,double Montobs)
        {
            InitializeComponent();
            bauche = Bauche;
            Monto = Montobs;
        }

        private void Md_VentaDv_Load(object sender, EventArgs e)
        {

            double PrecioD = Convert.ToDouble(objCtrlBauche.MostrarPreciodolar());
            txtBauche.Text = bauche.ToString();
            txtMontoBs.Text = Monto.ToString();
            txtMontoDv.Text = (Monto / PrecioD).ToString();
            ListarVendedores();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            bool Verificar = objVenta.verificarBaucheRepetidoVenta(Convert.ToInt32(txtBauche.Text));
            if (Verificar)
            {
                MessageBox.Show("Ya se Registro este Codigo");
            }
            else
            {
                CapaEntidad.Venta oVenta = new CapaEntidad.Venta()
                {
                    Bauche = new Bauche() { Idbauche = Convert.ToInt32(txtBauche.Text) },
                    Monto = Convert.ToDouble(txtMontoDv.Text),
                    Vendedor = new Vendedor() { Idvendedor = Convert.ToInt32(cbVendedor.SelectedValue) },
                    Fecha = fecha,
                    Estado = "+",
                };
                objVendedor.AumentarMontoVendedor(oVenta);
                oVenta.Total = objVendedor.ControlMontoV(oVenta);
                objVenta.AgregarVenta(oVenta);
                this.Close();
            }

            

        }

        private void ListarVendedores()
        {
            cbVendedor.DataSource = objVendedor.ListarVendedores();
            cbVendedor.DisplayMember = "Vendedor";
            cbVendedor.ValueMember = "idvendedor";
        }
       
    }
}
