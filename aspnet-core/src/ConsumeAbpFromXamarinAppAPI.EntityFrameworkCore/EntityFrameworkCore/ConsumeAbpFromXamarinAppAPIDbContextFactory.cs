using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace ConsumeAbpFromXamarinAppAPI.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class ConsumeAbpFromXamarinAppAPIDbContextFactory : IDesignTimeDbContextFactory<ConsumeAbpFromXamarinAppAPIDbContext>
{
    public ConsumeAbpFromXamarinAppAPIDbContext CreateDbContext(string[] args)
    {
        ConsumeAbpFromXamarinAppAPIEfCoreEntityExtensionMappings.Configure();

        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<ConsumeAbpFromXamarinAppAPIDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));

        return new ConsumeAbpFromXamarinAppAPIDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../ConsumeAbpFromXamarinAppAPI.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
