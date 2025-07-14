using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionDeGastos.Models;
using System.Xml;
using Newtonsoft.Json;

namespace GestionDeGastos.Data
{
    internal class UsuarioData
    {
        private static readonly string ruta = "Data/usuarios.json";

        public static List<Usuario> CargarUsuarios()
        {
            if (!File.Exists(ruta))
                return new List<Usuario>();

            string json = File.ReadAllText(ruta);
            return JsonConvert.DeserializeObject<List<Usuario>>(json);
        }

        public static void GuardarUsuarios(List<Usuario> usuarios)
        {
            string directorio = Path.GetDirectoryName(ruta);

            if (!Directory.Exists(directorio))
            {
                Directory.CreateDirectory(directorio);
            }

            string json = JsonConvert.SerializeObject(usuarios, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(ruta, json);
        }
    }
}
