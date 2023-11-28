using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDADES
{
    public class RespuestaCliente
    {
        public int IdRc { get; set; }
        public DateTime fechaEncuesta { get; set; }
        public RespuestaPosible respuestaPosible { get; set; }

    }
}
