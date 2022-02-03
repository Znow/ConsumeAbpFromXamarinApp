using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace ConsumeAbpFromXamarinApp.Data;

/* This is used if database provider does't define
 * IConsumeAbpFromXamarinAppDbSchemaMigrator implementation.
 */
public class NullConsumeAbpFromXamarinAppDbSchemaMigrator : IConsumeAbpFromXamarinAppDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
