using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.Classes.Selection;
using BlueprintCore.Blueprints.References;

namespace LostChapters.Modules.HellknightCodex.PrestigeClasses.Hellknight.Codex;

internal class ImposingPresenceProgression
{
    public static readonly string Guid = "{14e3449f-e2db-41bb-b02d-4f6a44682b66}";

    private static readonly string FeatureName = "ImposingPresence";
    private static readonly string DisplayName = $"{FeatureName}.Name";
    private static readonly string Description = $"{FeatureName}.Description";

    internal static void Configure()
    {
        InitialSelection.Configure();
        MainSelection.Configure();

        ProgressionConfigurator.New(FeatureName, Guid)
            .SetClasses([CharacterClassRefs.HellknightClass.ToString(), CharacterClassRefs.HellknightSigniferClass.ToString()])
            .AddToLevelEntry(level: 01, features: InitialSelection.Guid)
            .AddToLevelEntry(level: 05, features: MainSelection.Guid)
            .AddToLevelEntry(level: 10, features: MainSelection.Guid)
            .AddToUIGroups([InitialSelection.Guid,MainSelection.Guid])
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .Configure();
    }

    internal class InitialSelection
    {
        public static readonly string Guid = "{737f05af-59c1-421a-9448-737051a8d407}";

        private static readonly string FeatureName = "ImposingPresence.InitialSelection";
        private static readonly string DisplayName = $"{FeatureName}.Name";
        private static readonly string Description = $"{FeatureName}.Description";

        internal static void Configure()
        {
            FeatureSelectionConfigurator.New(FeatureName, Guid)
                .AddToAllFeatures([
                    FeatureRefs.DazzlingDisplayFeature.ToString(),
                    FeatureRefs.PowerAttackFeature.ToString(),
                    FeatureRefs.IntimidatingProwess.ToString(),
                    FeatureRefs.CornugonSmash.ToString(),
                    FeatureRefs.ShatterDefenses.ToString(),
                    FeatureRefs.Toughness.ToString(),
                    FeatureRefs.Dodge.ToString(),
                    FeatureRefs.IronWill.ToString(),
                    FeatureRefs.LightningReflexes.ToString(),
                    FeatureRefs.GreatFortitude.ToString()])
                .SetIsClassFeature(true)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }

    internal class MainSelection
    {
        public static readonly string Guid = "{e81cd992-fc40-4fa8-8c4c-5b307e271f41}";

        private static readonly string FeatureName = "ImposingPresence.MainSelection";
        private static readonly string DisplayName = $"{FeatureName}.Name";
        private static readonly string Description = $"{FeatureName}.Description";

        internal static void Configure()
        {
            FeatureSelectionConfigurator.New(FeatureName, Guid)
                .AddToAllFeatures([
                    FeatureRefs.DazzlingDisplayFeature.ToString(),
                    FeatureRefs.PowerAttackFeature.ToString(),
                    FeatureRefs.IntimidatingProwess.ToString(),
                    FeatureRefs.CornugonSmash.ToString(),
                    FeatureRefs.ShatterDefenses.ToString(),
                    ParametrizedFeatureRefs.ImprovedCritical.ToString(),
                    FeatureRefs.DreadfulCarnage.ToString(),
                    FeatureRefs.Toughness.ToString(),
                    FeatureRefs.Dodge.ToString(),
                    FeatureRefs.IronWill.ToString(),
                    FeatureRefs.LightningReflexes.ToString(),
                    FeatureRefs.GreatFortitude.ToString()])
                .SetIsClassFeature(true)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }
}
