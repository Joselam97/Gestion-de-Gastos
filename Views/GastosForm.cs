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
        private string usuarioActual;
        private List<Grupo> grupos;
        private string rutaGastos = "gastos.json";

        public GastosForm(string usuario)
        {
            InitializeComponent();
            usuarioActual = usuario;

            CargarGruposDelUsuario();
            CargarCategorias();
            TipoGasto_CheckedChanged(null, null);
        }

        private void CargarGruposDelUsuario()
        {
            if (File.Exists("grupos.json"))
            {
                string json = File.ReadAllText("grupos.json");
                grupos = JsonConvert.DeserializeObject<List<Grupo>>(json);
                var gruposUsuario = grupos.Where(g => g.Usuarios.Contains(usuarioActual)).ToList();

                cmbGrupos.Items.Clear();
                foreach (var grupo in gruposUsuario)
                {
                    cmbGrupos.Items.Add(grupo.Nombre);
                }
            }
        }

        private void TipoGasto_CheckedChanged(object sender, EventArgs e)
        {
            cmbGrupos.Enabled = rdbGrupal.Checked;

            if (!rdbGrupal.Checked)
            {
                cmbGrupos.SelectedIndex = -1;
            }
        }

        private void CargarCategorias()
        {
            cmbCategoria.Items.Clear();
            cmbCategoria.Items.AddRange(new string[]
            {
        "Servicios Basicos", "Carro", "Comida", "Ocio", "Alquiler",
        "Deuda", "Negocios", "Estudios", "Salud", "Servicios Profesionales", "Personal"
            });

            cmbCategoria.SelectedIndex = 0; 
        }

        private void btnGuardarGasto_Click(object sender, EventArgs e)
        {
            if (cmbCategoria.SelectedItem == null)
            {
                MessageBox.Show("Seleccione una categoria para el gasto.");
                return;
            }

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

            if (File.Exists(rutaGastos))
            {
                string json = File.ReadAllText(rutaGastos);
                listaGastos = JsonConvert.DeserializeObject<List<Gasto>>(json) ?? new List<Gasto>();
            }

            listaGastos.Add(nuevoGasto);
            File.WriteAllText(rutaGastos, JsonConvert.SerializeObject(listaGastos, Formatting.Indented));

            MessageBox.Show("Gasto guardado correctamente.");
            LimpiarCampos();
        }


        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

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
