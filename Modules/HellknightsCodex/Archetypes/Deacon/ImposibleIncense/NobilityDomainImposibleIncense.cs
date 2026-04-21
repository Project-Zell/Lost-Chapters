using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using LostChapters.Modules.HellknightCodex.Archetypes.Deacon.Incense;

namespace LostChapters.Modules.HellknightsCodex.Archetypes.Deacon.ImposibleIncense;

internal class NobilityDomainImposibleIncense
{
    public static readonly string Guid = "{33be61d6-1e1b-416e-923e-12332f11f95f}";

    private static readonly string FeatureName = "NobilityDomainImposibleIncense";
    private static readonly string DisplayName = $"{FeatureName}.Name";
    private static readonly string Description = $"{FeatureName}.Description";

    private static readonly string Domain = FeatureRefs.NobilityDomainAllowed.ToString();
    private static readonly string MinorFeatureGuid = NobilityDomainIncense.MinorFeature.Guid;
    private static readonly string MajorFeatureGuid = NobilityDomainIncense.MajorFeature.Guid;

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
        public static readonly string Guid = "{b2318c38-012a-406b-897a-7d2f66f4301f}";

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
