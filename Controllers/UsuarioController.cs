using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionDeGastos.Data;
using GestionDeGastos.Models;

namespace GestionDeGastos.Controllers
{
    internal class UsuarioController
    {
        private List<Usuario> usuarios;

        public UsuarioController()
        {
            usuarios = UsuarioData.CargarUsuarios();
        }

        public string RegistrarUsuario(string nombre, string correo, string contrasena)
        {
            if (usuarios.Any(u => u.Correo == correo))
                return "Ya existe un usuario con ese correo";

            var nuevo = new Usuario(usuarios.Count + 1, nombre, correo, contrasena);
            if (!nuevo.DatosValidos())
                return "Faltan datos";

            usuarios.Add(nuevo);
            UsuarioData.GuardarUsuarios(usuarios);
            return "Usuario registrado exitosamente";
        }
    }
}
