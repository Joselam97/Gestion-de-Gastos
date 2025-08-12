using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using GestionDeGastos.Web.Modelos;
using GestionDeGastos.Web.Servicios;

namespace GestionDeGastos.Web.Datos
{
    public class GrupoRepositorioJson
    {
        private readonly RutasArchivos _rutas;
        private static readonly JsonSerializerOptions _opts = new() { WriteIndented = true, PropertyNameCaseInsensitive = true };

        public GrupoRepositorioJson(RutasArchivos rutas) => _rutas = rutas;

        public async Task<List<Grupo>> CargarAsync()
        {
            if (!File.Exists(_rutas.Grupos)) return new List<Grupo>();
            var json = await File.ReadAllTextAsync(_rutas.Grupos);
            return JsonSerializer.Deserialize<List<Grupo>>(json, _opts) ?? new List<Grupo>();
        }

        public async Task GuardarAsync(List<Grupo> grupos)
        {
            var json = JsonSerializer.Serialize(grupos, _opts);
            await File.WriteAllTextAsync(_rutas.Grupos, json);
        }

        public async Task<Grupo> CrearAsync(Grupo nuevo)
        {
            var grupos = await CargarAsync();
            var nextId = grupos.Count == 0 ? 1 : grupos.Max(g => g.Id) + 1;
            nuevo.Id = nextId;

            grupos.Add(nuevo);
            await GuardarAsync(grupos);
            return nuevo;
        }
    }
}
