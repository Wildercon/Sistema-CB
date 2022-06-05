using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Causa
    {
        public int Idcausa { get; set; }
        public int Idcliente { get; set; }
        public int Grupo { get; set; }
        public string Cod_Billete { get; set; }
        public string Observacion { get; set; }
    }
}
