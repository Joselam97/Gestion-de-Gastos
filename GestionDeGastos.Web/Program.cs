using GestionDeGastos.Web.Components;
using GestionDeGastos.Web.Datos;
using GestionDeGastos.Web.Servicios;

var builder = WebApplication.CreateBuilder(args);

// Blazor Web App (.NET 8)
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Rutas y repos
builder.Services.AddSingleton(sp => new RutasArchivos(builder.Environment.ContentRootPath));
builder.Services.AddSingleton<UsuarioRepositorioJson>();
builder.Services.AddSingleton<GrupoRepositorioJson>();
builder.Services.AddSingleton<GastoRepositorioJson>();

var app = builder.Build();

// Solo en producción forzamos HTTPS/HSTS
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
    app.UseHttpsRedirection();
}

app.UseStaticFiles();
app.UseAntiforgery();

// Montar la app (usa Components/App.razor)
app.MapRazorComponents<App>()
   .AddInteractiveServerRenderMode();

app.Run();
