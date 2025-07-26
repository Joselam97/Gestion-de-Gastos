using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using GestionDeGastos.Views;

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
            RegistroForm registroForm = new RegistroForm();
            registroForm.Show();       
            this.Hide();               
        }

        private void btnGrupos_Click(object sender, EventArgs e)
        {
            GrupoForm grupoForm = new GrupoForm();
            grupoForm.ShowDialog();
        }

        private void btnGastos_Click(object sender, EventArgs e)
        {
            GastosForm gastosForm = new GastosForm(nombreUsuario);
            gastosForm.ShowDialog();
        }

        private void lblNombre_Click(object sender, EventArgs e)
        {

        }

        private void btnGestionarGrupos_Click(object sender, EventArgs e)
        {
            GestionarGruposForm gestionarGruposForm = new GestionarGruposForm();
            gestionarGruposForm.ShowDialog();
        }

        private void btnSaldo_Click(object sender, EventArgs e)
        {
            SaldoForm saldoForm = new SaldoForm(nombreUsuario);  
            saldoForm.ShowDialog();
        }
    }
}