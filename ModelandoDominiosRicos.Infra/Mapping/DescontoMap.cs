using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModelandoDominiosRicos.Domain.Entities;

namespace ModelandoDominiosRicos.Infra.Mapping;

public class DescontoMap : IEntityTypeConfiguration<Desconto>
{
    public void Configure(EntityTypeBuilder<Desconto> builder)
    {
        builder.ToTable("md_descontos");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.DataExpiracao)
            .HasColumnName("data_expiracao")
            .HasColumnType("varchar")
            .IsRequired();

        builder.Property(x => x.ValorDesconto)
            .HasColumnName("valor_desconto")
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.Property(x => x.TimeStamp)
            .HasColumnName("timestamp")
            .HasColumnType("TIMESTAMP");

        builder.Ignore(x => x.IsValid);
        builder.Ignore(x => x.Notifications); 
    }
}

