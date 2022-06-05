using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Credito
    {
        public int Idcredito { get; set; }
        public string Fecha { get; set; }
        public Cliente Cliente { get; set; }
        public Producto Producto { get; set; }
        public double Cantidad { get; set; }
    }
}
