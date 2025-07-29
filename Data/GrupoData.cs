using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using GestionDeGastos.Models;

namespace GestionDeGastos.Data
{
    internal class GrupoData
    {
        //ruta para almacenar grupos
        private static readonly string ruta = "Data/grupos.json";

        public static List<Grupo> CargarGrupos()
        {
            //si no existe devuelve el archivo vacio
            if (!File.Exists(ruta))
                return new List<Grupo>();

            //lee todo el contenido
            string json = File.ReadAllText(ruta);
            //deserealiza y devuelve la lista grupo
            return JsonConvert.DeserializeObject<List<Grupo>>(json);
        }

        public static void GuardarGrupos(List<Grupo> grupos)
        {
            //obtiene el nombre del directorio apartir de la ruta
            string directorio = Path.GetDirectoryName(ruta);

            //si el directorio no existe lo crea
            if (!Directory.Exists(directorio))
                Directory.CreateDirectory(directorio);

            //convierte la lista con identacion legible
            string json = JsonConvert.SerializeObject(grupos, Formatting.Indented);
            File.WriteAllText(ruta, json);
        }
    }
}