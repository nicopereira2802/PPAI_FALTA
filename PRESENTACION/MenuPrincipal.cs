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
            lblBienvenida.Text = "¡Bienvenido " + CapitalizarPrimeraLetra(usu.nomusu)+ " !";
            lblBienvenida.Visible = true;
            lblBienvenida.TextAlign = ContentAlignment.MiddleCenter; // Centrar el texto
            CenterToScreen();
        }

        private string CapitalizarPrimeraLetra(string texto)
        {
            // Verificar si el texto es nulo o está vacío
            if (string.IsNullOrEmpty(texto))
                return texto;

            // Capitalizar la primera letra y mantener el resto del texto
            return char.ToUpper(texto[0]) + texto.Substring(1);
        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            string imagePath = "C:\\Users\\Mi PC\\Desktop\\DiseñodeSistemas\\PPAI3\\PPAI_FALTA\\lineas_1.jpg";
            Image image = Image.FromFile(imagePath);

            // Ajustar la imagen al tamaño de la PictureBox
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Image = image;
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

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
