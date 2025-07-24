using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionDeGastos.Data;
using GestionDeGastos.Models;
using GestionDeGastos.Data;
using GestionDeGastos.Models;

namespace GestionDeGastos.Controllers
{

    public class UsuarioController
    {
        //metodo que registra usuarios
        public string RegistrarUsuario(string nombre, string correo, string contrasena, string rutaImagen)
        {
            //carga la lista de usuarios guardados en JSON
            List<Usuario> usuarios = UsuarioData.CargarUsuarios();

            //verifica si existe un usuario con ese correo
            bool existeCorreo = usuarios.Exists(u => u.Correo.ToLower() == correo.ToLower());
            if (existeCorreo)
            {
                return "Ya existe un usuario con ese correo!";
            }

            //crea usuario con los datos ingresados
            Usuario nuevoUsuario = new Usuario
            {
                Nombre = nombre,
                Correo = correo,
                Contrasena = contrasena,
                RutaImagen = rutaImagen
            };

            //agrega usuario a la lista existente
            usuarios.Add(nuevoUsuario);
            UsuarioData.GuardarUsuarios(usuarios);

            //mensaje devuelto
            return "Usuario registrado exitosamente";
        }

        public string ValidarInicioSesion(string correo, string contrasena)
        {
            List<Usuario> usuarios = UsuarioData.CargarUsuarios();

            var usuario = usuarios.FirstOrDefault(u =>
                u.Correo.ToLower() == correo.ToLower() &&
                u.Contrasena == contrasena);

            if (usuario == null)
                return "Correo o contraseña incorrectos.";

            return "OK";
        }
    }
}