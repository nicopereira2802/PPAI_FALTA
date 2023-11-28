using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTIDADES;
using DATOS;


namespace NEGOCIO
{
    public class CN_Encuesta
    {
        private CD_Encuesta objcd_encuesta = new CD_Encuesta();

        public Encuesta ObtenerEncuesta(int Ide)
        {
            return objcd_encuesta.ObtenerEncuesta(Ide);
        }
    }
}
