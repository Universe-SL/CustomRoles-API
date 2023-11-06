using System.Collections.Generic;
using CustomRoles.API.Utils;
using Nebuli.API.Features.Player;
using PlayerRoles;
using UnityEngine;

namespace CustomRoles.API;

public static class Extensions
{
    private static readonly Dictionary<NebuliPlayer, CustomRole> CustomRolesByPlayer = new();
    
    /// <summary>
    /// Give a player a custom role.
    /// </summary>
    /// <param name="player">The Player to give the role.</param>
    /// <param name="customRole">The role to give to the player.</param>
    public static void SetCustomRole(this NebuliPlayer player, CustomRole customRole)
    {
        if (!CustomRolesByPlayer.ContainsKey(player))
            CustomRolesByPlayer.Add(player, null);

        CustomRolesByPlayer[player] = customRole;
    }
    
    /// <summary>
    /// Gets the actual custom role of a player.
    /// </summary>
    /// <param name="player">The player with the custom role.</param>
    /// <returns>The custom role of the player.</returns>
    public static CustomRole GetCustomRole(this NebuliPlayer player)
    {
        return !CustomRolesByPlayer.ContainsKey(player) ? null : CustomRolesByPlayer[player];
    }
    
    public static CustomRole AssignCustomRole(this RoleTypeId roleTypeId)
    {
        if (!CustomRoleManager._customRolesByRole.ContainsKey(roleTypeId))
            return null;

        var finalList = CustomRoleManager._customRolesByRole[roleTypeId];
        return finalList[Random.Range(0, finalList.Count)];
    } 
}