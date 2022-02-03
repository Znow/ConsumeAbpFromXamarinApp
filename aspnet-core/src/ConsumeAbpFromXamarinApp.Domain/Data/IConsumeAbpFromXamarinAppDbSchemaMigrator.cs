using System.Threading.Tasks;

namespace ConsumeAbpFromXamarinApp.Data;

public interface IConsumeAbpFromXamarinAppDbSchemaMigrator
{
    Task MigrateAsync();
}
