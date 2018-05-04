using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace taller_de_validaciones.Elementos
{
   public class RPS
    {
        public string Nombre { get;set;}
        public long NumeroDocumento { get; set; }
        internal TipoDocumento TipoDocumento { get; set; }
        internal Rango Rango { get; set; }
        public long CostoServicio { get; set; }

    }
}
