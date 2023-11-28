using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using CsvHelper;
using System.IO;



using ENTIDADES;
using NEGOCIO;


namespace PRESENTACION
{
    public partial class ConsultaEncuesta : Form
    {
        private DateTime fechaInicioAnterior;
        private DateTime fechaFinAntlistaLlamadaDatoserior;
        private bool Inicio;
        
        List<List<string>> listaLlamadaDatos;

        GestorConsultaEncuesta gestor = new GestorConsultaEncuesta();
        public ConsultaEncuesta()
        {
            InitializeComponent();
            dataGridLlamadas.CellFormatting += dataGridLlamadas_CellFormatting;
            dataGridLlamadas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            Inicio = false;

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

            DateTime fechaInicio = dateTimeInicio.Value;
            DateTime fechaFin = dateTimeFin.Value;

            List<Llamada> llamadasEPantalla = gestor.validarPeriodo(fechaInicio, fechaFin);
            //List<Llamada> llamadasEPantalla = new CN_Llamada().Listar();
            mostrarLlamadas(llamadasEPantalla);

            dataGridLlamadas.SelectionChanged += dataGridLlamadas_SelectionChanged;
        }

        public void mostrarLlamadas(List<Llamada> llamadasCEncuesta)
        {
            // Columna para la propiedad Nombre de ClasePrincipal
            
            dataGridLlamadas.DataSource = llamadasCEncuesta;
            dataGridLlamadas.Columns["descripcionOperador"].HeaderText = "Descripción del Operador";
            dataGridLlamadas.Columns["detalleEncuesta"].HeaderText = "Detalle de la Encuesta";
            dataGridLlamadas.Columns["duracion"].HeaderText = "Duración";
            dataGridLlamadas.Columns["encuestaEnviada"].HeaderText = "Encuesta Enviada";
            dataGridLlamadas.Columns["cliente"].HeaderText = "Cliente";
            dataGridLlamadas.ClearSelection();

        }

        private void dataGridLlamadas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Verifica si la celda que se está formateando es la que te interesa
            if (e.ColumnIndex == dataGridLlamadas.Columns["cliente"].Index && e.RowIndex >= 0)
            {

                Cliente cliente = (Cliente)e.Value;

                String dni = cliente.dni;

                e.Value = dni.ToString();

                e.FormattingApplied = true;
            }

        }
        private void dataGridLlamadas_SelectionChanged(object sender, EventArgs e)
        {
            // Acciones que se ejecutarán cuando cambie la selección de filas
            // Puedes acceder a la fila seleccionada usando: dataGridLlamadas.SelectedRows[0]
            // Por ejemplo, puedes obtener el valor de una celda así: dataGridLlamadas.SelectedRows[0].Cells["descripcionOperador"].Value
            // Realiza aquí las acciones que necesites al seleccionar una fila.
            DataGridViewRow selectedRow = dataGridLlamadas.CurrentRow;

            // Verificar si se ha seleccionado una fila
            if (selectedRow != null)
            {
                // Obtener los valores de las celdas de la fila seleccionada
                Llamada llamadaSeleccionado = (Llamada)selectedRow.DataBoundItem;

                listaLlamadaDatos = gestor.tomarSeleccionLlamada(llamadaSeleccionado);
         
                mostrarDatosLista(listaLlamadaDatos);

            }
        }

        public void mostrarDatosLista(List<List<string>> listaLlamadaDatos)
        {
            List<string> listaConcatenada = listaLlamadaDatos.SelectMany(lista => lista).ToList();
            List<string> primeraLista = listaLlamadaDatos[0];
            int x = 0;
            gestor.ObtenerListaDeEncabezados(primeraLista);
           
            listBox1.DataSource = listaConcatenada;
            



                // Actualizar la vista del DataGridView

            }
        private void ConsultaEncuesta_Load(object sender, EventArgs e)
        {

        }

        private void btnCsv_Click(object sender, EventArgs e)

        {
            List<string> primeraLista = listaLlamadaDatos[0];
            List<string> segundaLista = listaLlamadaDatos[1];
            segundaLista.Reverse();
            List<string> segundaListaPreguntas = new List<string>();

            for (int i = 0; i < segundaLista.Count; i++)
            {
                // Excluir el primer elemento y las posiciones que son múltiplos de 3
                if ((i + 1) % 3 != 0)
                {
                    segundaListaPreguntas.Add(segundaLista[i]);
                }
            }

            List<PreguntaCsv> listaDePreguntas = new CN_PreguntaCsv().ConvertirLista(segundaListaPreguntas);


            string nombre = primeraLista[0].Trim();
            string estado = primeraLista[1].Trim();
            string duracion = primeraLista[2].Trim(); // Duración también es un string

            // Crear una instancia de Encabezado
            Encabezado encabezado = new Encabezado(nombre, estado, duracion);

            // Crear una lista que contenga la instancia de Encabezado
            List<Encabezado> listaDeEncabezados = new List<Encabezado> { encabezado };

            // Ruta del archivo CSV
            string rutaArchivoCsv = "C:\\Users\\nicolas\\Desktop\\TERCERINTENTO\\PPAI_ORDENADO\\RespuestasArchivo.csv";

            // Escribir los encabezados en el archivo CSV
            using (var writer = new StreamWriter(rutaArchivoCsv, false, Encoding.UTF8))
            using (var csvWriter = new CsvWriter(writer, CultureInfo.CurrentCulture))
            {
                csvWriter.WriteRecords(listaDeEncabezados);
            }

            File.AppendAllText(rutaArchivoCsv, Environment.NewLine + "Preguntas:");

            // Escribir los datos de las preguntas en el archivo CSV
            using (var writer = new StreamWriter(rutaArchivoCsv, true, Encoding.UTF8))
            using (var csvWriter = new CsvWriter(writer, CultureInfo.CurrentCulture))
            {
                csvWriter.WriteRecords(listaDePreguntas);
            }

        }
    }
}
