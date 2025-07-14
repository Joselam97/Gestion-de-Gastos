using GestionDeGastos.Controllers;
using System;
using System.Windows.Forms;

namespace GestionDeGastos.Views
{
    public partial class RegistroForm : Form
    {
        private UsuarioController controlador;

        public RegistroForm()
        {
            InitializeComponent();
            controlador = new UsuarioController();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string correo = txtCorreo.Text;
            string contrasena = txtContrasena.Text;

            string resultado = controlador.RegistrarUsuario(nombre, correo, contrasena);
            MessageBox.Show(resultado);
        }
    }
}