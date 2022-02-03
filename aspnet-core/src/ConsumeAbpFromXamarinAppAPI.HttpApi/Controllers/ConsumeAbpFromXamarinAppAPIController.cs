using ConsumeAbpFromXamarinAppAPI.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace ConsumeAbpFromXamarinAppAPI.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class ConsumeAbpFromXamarinAppAPIController : AbpControllerBase
{
    protected ConsumeAbpFromXamarinAppAPIController()
    {
        LocalizationResource = typeof(ConsumeAbpFromXamarinAppAPIResource);
    }
}
