using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.Utility;
using LostChapters.Tools;
using System.Linq;

namespace LostChapters.Modules.Custom.Archetypes.FalseKnight.Tools;

internal class FalseKnightSummonUnitHelper
{
    internal static BlueprintUnit CreateSummonUnit(
        string unitName, string guid, string displayName, string prefabID, string raceID, Gender gender, Alignment alignment,
        (int Str, int Dex, int Con, int Int, int Wis, int Cha) stats, BlueprintUnit.UnitBody unitBody, BlueprintUnit.UnitSkills unitSkills,
        BlueprintFeatureReference[] feats = null, BlueprintUnitFactReference[] facts = null, SelectionEntry[] selectionEntries = null)
    {
        var levelAndBaB = 14;

        var baseFeatureSelection = new SelectionEntry()
        {
            m_Selection = BlueprintTool.GetRef<BlueprintFeatureSelectionReference>(FeatureSelectionRefs.BasicFeatSelection.ToString()),
            m_Features = feats
        };

        BlueprintUnitFactReference[] baseFacts = [
            BlueprintTool.GetRef<BlueprintUnitFactReference>(FeatureRefs.Incorporeal.ToString()),
            BlueprintTool.GetRef<BlueprintUnitFactReference>(BuffRefs.GhostFX.ToString()),
            BlueprintTool.GetRef<BlueprintUnitFactReference>(BuffRefs.Unlootable.ToString()),
            BlueprintTool.GetRef<BlueprintUnitFactReference>(UnitFactRefs.DeflectionArmor4.ToString())];

        var unitFacts = facts is null ? baseFacts?.Select(fact => (Blueprint<BlueprintUnitFactReference>)fact.Guid).ToList() : 
            [.. baseFacts.Concat(facts).Select(fact => (Blueprint<BlueprintUnitFactReference>)fact.Guid)];
        
        SelectionEntry[] selections = selectionEntries is null ? [baseFeatureSelection] : [.. selectionEntries, baseFeatureSelection];

        var ghostPaladin = UnitRefs.GhostPaladin20Summon.Reference.Get();
        var unitVisual = BlueprintUnitHelper.GetUnitVisual(ghostPaladin);

        var dumbBrain = "5abc8884c6f15204c8604cb01a2efbab";

        return UnitConfigurator.New(unitName, guid)
            .AddClassLevels(levels: levelAndBaB, characterClass: CharacterClassRefs.WarriorClass.ToString(), raceStat: StatType.Constitution, skills: [StatType.SkillAthletics, StatType.SkillMobility], selections: selections)
            .AddBuffOnEntityCreated(BuffRefs.Unlootable.ToString())
            .SetAlignment(Alignment.ChaoticEvil)
            .SetPrefab(prefabID)
            .SetFaction(FactionRefs.Summoned.ToString())
            .SetType(UnitTypeRefs.Spectre.ToString())
            .SetSize(Size.Medium)
            .SetRace(raceID)
            .SetGender(gender)
            .SetAlignment(alignment)
            .SetBrain(dumbBrain)
            .AddFacts(unitFacts)
            .SetBody(unitBody)
            .SetVisual(unitVisual)
            .SetSkills(unitSkills)
            .SetBaseAttackBonus(levelAndBaB)
            .SetStrength(stats.Str)
            .SetDexterity(stats.Dex)
            .SetConstitution(stats.Con)
            .SetIntelligence(stats.Int)
            .SetWisdom(stats.Wis)
            .SetCharisma(stats.Cha)
            .SetMaxHP(0)
            .SetSpeed(30.Feet())
            .SetStartingInventory([])
            .SetAdditionalTemplates([])
            .SetFactionOverrides(new FactionOverrides())
            .AddUnitUpgraderComponent(upgraders: [UnitUpgraderRefs.PF_359232_RemoveBrokenSummonOnLoad.ToString()])
            .SetPortrait(ghostPaladin.m_Portrait)
            .SetDisplayName(displayName)
            .Configure();
    }
}
