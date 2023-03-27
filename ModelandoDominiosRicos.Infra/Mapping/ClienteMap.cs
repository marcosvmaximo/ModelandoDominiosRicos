using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModelandoDominiosRicos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelandoDominiosRicos.Infra.Mapping;

public class ClienteMap : IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> builder)
    {
        builder.ToTable("md_clientes");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Nome)
            .HasColumnName("nome")
            .HasColumnType("varchar");

        builder.Property(x => x.Email)
            .HasColumnName("email")
            .HasColumnType("varchar");

        builder.Property(x => x.TimeStamp)
            .HasColumnName("timestamp")
            .HasColumnType("TIMESTAMP");

        builder.Ignore(x => x.IsValid);
        builder.Ignore(x => x.Notifications);
    }
}
