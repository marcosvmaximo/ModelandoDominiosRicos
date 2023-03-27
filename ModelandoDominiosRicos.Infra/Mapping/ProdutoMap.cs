using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModelandoDominiosRicos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelandoDominiosRicos.Infra.Mapping;

public class ProdutoMap : IEntityTypeConfiguration<Produto>
{
    public void Configure(EntityTypeBuilder<Produto> builder)
    {
        builder.ToTable("md_produtos");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Titulo)
            .HasColumnName("titulo_produto")
            .HasColumnType("varchar");

        builder.Property(x => x.Preco)
            .HasColumnName("preco")
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.Property(x => x.Active)
            .HasColumnName("esta_ativo")
            .HasColumnType("bool")
            .IsRequired();

        builder.Property(x => x.TimeStamp)
            .HasColumnName("timestamp")
            .HasColumnType("TIMESTAMP");

        builder.Ignore(x => x.IsValid);
        builder.Ignore(x => x.Notifications);
    }
}
