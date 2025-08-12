using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using GestionDeGastos.Web.Modelos;
using GestionDeGastos.Web.Servicios;

namespace GestionDeGastos.Web.Datos
{
    public class GastoRepositorioJson
    {
        private readonly RutasArchivos _rutas;
        private static readonly JsonSerializerOptions _opts = new() { WriteIndented = true, PropertyNameCaseInsensitive = true };

        public GastoRepositorioJson(RutasArchivos rutas) => _rutas = rutas;

        public async Task<List<Gasto>> CargarAsync()
        {
            if (!File.Exists(_rutas.Gastos)) return new List<Gasto>();
            var json = await File.ReadAllTextAsync(_rutas.Gastos);
            return JsonSerializer.Deserialize<List<Gasto>>(json, _opts) ?? new List<Gasto>();
        }

        public async Task GuardarAsync(List<Gasto> gastos)
        {
            var json = JsonSerializer.Serialize(gastos, _opts);
            await File.WriteAllTextAsync(_rutas.Gastos, json);
        }

        public async Task<Gasto> CrearAsync(Gasto nuevo)
        {
            var gastos = await CargarAsync();
            var nextId = gastos.Count == 0 ? 1 : gastos.Max(g => g.Id) + 1;
            nuevo.Id = nextId;
            gastos.Add(nuevo);
            await GuardarAsync(gastos);
            return nuevo;
        }
    }
}