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


            foreach (var usuario in usuarios)
            {
                clbUsuarios.Items.Add(usuario);
            }
        }

        private void btnGuardarGrupo_Click(object sender, EventArgs e)
        {
            string nombreGrupo = txtNombreGrupo.Text.Trim();
            if (string.IsNullOrEmpty(nombreGrupo))
            {
                MessageBox.Show("Debe ingresar un nombre para el grupo.");
                return;
            }

            string rutaArchivo = "grupos.json";
            List<Grupo> grupos = new List<Grupo>();

            if (File.Exists(rutaArchivo))
            {
                string json = File.ReadAllText(rutaArchivo);
                grupos = JsonConvert.DeserializeObject<List<Grupo>>(json) ?? new List<Grupo>();
            }

            if (grupos.Any(g => g.Nombre.Equals(nombreGrupo, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("Ya existe un grupo con ese nombre.");
                return;
            }

            Grupo nuevoGrupo = new Grupo
            {
                Nombre = nombreGrupo,
                Usuarios = new List<string>()
            };

            foreach (var item in clbUsuarios.CheckedItems)
            {
                nuevoGrupo.Usuarios.Add(item.ToString());
            }

            grupos.Add(nuevoGrupo);
            string jsonActualizado = JsonConvert.SerializeObject(grupos, Formatting.Indented);
            File.WriteAllText(rutaArchivo, jsonActualizado);

            MessageBox.Show("Grupo guardado exitosamente.");
            txtNombreGrupo.Clear();
        }

        private Button btnVolver;
    }
}