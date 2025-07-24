using System.Collections.Generic;
using GestionDeGastos.Models;

namespace GestionDeGastos.Models
{
    public class Grupo
    {
        public string Nombre { get; set; }
        public List<Usuario> Miembros { get; set; }
    }
}