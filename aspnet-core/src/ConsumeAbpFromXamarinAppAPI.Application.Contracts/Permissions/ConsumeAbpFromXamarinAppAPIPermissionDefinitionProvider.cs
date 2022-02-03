using ConsumeAbpFromXamarinAppAPI.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace ConsumeAbpFromXamarinAppAPI.Permissions;

public class ConsumeAbpFromXamarinAppAPIPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(ConsumeAbpFromXamarinAppAPIPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(ConsumeAbpFromXamarinAppAPIPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<ConsumeAbpFromXamarinAppAPIResource>(name);
    }
}
