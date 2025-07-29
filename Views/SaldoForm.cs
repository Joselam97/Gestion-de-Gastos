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
        //info de gastos y grupos del usuario que se loggeo
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
            //verifica si existe el archivo en grupos
            if (File.Exists("grupos.json"))
            {
                //carga el contenido json y lo deserealiza 
                string json = File.ReadAllText("grupos.json");
                listaGrupos = JsonConvert.DeserializeObject<List<Grupo>>(json);
                //filtra los grupos donde el usuario esta incluido
                var gruposUsuario = listaGrupos.Where(g => g.Usuarios.Contains(usuarioActual)).ToList();

                cmbGrupos.Items.Clear();
                //recorre cada grupo donde aparece el usuario
                foreach (var grupo in gruposUsuario)
                {
                    cmbGrupos.Items.Add(grupo.Nombre);
                }
            }
        }

        private void rdbPersonal_CheckedChanged(object sender, EventArgs e)
        {
            //si elige gasto personal desactiva la seleccion de grupo
            cmbGrupos.Enabled = false;
        }

        private void rdbGrupal_CheckedChanged(object sender, EventArgs e)
        {
            //si elige grupo entonces activa la seccion de grupos
            cmbGrupos.Enabled = true;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            //cierra el formulario actual y vuelve al anterior
            this.Close(); 
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            //verifica que el presupuesto ingresado sea valido
            if (!decimal.TryParse(txtPresupuesto.Text, out decimal presupuesto))
            {
                MessageBox.Show("Ingrese un presupuesto válido.");
                return;
            }

            //obtiene el grupo seleccionado si se eligio gasto grupal
            string grupoSeleccionado = rdbGrupal.Checked ? cmbGrupos.SelectedItem?.ToString() : null;
            DateTime desde = dtpInicio.Value.Date;
            DateTime hasta = dtpFin.Value.Date;

            //valida que las fechas esten en orden de "incio" a "fin"
            if (desde > hasta)
            {
                MessageBox.Show("La fecha de inicio debe ser anterior a la fecha de fin.");
                return;
            }

            //si existe el archivo gastos, lo carga y filtra los datos
            if (File.Exists("gastos.json"))
            {
                string json = File.ReadAllText("gastos.json");
                listaGastos = JsonConvert.DeserializeObject<List<Gasto>>(json);

                //filtra los gastos segun fecha, usuario y tipo grupal o personal
                var gastosFiltrados = listaGastos.Where(g =>
                    g.Fecha.Date >= desde &&
                    g.Fecha.Date <= hasta &&
                    string.Equals(g.QuienPago, usuarioActual, StringComparison.OrdinalIgnoreCase) &&
                    ((rdbPersonal.Checked && string.IsNullOrEmpty(g.Grupo)) ||
                     (rdbGrupal.Checked && g.Grupo == grupoSeleccionado))
                ).ToList();

                //limpia la lista anterior y muestra los nuevos resultados
                lstReporte.Items.Clear();
                decimal totalGastos = 0;

                //recorre los gastos filtrados, los suma y los agrega a la lista
                foreach (var gasto in gastosFiltrados)
                {
                    totalGastos += gasto.Monto;
                    var item = new ListViewItem(new[]
                    {
                gasto.Fecha.ToShortDateString(),
                gasto.Nombre,
                //muestra el monto en colones
                "₡" + gasto.Monto.ToString("N2"),
                gasto.Descripcion,
                gasto.Categoria ?? "Sin categoría"
            });
                    lstReporte.Items.Add(item);
                }

                //calcula el saldo neto y lo muestra al usuario
                decimal saldoNeto = presupuesto - totalGastos;
                lblResultado.Text = $"Saldo Neto: ₡{saldoNeto:N2}";
            }
        }
    }
}