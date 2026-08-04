using BlueprintCore.Blueprints.Configurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using LostChapters.Modules.HellknightCodex.AnimalCompanions.Hellhound;

namespace LostChapters.Modules.HellknightsCodex.AnimalCompanions.Hellhound;

internal class HellhoundProgression
{
    public static readonly string Guid = "{f8ec70d5-52e4-44bb-8ccd-22340a0d93b5}";

    private const string Progression = "HellhoundProgression";

    public static void Configure()
    {
        HellhoundTeamworkFeatSelection.Configure();

        ProgressionConfigurator.New(Progression, Guid)
            .SetClasses(CharacterClassRefs.AnimalCompanionClass.ToString())
            .AddToLevelEntries(level: 07, HellhoundTeamworkFeatSelection.Guid)
            .AddToLevelEntries(level: 13, HellhoundTeamworkFeatSelection.Guid)
            .AddToLevelEntries(level: 18, HellhoundTeamworkFeatSelection.Guid)
            .SetIsClassFeature(true)
            .Configure();
    }
}
