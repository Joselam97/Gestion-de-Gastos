using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using GestionDeGastos.Web.Modelos;
using GestionDeGastos.Web.Servicios;

namespace GestionDeGastos.Web.Datos
{
    public class UsuarioRepositorioJson
    {
        private readonly RutasArchivos _rutas;
        private static readonly JsonSerializerOptions _opts = new JsonSerializerOptions
        {
            WriteIndented = true,
            PropertyNameCaseInsensitive = true
        };

        public UsuarioRepositorioJson(RutasArchivos rutas)
        {
            _rutas = rutas;
        }

        public async Task<List<Usuario>> CargarAsync()
        {
            if (!File.Exists(_rutas.Usuarios))
                return new List<Usuario>();

            var json = await File.ReadAllTextAsync(_rutas.Usuarios);
            return JsonSerializer.Deserialize<List<Usuario>>(json, _opts) ?? new List<Usuario>();
        }

        public async Task GuardarAsync(List<Usuario> usuarios)
        {
            var json = JsonSerializer.Serialize(usuarios, _opts);
            await File.WriteAllTextAsync(_rutas.Usuarios, json);
        }
    }
}
