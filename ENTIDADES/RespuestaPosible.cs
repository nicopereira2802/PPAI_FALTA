using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDADES
{
    public class RespuestaPosible
    {
        public int IdRespos { get; set; }
        public string descripcion { get; set; }
        public int valor { get; set; }

        public Pregunta pregunta { get; set; }
    }
}
