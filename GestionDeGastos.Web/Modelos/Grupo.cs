namespace GestionDeGastos.Web.Modelos
{
    public class Grupo
    {
        //get y set para nombre de grupo
        public string Nombre { get; set; }
        //lista de usuarios que pertenecen a este grupo
        public List<string> Usuarios { get; set; } = new List<string>();
    }
}
