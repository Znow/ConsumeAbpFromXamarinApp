using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace ConsumeAbpFromXamarinAppAPI;

[Dependency(ReplaceServices = true)]
public class ConsumeAbpFromXamarinAppAPIBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "ConsumeAbpFromXamarinAppAPI";
}
