using Microsoft.EntityFrameworkCore;
using Refit;
using WebApplication2.Data;
using WebApplication2.Repositories;
using WebApplication2.Repositories.interfaces;
using WebApplication2.Services;

var builder = WebApplication.CreateBuilder(args);
DotNetEnv.Env.Load("./.env");


// Add services to the container.
builder.Services.AddControllersWithViews();
string connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("A variável de ambiente DB_CONNECTION_STRING não foi definida corretamente.");
}

builder.Services.AddEntityFrameworkSqlServer()
    .AddDbContext<AppDBContext>(
        options => options.UseSqlServer(Environment.GetEnvironmentVariable("DB_CONNECTION_STRING"))
        );

builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddTransient<IProdutoRepository, ProdutoRepository>();
builder.Services.AddTransient<IntegrationServices>();
builder.Services.AddTransient<ClienteServices>();
builder.Services.AddTransient<ProdutoServices>();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();