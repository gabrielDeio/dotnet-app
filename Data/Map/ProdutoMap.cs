using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication2.Models;

namespace WebApplication2.Data.Map;

public class ProdutoMap : IEntityTypeConfiguration<ProdutoModel>
{
    public void Configure(EntityTypeBuilder<ProdutoModel> builder)
    {
        builder.HasKey(x => x.IdProduto);
        builder.Property(x => x.DscProduto).IsRequired();
        builder.Property(x => x.VlrUnitario).IsRequired();
    }
}