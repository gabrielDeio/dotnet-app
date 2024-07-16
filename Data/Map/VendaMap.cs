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
        builder.Property(x => x.VlrTotalVenda).IsRequired();
        builder.Property(x => x.VlrUnitarioVenda).IsRequired();
        builder.Property(x => x.IdCliente).IsRequired();
        builder.Property(x => x.IdProduto);

        builder.HasOne(x => x.Cliente);
        builder.HasOne(x => x.Produto);
        
    }
}