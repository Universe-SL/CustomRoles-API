# CustomRoles-API

Custom Roles API for the Nebuli Framework.

## How to create a custom role
- Implement the CustomRole class in your class
- Example:
```cs
public class ExampleRole : CustomRole
{
      public string Name { get; set; } = "Example Role Name";

      public string Description { get; set; } = "Example Role Description";

      public List<RoleTypeId> RolesAffected { get; set; } = new() { RoleTypeId.ClassD };

      public List<Item> Inventory { get; set; } = new() ....;

      public void OnLoad(NebuliPlayer player)
      {
             // Show the spawn hint to the player
             player......;
             base.OnLoad(player);
      }
}
```

## Are the created customroles automatically registered?
Yes, the CustomRoles.dll needs to be in the Plugins folder.
