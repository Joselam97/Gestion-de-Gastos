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
        //ruta del avatar
        private string rutaAvatarSeleccionada;

        public RegistroForm()
        {
            InitializeComponent();
        }


        //selecciona la imagen del avatar
        private void btnSeleccionarAvatar_Click(object sender, EventArgs e)
        {
            //abre el dialogo con archivos
            OpenFileDialog ofd = new OpenFileDialog();
            //filtro para tipos de archivos
            ofd.Filter = "Archivos de imagen (*.png;*.jpg)|*.png;*.jpg";
            //carpeta predeterminada
            ofd.InitialDirectory = Path.Combine(Application.StartupPath, "ImagenesUsuarios");

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                //guarda la ruta de la imagen seleccionada
                rutaAvatarSeleccionada = ofd.FileName;

                //muestra la imagen en el form 
                pictureBoxImagen.Image = Image.FromFile(rutaAvatarSeleccionada);
                //ajusta la imagen al contenedor
                pictureBoxImagen.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        
        //evento para registrar un nuevo usuario
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            //obtiene la info ingresada (nombre, correo, contra)
            string nombre = txtNombre.Text.Trim();
            string correo = txtCorreo.Text.Trim();
            string contrasena = txtContrasena.Text;

            //valida que todos los campos esten completos
            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(correo) || string.IsNullOrWhiteSpace(contrasena))
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }

            //verifica que se haya seleccionado un avatar
            if (string.IsNullOrEmpty(rutaAvatarSeleccionada))
            {
                MessageBox.Show("Debe seleccionar una imagen de avatar.");
                return;
            }

            //crea el nuevo objeto usuario
            Usuario nuevoUsuario = new Usuario
            {
                Nombre = nombre,
                Correo = correo,
                Contrasena = contrasena,
                RutaImagen = rutaAvatarSeleccionada
            };

            //ruta del archivo donde se guardan los usuarios
            List<Usuario> usuarios = new List<Usuario>();
            string rutaArchivo = "usuarios.json";

            //si ya existe el archivo, carga la lista actual
            if (File.Exists(rutaArchivo))
            {
                string jsonExistente = File.ReadAllText(rutaArchivo);
                usuarios = JsonConvert.DeserializeObject<List<Usuario>>(jsonExistente) ?? new List<Usuario>();
            }

            //verifica si ya existe un usuario con ese nombre y password
            bool usuarioExistente = usuarios.Any(u =>
                u.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase) &&
                u.Contrasena == contrasena);

            if (usuarioExistente)
            {
                MessageBox.Show("Ya existe un usuario con ese nombre o contraseña.");
                return;
            }
            //agrega usuario nuevo a la lista
            usuarios.Add(nuevoUsuario);

            //guarda la lista actualizada en el archivo json
            string jsonActualizado = JsonConvert.SerializeObject(usuarios, Formatting.Indented);
            File.WriteAllText(rutaArchivo, jsonActualizado);

            MessageBox.Show("Usuario registrado exitosamente.");

            //limpia los campos
            txtNombre.Clear();
            txtCorreo.Clear();
            txtContrasena.Clear();
            pictureBoxImagen.Image = null;
            rutaAvatarSeleccionada = "";
        }

        //evento para iniciar sesion
        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            string correo = txtCorreo.Text.Trim();
            string contrasena = txtContrasena.Text;

            //valida que los tres campos sean ingresados
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

            //carga usuarios desde el archivo
            string json = File.ReadAllText(rutaArchivo);
            var usuarios = JsonConvert.DeserializeObject<List<Usuario>>(json) ?? new List<Usuario>();

            //busca si existe un usuario que coincida exactamente
            var usuarioEncontrado = usuarios.FirstOrDefault(u =>
                u.Nombre == nombre &&
                u.Correo == correo &&
                u.Contrasena == contrasena
            );

            if (usuarioEncontrado != null)
            {
                MessageBox.Show($"Bienvenido {usuarioEncontrado.Nombre}", "Inicio exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //muestra el formulario principal y oculta el actual
                PrincipalForm principal = new PrincipalForm(usuarioEncontrado.Nombre, usuarioEncontrado.RutaImagen);
                principal.Show();
                this.Hide();
            }
            //en caso de equivocarse
            else
            {
                MessageBox.Show("Nombre, correo o contraseña incorrectos.", "Error de inicio", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //evento que se dispara para cargar el formulario de registro
        private void RegistroForm_Load(object sender, EventArgs e)
        {
            CargarImagen(pictureBox1);
            CargarImagen(pictureBox2);
            CargarImagen(pictureBox3);
            CargarImagen(pictureBox4);
        }

        //metodo para cargar imagenes predefinidas en los picturebox del formulario
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

        //evento al hacer click en el avatar predefinido
        private void ImagenSeleccionada(object sender, EventArgs e)
        {
            PictureBox avatarClicado = sender as PictureBox;

            if (avatarClicado != null && avatarClicado.Tag != null)
            {
                string rutaRelativa = avatarClicado.Tag.ToString();
                string rutaCompleta = Path.Combine(Application.StartupPath, rutaRelativa);

                //obtiene la ruta de la imagen en caso de existir
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