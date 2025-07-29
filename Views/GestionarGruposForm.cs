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
        //ruta del archivo donde se almacenan los grupos
        private string rutaArchivo = "grupos.json";
        //lista que almacena los grupos cargados
        private List<Grupo> grupos = new List<Grupo>();
        //grupo que el usuario selecciona para modificar
        private Grupo grupoSeleccionado;

        public GestionarGruposForm()
        {
            InitializeComponent();
        }

        //evento que cierra el formulario
        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //carga todos los grupos grupos guardados y los muestra en el listbox
        private void btnVerGrupos_Click(object sender, EventArgs e)
        {
            //limpia la lista visual
            lstGrupos.Items.Clear();
            //limpia la lista interna
            grupos.Clear();          

            //verifica si existe el archivo
            if (File.Exists(rutaArchivo))
            {
                //lee el contenido json
                string json = File.ReadAllText(rutaArchivo);
                grupos = JsonConvert.DeserializeObject<List<Grupo>>(json) ?? new List<Grupo>();

                if (grupos.Count == 0)
                {
                    MessageBox.Show("No hay grupos guardados.");
                    return;
                }

                //muestra los nombres de los grupos en la interfaz
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

        //elimina el grupo seleccionado de la lista
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
                //filtra el grupo que se desea eliminar
                grupos = grupos.Where(g => !g.Nombre.Equals(nombreSeleccionado, StringComparison.OrdinalIgnoreCase)).ToList();
                //guarda la lista actualizada
                File.WriteAllText(rutaArchivo, JsonConvert.SerializeObject(grupos, Formatting.Indented));

                MessageBox.Show("Grupo eliminado correctamente.");
                //refresca la lista
                btnVerGrupos_Click(sender, e); 
            }
        }

        //permite modificar el grupo seleccionado
        private void btnModificarGrupo_Click(object sender, EventArgs e)
        {
            if (lstGrupos.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un grupo para modificar.");
                return;
            }
            //carga la informacion del grupo
            ActualizarVistaGrupoSeleccionado();
        }

        //agrega usuarios seleccionados al grupo actualmente seleccionado
        private void btnAgregarUsuarios_Click(object sender, EventArgs e)
        {
            if (grupoSeleccionado == null)
            {
                MessageBox.Show("Primero selecciona un grupo para modificar.");
                return;
            }

            //recorre los usuarios seleccionados y los agrega al grupo si no estan
            foreach (var item in chkUsuarios.CheckedItems)
            {
                string nombre = item.ToString();
                if (!grupoSeleccionado.Usuarios.Contains(nombre))
                {
                    grupoSeleccionado.Usuarios.Add(nombre);
                }
            }

            //guarda los cambios en el archivo
            File.WriteAllText(rutaArchivo, JsonConvert.SerializeObject(grupos, Formatting.Indented));

            MessageBox.Show("Usuarios agregados correctamente.");

            //refresca la vista del grupo
            btnModificarGrupo_Click(sender, e);
        }


        //permite cambiar el nombre del grupo
        private void btnCambiarNombre_Click(object sender, EventArgs e)
        {
            if (grupoSeleccionado == null)
            {
                MessageBox.Show("Primero selecciona un grupo.");
                return;
            }

            string nuevoNombre = txtNuevoNombreGrupo.Text.Trim();

            //si el nombre a cambiar esta vacio
            if (string.IsNullOrEmpty(nuevoNombre))
            {
                MessageBox.Show("Ingresa un nuevo nombre para el grupo.");
                return;
            }

            //verifica si ya existe un nuevo grupo con el mismo nombre
            if (grupos.Any(g => g.Nombre.Equals(nuevoNombre, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("Ya existe un grupo con ese nombre.");
                return;
            }

            //actualiza el nombre
            grupoSeleccionado.Nombre = nuevoNombre;

            File.WriteAllText(rutaArchivo, JsonConvert.SerializeObject(grupos, Formatting.Indented));
            MessageBox.Show("Nombre del grupo actualizado.");

            //refresca la lista de grupos
            btnVerGrupos_Click(null, null); 

            //vuelve a seleccionar el grupo seleccionado
            lstGrupos.SelectedItem = nuevoNombre;
            //actualiza la vista
            ActualizarVistaGrupoSeleccionado();
        }

        //elimina un usuario del grupo actual haciendo doble clic sobre su nombre
        private void lstIntegrantesActuales_DoubleClick(object sender, EventArgs e)
        {
            if (lstIntegrantesActuales.SelectedItem != null && grupoSeleccionado != null)
            {
                string usuarioEliminar = lstIntegrantesActuales.SelectedItem.ToString();

                var confirm = MessageBox.Show($"¿Deseas quitar a {usuarioEliminar} del grupo?", "Confirmar", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    //elimina el grupo de la lista
                    grupoSeleccionado.Usuarios.Remove(usuarioEliminar);

                    File.WriteAllText(rutaArchivo, JsonConvert.SerializeObject(grupos, Formatting.Indented));
                    //refresca la vista
                    btnModificarGrupo_Click(sender, e); 
                }
            }
        }

        //cuando cambia el grupo seleccionado en la lista, actualiza la info
        private void lstGrupos_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarVistaGrupoSeleccionado();
        }

        //actualiza los controles visuales con los datos del grupo seleccionado
        private void ActualizarVistaGrupoSeleccionado()
        {
            if (lstGrupos.SelectedItem == null)
                return;

            string nombreSeleccionado = lstGrupos.SelectedItem.ToString();
            grupoSeleccionado = grupos.FirstOrDefault(g => g.Nombre.Equals(nombreSeleccionado, StringComparison.OrdinalIgnoreCase));

            if (grupoSeleccionado == null)
                return;

            //muestra los integrantes actuales
            lstIntegrantesActuales.Items.Clear();
            foreach (var usuario in grupoSeleccionado.Usuarios)
            {
                lstIntegrantesActuales.Items.Add(usuario);
            }

            //muestra en el checklist solo los usuarios que no estan en el grupo
            var usuariosTotales = UsuarioData.CargarUsuarios(); 
            chkUsuarios.Items.Clear();
            foreach (var usuario in usuariosTotales)
            {
                if (!grupoSeleccionado.Usuarios.Contains(usuario.Nombre))
                {
                    chkUsuarios.Items.Add(usuario.Nombre);
                }
            }

            //rellena el campo con el nombre actual
            txtNuevoNombreGrupo.Text = grupoSeleccionado.Nombre;
        }

        private void GestionarGruposForm_Load(object sender, EventArgs e)
        {

        }
    }
}
