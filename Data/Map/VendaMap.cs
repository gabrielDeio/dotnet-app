using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication2.Models;

namespace WebApplication2.Data.Map;

public class VendaMap : IEntityTypeConfiguration<VendaModel>
{
    public void Configure(EntityTypeBuilder<VendaModel> builder)
    {
        builder.HasKey(x => x.IdVenda);
        builder.Property(x => x.IdVenda).ValueGeneratedNever();
        builder.Property(x => x.DthVenda).IsRequired();
        builder.Property(x => x.QtdVenda).IsRequired();
        builder.Ignore(x => x.VlrTotalVenda);
        builder.Property(x => x.VlrUnitarioVenda).IsRequired();
        builder.Property(x => x.IdCliente).IsRequired().HasColumnName("IdCliente");
        builder.Property(x => x.IdProduto).HasColumnName("IdProduto");

        builder.HasOne(x => x.Cliente)
            .WithMany()
            .HasForeignKey(x => x.IdCliente)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Produto)
            .WithMany()
            .HasForeignKey(x => x.IdProduto)
            .OnDelete(DeleteBehavior.Restrict);
        
    }
}