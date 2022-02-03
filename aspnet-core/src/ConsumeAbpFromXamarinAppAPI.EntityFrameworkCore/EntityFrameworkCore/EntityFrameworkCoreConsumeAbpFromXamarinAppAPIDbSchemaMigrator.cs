using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ConsumeAbpFromXamarinAppAPI.Data;
using Volo.Abp.DependencyInjection;

namespace ConsumeAbpFromXamarinAppAPI.EntityFrameworkCore;

public class EntityFrameworkCoreConsumeAbpFromXamarinAppAPIDbSchemaMigrator
    : IConsumeAbpFromXamarinAppAPIDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreConsumeAbpFromXamarinAppAPIDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the ConsumeAbpFromXamarinAppAPIDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<ConsumeAbpFromXamarinAppAPIDbContext>()
            .Database
            .MigrateAsync();
    }
}
