using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using LostChapters.Modules.HellknightCodex.Archetypes.Deacon.Incense;

namespace LostChapters.Modules.HellknightsCodex.Archetypes.Deacon.ImposibleIncense;

internal class MagicDomainImposibleIncense
{
    public static readonly string Guid = "{d8b27bad-e9cf-4811-ac23-dd92cb745d51}";

    private static readonly string FeatureName = "MagicDomainImposibleIncense";
    private static readonly string DisplayName = $"{FeatureName}.Name";
    private static readonly string Description = $"{FeatureName}.Description";

    private static readonly string Domain = FeatureRefs.MagicDomainAllowed.ToString();
    private static readonly string MinorFeatureGuid = MagicDomainIncense.MinorFeature.Guid;
    private static readonly string MajorFeatureGuid = MagicDomainIncense.MajorFeature.Guid;

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
        public static readonly string Guid = "{b4d38d2e-e802-46a2-8383-f222533a277c}";

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
