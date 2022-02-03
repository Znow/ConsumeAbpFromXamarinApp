using ConsumeAbpFromXamarinApp.Localization;
using Volo.Abp.AspNetCore.Components;

namespace ConsumeAbpFromXamarinApp.Blazor;

public abstract class ConsumeAbpFromXamarinAppComponentBase : AbpComponentBase
{
    protected ConsumeAbpFromXamarinAppComponentBase()
    {
        LocalizationResource = typeof(ConsumeAbpFromXamarinAppResource);
    }
}
