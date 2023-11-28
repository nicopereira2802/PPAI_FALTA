using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDADES
{
    public class Llamada
        
    {
        public int Idll { get; set; }
        public string descripcionOperador { get; set; }
        public string detalleEncuesta { get; set; }
        // es int o datetime 
        public int duracion { get; set; }
        public bool encuestaEnviada { get; set; }
        public Cliente cliente { get; set; }

        public List<CambioEstado> cambiosEstados { get; set; }

        public List<RespuestaCliente> respuestaDeEncuesta { get; set; }

    }
}
