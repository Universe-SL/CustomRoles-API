using System;
using System.Collections.Generic;
using System.Linq;
using CustomRoles.API.Utils;
using MEC;
using Nebuli.API.Features;
using Nebuli.Events.EventArguments.Player;
using Nebuli.Events.Handlers;
using PlayerRoles;

namespace CustomRoles.API;

public class CustomRoleManager
{
    private readonly Dictionary<int, CustomRole> _customRolesById = new ();
    internal static readonly Dictionary<RoleTypeId, List<CustomRole>> _customRolesByRole = new();

    internal void RegisterEvents()
    {
        PlayerHandlers.RoleChange += OnRoleChange;
    }
    
    internal void LoadClasses()
    {
        foreach (var type in typeof(CustomRoleManager).Assembly.GetTypes())
        { 
            if (!type.IsSubclassOf(typeof(CustomRole)))
                continue;

            Register(type);
        }
    }
    
    private void Register(Type type)
    {
        if (Activator.CreateInstance(type) is not CustomRole customRole)
            return;
        
        customRole.customRoleId = _customRolesById.Count;

        _customRolesById.Add(_customRolesById.Count, customRole);

        foreach (var role in customRole.RolesAffected)
        {
            if (!_customRolesByRole.ContainsKey(role))
                _customRolesByRole.Add(role, new List<CustomRole>());

            _customRolesByRole[role].Add(customRole);
        }
        
        Log.Info($"[CustomRole Manager] {customRole.Name} has been registered successfully");
    }
    
    /// <summary>
    /// Get a custom role by its name.
    /// </summary>
    /// <param name="name">The name of the custom role.</param>
    /// <returns>The custom role with the specified name</returns>
    public CustomRole GetCustomRoleByName(string name) => _customRolesById.Values.FirstOrDefault(x => x.Name == name);
    
    /// <summary>
    /// Assign automatically a custom role from the list of custom roles to the player.
    /// Note: It only assign custom roles that affect the player's role type (Check RolesAffected in CustomRole.cs).
    /// </summary>
    /// <param name="args">The Player Role Change Event.</param>
    private void OnRoleChange(PlayerRoleChangeEvent args)
    {
        var customRole = args.NewRole.AssignCustomRole();

        if (customRole == null)
        {
            args.Player.SetCustomRole(null);
            return;
        }
        
        args.Player.SetCustomRole(customRole);
        
        Timing.CallDelayed(2f, () =>
        {
            if (customRole.Inventory is not null)
            {
                args.Player.ClearInventory();
                args.Player.AddItems(customRole.Inventory);
            }
        });
        
        customRole.OnLoad(args.Player);
    }
}