using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace GestionDeGastos.Views
{
    public partial class PrincipalForm : Form
    {
        private string nombreUsuario;
        private string rutaImagen;

        public PrincipalForm(string nombre, string rutaAvatar)
        {
            InitializeComponent();

            nombreUsuario = nombre;       
            rutaImagen = rutaAvatar;      

            lblNombre.Text = $"Bienvenido, {nombreUsuario}!";

          
            if (!string.IsNullOrEmpty(rutaImagen))
            {
                string rutaCompleta = Path.Combine(Application.StartupPath, rutaImagen);

                if (File.Exists(rutaCompleta))
                {
                    pictureBoxAvatar.Image = Image.FromFile(rutaCompleta);
                }
                else
                {
                    pictureBoxAvatar.Image = Image.FromFile("ImagenesUsuarios/avatar1.png");
                }
            }
            else
            {
                pictureBoxAvatar.Image = Image.FromFile("ImagenesUsuarios/avatar1.png");
            }
        }


        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void btnGrupos_Click(object sender, EventArgs e)
        {
            GrupoForm grupoForm = new GrupoForm();
            grupoForm.ShowDialog();
        }

        private void btnGastos_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Aqui se abrira la funcionalidad de gastos");
        }

        private void lblNombre_Click(object sender, EventArgs e)
        {

        }
    }
}