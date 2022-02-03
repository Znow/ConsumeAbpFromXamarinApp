﻿using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace ConsumeAbpFromXamarinApp;

[Dependency(ReplaceServices = true)]
public class ConsumeAbpFromXamarinAppBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "ConsumeAbpFromXamarinApp";
}
