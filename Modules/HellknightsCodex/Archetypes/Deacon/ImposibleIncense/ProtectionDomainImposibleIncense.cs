using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using LostChapters.Modules.HellknightCodex.Archetypes.Deacon.Incense;

namespace LostChapters.Modules.HellknightsCodex.Archetypes.Deacon.ImposibleIncense;

internal class ProtectionDomainImposibleIncense
{
    public static readonly string Guid = "{21bf1270-c057-4ea5-b9bb-dfb448c72188}";

    private static readonly string FeatureName = "ProtectionDomainImposibleIncense";
    private static readonly string DisplayName = $"{FeatureName}.Name";
    private static readonly string Description = $"{FeatureName}.Description";

    private static readonly string Domain = FeatureRefs.ProtectionDomainAllowed.ToString();
    private static readonly string MinorFeatureGuid = ProtectionDomainIncense.MinorFeature.Guid;
    private static readonly string MajorFeatureGuid = ProtectionDomainIncense.MajorFeature.Guid;

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
        public static readonly string Guid = "{4cd9c9f1-fc4e-4ddf-96c5-c8e09ec5f170}";

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
