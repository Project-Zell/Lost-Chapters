using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostChapters.Modules.Custom.Archetypes.MageSlayer;

internal class JawStrikeUpgradeFeature
{
    public static readonly string Guid = "{15e89950-da7d-4604-a05e-1d611830a85f}";

    private static readonly string FeatureName = "JawStrikeUpgradeFeature";
    private static readonly string DisplayName = $"{FeatureName}.Name";
    private static readonly string Description = $"{FeatureName}.Description";

    //private static readonly Sprite Icon = $"{_Module.IconPath}/ .png";

    internal static void Configure()
    {
        FeatureConfigurator.New(FeatureName, Guid)
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            //.AddFeatureTagsComponent()
            //.SetIcon(Icon)
            .Configure();
    }
}
