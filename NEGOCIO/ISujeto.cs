using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEGOCIO
{
    public interface ISujeto
    {
        IIterador CrearIterador(object[] lista);
    }
}
