using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using GestionDeGastos.Models;
using Newtonsoft.Json;

namespace GestionDeGastos.Views
{
    public partial class RegistroForm : Form
    {
        private string rutaAvatarSeleccionada;


        private void btnSeleccionarAvatar_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Archivos de imagen (*.png;*.jpg)|*.png;*.jpg";
            ofd.InitialDirectory = Path.Combine(Application.StartupPath, "ImagenesUsuarios");

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                rutaAvatarSeleccionada = ofd.FileName;

                
                pictureBoxImagen.Image = Image.FromFile(rutaAvatarSeleccionada);
                pictureBoxImagen.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        public RegistroForm()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            string correo = txtCorreo.Text.Trim();
            string contrasena = txtContrasena.Text;

            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(correo) || string.IsNullOrWhiteSpace(contrasena))
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }

            if (string.IsNullOrEmpty(rutaAvatarSeleccionada))
            {
                MessageBox.Show("Debe seleccionar una imagen de avatar.");
                return;
            }


            Usuario nuevoUsuario = new Usuario
            {
                Nombre = nombre,
                Correo = correo,
                Contrasena = contrasena,
                RutaImagen = rutaAvatarSeleccionada
            };

            List<Usuario> usuarios = new List<Usuario>();
            string rutaArchivo = "usuarios.json";

            if (File.Exists(rutaArchivo))
            {
                string jsonExistente = File.ReadAllText(rutaArchivo);
                usuarios = JsonConvert.DeserializeObject<List<Usuario>>(jsonExistente) ?? new List<Usuario>();
            }

            bool usuarioExistente = usuarios.Any(u =>
    u.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase) &&
    u.Contrasena == contrasena);

            if (usuarioExistente)
            {
                MessageBox.Show("Ya existe un usuario con ese nombre o contraseña.");
                return;
            }

            usuarios.Add(nuevoUsuario);

            
            string jsonActualizado = JsonConvert.SerializeObject(usuarios, Formatting.Indented);
            File.WriteAllText(rutaArchivo, jsonActualizado);

            MessageBox.Show("Usuario registrado exitosamente.");

            txtNombre.Clear();
            txtCorreo.Clear();
            txtContrasena.Clear();
            pictureBoxImagen.Image = null;
            rutaAvatarSeleccionada = "";
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            string correo = txtCorreo.Text.Trim();
            string contrasena = txtContrasena.Text;

            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(correo) || string.IsNullOrWhiteSpace(contrasena))
            {
                MessageBox.Show("Debe ingresar nombre, correo y contraseña.");
                return;
            }

            string rutaArchivo = "usuarios.json";

            if (!File.Exists(rutaArchivo))
            {
                MessageBox.Show("No hay usuarios registrados.");
                return;
            }

            string json = File.ReadAllText(rutaArchivo);
            var usuarios = JsonConvert.DeserializeObject<List<Usuario>>(json) ?? new List<Usuario>();

            
            var usuarioEncontrado = usuarios.FirstOrDefault(u =>
                u.Nombre == nombre &&
                u.Correo == correo &&
                u.Contrasena == contrasena
            );

            if (usuarioEncontrado != null)
            {
                MessageBox.Show($"Bienvenido {usuarioEncontrado.Nombre}", "Inicio exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                PrincipalForm principal = new PrincipalForm(usuarioEncontrado.Nombre, usuarioEncontrado.RutaImagen);
                principal.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Nombre, correo o contraseña incorrectos (recuerde que distingue mayúsculas y minúsculas).", "Error de inicio", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RegistroForm_Load(object sender, EventArgs e)
        {
            CargarImagen(pictureBox1);
            CargarImagen(pictureBox2);
            CargarImagen(pictureBox3);
            CargarImagen(pictureBox4);
        }

        private void CargarImagen(PictureBox pb)
        {
            if (pb.Tag != null)
            {
                string rutaRelativa = pb.Tag.ToString();
                string rutaCompleta = Path.Combine(Application.StartupPath, rutaRelativa);

                if (File.Exists(rutaCompleta))
                {
                    pb.Image = Image.FromFile(rutaCompleta);
                }
                else
                {
                    MessageBox.Show($"No se pudo cargar la imagen: {rutaCompleta}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ImagenSeleccionada(object sender, EventArgs e)
        {
            PictureBox avatarClicado = sender as PictureBox;

            if (avatarClicado != null && avatarClicado.Tag != null)
            {
                string rutaRelativa = avatarClicado.Tag.ToString();
                string rutaCompleta = Path.Combine(Application.StartupPath, rutaRelativa);

                if (File.Exists(rutaCompleta))
                {
                    pictureBoxImagen.Image = Image.FromFile(rutaCompleta);
                    rutaAvatarSeleccionada = rutaRelativa;
                }
                else
                {
                    MessageBox.Show("No se encontró la imagen seleccionada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}