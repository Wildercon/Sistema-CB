using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Factura
    {
        public int Idfactura { get; set; }
        public Bauche bauche { get; set; }
        public double Cantidad { get; set; }
        public Producto producto { get; set; }
        public string Fecha { get; set; }
    }
}
