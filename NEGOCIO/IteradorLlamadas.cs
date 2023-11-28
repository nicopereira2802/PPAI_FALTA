using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTIDADES;

namespace NEGOCIO
{
    public class IteradorLlamadas: IIterador
    {
        private Llamada[] llamadas;
        private int posicionActual;

        public IteradorLlamadas(Llamada[] llamadas)
        {
            this.llamadas = llamadas;
            this.posicionActual = 0;
        }

        public void primero()
        {
            posicionActual = 0;
        }

        public bool haTerminado()
        {
            return posicionActual >= llamadas.Length;
        }

        public object actual()
        {
            return haTerminado() ? null : llamadas[posicionActual];
        }

        public void siguiente()
        {
            posicionActual++;
        }

        public bool cumpleFiltro(List<DateTime> filtros)
        {
            foreach(Llamada llamada in llamadas)
            {
                bool var5 = new CN_Llamada().esDePeriodo(filtros[0], filtros[1],llamada);
            }    
            
            
        }
       
    }
}
