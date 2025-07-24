using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using GestionDeGastos.Data;
using GestionDeGastos.Models;


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

            if (string.IsNullOrWhiteSpace(nombreGrupo))
            {
                MessageBox.Show("Debe ingresar un nombre para el grupo.");
                return;
            }

            if (clbUsuarios.CheckedItems.Count == 0)
            {
                MessageBox.Show("Debe seleccionar al menos un miembro.");
                return;
            }

            List<Usuario> miembros = clbUsuarios.CheckedItems.Cast<Usuario>().ToList();

            Grupo nuevoGrupo = new Grupo
            {
                Nombre = nombreGrupo,
                Miembros = miembros
            };

            List<Grupo> grupos = GrupoData.CargarGrupos();
            grupos.Add(nuevoGrupo);
            GrupoData.GuardarGrupos(grupos);

            MessageBox.Show("Grupo guardado exitosamente.");
            txtNombreGrupo.Clear();
            for (int i = 0; i < clbUsuarios.Items.Count; i++)
            {
                clbUsuarios.SetItemChecked(i, false);
            }
        }
    }
}