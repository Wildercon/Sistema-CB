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
    public partial class Md_PendCobrar : Form
    {
        int IndexClient = 0;
        int Bauche = 0;
        double MontoBauche;
        public Md_PendCobrar(int cliente)
        {
            InitializeComponent();
            IndexClient = cliente;
        }
        public Md_PendCobrar(int cliente, int bauche, double montoBauche)
        {
            InitializeComponent();
            IndexClient = cliente;
            Bauche = bauche;
            MontoBauche = montoBauche;
        }

        private void Md_PendCobrar_Load(object sender, EventArgs e)
        {
            ListarCliente();
            cb_Cliente.SelectedIndex = IndexClient;
        }

        private void ListarDeuda()
        {
            dataGridPendCobrar.Rows.Clear();
            List<PendCobrarBs> list = new CD_PendCobrarBs().ConsultarDeuda();

            if(cb_Cliente.SelectedIndex > 0)
            {

                foreach (PendCobrarBs item in list.Where(e => e.oCliente.Id == Convert.ToInt32(cb_Cliente.SelectedValue)))
                    dataGridPendCobrar.Rows.Add(new object[] { item.Fecha, item.Detalle, item.Op, item.MontoDeuda, item.Total });
            }
            
        }
        private void ListarCliente()
        {
            cb_Cliente.DataSource = new CD_Cliente().ListarCliente();
            cb_Cliente.DisplayMember = "cliente";
            cb_Cliente.ValueMember = "id";
            cb_Cliente.AutoCompleteCustomSource = AutoListarClientes();
            cb_Cliente.AutoCompleteMode = AutoCompleteMode.Suggest;
            cb_Cliente.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }
        private AutoCompleteStringCollection AutoListarClientes()
        {
            DataTable tabla = new DataTable();
            tabla = new CD_Cliente().ListarCliente();
            AutoCompleteStringCollection dato = new AutoCompleteStringCollection();

            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                string dator;
                dator = tabla.Rows[i]["cliente"].ToString();
                dato.Add(dator);
            }
            return dato;
        }

        private void cb_Cliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListarDeuda();
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            string verificar = string.Empty;
            if (cb_Op.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione Tipo de operacion ");
                return;
            }
            if (txtMonto.Text == String.Empty || txtMonto.Text == "0" )
            {
                MessageBox.Show("Ingresar monto Valido");
                return;
            }
            if(txtDetalle.Text == String.Empty)
            {
                MessageBox.Show("Debe Introducir un Detalle");
                return;
            }
            List<PendCobrarBs> lista = new CD_PendCobrarBs().ConsultarDeuda();
            double montoTotalDeuda = (from d in lista where d.oCliente.Id == Convert.ToInt32(cb_Cliente.SelectedValue) select d.Total).FirstOrDefault();
            PendCobrarBs oPendCobrarBs = new PendCobrarBs()
            {
                oCliente = new Cliente { Id = Convert.ToInt32(cb_Cliente.SelectedValue) },
                MontoDeuda = Convert.ToDouble(txtMonto.Text),
                Detalle = txtDetalle.Text,
                Op = cb_Op.Text,
            };
            if (cb_Op.SelectedIndex == 0)
            {
                oPendCobrarBs.Total = Convert.ToDouble(txtMonto.Text) + montoTotalDeuda;
                verificar = new CD_PendCobrarBs().agregarDeuda(oPendCobrarBs);
                if (verificar != string.Empty) MessageBox.Show(verificar);
            }
                
                
            else if (cb_Op.SelectedIndex == 1)
            {
                if (Convert.ToDouble(txtMonto.Text) > MontoBauche)
                {
                    MessageBox.Show("El monto o puede ser mayor al bauche");
                    return;
                }
                oPendCobrarBs.Total = montoTotalDeuda - Convert.ToDouble(txtMonto.Text);
                verificar = new CD_PendCobrarBs().agregarDeuda(oPendCobrarBs);
                if (verificar != string.Empty) MessageBox.Show(verificar);
                else
                {
                    var ofactura = new Factura()
                    {
                        producto = new Producto() { Idproducto = 76 },
                        Cantidad = Convert.ToInt32(txtMonto.Text),
                        bauche = new Bauche() { Idbauche = Bauche },
                        PrecioP = 1
                    };
                    CD_Factura agregarD = new CD_Factura();
                    agregarD.AgregarProFactura(ofactura);
                }
            }
                
            
            
            ListarDeuda();
        }


    }
}
