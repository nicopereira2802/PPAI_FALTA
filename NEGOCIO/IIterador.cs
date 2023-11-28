using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEGOCIO
{
    public interface IIterador
    {
        // Devuelve el elemento actual del iterador.
        object actual();

        // Verifica si el iterador ha terminado de recorrer la colección.
        bool haTerminado();

        // Posiciona el iterador en el primer elemento de la colección.
        void primero();

        // Mueve el iterador al siguiente elemento de la colección.
        void siguiente();
    }
}
