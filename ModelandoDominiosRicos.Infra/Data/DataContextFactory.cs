using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ModelandoDominiosRicos.Infra.Data;

public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
{
    DataContext IDesignTimeDbContextFactory<DataContext>.CreateDbContext(string[] args)
    {
        var connectionString =
        "server=localhost;database=modelandoDominioRicos;user=root;password=88378621;";

        var optionsBuilder = new DbContextOptionsBuilder<DataContext>();

        optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

        return new DataContext(optionsBuilder.Options);
    }
}
