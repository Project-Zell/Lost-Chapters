using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;

namespace LostChapters.Modules.Custom.Archetypes.FalseKnight.FallenOrder;

internal class FallenOrderFeature
{
    public static readonly string Guid = "{82aca15c-357a-4d92-88d6-3a2e62a82190}";

    private static readonly string BaseName = "FallenOrder";

    private static readonly string FeatureName = $"{BaseName}Feature";
    private static readonly string DisplayName = $"{FeatureName}.Name";
    private static readonly string Description = $"{FeatureName}.Description";

    public static void Configure()
    {
        Challenge.Configure();

        ImpostorFeature.Configure();
        RevenantFeature.Configure();
        UnyieldingDevotionFeature.Configure();

        ProgressionConfigurator.New(FeatureName, Guid)
            .AddToLevelEntry(level: 01, features: Challenge.Guid)
            .AddToLevelEntry(level: 02, features: ImpostorFeature.Guid)
            .AddToLevelEntry(level: 08, features: RevenantFeature.Guid)
            .AddToLevelEntry(level: 15, features: UnyieldingDevotionFeature.Guid)
            .SetUIGroups(UIGroupBuilder.New().AddGroup([Challenge.Guid]))
            .SetClasses(CharacterClassRefs.CavalierClass.ToString())
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .Configure();
    }

    internal class Challenge
    {
        public static readonly string Guid = "{25c96df7-b2ec-4db1-ac49-f77ca28bd5d5}";

        private static readonly string FeatureName = $"{FallenOrderFeature.FeatureName}.Challenge";
        private static readonly string DisplayName = $"{FeatureName}.Name";
        private static readonly string Description = $"{FeatureName}.Description";

        internal static void Configure()
        {
            FeatureConfigurator.New(FeatureName, Guid)
                .SetIsClassFeature(true)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }
}
