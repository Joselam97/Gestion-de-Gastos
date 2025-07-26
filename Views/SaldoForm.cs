using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using GestionDeGastos.Models;
using Newtonsoft.Json;

namespace GestionDeGastos.Views
{
    public partial class SaldoForm : Form
    {
        private string usuarioActual;
        private List<Gasto> listaGastos;
        private List<Grupo> listaGrupos;

        public SaldoForm(string usuario)
        {
            InitializeComponent();
            usuarioActual = usuario;
            CargarGruposDelUsuario();
        }

        private void CargarGruposDelUsuario()
        {
            if (File.Exists("grupos.json"))
            {
                string json = File.ReadAllText("grupos.json");
                listaGrupos = JsonConvert.DeserializeObject<List<Grupo>>(json);
                var gruposUsuario = listaGrupos.Where(g => g.Usuarios.Contains(usuarioActual)).ToList();

                cmbGrupos.Items.Clear();
                foreach (var grupo in gruposUsuario)
                {
                    cmbGrupos.Items.Add(grupo.Nombre);
                }
            }
        }

        private void rdbPersonal_CheckedChanged(object sender, EventArgs e)
        {
            cmbGrupos.Enabled = false;
        }

        private void rdbGrupal_CheckedChanged(object sender, EventArgs e)
        {
            cmbGrupos.Enabled = true;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(txtPresupuesto.Text, out decimal presupuesto))
            {
                MessageBox.Show("Ingrese un presupuesto válido.");
                return;
            }

            string grupoSeleccionado = rdbGrupal.Checked ? cmbGrupos.SelectedItem?.ToString() : null;
            DateTime desde = dtpInicio.Value.Date;
            DateTime hasta = dtpFin.Value.Date;

            if (desde > hasta)
            {
                MessageBox.Show("La fecha de inicio debe ser anterior a la fecha de fin.");
                return;
            }

            if (File.Exists("gastos.json"))
            {
                string json = File.ReadAllText("gastos.json");
                listaGastos = JsonConvert.DeserializeObject<List<Gasto>>(json);

                var gastosFiltrados = listaGastos.Where(g =>
                    g.Fecha.Date >= desde &&
                    g.Fecha.Date <= hasta &&
                    string.Equals(g.QuienPago, usuarioActual, StringComparison.OrdinalIgnoreCase) &&
                    ((rdbPersonal.Checked && string.IsNullOrEmpty(g.Grupo)) ||
                     (rdbGrupal.Checked && g.Grupo == grupoSeleccionado))
                ).ToList();

                lstReporte.Items.Clear();
                decimal totalGastos = 0;

                foreach (var gasto in gastosFiltrados)
                {
                    totalGastos += gasto.Monto;
                    var item = new ListViewItem(new[]
                    {
                gasto.Fecha.ToShortDateString(),
                gasto.Nombre,
                "₡" + gasto.Monto.ToString("N2"),
                gasto.Descripcion,
                gasto.Categoria ?? "Sin categoría"
            });
                    lstReporte.Items.Add(item);
                }

                decimal saldoNeto = presupuesto - totalGastos;
                lblResultado.Text = $"Saldo Neto: ₡{saldoNeto:N2}";
            }
        }
    }
}