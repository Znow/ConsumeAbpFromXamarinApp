using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ConsumeAbpFromXamarinApp.Data;
using Volo.Abp.DependencyInjection;

namespace ConsumeAbpFromXamarinApp.EntityFrameworkCore;

public class EntityFrameworkCoreConsumeAbpFromXamarinAppDbSchemaMigrator
    : IConsumeAbpFromXamarinAppDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreConsumeAbpFromXamarinAppDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the ConsumeAbpFromXamarinAppDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<ConsumeAbpFromXamarinAppDbContext>()
            .Database
            .MigrateAsync();
    }
}
