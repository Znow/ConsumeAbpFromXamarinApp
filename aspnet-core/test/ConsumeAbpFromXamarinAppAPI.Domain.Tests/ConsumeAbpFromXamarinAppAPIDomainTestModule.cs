using ConsumeAbpFromXamarinAppAPI.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace ConsumeAbpFromXamarinAppAPI;

[DependsOn(
    typeof(ConsumeAbpFromXamarinAppAPIEntityFrameworkCoreTestModule)
    )]
public class ConsumeAbpFromXamarinAppAPIDomainTestModule : AbpModule
{

}
