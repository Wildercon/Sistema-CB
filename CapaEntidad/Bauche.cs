using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Bauche
    {
        public int Idbauche { get; set; }
        public int Codigo { get; set; }
        public string Fecha { get; set; }
        public double Monto { get; set; }
        public int Banco { get; set; }
        public Cliente cliente { get; set; }
        public string Estado { get; set; }
        public string Observacion { get; set; }

    }
}
