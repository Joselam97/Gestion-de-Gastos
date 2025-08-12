using System.IO;

namespace GestionDeGastos.Web.Servicios
{
    public class RutasArchivos
    {
        public string CarpetaDatos { get; }
        public string Usuarios => Path.Combine(CarpetaDatos, "usuarios.json");
        public string Grupos => Path.Combine(CarpetaDatos, "grupos.json");
        public string Gastos => Path.Combine(CarpetaDatos, "gastos.json");
        public string Invitaciones => Path.Combine(CarpetaDatos, "invitaciones.json");

        public RutasArchivos(string contentRootPath)
        {
            CarpetaDatos = Path.Combine(contentRootPath, "App_Data");
            Directory.CreateDirectory(CarpetaDatos);
        }
    }
}
