using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using GestionDeGastos.Models;

namespace GestionDeGastos.Data
{
    internal class GrupoData
    {
        private static readonly string ruta = "Data/grupos.json";

        public static List<Grupo> CargarGrupos()
        {
            if (!File.Exists(ruta))
                return new List<Grupo>();

            string json = File.ReadAllText(ruta);
            return JsonConvert.DeserializeObject<List<Grupo>>(json);
        }

        public static void GuardarGrupos(List<Grupo> grupos)
        {
            string directorio = Path.GetDirectoryName(ruta);

            if (!Directory.Exists(directorio))
                Directory.CreateDirectory(directorio);

            string json = JsonConvert.SerializeObject(grupos, Formatting.Indented);
            File.WriteAllText(ruta, json);
        }
    }
}