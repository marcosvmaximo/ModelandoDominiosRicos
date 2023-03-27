using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModelandoDominiosRicos.Domain.Entities;

namespace ModelandoDominiosRicos.Infra.Mapping;

public class ItemPedidoMap : IEntityTypeConfiguration<ItemPedido>
{
    public void Configure(EntityTypeBuilder<ItemPedido> builder)
    {
        builder.ToTable("md_itens_pedidos");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.IdProduto)
            .HasColumnName("produto_id")
            .HasColumnType("char")
            .IsRequired();

        builder.Property(x => x.IdCliente)
            .HasColumnName("cliente_id")
            .HasColumnType("char")
            .IsRequired();

        builder.Property(x => x.Quantidade)
            .HasColumnName("quantidade_produto")
            .HasColumnType("int");

        builder.HasOne(x => x.Produto)
            .WithOne()
            .HasForeignKey<ItemPedido>(x => x.IdProduto);

        builder.HasOne(x => x.Cliente)
            .WithMany()
            .HasForeignKey(x => x.IdCliente);

        builder.Property(x => x.TimeStamp)
            .HasColumnName("timestamp")
            .HasColumnType("TIMESTAMP");

        builder.Ignore(x => x.IsValid);
        builder.Ignore(x => x.Notifications);
    }
}
