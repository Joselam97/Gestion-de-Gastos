using GestionDeGastos.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace GestionDeGastos.Views
{
    public partial class ReporteGastosForm : Form
    {
        private string usuarioActual;
        private List<Grupo> grupos = new List<Grupo>();

        public ReporteGastosForm(string usuario)
        {
            InitializeComponent();
            usuarioActual = usuario;

            CargarGrupos();
            cmbTipo.SelectedIndex = 0; 
        }

        private void CargarGrupos()
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

        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbGrupos.Enabled = (cmbTipo.SelectedItem.ToString() == "Grupal");
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            if (!File.Exists("gastos.json")) return;

            string json = File.ReadAllText("gastos.json");
            var gastos = JsonConvert.DeserializeObject<List<Gasto>>(json);

            var desde = dtpDesde.Value.Date;
            var hasta = dtpHasta.Value.Date;

            List<Gasto> filtrados = new List<Gasto>();

            if (cmbTipo.SelectedItem.ToString() == "Personal")
            {
                filtrados = gastos.Where(g =>
                    g.QuienPago == usuarioActual &&
                    string.IsNullOrEmpty(g.Grupo) &&
                    g.Fecha.Date >= desde && g.Fecha.Date <= hasta).ToList();
            }
            else
            {
                if (cmbGrupos.SelectedItem == null)
                {
                    MessageBox.Show("Seleccione un grupo.");
                    return;
                }

                string grupoSeleccionado = cmbGrupos.SelectedItem.ToString();

                filtrados = gastos.Where(g =>
                    g.Grupo == grupoSeleccionado &&
                    g.Fecha.Date >= desde && g.Fecha.Date <= hasta).ToList();
            }

            dgvGastos.DataSource = filtrados;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void ReporteGastosForm_Load(object sender, EventArgs e)
        {

        }
    }
}