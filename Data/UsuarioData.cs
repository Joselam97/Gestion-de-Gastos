using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using GestionDeGastos.Models;
using Newtonsoft.Json;

namespace GestionDeGastos.Data
{
    internal class UsuarioData
    {

        //carga lista de usuarios del archivo usuarios.json
        public static List<Usuario> CargarUsuarios()
        {
            //variable para la ruta
            string rutaArchivo = "usuarios.json";

            //si el archivo no existe retorna una lista vacia
            if (!File.Exists(rutaArchivo))
                return new List<Usuario>();

            //lee el archivo y lo convierte en una lista de usuarios
            string json = File.ReadAllText(rutaArchivo);
            return JsonConvert.DeserializeObject<List<Usuario>>(json);
        }

        //guarda lista en el archivo usuarios.json
        public static void GuardarUsuarios(List<Usuario> usuarios)
        {
            string rutaArchivo = "usuarios.json";
            //obtiene el nombre de directorio usuarios.json
            string directorio = Path.GetDirectoryName(rutaArchivo);

            //si el directorio no extiste lo crea
            if (!Directory.Exists(directorio))
            {
                Directory.CreateDirectory(directorio);
            }

            //convierte la lista de usuarios en formato json
            string json = JsonConvert.SerializeObject(usuarios, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(rutaArchivo, json);
        }
    }
}
