using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.Classes.Selection;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;

namespace LostChapters.Modules.HellknightCodex.PrestigeClasses.Hellknight;

public class HellknightClassChanger
{
    public static void Configure()
    {
        HellknightDisciplineSelection.Configure();
        HellknightOrderSelectionFeature.Configure();
        HellknightCodexSelection.Configure();

        InfernalArmorFeature.Configure();
        ForgedInHellFeature.Configure();

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
            .AddToLevelEntry(level: 02, features: ForgedInHellFeature.Guid)
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

    #region Codex of the Lawbringer
    private static readonly string LawbringerCodex = "Hellknight.LawbringerCodex";
    private static readonly string LawbringerCodexGUID = "bafac28e-dba2-45af-a106-df80915488af";

    private static readonly string LawbringerCodexName = "LawbringerCodex.BuffName";
    private static readonly string LawbringerCodexDescription = "LawbringerCodex.Description";

    private static BlueprintProgression CreateLawbringerCodexProgression()
    {
        return ProgressionConfigurator.New(LawbringerCodex, LawbringerCodexGUID)
            .SetClasses(CharacterClassRefs.HellknightClass.ToString())
            .AddToLevelEntry(1, FeatureSelectionRefs.OrderOfTheNailFavoriteEnemySelection.ToString())
            .SetIsClassFeature(true)
            .SetDisplayName(LawbringerCodexName)
            .SetDescription(LawbringerCodexDescription)
            .Configure();
    }
    #endregion

    #region Armiger Codex
    private static readonly string ArmigerCodex = "Hellknight.Codex.Armger";
    private static readonly string ArmigerCodexGuid = "8b9c7c22-ea10-41b8-98c3-2c6d7c225acd";

    private static readonly string ArmigerCodexDisplayName = "Hellknight.Codex.Armiger.BuffName";
    private static readonly string ArmigerCodexDescription = "Hellknight.Codex.Armiger.Description";

    private static BlueprintProgression CreateArmigerCodexProgression()
    {
        return ProgressionConfigurator.New(ArmigerCodex, ArmigerCodexGuid)
            .SetClasses(CharacterClassRefs.HellknightClass.ToString())
            .AddToLevelEntry(2, FeatureSelectionRefs.RangerStyleMenacingSelection10.ToString())
            .AddToLevelEntry(6, FeatureSelectionRefs.RangerStyleMenacingSelection10.ToString())
            .AddToLevelEntry(10, FeatureSelectionRefs.RangerStyleMenacingSelection10.ToString())
            .SetUIGroups(UIGroupBuilder.New()
                .AddGroup(new Blueprint<BlueprintFeatureBaseReference>[] { FeatureSelectionRefs.RangerStyleMenacingSelection10.ToString() }))
            .SetIsClassFeature(true)
            .SetDisplayName(ArmigerCodexDisplayName)
            .SetDescription(ArmigerCodexDescription)
            .Configure();
    }
    #endregion

}
