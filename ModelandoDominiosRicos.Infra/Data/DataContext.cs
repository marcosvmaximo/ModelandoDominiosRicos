using System;
using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;
using ModelandoDominiosRicos.Domain.Entities;

namespace ModelandoDominiosRicos.Infra.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<Cliente> Clientes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Notification>().HasNoKey();
        modelBuilder.Entity<Cliente>().Ignore(x => x.Notifications);
    }
}

