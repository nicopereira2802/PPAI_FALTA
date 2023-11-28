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
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal(Usuario usu)
        {
            InitializeComponent();
            lblBienvenida.Text = "Bienvenido " + usu.nomusu;
            lblBienvenida.Visible = true;
        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            ConsultaEncuesta ventana = new ConsultaEncuesta();
            ventana.Show();
            this.Hide();
        }
    }
}
