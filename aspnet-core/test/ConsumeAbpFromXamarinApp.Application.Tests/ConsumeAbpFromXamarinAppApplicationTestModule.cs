using Volo.Abp.Modularity;

namespace ConsumeAbpFromXamarinApp;

[DependsOn(
    typeof(ConsumeAbpFromXamarinAppApplicationModule),
    typeof(ConsumeAbpFromXamarinAppDomainTestModule)
    )]
public class ConsumeAbpFromXamarinAppApplicationTestModule : AbpModule
{

}
