using ConsumeAbpFromXamarinApp.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace ConsumeAbpFromXamarinApp.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(ConsumeAbpFromXamarinAppEntityFrameworkCoreModule),
    typeof(ConsumeAbpFromXamarinAppApplicationContractsModule)
    )]
public class ConsumeAbpFromXamarinAppDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
    }
}
