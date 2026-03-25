using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.References;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using LostChapters._test;

namespace LostChapters.Modules.HellknightCodex.AnimalCompanions.Hellhound;

internal class HellhoundClassProgression
{
    public static readonly string Guid = "{f8ec70d5-52e4-44bb-8ccd-22340a0d93b5}";

    private const string Progression = "HellhoundClass.Progression";

    public static void CreateProgression()
    {
        ProgressionConfigurator.New(Progression, Guid)

            .AddToLevelEntry(level: 01, features: HellhoundHellbiteFeature.Guid)
            .AddToLevelEntry(level: 05, features: HellhoundHellbiteFeature.Guid)
            .AddToLevelEntry(level: 06, features: HellhoundSmartFeature.Guid)
            .AddToLevelEntry(level: 10, features: HellhoundHellbiteFeature.Guid)
            .AddToLevelEntry(level: 10, features: HellhoundHellfireFeature.Guid)
            .AddToLevelEntry(level: 12, features: HellhoundSmartFeature.Guid)
            .AddToLevelEntry(level: 15, features: HellhoundHellbiteFeature.Guid)
            .AddToLevelEntry(level: 18, features: HellhoundSmartFeature.Guid)
            .AddToLevelEntry(level: 20, features: HellhoundHellbiteFeature.Guid)
            .AddToLevelEntry(level: 20, features: HellhoundCapstoneFeature.Guid)
            .SetGiveFeaturesForPreviousLevels(true)
            .SetAllowNonContextActions(false)
            .SetIsClassFeature(true)
            .Configure();
    }
}