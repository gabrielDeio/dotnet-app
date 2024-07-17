using Microsoft.EntityFrameworkCore;
using WebApplication2.Data.Map;
using WebApplication2.Models;

namespace WebApplication2.Data;

public class AppDBContext : DbContext
{
    public AppDBContext(DbContextOptions<AppDBContext> options)
    : base(options)
    {}
    
    public DbSet<ClienteModel> Clientes { get; set; }
    public DbSet<ProdutoModel> Produtos { get; set; }
    public DbSet<VendaModel> Vendas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ClienteMap());
        modelBuilder.ApplyConfiguration(new ProdutoMap());
        modelBuilder.ApplyConfiguration(new VendaMap());
        base.OnModelCreating(modelBuilder);
    }
}