using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication2.Models;

namespace WebApplication2.Data.Map;

public class ClienteMap : IEntityTypeConfiguration<ClienteModel>
{
    public void Configure(EntityTypeBuilder<ClienteModel> builder)
    {
        builder.HasKey(x => x.IdCliente);
        builder.Property(x => x.NmCliente).IsRequired().HasMaxLength(255);
        builder.Property(x => x.Cidade).IsRequired().HasMaxLength(255);
    }
}