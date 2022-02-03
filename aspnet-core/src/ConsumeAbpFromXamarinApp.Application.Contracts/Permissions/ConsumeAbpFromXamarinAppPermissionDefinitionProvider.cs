using ConsumeAbpFromXamarinApp.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace ConsumeAbpFromXamarinApp.Permissions;

public class ConsumeAbpFromXamarinAppPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(ConsumeAbpFromXamarinAppPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(ConsumeAbpFromXamarinAppPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<ConsumeAbpFromXamarinAppResource>(name);
    }
}
