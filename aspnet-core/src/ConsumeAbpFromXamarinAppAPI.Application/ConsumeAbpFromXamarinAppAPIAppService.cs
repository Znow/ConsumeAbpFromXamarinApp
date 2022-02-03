using System;
using System.Collections.Generic;
using System.Text;
using ConsumeAbpFromXamarinAppAPI.Localization;
using Volo.Abp.Application.Services;

namespace ConsumeAbpFromXamarinAppAPI;

/* Inherit your application services from this class.
 */
public abstract class ConsumeAbpFromXamarinAppAPIAppService : ApplicationService
{
    protected ConsumeAbpFromXamarinAppAPIAppService()
    {
        LocalizationResource = typeof(ConsumeAbpFromXamarinAppAPIResource);
    }
}
