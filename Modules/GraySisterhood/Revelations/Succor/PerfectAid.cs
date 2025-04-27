using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using LostChapters.Modules.GraySisterhood.Feats;
using static LostChapters.Modules.GraySisterhood.Revelations.OracleSuccorMysteryFeature;

namespace LostChapters.Modules.GraySisterhood.Revelations.Succor;

internal class PerfectAid
{
    public static readonly string Guid = "{eef84b96-f5f5-4403-8c54-196f55addbef}";

    private static readonly string FeatureName = "PerfectAid";
    private static readonly string DisplayName = "PerfectAid.Name";
    private static readonly string Description = "PerfectAid.Description";

    public static void Configure()
    {
        Progression.Configure();

        FeatureConfigurator.New(FeatureName, Guid, Kingmaker.Blueprints.Classes.FeatureGroup.OracleRevelation)
            .AddFacts([BodyguardFeature.Guid, Progression.Guid])
            .AddPrerequisiteFeaturesFromList(
                amount: 1,
                features: [OracleSuccorMysteryFeature.Guid, DivineHerbalistVariation.Guid, EnlightenedPhilosopherVariation.Guid])
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .Configure();
    }

    internal class Progression
    {
        public static readonly string Guid = "{330b93d1-31ad-46bf-b37f-8f508087e759}";

        private static readonly string ProgressionName = "PerfectAid.Progression";
        public static void Configure()
        {
            var aidAnotherArmorClassRank = AidAnotherFeature.ArmorClassRank.Guid;

            ProgressionConfigurator.New(ProgressionName, Guid)
            .SetClasses(CharacterClassRefs.OracleClass.ToString())
            .AddToLevelEntry(level: 01, features: aidAnotherArmorClassRank)
            .AddToLevelEntry(level: 04, features: aidAnotherArmorClassRank)
            .AddToLevelEntry(level: 09, features: aidAnotherArmorClassRank)
            .AddToLevelEntry(level: 14, features: aidAnotherArmorClassRank)
            .AddToLevelEntry(level: 19, features: aidAnotherArmorClassRank)
            .SetHideInCharacterSheetAndLevelUp(true)
            .SetHideInUI(true)
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .Configure();
        }
    }
}
