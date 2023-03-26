using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModelandoDominiosRicos.Domain.Entities;

namespace ModelandoDominiosRicos.Infra.Mapping;

public class ItemPedidoMap : IEntityTypeConfiguration<ItemPedido>
{
    public void Configure(EntityTypeBuilder<ItemPedido> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Produto);

        builder.HasOne(x => x.Cliente)
            .WithMany(x => x.CarrinhoItensPedido)
            .HasForeignKey(x => x.IdCliente);
    }
}
