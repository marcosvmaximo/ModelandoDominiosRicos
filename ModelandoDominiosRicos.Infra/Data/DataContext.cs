using System;
using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;
using ModelandoDominiosRicos.Domain.Entities;
using ModelandoDominiosRicos.Domain.Entities.Common;
using ModelandoDominiosRicos.Infra.Mapping;

namespace ModelandoDominiosRicos.Infra.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Produto> Produtos { get; set; }
    public DbSet<Desconto> Descontos { get; set; }
    public DbSet<ItemPedido> ItemPedidos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new ClienteMap());
        modelBuilder.ApplyConfiguration(new DescontoMap());
        modelBuilder.ApplyConfiguration(new ItemPedidoMap());
        modelBuilder.ApplyConfiguration(new ProdutoMap());

    }
}

