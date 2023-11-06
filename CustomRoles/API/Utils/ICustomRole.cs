using System.Collections.Generic;
using Nebuli.API.Features.Items;
using Nebuli.API.Features.Player;
using PlayerRoles;

namespace CustomRoles.API.Utils;

/// <summary>
/// THIS CLASS SHOULD NOT BE USED WHEN CREATING A CUSTOM ROLE.
/// </summary>
public interface ICustomRole
{
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public List<RoleTypeId> RolesAffected { get; set; }
    
    public List<Item> Inventory { get; set; }
    
    public void OnLoad(NebuliPlayer player);
}