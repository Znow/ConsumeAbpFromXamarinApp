using Volo.Abp.Modularity;

namespace ConsumeAbpFromXamarinAppAPI;

[DependsOn(
    typeof(ConsumeAbpFromXamarinAppAPIApplicationModule),
    typeof(ConsumeAbpFromXamarinAppAPIDomainTestModule)
    )]
public class ConsumeAbpFromXamarinAppAPIApplicationTestModule : AbpModule
{

}
