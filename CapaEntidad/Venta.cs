using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Venta
    {
        public int Idventa { get; set; }
        public Vendedor Vendedor { get; set; }
        public string Fecha { get; set; }
        public double Monto { get; set; }
        public Bauche Bauche { get; set; }
        public string Estado { get; set; }
        public double Total { get; set; }
    }
}
