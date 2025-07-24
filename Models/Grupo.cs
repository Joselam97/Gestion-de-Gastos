using System.Collections.Generic;
using GestionDeGastos.Models;

namespace GestionDeGastos.Models
{
    public class Grupo
    {
        public string Nombre { get; set; }
        public List<string> Usuarios { get; set; } = new List<string>();
    }
}