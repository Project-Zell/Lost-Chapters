using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using LostChapters.Modules.HellknightCodex.Archetypes.Deacon.Incense;
using LostChapters.Modules.HellknightsCodex.Archetypes.Deacon.Incense;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostChapters.Modules.HellknightsCodex.Archetypes.Deacon.ImposibleIncense;

internal class PlantDomainImposibleIncense
{
    public static readonly string Guid = "{c8eb80e0-1ca5-4ec2-ac55-69f66c806efc}";

    private static readonly string FeatureName = "PlantDomainImposibleIncense";
    private static readonly string DisplayName = $"{FeatureName}.Name";
    private static readonly string Description = $"{FeatureName}.Description";

    private static readonly string Domain = FeatureRefs.PlantDomainAllowed.ToString();
    private static readonly string MinorFeatureGuid = PlantDomainIncense.MinorFeature.Guid;
    private static readonly string MajorFeatureGuid = PlantDomainIncense.MajorFeature.Guid;

    //private static readonly Sprite Icon = $"{_Module.IconPath}/ .png";

    internal static void Configure()
    {
        FeatureConfigurator.New(FeatureName, Guid)
            .AddPrerequisiteNoFeature(feature: Domain, checkInProgression: true, hideInUI: true)
            .AddFacts([Progression.Guid])
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            //.SetIcon(Icon)
            .Configure();
    }

    internal class Progression
    {
        public static readonly string Guid = "{0973b6c3-99e4-49ad-b20d-679751868744}";

        private static readonly string ProgressionName = $"{FeatureName}.Progression";

        internal static void Configure()
        {
            ProgressionConfigurator.New(ProgressionName, Guid)
                .AddToLevelEntries(level: 01, features: MinorFeatureGuid)
                .AddToLevelEntries(level: 10, features: MajorFeatureGuid)
                .SetClasses(classes: CharacterClassRefs.WarpriestClass.ToString())
                .SetIsClassFeature(true)
                .SetHideInUI()
                .Configure();
        }
    }
}
