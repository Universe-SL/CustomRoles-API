using System.Collections.Generic;
using Nebuli.API.Features.Items;
using Nebuli.API.Features.Player;
using PlayerRoles;

namespace CustomRoles.API.Utils;

/// <summary>
/// The Class to create custom roles.
/// </summary>
public abstract class CustomRole : ICustomRole
{
    internal int customRoleId;
    
    public string Name { get; set; } = string.Empty;
    
    public string Description { get; set; } = string.Empty;
    
    public List<RoleTypeId> RolesAffected { get; set; } = new();

    public List<Item> Inventory { get; set; } = null;
    
    public void OnLoad(NebuliPlayer player) { }
}