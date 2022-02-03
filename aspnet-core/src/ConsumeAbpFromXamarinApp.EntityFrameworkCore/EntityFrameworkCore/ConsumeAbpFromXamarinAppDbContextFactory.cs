using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace ConsumeAbpFromXamarinApp.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class ConsumeAbpFromXamarinAppDbContextFactory : IDesignTimeDbContextFactory<ConsumeAbpFromXamarinAppDbContext>
{
    public ConsumeAbpFromXamarinAppDbContext CreateDbContext(string[] args)
    {
        ConsumeAbpFromXamarinAppEfCoreEntityExtensionMappings.Configure();

        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<ConsumeAbpFromXamarinAppDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));

        return new ConsumeAbpFromXamarinAppDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../ConsumeAbpFromXamarinApp.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
