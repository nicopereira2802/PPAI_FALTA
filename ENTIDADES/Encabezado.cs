using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDADES
{
    public class Encabezado
    {
        public string Nombre { get; set; }

        public string Estado { get; set; }
        public string Duracion { get; set; }

        public Encabezado(string nombre, string estado, string duracion)
        {
            Nombre = nombre;
            Estado = estado;
            Duracion = duracion;
        }
    }
}
