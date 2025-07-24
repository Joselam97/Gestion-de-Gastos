using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using GestionDeGastos.Data;
using GestionDeGastos.Models;
using Newtonsoft.Json;

namespace GestionDeGastos.Views
{
    public partial class GestionarGruposForm : Form
    {
        private string rutaArchivo = "grupos.json";
        private List<Grupo> grupos = new List<Grupo>();
        private Grupo grupoSeleccionado;

        public GestionarGruposForm()
        {
            InitializeComponent();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnVerGrupos_Click(object sender, EventArgs e)
        {
            lstGrupos.Items.Clear(); 
            grupos.Clear();          

            if (File.Exists(rutaArchivo))
            {
                string json = File.ReadAllText(rutaArchivo);
                grupos = JsonConvert.DeserializeObject<List<Grupo>>(json) ?? new List<Grupo>();

                if (grupos.Count == 0)
                {
                    MessageBox.Show("No hay grupos guardados.");
                    return;
                }

                foreach (var grupo in grupos)
                {
                    lstGrupos.Items.Add(grupo.Nombre);
                }
            }
            else
            {
                MessageBox.Show("No se encontró el archivo de grupos.");
            }
        }

        private void btnEliminarGrupo_Click(object sender, EventArgs e)
        {
            if (lstGrupos.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un grupo para eliminar.");
                return;
            }

            string nombreSeleccionado = lstGrupos.SelectedItem.ToString();

            var confirmacion = MessageBox.Show($"¿Estás seguro de eliminar el grupo \"{nombreSeleccionado}\"?", "Confirmar", MessageBoxButtons.YesNo);
            if (confirmacion == DialogResult.Yes)
            {
                grupos = grupos.Where(g => !g.Nombre.Equals(nombreSeleccionado, StringComparison.OrdinalIgnoreCase)).ToList();
                File.WriteAllText(rutaArchivo, JsonConvert.SerializeObject(grupos, Formatting.Indented));

                MessageBox.Show("Grupo eliminado correctamente.");
                btnVerGrupos_Click(sender, e); 
            }
        }

        private void btnModificarGrupo_Click(object sender, EventArgs e)
        {
            if (lstGrupos.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un grupo para modificar.");
                return;
            }

            ActualizarVistaGrupoSeleccionado();
        }

        private void btnAgregarUsuarios_Click(object sender, EventArgs e)
        {
            if (grupoSeleccionado == null)
            {
                MessageBox.Show("Primero selecciona un grupo para modificar.");
                return;
            }

            foreach (var item in chkUsuarios.CheckedItems)
            {
                string nombre = item.ToString();
                if (!grupoSeleccionado.Usuarios.Contains(nombre))
                {
                    grupoSeleccionado.Usuarios.Add(nombre);
                }
            }

            File.WriteAllText(rutaArchivo, JsonConvert.SerializeObject(grupos, Formatting.Indented));

            MessageBox.Show("Usuarios agregados correctamente.");

            btnModificarGrupo_Click(sender, e);
        }


        private void btnCambiarNombre_Click(object sender, EventArgs e)
        {
            if (grupoSeleccionado == null)
            {
                MessageBox.Show("Primero selecciona un grupo.");
                return;
            }

            string nuevoNombre = txtNuevoNombreGrupo.Text.Trim();

            if (string.IsNullOrEmpty(nuevoNombre))
            {
                MessageBox.Show("Ingresa un nuevo nombre para el grupo.");
                return;
            }

            if (grupos.Any(g => g.Nombre.Equals(nuevoNombre, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("Ya existe un grupo con ese nombre.");
                return;
            }

            grupoSeleccionado.Nombre = nuevoNombre;

            File.WriteAllText(rutaArchivo, JsonConvert.SerializeObject(grupos, Formatting.Indented));
            MessageBox.Show("Nombre del grupo actualizado.");

            btnVerGrupos_Click(null, null); 

            
            lstGrupos.SelectedItem = nuevoNombre;
            ActualizarVistaGrupoSeleccionado();
        }

        private void lstIntegrantesActuales_DoubleClick(object sender, EventArgs e)
        {
            if (lstIntegrantesActuales.SelectedItem != null && grupoSeleccionado != null)
            {
                string usuarioEliminar = lstIntegrantesActuales.SelectedItem.ToString();

                var confirm = MessageBox.Show($"¿Deseas quitar a {usuarioEliminar} del grupo?", "Confirmar", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    grupoSeleccionado.Usuarios.Remove(usuarioEliminar);

                    File.WriteAllText(rutaArchivo, JsonConvert.SerializeObject(grupos, Formatting.Indented));
                    btnModificarGrupo_Click(sender, e); 
                }
            }
        }

        private void lstGrupos_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarVistaGrupoSeleccionado();
        }

        private void ActualizarVistaGrupoSeleccionado()
        {
            if (lstGrupos.SelectedItem == null)
                return;

            string nombreSeleccionado = lstGrupos.SelectedItem.ToString();
            grupoSeleccionado = grupos.FirstOrDefault(g => g.Nombre.Equals(nombreSeleccionado, StringComparison.OrdinalIgnoreCase));

            if (grupoSeleccionado == null)
                return;

            lstIntegrantesActuales.Items.Clear();
            foreach (var usuario in grupoSeleccionado.Usuarios)
            {
                lstIntegrantesActuales.Items.Add(usuario);
            }

            var usuariosTotales = UsuarioData.CargarUsuarios(); 
            chkUsuarios.Items.Clear();
            foreach (var usuario in usuariosTotales)
            {
                if (!grupoSeleccionado.Usuarios.Contains(usuario.Nombre))
                {
                    chkUsuarios.Items.Add(usuario.Nombre);
                }
            }

            txtNuevoNombreGrupo.Text = grupoSeleccionado.Nombre;
        }

        private void GestionarGruposForm_Load(object sender, EventArgs e)
        {

        }
    }
}
