using GestionDeGastos.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace GestionDeGastos.Views
{
    public partial class GastosForm : Form
    {
        //usuario loggeado
        private string usuarioActual;
        //grupos del usuario
        private List<Grupo> grupos;
        //ruta donde se guardaran los gastos
        private string rutaGastos = "gastos.json";

        public GastosForm(string usuario)
        {
            InitializeComponent();
            usuarioActual = usuario;

            CargarGruposDelUsuario();
            CargarCategorias();
            TipoGasto_CheckedChanged(null, null);
        }

        //carga los grupos del usuario
        private void CargarGruposDelUsuario()
        {

            if (File.Exists("grupos.json"))
            {
                string json = File.ReadAllText("grupos.json");
                grupos = JsonConvert.DeserializeObject<List<Grupo>>(json);
                //filtra los grupos donde el usuario este registrado
                var gruposUsuario = grupos.Where(g => g.Usuarios.Contains(usuarioActual)).ToList();

                cmbGrupos.Items.Clear();
                //recorre los grupos donde se encuentra el usuario
                foreach (var grupo in gruposUsuario)
                {
                    cmbGrupos.Items.Add(grupo.Nombre);
                }
            }
        }

        //habilita o desahabilita el cuadro de grupos si es gasto grupal
        private void TipoGasto_CheckedChanged(object sender, EventArgs e)
        {
            cmbGrupos.Enabled = rdbGrupal.Checked;

            if (!rdbGrupal.Checked)
            {
                //limpia la seccion si se cambia a gasto personal
                cmbGrupos.SelectedIndex = -1;
            }
        }

        //carga categorias de gasto
        private void CargarCategorias()
        {
            cmbCategoria.Items.Clear();
            cmbCategoria.Items.AddRange(new string[]
            {
        "Servicios Basicos", "Carro", "Comida", "Ocio", "Hogar", "Alquiler",
        "Deuda", "Negocios", "Estudios", "Salud", "Servicios Profesionales", "Personal"
            });
            //seleccion 0 por defecto
            cmbCategoria.SelectedIndex = 0; 
        }

        //evento que guarda el gasto
        private void btnGuardarGasto_Click(object sender, EventArgs e)
        {
            if (cmbCategoria.SelectedItem == null)
            {
                MessageBox.Show("Seleccione una categoria para el gasto.");
                return;
            }

            //crea un objeto gasto con los datos del formulario
            Gasto nuevoGasto = new Gasto
            {
                Nombre = txtNombre.Text.Trim(),
                Descripcion = txtDescripcion.Text.Trim(),
                Monto = decimal.Parse(txtMonto.Text),
                Fecha = dtpFecha.Value,
                QuienPago = usuarioActual,
                Grupo = rdbGrupal.Checked ? cmbGrupos.SelectedItem?.ToString() : null,
                Categoria = cmbCategoria.SelectedItem?.ToString(),
            };

            List<Gasto> listaGastos = new List<Gasto>();

            //carga los gastos existentes si el archivo ya existe
            if (File.Exists(rutaGastos))
            {
                string json = File.ReadAllText(rutaGastos);
                listaGastos = JsonConvert.DeserializeObject<List<Gasto>>(json) ?? new List<Gasto>();
            }

            //agrega el nuevo gasto a la lista
            listaGastos.Add(nuevoGasto);
            //guarda la lista de gastos actualizada en el archivo
            File.WriteAllText(rutaGastos, JsonConvert.SerializeObject(listaGastos, Formatting.Indented));

            MessageBox.Show("Gasto guardado correctamente.");
            //limpia el formulario para nuevos ingresos
            LimpiarCampos();
        }


        //cierra el form y vuelve al anterior
        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        //limipia los campos del formulario
        private void LimpiarCampos()
        {
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            txtMonto.Text = "";
            cmbGrupos.SelectedIndex = -1;
            cmbCategoria.SelectedIndex = -1;
            dtpFecha.Value = DateTime.Now;
            rdbPersonal.Checked = true;
        }

        private void GastosForm_Load(object sender, EventArgs e)
        {

        }
    }
}
