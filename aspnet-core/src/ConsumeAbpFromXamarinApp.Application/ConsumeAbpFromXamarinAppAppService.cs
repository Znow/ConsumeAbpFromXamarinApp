using System;
using System.Collections.Generic;
using System.Text;
using ConsumeAbpFromXamarinApp.Localization;
using Volo.Abp.Application.Services;

namespace ConsumeAbpFromXamarinApp;

/* Inherit your application services from this class.
 */
public abstract class ConsumeAbpFromXamarinAppAppService : ApplicationService
{
    protected ConsumeAbpFromXamarinAppAppService()
    {
        LocalizationResource = typeof(ConsumeAbpFromXamarinAppResource);
    }
}
