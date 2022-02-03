using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace ConsumeAbpFromXamarinAppAPI.Data;

/* This is used if database provider does't define
 * IConsumeAbpFromXamarinAppAPIDbSchemaMigrator implementation.
 */
public class NullConsumeAbpFromXamarinAppAPIDbSchemaMigrator : IConsumeAbpFromXamarinAppAPIDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
