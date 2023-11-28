using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDADES
{
    public class Encuesta

    {
        public int idEnc { get; set; }
        public string descripcion { get; set; }
        public List<Pregunta> pregunta { get; set; }

    }
}
