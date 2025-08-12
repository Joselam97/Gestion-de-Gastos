namespace GestionDeGastos.Web.Modelos
{
    public class Grupo
    {
        //get y set 
        public string Nombre { get; set; }
        public int Id { get; set; }
        //lista de usuarios que pertenecen a este grupo
        public List<string> Usuarios { get; set; } = new List<string>();
    }
}
