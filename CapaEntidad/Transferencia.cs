using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Transferencia
    {
        public int Idtransferencia { get; set; }
        public string Beneficiario { get; set; }
        public string Cuenta { get; set; }
        public int Cedula { get; set; }
        public string Banco { get; set; }
        public double Monto { get; set; }
        public Cliente Cliente { get; set; }
        public string Referencia { get; set; }
        public string Fecha { get; set; }
    }
}
