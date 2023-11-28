using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ENTIDADES;
using DATOS;

namespace NEGOCIO
{
    public class CN_RespuestaCliente
    {
        private CD_RespuestaCliente objcd_cliente = new CD_RespuestaCliente();

        public List<RespuestaCliente> Listar(int Idlla)
        {
            return objcd_cliente.Listar(Idlla);
        }
    }

}
