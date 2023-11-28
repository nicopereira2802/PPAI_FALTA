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
        List<List<string>> listaLlamadaDatos;
        GestorConsultaEncuesta gestor = new GestorConsultaEncuesta();
        public ConsultaEncuesta()
        {
            InitializeComponent();
            dataGridLlamadas.CellFormatting += dataGridLlamadas_CellFormatting;
            dataGridLlamadas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

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
            // Columna para el atributo de OtraClase
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

                // Realizar cualquier otra acción que necesites con el objeto seleccionado
                // ...
                // Ejemplo de mostrar una propiedad del objeto en un MessageBox
                MessageBox.Show("Se ha seleccionado la Llamada{llamadaSeleccionado.Idll} con operador {llamadaSeleccionado.descripcionOperador}", "Mensaje Informativo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //List<string> listaLlamadaDatos = gestorConsultarEncuesta.tomarSeleccionLlamada(llamadaSeleccionado);
                //mostrarDatosLLamada(listaLlamadaDatos);

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
            string nombre = primeraLista[0].Trim();
            string estado = primeraLista[1].Trim();
            string duracion = primeraLista[2].Trim(); // Duración también es un string

            // Crear una instancia de Encabezado
            Encabezado encabezado = new Encabezado(nombre, estado, duracion);

            // Crear una lista que contenga la instancia de Encabezado
            List<Encabezado> listaDeEncabezados = new List<Encabezado> { encabezado };

            // Ruta del archivo CSV
            string rutaArchivoCsv = "C:\\Users\\nicolas\\Desktop\\TERCERINTENTO\\PPAI_ORDENADO\\file.csv";

            // Escribir los encabezados en el archivo CSV
            using (var writer = new StreamWriter(rutaArchivoCsv, false, Encoding.UTF8))
            using (var csvWriter = new CsvWriter(writer, CultureInfo.CurrentCulture))
            {
                csvWriter.WriteRecords(listaDeEncabezados);
            }

        }
        public class Registro
        {
            public int Id { get; set; }
            public string Name { get; set; }

            public Registro(int id, string name)
            {
                Id = id;
                Name = name;
            }
        }

        public class Encabezado
        {
            public string Nombre { get; set; }

            public string Estado { get; set; }
            public string Duracion { get; set; }

            public Encabezado(string nombre, string estado,string duracion)
            {
                Nombre = nombre;
                Estado = estado;
                Duracion = duracion;
            }
        }
    }
}
