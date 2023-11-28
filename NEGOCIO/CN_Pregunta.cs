using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTIDADES;
using DATOS;

namespace NEGOCIO
{
    public class CN_Pregunta
    {
        private CD_Pregunta objcd_cliente = new CD_Pregunta();

        public Pregunta ObtenerPregunta(int IDp)
        {
            return objcd_cliente.ObtenerPregunta(IDp);
        }
    }
}
