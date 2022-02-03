using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace ConsumeAbpFromXamarinAppAPI.Blazor;

[Dependency(ReplaceServices = true)]
public class ConsumeAbpFromXamarinAppAPIBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "ConsumeAbpFromXamarinAppAPI";
}
