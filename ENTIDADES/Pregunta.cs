using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDADES
{
    public class Pregunta

    {
        public int iDPreg { get; set; }
        public string descripcion { get; set; }
        public List<RespuestaPosible> respuestaP { get; set; }

        public Encuesta encuesta { get; set; }

    }
}
