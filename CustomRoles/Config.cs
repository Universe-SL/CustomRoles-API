using System.ComponentModel;
using Nebuli.API.Interfaces;

namespace CustomRoles;

public class Config : IConfiguration
{
    [Description("Whether or not the plugin is enabled.")]
    public bool IsEnabled { get; set; } = true;

    [Description("Whether or not the plugin should show debug logs.")]
    public bool Debug { get; set; } = false;
}