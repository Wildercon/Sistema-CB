using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Compra
    {
        public int Idcompra { get; set; }
        public Cliente Cliente { get; set; }
        public double Monto { get; set; }
        public string Fecha { get; set; }
        public string Refencia { get; set; }
        public string Estado { get; set; }
    }
}
