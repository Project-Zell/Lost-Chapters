using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using LostChapters.Modules.HellknightsCodex.Archetypes.Deacon.Incense;

namespace LostChapters.Modules.HellknightsCodex.Archetypes.Deacon.ImposibleIncense;

internal class AirDomainImposibleIncense
{
    public static readonly string Guid = "{1b0309d0-1f2e-4765-a6d3-6ad120cba1dd}";

    private static readonly string FeatureName = "AirDomainImposibleIncense";
    private static readonly string DisplayName = $"{FeatureName}.Name";
    private static readonly string Description = $"{FeatureName}.Description";

    private static readonly string Domain = FeatureRefs.AirDomainAllowed.ToString();
    private static readonly string MinorFeatureGuid = AirDomainIncense.MinorFeature.Guid;
    private static readonly string MajorFeatureGuid = AirDomainIncense.MajorFeature.Guid;

    //private static readonly Sprite Icon = $"{_Module.IconPath}/ .png";

    internal static void Configure()
    {
        Progression.Configure();

        FeatureConfigurator.New(FeatureName, Guid)
            .AddPrerequisiteNoFeature(feature: Domain, checkInProgression: true, hideInUI: true)
            .AddFacts([Progression.Guid])
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            //.AddFeatureTagsComponent()
            //.SetIcon(Icon)
            .Configure();
    }

    internal class Progression
    {
        public static readonly string Guid = "{05a6bbea-8c6f-43cf-a19c-df8064cccddf}";

        private static readonly string ProgressionName = $"{FeatureName}.Progression";

        internal static void Configure()
        {
            ProgressionConfigurator.New(ProgressionName, Guid)
                .AddToLevelEntries(level: 01, features: MinorFeatureGuid)
                .AddToLevelEntries(level: 10, features: MajorFeatureGuid)
                .SetClasses(classes: CharacterClassRefs.WarpriestClass.ToString())
                .SetIsClassFeature(true)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetHideInUI()
                .Configure();
        }
    }
}
