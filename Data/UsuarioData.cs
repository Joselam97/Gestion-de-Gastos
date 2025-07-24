using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using GestionDeGastos.Models;
using Newtonsoft.Json;

namespace GestionDeGastos.Data
{
    internal class UsuarioData
    {

        public static List<Usuario> CargarUsuarios()
        {
            string rutaArchivo = "usuarios.json";

            if (!File.Exists(rutaArchivo))
                return new List<Usuario>();

            string json = File.ReadAllText(rutaArchivo);
            return JsonConvert.DeserializeObject<List<Usuario>>(json);
        }

        public static void GuardarUsuarios(List<Usuario> usuarios)
        {
            string rutaArchivo = "usuarios.json";
            string directorio = Path.GetDirectoryName(rutaArchivo);

            if (!Directory.Exists(directorio))
            {
                Directory.CreateDirectory(directorio);
            }

            string json = JsonConvert.SerializeObject(usuarios, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(rutaArchivo, json);
        }
    }
}
