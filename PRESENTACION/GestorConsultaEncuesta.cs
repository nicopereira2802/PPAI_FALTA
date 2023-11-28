using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ENTIDADES;
using NEGOCIO;
using System.Globalization;
using CsvHelper;
using System.IO;

namespace PRESENTACION
{
    public class GestorConsultaEncuesta:ISujeto
    {

		public IIterador CrearIterador(object[] llamadasDelGestor)
		{
			if (llamadasDelGestor != null && llamadasDelGestor.Length > 0 && llamadasDelGestor[0] is Llamada)
			{
				return new IteradorLlamadas((Llamada[])llamadasDelGestor);
			}
			else
			{
				// Puedes manejar otros tipos de objetos o devolver un iterador genérico según tus necesidades.
				return null;
			}

		}

		public List<Llamada> buscarLlamadasEncuestasRespondidas(DateTime fechainicio, DateTime fechafin)
		{
			List<Llamada> llamadasConEncuesta = new List<Llamada>();
			List<Llamada> llamadasDelGestor = new CN_Llamada().Listar();
			IIterador iterador = CrearIterador(llamadasDelGestor.ToArray());
			List<DateTime> filtro = new List<DateTime>();
			filtro.Add(fechainicio);
			filtro.Add(fechafin);

			while (iterador.haTerminado() != true)
			{
				Llamada llamadaActual = (Llamada)iterador.actual();
				foreach (Llamada llamada in llamadasDelGestor)
				{
					bool cumpleFiltros = iterador.cumpleFiltro(filtro);

					if (cumpleFiltros == true)
					{
						if (llamada.encuestaEnviada == true)
						{
							llamadasConEncuesta.Add(llamada);
						}
					}
					iterador.siguiente();
				}
			}
			return llamadasConEncuesta;
		}



		public List<Llamada> validarPeriodo(DateTime fechainicio, DateTime fechafin)
		{
			List<Llamada> llamadaCEncuesta = new List<Llamada>();
			if (fechainicio <= fechafin)
			{

				MessageBox.Show("¡Es fecha valida!", "Mensaje Informativo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				llamadaCEncuesta = buscarLlamadasEncuestasRespondidas(fechainicio, fechafin);
				return llamadaCEncuesta;

			}
			else
			{
				MessageBox.Show("¡ERROR,No Es fecha valida!", "Mensaje Informativo", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return llamadaCEncuesta;

			}
		}

		public List<List<string>> buscarDatosLlamada(Llamada llamadaSeleccionada)
		{
			List<List<string>> listaTotal = new List<List<string>>();
			List<string> lista1 = new List<String>();
			List<string> lista2 = new List<String>();

			lista1 = new CN_Llamada().getDatos(llamadaSeleccionada);


			lista2 = new CN_Llamada().getRespuestas(llamadaSeleccionada);
			lista2.Reverse();

			listaTotal.Add(lista1);
			listaTotal.Add(lista2);
			

			return listaTotal;
		}
		public List<List<string>> tomarSeleccionLlamada(Llamada llamadaSeleccionada)
		{
			List<List<string>> listaTotal2 = new List<List<string>>();
			listaTotal2 = buscarDatosLlamada(llamadaSeleccionada);

			
			string mensaje = string.Join(Environment.NewLine, listaTotal2);
			
			return listaTotal2;
			//listaTotal2 = buscarDatosLlamada(llamadaSeleccionada);
		}

		public List<string> ObtenerListaDeEncabezados(List<string> primeraLista)
		{
			List<string> valores = new List<string>();
			int x = 0;
			foreach (string item in primeraLista)
			{

				// Suponiendo que los datos están separados por algún carácter, como ","
				//string[] partes = item.Split('\n');
				string[] partes = item.Split(',');

				// Verificar si hay suficientes elementos en las partes para crear una instancia de Encabezado
				if (x == 2)
				{
					
					string nombre = primeraLista[0].Trim();
					string estado = primeraLista[1].Trim();
					string duracion = primeraLista[2].Trim(); // Duración también es un string

					valores.Add(nombre);
					valores.Add(estado);
					valores.Add(duracion);	
					// Crear una instancia de Encabezado y agregarla a la lista
					//Encabezado encabezado = new Encabezado(nombre, estado, duracion);
				}
				x++;
			}
			return valores;
		}


	}
}
