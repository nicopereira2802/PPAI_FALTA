using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDADES
{
    public class CambioEstado
    {
        public int IdCam { get; set; }
        public DateTime fechaHoraInicio { get; set;}
        public Estado estado { get; set; }

    }
}
