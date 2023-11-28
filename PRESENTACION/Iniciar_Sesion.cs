using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ENTIDADES;
using NEGOCIO;


namespace PRESENTACION
{
    public partial class Iniciar_Sesion : Form
    {
        public Iniciar_Sesion()
        {
            InitializeComponent();
            dataGridView1.CellFormatting += dataGridView1_CellFormatting;

        }


        private void button1_Click(object sender, EventArgs e)
        {
            Encuesta ListaEstados = new CN_Encuesta().ObtenerEncuesta(1);
            mostrarEstados(ListaEstados);
        }

        public void mostrarEstados(Encuesta ListaEstados)
        {
            dataGridView1.DataSource = ListaEstados;
            /*
            dataGridView1.Columns["descripcionOperador"].HeaderText = "Descripción del Operador";
            dataGridView1.Columns["detalleEncuesta"].HeaderText = "Detalle de la Encuesta";
            dataGridView1.Columns["duracion"].HeaderText = "Duración";
            dataGridView1.Columns["encuestaEnviada"].HeaderText = "Encuesta Enviada";
            dataGridView1.Columns["cliente"].HeaderText = "Cliente";
            */

        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            /*
            // Verifica si la celda que se está formateando es la que te interesa
            if (e.ColumnIndex == dataGridView1.Columns["cliente"].Index && e.RowIndex >= 0)
            {
     
                Cliente cliente = (Cliente)e.Value;

                String dni = cliente.dni;

                e.Value = dni.ToString();

                e.FormattingApplied = true;
            }*/
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<Usuario> ListaUsuarios = new CN_Usuario().Listar();
            bool lec = false;
            foreach (Usuario usu in ListaUsuarios)
            {
                if (usu.nomusu == txtUsuario.Text && usu.clave == txtContrasena.Text)
                {
                    MessageBox.Show("¡Bienvenido, Usuario valido!", "Mensaje Informativo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MenuPrincipal ventana = new MenuPrincipal(usu);
                    lec = true;
                    ventana.Show();
                    this.Hide();
                }
            }
            if(lec == false)
            {
                MessageBox.Show("¡ERROR,Usuario no valido!", "Mensaje Informativo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Iniciar_Sesion_Load(object sender, EventArgs e)
        {

        }
    }
}
