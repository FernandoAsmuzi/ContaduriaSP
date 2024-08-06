using ContadSP.Data;
using ContadSP.Models;
using ContadSP.Repositorios;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

using Blazored.SessionStorage; //inicio de sesion
using Microsoft.AspNetCore.Components.Authorization;//inicio de sesion
using ContadSP.Extensiones;//inicio de sesion
using Radzen;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddBlazoredSessionStorage();//inicio de sesion
builder.Services.AddScoped<AuthenticationStateProvider, AutenticacionExtension>();//inicio de sesion
builder.Services.AddAuthorizationCore();//inicio de sesion

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<IRepositorio<Articulo>, Repositorio<Articulo>>();
builder.Services.AddScoped<IRepositorio<Categoria>, Repositorio<Categoria>>();
builder.Services.AddScoped<IRepositorio<Destino>, Repositorio<Destino>>();
builder.Services.AddScoped<IRepositorio<DetallePedido>, Repositorio<DetallePedido>>();
builder.Services.AddScoped<IRepositorio<DetalleProvision>, Repositorio<DetalleProvision>>();
builder.Services.AddScoped<IRepositorio<Estado>, Repositorio<Estado>>();
builder.Services.AddScoped<IRepositorio<Pedido>, Repositorio<Pedido>>();
builder.Services.AddScoped<IRepositorio<PedidoProveedor>, Repositorio<PedidoProveedor>>();
builder.Services.AddScoped<IRepositorio<Proceso>, Repositorio<Proceso>>();
builder.Services.AddScoped<IRepositorio<ProcesoPedido>, Repositorio<ProcesoPedido>>();
builder.Services.AddScoped<IRepositorio<Proveedor>, Repositorio<Proveedor>>();
builder.Services.AddScoped<IRepositorio<Provision>, Repositorio<Provision>>();
builder.Services.AddScoped<IRepositorio<ProvisionExp>, Repositorio<ProvisionExp>>();
builder.Services.AddScoped<IRepositorio<SitFiscal>, Repositorio<SitFiscal>>();
builder.Services.AddScoped<IRepositorio<TipoPedido>, Repositorio<TipoPedido>>();
builder.Services.AddScoped<IRepositorio<UnidadMedida>, Repositorio<UnidadMedida>>();
builder.Services.AddScoped<IRepositorio<Usuario>, Repositorio<Usuario>>();

builder.Services.AddRadzenComponents();

builder.Services.AddHttpClient(); 
builder.Services.AddDbContext<ContadSPContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
    new MySqlServerVersion(new Version(8, 0, 36))
    ));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

// lectura del directorio de fotos
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "fotos1")),
    RequestPath = "/fotos1"
});

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
