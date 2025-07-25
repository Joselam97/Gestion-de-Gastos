using System;

namespace GestionDeGastos.Models
{
    public class Gasto
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; }
        public string QuienPago { get; set; }
        public string Grupo { get; set; }

        public string Categoria { get; set; }
    }
}