using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using GestionDeGastos.Data;
using GestionDeGastos.Models;
using Newtonsoft.Json;


namespace GestionDeGastos.Views
{
    public partial class GrupoForm : Form
    {
        public GrupoForm()
        {
            InitializeComponent();
            CargarUsuarios();
        }

        private void CargarUsuarios()
        {
            var usuarios = UsuarioData.CargarUsuarios();

            MessageBox.Show($"Usuarios cargados: {usuarios.Count}");

            //agrega cada usuario al box
            foreach (var usuario in usuarios)
            {
                clbUsuarios.Items.Add(usuario);
            }
        }

        private void btnGuardarGrupo_Click(object sender, EventArgs e)
        {
            //obtiene el nombre del grupo desde el textbox
            string nombreGrupo = txtNombreGrupo.Text.Trim();

            //si no se agrega nombre para el grupo
            if (string.IsNullOrEmpty(nombreGrupo))
            {
                MessageBox.Show("Debe ingresar un nombre para el grupo.");
                return;
            }

            //ruta donde se guardaran los grupos
            string rutaArchivo = "grupos.json";
            List<Grupo> grupos = new List<Grupo>();

            //si ya existe el archivo lo carga para verificar duplicados
            if (File.Exists(rutaArchivo))
            {
                string json = File.ReadAllText(rutaArchivo);
                //deserealiza el archivo json
                grupos = JsonConvert.DeserializeObject<List<Grupo>>(json) ?? new List<Grupo>();
            }

            //verifica que no exista ya un grupo con ese nombre. Ignorando Lower/Upper Case
            if (grupos.Any(g => g.Nombre.Equals(nombreGrupo, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("Ya existe un grupo con ese nombre.");
                return;
            }

            //crea un nuevo grupo con el nombre y los usuarios seleccionados
            Grupo nuevoGrupo = new Grupo
            {
                Nombre = nombreGrupo,
                Usuarios = new List<string>()
            };

            //agrega los usuarios seleccionados en el CheckedListBox al grupo
            foreach (var item in clbUsuarios.CheckedItems)
            {
                nuevoGrupo.Usuarios.Add(item.ToString());
            }

            //agrega el nuevo grupo a la lista y lo guarda en el archivo json
            grupos.Add(nuevoGrupo);
            string jsonActualizado = JsonConvert.SerializeObject(grupos, Formatting.Indented);
            File.WriteAllText(rutaArchivo, jsonActualizado);

            MessageBox.Show("Grupo guardado exitosamente.");

            //limpia el campo del nombre de grupo para seguir guardando otros grupos
            txtNombreGrupo.Clear();
        }

        private Button btnVolver;
    }
}