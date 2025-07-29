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
        //grupos cargados desde archivo
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
            //verifica si el archivo existe en grupos.json
            if (File.Exists("grupos.json"))
            {
                //lee el archivo json
                string json = File.ReadAllText("grupos.json");
                //convierte a lista de grupos
                grupos = JsonConvert.DeserializeObject<List<Grupo>>(json);
                //filtra solo los grupos en los que participa el usuario actual
                var gruposUsuario = grupos.Where(g => g.Usuarios.Contains(usuarioActual)).ToList();

                //limpia el box antes de llenarlo
                cmbGrupos.Items.Clear();
                //recorre todos los grupos donde aparece el usuario para llenarlos
                foreach (var grupo in gruposUsuario)
                {
                    //agrega cada grupo al box
                    cmbGrupos.Items.Add(grupo.Nombre);
                }
            }
        }

        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //habilita el box solo si se selecciona "Grupal"
            cmbGrupos.Enabled = (cmbTipo.SelectedItem.ToString() == "Grupal");
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            //si no existe el archivo gastos.json no se puede continuar
            if (!File.Exists("gastos.json")) return;

            //lee el archivo json
            string json = File.ReadAllText("gastos.json");
            //carga la lista de gastos
            var gastos = JsonConvert.DeserializeObject<List<Gasto>>(json);

            //fecha de inicio
            var desde = dtpDesde.Value.Date;
            //fecha final
            var hasta = dtpHasta.Value.Date;

            //lista donde se guardaran los gastos filtrados
            List<Gasto> filtrados = new List<Gasto>();

            //si el tipo es "Personal" filtra por usuario sin grupo
            if (cmbTipo.SelectedItem.ToString() == "Personal")
            {
                filtrados = gastos.Where(g =>
                    g.QuienPago == usuarioActual &&
                    string.IsNullOrEmpty(g.Grupo) &&
                    g.Fecha.Date >= desde && g.Fecha.Date <= hasta).ToList();
            }
            else
            {
                //si grupo seleccionado es null muestra un error
                if (cmbGrupos.SelectedItem == null)
                {
                    MessageBox.Show("Seleccione un grupo.");
                    return;
                }

                string grupoSeleccionado = cmbGrupos.SelectedItem.ToString();

                //filtra por gastos del grupo seleccionado en el rango de fechas
                filtrados = gastos.Where(g =>
                    g.Grupo == grupoSeleccionado &&
                    g.Fecha.Date >= desde && g.Fecha.Date <= hasta).ToList();
            }

            //muestra los resultados filtrados en el DataGridView
            dgvGastos.DataSource = filtrados;

            decimal totalGastos = filtrados.Sum(g => g.Monto);
            lblTotalGastos.Text = $"Total Gastos: ₡{totalGastos:N2}";
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            //cierra el formulario actual
            this.Close(); 
        }

        private void ReporteGastosForm_Load(object sender, EventArgs e)
        {

        }

        private void lblTotalGastos_Click(object sender, EventArgs e)
        {

        }
    }
}