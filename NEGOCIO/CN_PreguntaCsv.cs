using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTIDADES;

namespace NEGOCIO
{
    public class CN_PreguntaCsv
    {
        public List<PreguntaCsv> ConvertirLista(List<string> preguntasYRespuestas)
        {
            List<PreguntaCsv> listaDePreguntas = new List<PreguntaCsv>();
            int x = 0;
            for (int i = 0; i < preguntasYRespuestas.Count; i++)
            {
                if (x == 1)
                {
                    // Crear una instancia de la clase Pregunta y agregarla a la lista
                    listaDePreguntas.Add(new PreguntaCsv
                    {
                        Respuesta = preguntasYRespuestas[i-1],
                        Descripcion  = preguntasYRespuestas[i],
                        Cierre = "*",
                    });
                    x = -1;
                }
                x++;
            }

            return listaDePreguntas;
        }
    }
}
