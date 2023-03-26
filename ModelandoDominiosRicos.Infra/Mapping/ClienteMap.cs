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
        builder.HasKey(x => x.Id);

        builder.HasMany(x => x.CarrinhoItensPedido)
               .WithOne(x => x.Cliente)
               .HasForeignKey(x => x.IdCliente);

        builder.Ignore(x => x.Notifications);

    }
}
