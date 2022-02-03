using ConsumeAbpFromXamarinApp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace ConsumeAbpFromXamarinApp;

[DependsOn(
    typeof(ConsumeAbpFromXamarinAppEntityFrameworkCoreTestModule)
    )]
public class ConsumeAbpFromXamarinAppDomainTestModule : AbpModule
{

}
