using ConsumeAbpFromXamarinApp.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace ConsumeAbpFromXamarinApp.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class ConsumeAbpFromXamarinAppController : AbpControllerBase
{
    protected ConsumeAbpFromXamarinAppController()
    {
        LocalizationResource = typeof(ConsumeAbpFromXamarinAppResource);
    }
}
