using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils.Types;
using Kingmaker.Enums;
using LostChapters.Modules.HellknightsCodex.AnimalCompanions.Hellhound;

namespace LostChapters.Modules.HellknightCodex.PrestigeClasses.Hellknight.Codex;

internal class TrackerCodexProgression
{
    public static readonly string Guid = "{38961edc-eb94-4d48-9c78-134e0caf4461}";

    private static readonly string FeatureName = "TrackerCodexProgression";
    private static readonly string DisplayName = $"{FeatureName}.Name";
    private static readonly string Description = $"{FeatureName}.Description";

    public static void Configure()
    {
        InitialFeature.Configure();

        ProgressionConfigurator.New(FeatureName, Guid)
            .AddPrerequisiteNoFeature(FeatureRefs.AnimalCompanionRank.ToString())
            .SetClasses([CharacterClassRefs.HellknightClass.ToString(), CharacterClassRefs.HellknightSigniferClass.ToString()])
            //.AddToLevelEntry(level: 01, features: null)
            //.AddToLevelEntry(level: 05, features: null)
            //.AddToLevelEntry(level: 10, features: null)
            //.SetRanks(3)
            //.AddToUIGroups([null])
            //.SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .Configure();
    }

    internal class InitialFeature
    {
        public static readonly string Guid = "{a7c2eaca-e04f-4520-8124-c1a557bda6ad}";

        private static readonly string FeatureName = "Tracker";
        private static readonly string DisplayName = $"{FeatureName}.Name";
        private static readonly string Description = $"{FeatureName}.Description";

        internal static void Configure()
        {
            //no mount
            AnimalCompanionUnitHellhound.Configure();

            FeatureConfigurator.New(FeatureName, Guid)
                .AddToFeatureSelection(FeatureSelectionRefs.BasicFeatSelection.ToString())
                .AddPet(
                    pet: AnimalCompanionUnitHellhound.Guid,
                    useContextValueLevel: true,
                    levelContextValue: ContextValues.Constant(7))
                .SetReapplyOnLevelUp(true)
                .SetIsClassFeature(true)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }
}
