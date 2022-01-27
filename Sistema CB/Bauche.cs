using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_CB
{
    class Bauche
    {  
        private int idBauche;
        private int codigo;
        private string fecha;
        private double monto;
        private string banco;
        private int idCliente;
        private string estado;
        private string observaciones;
        private string cliente;
        private string direccion;
        private int IdFactura;
        private string Producto;
        private double PrecioProducto;
        private int idProducto;
        private double cantidad;
        private int idtransferencia;
        private string beneficiario;
        private string cuenta;
        private int cedula;
        private string referencia;
        private string idtxt;
        private int grupo;
        private string codbillete;
        private string vendedor;
        private int idvendedor;
        private double montovendedor;
        private double preciodolar;
        private int idcuenta; 

        public int IdBauche { get => idBauche; set => idBauche = value; }
        public int Codigo { get => codigo; set => codigo = value; }
        public string Fecha { get => fecha; set => fecha = value; }
        public double Monto { get => monto; set => monto = value; }
        public int IdCliente { get => idCliente; set => idCliente = value; }
        public string Estado { get => estado; set => estado = value; }
        public string Observaciones { get => observaciones; set => observaciones = value; }
        public string Banco { get => banco; set => banco = value; }
        public string Cliente { get => cliente; set => cliente = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public int IdFactura1 { get => IdFactura; set => IdFactura = value; }
        public string Producto1 { get => Producto; set => Producto = value; }
        public double PrecioProducto1 { get => PrecioProducto; set => PrecioProducto = value; }
        public int IdProducto { get => idProducto; set => idProducto = value; }
        public double Cantidad { get => cantidad; set => cantidad = value; }
        public int Idtransferencia { get => idtransferencia; set => idtransferencia = value; }
        public string Beneficiario { get => beneficiario; set => beneficiario = value; }
        public string Cuenta { get => cuenta; set => cuenta = value; }
        public int Cedula { get => cedula; set => cedula = value; }
        public string Referencia { get => referencia; set => referencia = value; }
        public string Idtxt { get => idtxt; set => idtxt = value; }
        public int Grupo { get => grupo; set => grupo = value; }
        public string Codbillete { get => codbillete; set => codbillete = value; }
        public string Vendedor { get => vendedor; set => vendedor = value; }
        public int Idvendedor { get => idvendedor; set => idvendedor = value; }
        public double Montovendedor { get => montovendedor; set => montovendedor = value; }
        public double Preciodolar { get => preciodolar; set => preciodolar = value; }
        public int Idcuenta { get => idcuenta; set => idcuenta = value; }
    }
}
