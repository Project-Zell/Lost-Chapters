using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils.Assets;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.ResourceLinks;
using Kingmaker.Utility;

namespace LostChapters.Modules.Custom.Archetypes.Demonologist.SummonUnits;

internal class DretchSummonUnit
{
    internal static readonly string Guid = "{5ec14759-51b1-4cf7-927d-6176766f8a3c}";
    
    internal static readonly string UnitName = "DretchSummonUnit";
    internal static readonly string DisplayName = $"{UnitName}.Name";

    private static readonly BlueprintUnit BaseUnit = UnitRefs.CR2_DretchStandard.Reference.Get();
    private static readonly string UnitType = UnitTypeRefs.DemonDretch.ToString();

    internal static void Configure()
    {
        Prefab.Configure();

        var unitBody = BaseUnit.Body;
        var unitVisual = BaseUnit.Visual;

        var unitSkills = new BlueprintUnit.UnitSkills()
        {
            Acrobatics = 5,
            Perception = 5,
            Stealth = 9,
        };

        var dretchBrainCauseFear = "ea5e916732fd4dddb95146a923f72b96";
        
        AssetLink<PrefabLink> assetLink = SummonDemonVisual.SmallDismemberFx.Guid;
        var prefabLink = assetLink.Get();
        
        unitVisual.BloodPuddleFx = prefabLink;
        unitVisual.DismemberFx = prefabLink;

        var unitSelections = new SelectionEntry()
        {
            m_Selection = FeatureSelectionRefs.BasicFeatSelection.Reference.Get().ToReference<BlueprintFeatureSelectionReference>(),
            m_Features = [FeatureRefs.Toughness.Reference.Get().ToReference<BlueprintFeatureReference>()]
        };

        UnitConfigurator.New(UnitName, Guid)
            .AddClassLevels(
                levels: 2,
                characterClass: CharacterClassRefs.OutsiderClass.ToString(),
                raceStat: StatType.Constitution,
                skills: [StatType.SkillPerception, StatType.SkillStealth],
                selections: [unitSelections])
            .AddBuffOnEntityCreated(BuffRefs.Unlootable.ToString())
            .AddBuffOnEntityCreated(SummonDemonVisual.SummonedDemonFx.FxID)
            .AddFacts([
                UnitFactRefs.NaturalArmor3.ToString(),

                FeatureRefs.SubtypeDemon.ToString(),
                FeatureRefs.SubtypeExtraplanar.ToString(),
                FeatureRefs.DemonOfMagicFeature.ToString(),
                
                FeatureRefs.DRColdIronOrGood5.ToString(),

                AbilityRefs.CauseFear.ToString()
            ])
            .SetAlignment(Alignment.ChaoticEvil)
            .SetPrefab(Prefab.PrefabID)
            .SetFaction(FactionRefs.Summoned.ToString())
            .SetType(UnitType)
            .SetSize(Size.Medium)
            .SetBrain(dretchBrainCauseFear)
            .SetBody(unitBody)
            .SetVisual(unitVisual)
            .SetSkills(unitSkills)
            .SetBaseAttackBonus(2)
            .SetStrength(12)
            .SetDexterity(10)
            .SetConstitution(14)
            .SetIntelligence(5)
            .SetWisdom(11)
            .SetCharisma(11)
            .SetMaxHP(0)
            .SetSpeed(25.Feet())
            .SetStartingInventory([])
            .SetAdditionalTemplates([])
            .SetFactionOverrides(new FactionOverrides())
            .AddUnitUpgraderComponent(upgraders: [UnitUpgraderRefs.PF_359232_RemoveBrokenSummonOnLoad.ToString()])
            .SetPortrait(BaseUnit.m_Portrait)
            .SetDisplayName(DisplayName)
            .Configure();     
    }

    internal class Prefab
    {
        internal static readonly string PrefabID = "{33daed16-905d-42b7-be4f-76029e609900}";

        private static readonly string SourcePrefabID = "08d7013c13b587541bead70c4a254977";

        internal static void Configure()
        {
            SummonDemonVisual.ConfigureUnit(
                unitName: UnitName, 
                newPrefabID: PrefabID, 
                sourcePrefabID: SourcePrefabID, 
                fxSize: SummonDemonVisual.FxSize.Small);
        }
    }
}