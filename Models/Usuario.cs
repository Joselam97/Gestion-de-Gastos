using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeGastos.Models
{
    public class Usuario
    {
        //getters y setters para usuario
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Contrasena { get; set; }
        public string RutaImagen { get; set; }

        public Usuario() { }

        //constructor
        public Usuario(int id, string nombre, string correo, string contrasena)
        {
            Id = id;
            Nombre = nombre;
            Correo = correo;
            Contrasena = contrasena;
        }

        //metodo para validar que los espacios no esten vacios
        public bool DatosValidos()
        {
            return !string.IsNullOrWhiteSpace(Nombre) &&
                   !string.IsNullOrWhiteSpace(Correo) &&
                   !string.IsNullOrWhiteSpace(Contrasena);
        }

        //sobreescribe el metodo para que muestre el nombre como string
        public override string ToString()
        {
            return Nombre;
        }
    }
}
