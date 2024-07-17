using Microsoft.EntityFrameworkCore;
using Refit;
using WebApplication2.Data;
using WebApplication2.Repositories;
using WebApplication2.Repositories.interfaces;
using WebApplication2.Services;

var builder = WebApplication.CreateBuilder(args);
var  MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
DotNetEnv.Env.Load("./.env");


// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy  =>
                      {
                          policy.WithOrigins("http://localhost:5173")
                          .AllowAnyHeader()
                          .AllowAnyMethod()
                          .AllowAnyOrigin();
                      });
});
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
builder.Services.AddTransient<IVendaRepository, VendaRepository>();
builder.Services.AddScoped<IVendaServices, VendaServices>();
builder.Services.AddScoped<IIntegrationServices, IntegrationServices>();
builder.Services.AddScoped<IClienteServices, ClienteServices>();
builder.Services.AddScoped<IProdutoServices, ProdutoServices>();
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
app.UseCors(MyAllowSpecificOrigins);
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();