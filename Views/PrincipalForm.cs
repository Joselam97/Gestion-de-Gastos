using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using GestionDeGastos.Views;

namespace GestionDeGastos.Views
{
    public partial class PrincipalForm : Form
    {
        //almacena nombre de usuario actual e imagen
        private string nombreUsuario;
        private string rutaImagen;

        //constructor del formulario principal
        public PrincipalForm(string nombre, string rutaAvatar)
        {
            InitializeComponent();

            nombreUsuario = nombre;       
            rutaImagen = rutaAvatar;      

            //muestra mensaje personalizado con el nomvre de usuario actual
            lblNombre.Text = $"Bienvenido(a), {nombreUsuario}!";

          //carga la imagen del avatar si existe, de lo contrario usa un avatar por defecto
            if (!string.IsNullOrEmpty(rutaImagen))
            {
                //ruta absoluta
                string rutaCompleta = Path.Combine(Application.StartupPath, rutaImagen);

                if (File.Exists(rutaCompleta))
                {
                    //carga el avatar del usuario
                    pictureBoxAvatar.Image = Image.FromFile(rutaCompleta);
                }
                else
                {
                    //usa avatar por defecto
                    pictureBoxAvatar.Image = Image.FromFile("ImagenesUsuarios/avatar1.png");
                }
            }
            //usa avatar por defecto
            else
            {
                pictureBoxAvatar.Image = Image.FromFile("ImagenesUsuarios/avatar1.png");
            }
        }

        //evento al hacer clic en "cerrar sesion"
        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            //crea nueva instancia del formulario 
            RegistroForm registroForm = new RegistroForm();
            registroForm.Show();       
            //oculta el formulario actual
            this.Hide();               
        }

        //evento al hacer click en "crear grupo"
        private void btnGrupos_Click(object sender, EventArgs e)
        {
            GrupoForm grupoForm = new GrupoForm();
            grupoForm.ShowDialog();
        }

        //evento al hacer click en "gastos"
        private void btnGastos_Click(object sender, EventArgs e)
        {
            GastosForm gastosForm = new GastosForm(nombreUsuario);
            gastosForm.ShowDialog();
        }

        private void lblNombre_Click(object sender, EventArgs e)
        {

        }
        //evento al hacer click en "gestionar grupos"
        private void btnGestionarGrupos_Click(object sender, EventArgs e)
        {
            GestionarGruposForm gestionarGruposForm = new GestionarGruposForm();
            gestionarGruposForm.ShowDialog();
        }

        //evento al hacer click en "calcular saldo neto"
        private void btnSaldo_Click(object sender, EventArgs e)
        {
            SaldoForm saldoForm = new SaldoForm(nombreUsuario);  
            saldoForm.ShowDialog();
        }

        //evento al hacer click en "reporte gastos"
        private void btnReporteGastos_Click(object sender, EventArgs e)
        {
            ReporteGastosForm reporteForm = new ReporteGastosForm(nombreUsuario);
            reporteForm.ShowDialog();
        }
    }
}