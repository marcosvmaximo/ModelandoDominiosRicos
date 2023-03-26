using System;
using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;
using ModelandoDominiosRicos.Domain.Entities;
using ModelandoDominiosRicos.Domain.Entities.Common;

namespace ModelandoDominiosRicos.Infra.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Produto> Produtos { get; set; }
    public DbSet<Desconto> Descontos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Notification>().HasNoKey();
        //modelBuilder.Entity<Entity>().Ignore(x => x.Notifications);
        modelBuilder.Entity<Produto>().Ignore(x => x.Notifications);
        modelBuilder.Entity<Cliente>().Ignore(x => x.Notifications);
    }
}

