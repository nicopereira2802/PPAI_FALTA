using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using ENTIDADES;
using DATOS;


namespace NEGOCIO
{
    public class CN_Llamada
    {
        private CD_Llamada objcd_llamada = new CD_Llamada();

        public List<Llamada> Listar()
        {
            return objcd_llamada.Listar();
        }

        public CambioEstado determinarUltimoCambioEstado(Llamada llamada)
        {
            List<CambioEstado> cambios = new List<CambioEstado>();
            cambios = new CN_CambioEstado().Listar(llamada.Idll);
            CambioEstado ultimo = new CambioEstado();

            foreach (CambioEstado cambioEstado in cambios)
            {
                /*
                bool var1 = new CN_CambioEstado().GetNombreEstado(cambioEstado);
         
                if (var1 == true)
                {
                    DateTime var2 = cambioEstado.fechaHoraInicio;
                    if (var2 >= fechainicio && var2 <= fechafin)
                    {
                        bool var3 = llamada.encuestaEnviada;
                        if (var3 == true)
                        {
                            return true;
                        }
                    }
                }*/
                if(ultimo == null)
                {
                    ultimo = cambioEstado;
                }
                else
                {
                    DateTime var1 = new CN_CambioEstado().GetFechaCambio(cambioEstado);
                    DateTime var2 = new CN_CambioEstado().GetFechaCambio(ultimo);
                    if(var1 > var2)
                    {
                        ultimo = cambioEstado;
                    }
                }
                
            }
          
            return ultimo;
        }

        public DateTime ObtenerFecha(List<CambioEstado> cambios)
        {
            DateTime primerFecha = new DateTime();
            bool Bandera = false;
            foreach (CambioEstado i in cambios)
            {
                if (Bandera == false)
                {
                    primerFecha = i.fechaHoraInicio;
                    Bandera = true;
                }
                else
                {
                    if (primerFecha > i.fechaHoraInicio)
                    {
                        primerFecha = i.fechaHoraInicio;
                    }
                }
            }
            return primerFecha;

        }
       
        public bool esDePeriodo(DateTime fechainicio, DateTime fechafin,Llamada llamada)
        {
            List<CambioEstado> cambios = new List<CambioEstado>();
            cambios = new CN_CambioEstado().Listar(llamada.Idll);
            DateTime fechaPrimero = ObtenerFecha(cambios);
            if (fechaPrimero >= fechainicio && fechaPrimero <= fechafin)
            {
                return true;
            }
            else
            {
                return false;
            }
         
        
            //CambioEstado ultimoCambio = determinarUltimoEstado(llamada);

          
        }

        public List<String> getDatos(Llamada llamada)
        {
            List<String> listaDeDatos = new List<String>();
            Cliente clienteDeLlamada = new CN_Cliente().ObtenerCliente(llamada.cliente.dni);
            String nombreCliente = clienteDeLlamada.nombreCompleto;
            
            //string clienteDeLlamada = this.cliente.getNombreCliente();
            CambioEstado ultimocambio = determinarUltimoCambioEstado(llamada);
            Estado ultimoEstado = new CN_Estado().ListarIdCambio(ultimocambio.estado.IdEst);
            String nombreUltimoEstado = ultimoEstado.nombre;


            int duracionLlamada = llamada.duracion;

            
            listaDeDatos.Add(nombreCliente);
            listaDeDatos.Add(nombreUltimoEstado);
            listaDeDatos.Add(Convert.ToString(duracionLlamada));

            
            return listaDeDatos;

        }

        public List<String> getRespuestas(Llamada llamada)
        {

            List<String> listaRespuestasPreEnc = new List<String>();
            List<RespuestaCliente> listaRespuestasLlamada = new CN_RespuestaCliente().Listar(llamada.Idll);

            foreach (RespuestaCliente respuestaC in listaRespuestasLlamada)
            {
                RespuestaPosible respuestaposible = new CN_RespuestaPosible().ObtenerRespuestaPosible(respuestaC.respuestaPosible.IdRespos);
                string descResp = respuestaposible.descripcion;
                listaRespuestasPreEnc.Add(descResp);

                Pregunta pregunta = new CN_Pregunta().ObtenerPregunta(respuestaposible.pregunta.iDPreg);
                string descPregunta = pregunta.descripcion;
                listaRespuestasPreEnc.Add(descPregunta);

                Encuesta encuesta = new CN_Encuesta().ObtenerEncuesta(pregunta.encuesta.idEnc);
                string descEnc = encuesta.descripcion;
                listaRespuestasPreEnc.Add(descEnc);

            }
            return listaRespuestasPreEnc;

        }
    }
}
