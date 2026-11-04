using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using BlueprintCore.Utils.Assets;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.Localization;
using Kingmaker.ResourceLinks;
using Kingmaker.Utility;
using LostChapters.Tools;
using System.Linq;
using UnityEngine;
using static LostChapters.Modules.Custom.Archetypes.Demonologist.Tools.SummonDemonVisual;

namespace LostChapters.Modules.Custom.Archetypes.Demonologist.Tools;

internal class DemonologistSummonUnitHelper
{
    internal static BlueprintUnit CreateSummonUnit(
        string unitName, string displayName, string guid, BlueprintUnit baseUnit, int level, string prefabID, 
        (int Str, int Dex, int Con, int Int, int Wis, int Cha) stats, int baseAttackBonus, FxSize fxSize,
        Size size = Size.Medium, int speed = 30, BlueprintArchetypeReference archetype = null, bool isCaster = false,
        BlueprintFeatureReference[] feats = null, BlueprintUnitFactReference[] facts = null, SelectionEntry skillFocus = null)
    {
        var unitVisual = BlueprintUnitHelper.GetUnitVisual(baseUnit);

        AssetLink<PrefabLink> assetLink = fxSize switch
        {
            FxSize.Medium => MediumDismemberFx.Guid,
            FxSize.Big => BigDismemberFx.Guid,
            FxSize.Giant => GiantDismemberFx.Guid,
            _ => SmallDismemberFx.Guid,
        };
        
        var prefabLink = assetLink.Get();
        
        unitVisual.BloodPuddleFx = prefabLink;
        unitVisual.DismemberFx = prefabLink;

        var baseFeatureSelection = new SelectionEntry()
        {
            m_Selection = BlueprintTool.GetRef<BlueprintFeatureSelectionReference>(FeatureSelectionRefs.BasicFeatSelection.ToString()),
            m_Features = feats
        };

        var unitFacts = facts is not null ? facts?.Select(fact => (Blueprint<BlueprintUnitFactReference>)fact.Guid).ToList() : baseUnit.m_AddFacts?.Select(fact => (Blueprint<BlueprintUnitFactReference>)fact.Guid).ToList();
        unitFacts = unitFacts?.Count > 0 ? unitFacts : [];
        
        var alternativeBrains = baseUnit.AlternativeBrains?.Select(brain => (Blueprint<BlueprintBrainReference>)brain.Guid).ToArray();
        alternativeBrains = alternativeBrains?.Length > 0 ? alternativeBrains : [];

        SelectionEntry[] selections = skillFocus is null ? [baseFeatureSelection] : [baseFeatureSelection, skillFocus];

        var localizedName = ScriptableObject.CreateInstance<SharedStringAsset>();
        localizedName.String = new LocalizedString()
        {
            m_Key = displayName
        };

        var summonUnit = UnitConfigurator.New(unitName, guid)
            .AddClassLevels(levels: level, characterClass: CharacterClassRefs.OutsiderClass.ToString(), archetypes: [archetype], raceStat: StatType.Constitution, skills: [StatType.SkillPerception, StatType.SkillStealth], selections: selections)
            .AddBuffOnEntityCreated(BuffRefs.Unlootable.ToString())
            .SetAlignment(Alignment.ChaoticEvil)
            .SetPrefab(prefabID)
            .SetFaction(FactionRefs.Summoned.ToString())
            .SetType(baseUnit.Type)
            .SetSize(size)
            .SetBrain(baseUnit.DefaultBrain)
            .SetAlternativeBrains(alternativeBrains)
            .AddFacts(unitFacts)
            .SetBody(BlueprintUnitHelper.GetUnitBody(baseUnit))
            .SetVisual(unitVisual)
            .SetSkills(BlueprintUnitHelper.GetUnitSkills(baseUnit))
            .SetBaseAttackBonus(baseAttackBonus)
            .SetStrength(stats.Str)
            .SetDexterity(stats.Dex)
            .SetConstitution(stats.Con)
            .SetIntelligence(stats.Int)
            .SetWisdom(stats.Wis)
            .SetCharisma(stats.Cha)
            .SetMaxHP(0)
            .SetSpeed(speed.Feet())
            .SetStartingInventory([])
            .SetAdditionalTemplates([])
            .SetFactionOverrides(new FactionOverrides())
            .AddUnitUpgraderComponent(upgraders: [UnitUpgraderRefs.PF_359232_RemoveBrokenSummonOnLoad.ToString()])
            .SetPortrait(baseUnit.m_Portrait)
            .SetDisplayName(displayName)
            .SetLocalizedName(localizedName)
            .Configure();

        if (isCaster) UnitConfigurator.For(guid).AddMobCaster().Configure();
        return summonUnit;
    }
}
