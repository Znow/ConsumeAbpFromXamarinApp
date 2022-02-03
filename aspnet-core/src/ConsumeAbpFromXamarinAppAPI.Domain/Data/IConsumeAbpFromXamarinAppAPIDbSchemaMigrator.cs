using System.Threading.Tasks;

namespace ConsumeAbpFromXamarinAppAPI.Data;

public interface IConsumeAbpFromXamarinAppAPIDbSchemaMigrator
{
    Task MigrateAsync();
}
