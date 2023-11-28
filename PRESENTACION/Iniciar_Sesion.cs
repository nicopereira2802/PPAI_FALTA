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
            

        }



        

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
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

        private void txtContrasena_TextChanged(object sender, EventArgs e)
        {
            txtContrasena.PasswordChar = '*';
        }
    }
}
