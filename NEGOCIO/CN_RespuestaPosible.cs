using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTIDADES;
using DATOS;

namespace NEGOCIO
{
    public class CN_RespuestaPosible
    {
        private CD_RespuestaPosible objcd_cliente = new CD_RespuestaPosible();

        public RespuestaPosible ObtenerRespuestaPosible(int idResPos)
        {
            return objcd_cliente.ObtenerRespuestaPosible(idResPos);
        }
    }
}
