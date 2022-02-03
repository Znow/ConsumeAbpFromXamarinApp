using ConsumeAbpFromXamarinAppAPI.Localization;
using Volo.Abp.AspNetCore.Components;

namespace ConsumeAbpFromXamarinAppAPI.Blazor;

public abstract class ConsumeAbpFromXamarinAppAPIComponentBase : AbpComponentBase
{
    protected ConsumeAbpFromXamarinAppAPIComponentBase()
    {
        LocalizationResource = typeof(ConsumeAbpFromXamarinAppAPIResource);
    }
}
