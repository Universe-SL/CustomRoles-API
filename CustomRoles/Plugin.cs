using System;
using CustomRoles.API;
using Nebuli.API.Features;

namespace CustomRoles;

public class Plugin : Plugin<Config>
{
    public override string Creator { get; } = "xNexusACS";
    
    public override string Name { get; } = "CustomRolesAPI";

    public override Version Version { get; } = new(1, 0, 0);

    public override Version NebuliVersion { get; } = new(1, 3, 4);

    public override bool SkipVersionCheck { get; } = true;

    private CustomRoleManager _customRoleManager;
    
    public override void OnEnabled()
    {
        _customRoleManager = new();
        
        _customRoleManager.LoadClasses();
        _customRoleManager.RegisterEvents();
        
        base.OnEnabled();
    }
    
    public override void OnDisabled()
    {
        _customRoleManager = null;
        
        base.OnDisabled();
    }
}