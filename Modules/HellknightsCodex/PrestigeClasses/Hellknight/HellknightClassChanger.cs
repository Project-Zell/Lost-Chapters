using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.Classes.Selection;
using BlueprintCore.Blueprints.References;
using Kingmaker.Blueprints.Classes.Selection;
using LostChapters.Modules.HellknightCodex.PrestigeClasses.Hellknight;

namespace LostChapters.Modules.HellknightsCodex.PrestigeClasses.Hellknight;

public class HellknightClassChanger
{
    public static void Configure()
    {
        HellknightDisciplineSelection.Configure();
        HellknightOrderSelectionFeature.Configure();
        HellknightCodexSelection.Configure();

        InfernalArmorFeature.Configure();
        FearmongerFeature.Configure();

        ProgressionConfigurator.For(ProgressionRefs.HellknightProgression)
            .RemoveFromLevelEntries(level: 01, features: FeatureSelectionRefs.HellKnightOrderSelection.ToString())
            .RemoveFromLevelEntries(level: 02, features: FeatureRefs.ArmorTraining.ToString())
            .RemoveFromLevelEntries(level: 03, features: FeatureSelectionRefs.HellknightDisciplineSelection.ToString())
            .RemoveFromLevelEntries(level: 05, features: FeatureRefs.ArmorTraining.ToString())
            .RemoveFromLevelEntries(level: 06, features: FeatureSelectionRefs.HellknightDisciplineSelection.ToString())
            .RemoveFromLevelEntries(level: 08, features: FeatureRefs.ArmorTraining.ToString())
            .RemoveFromLevelEntries(level: 09, features: FeatureSelectionRefs.HellknightDisciplineSelection.ToString())
            .RemoveFromLevelEntries(level: 09, features: FeatureRefs.HellKnightInfernalArmor.ToString())
            .AddToLevelEntry(level: 01, features: HellknightOrderSelectionFeature.Guid)
            .AddToLevelEntry(level: 01, features: HellknightCodexSelection.Guid)
            .AddToLevelEntry(level: 02, features: InfernalArmorFeature.Guid)
            .AddToLevelEntry(level: 02, features: FearmongerFeature.Guid)
            .AddToLevelEntry(level: 03, features: HellknightDisciplineSelection.Guid)
            .AddToLevelEntry(level: 05, features: InfernalArmorFeature.Guid)
            .AddToLevelEntry(level: 06, features: HellknightDisciplineSelection.Guid)
            .AddToLevelEntry(level: 08, features: InfernalArmorFeature.Guid)
            .AddToLevelEntry(level: 09, features: HellknightDisciplineSelection.Guid)
            .AddToUIDeterminatorsGroup([HellknightOrderSelectionFeature.Guid])
            .Configure();
    }

    private static readonly string HellknightCodex = "Hellknight.Codex";
    private static readonly string HellknightCodexGUID = "6a34865b-3164-44c7-85b1-e8432b2394a0";

    private static readonly string HellknightCodexName = "HellknightCodex.BuffName";
    private static readonly string HellknightCodexDescription = "HellknightCodex.Description";

    public static BlueprintFeatureSelection CreateHellknightCodex()
    {
        var icon = FeatureSelectionRefs.DiscoverySelection.Reference.Get().Icon;

        return FeatureSelectionConfigurator.New(HellknightCodex, HellknightCodexGUID)
            //.AddToAllFeatures(FeatureSelectionRefs.OrderOfTheNailFavoriteEnemySelection.ToString(), InfiltratorCodex.CreateCodex(), CreateArmigerCodexProgression())
            .SetDisplayName(HellknightCodexName)
            .SetDescription(HellknightCodexDescription)
            .SetIcon(icon)
            .Configure();
    }
}
