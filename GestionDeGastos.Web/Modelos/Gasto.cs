namespace GestionDeGastos.Web.Modelos
{
    public class Gasto
    {
        //getters y setters para los gastos
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; }
        public string QuienPago { get; set; }
        public string Grupo { get; set; }
        public int Id { get; set; }

        public string Categoria { get; set; }
    }
}
