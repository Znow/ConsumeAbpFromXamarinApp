using ConsumeAbpFromXamarinAppAPI.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace ConsumeAbpFromXamarinAppAPI.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(ConsumeAbpFromXamarinAppAPIEntityFrameworkCoreModule),
    typeof(ConsumeAbpFromXamarinAppAPIApplicationContractsModule)
    )]
public class ConsumeAbpFromXamarinAppAPIDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
    }
}
