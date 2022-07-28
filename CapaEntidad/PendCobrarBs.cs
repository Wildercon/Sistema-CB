using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class PendCobrarBs
    {
        public Cliente oCliente { get; set; }
        public double MontoDeuda { get; set; }
        public double Total { get; set; }
        public string Op { get; set; }
        public string Detalle { get; set; }
        public string Fecha { get; set; }

    }
}
