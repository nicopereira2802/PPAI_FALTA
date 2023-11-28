using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTIDADES;
using DATOS;

namespace NEGOCIO
{
    public class CN_Estado
    {
        private CD_Estado objcd_estado = new CD_Estado();

        public List<Estado> Listar()
        {
            return objcd_estado.Listar();
        }

        public Estado ListarIdCambio(int IdE)
        {
            return objcd_estado.ListarIdCambio(IdE);
        }

        public void esFinalizada(String condicion)
        {
            Listar();
        }
    }
}
