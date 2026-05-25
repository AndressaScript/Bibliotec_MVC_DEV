using Bibliotec_MVC_DEV.Contexts;
using Bibliotec_MVC_DEV.Interfaces;
using Bibliotec_MVC_DEV.Repositories;
using Bibliotec_MVC_DEV.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//adicionar aqui!!!!! depois do builder service e antes do builder.Builder

builder.Services.AddDbContext<BbDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//adicionando seesoes
builder.Services.AddSession( options => {
    options.IdleTimeout = TimeSpan.FromMinutes(30); //está definindo a sessão em 30 min. 30 minutos sem requisição a página desloga.
    options.Cookie.HttpOnly = true; //a sessão armazena dados no cookie, sem possivel acessar apenas através do http, sem o inspesor de elementos
    options.Cookie.IsEssential = true; // está utilizando porque é essencial, sem necessariamente precisar perguntar para o usuario se ele aceita os cookies

});

builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>(); //primeiro a interface depois o repositorio
builder.Services.AddScoped<IUsuarioService, UsuarioService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
 
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

//add aqui

app.UseSession();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
