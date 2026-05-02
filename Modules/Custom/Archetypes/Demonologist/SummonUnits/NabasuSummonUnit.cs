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

internal class NabasuSummonUnit
{
    internal static readonly string Guid = "{c011be55-0771-4dc9-9ded-d63222e7390e}";

    internal static readonly string UnitName = "NabasuSummonUnit";
    internal static readonly string DisplayName = $"{UnitName}.Name";

    private static readonly BlueprintUnit BaseUnit = UnitRefs.CR8_NabasuStandard.Reference.Get();
    private static readonly string UnitType = UnitTypeRefs.DemonNabasu.ToString();

    internal static void Configure()
    {
        Prefab.Configure();

        var unitBody = BaseUnit.Body;
        var unitVisual = BaseUnit.Visual;

        var unitSkills = new BlueprintUnit.UnitSkills()
        {
            Acrobatics = 15,
            KnowledgeArcana = 14,
            KnowledgeWorld = 14,
            Perception = 23,
            Stealth = 15,
            LoreNature = 15
        };

        var nabasuStandartBrain = "3a12aaa14d560a5498b008a4c7c09fc0";
        var nabasuHoldPersonBrain = "1df6b047517b35240b64823b9e86519f";

        AssetLink<PrefabLink> assetLink = SummonDemonVisual.SmallDismemberFx.Guid;
        var prefabLink = assetLink.Get();

        unitVisual.BloodPuddleFx = prefabLink;
        unitVisual.DismemberFx = prefabLink;

        var unitSelections = new SelectionEntry()
        {
            m_Selection = FeatureSelectionRefs.BasicFeatSelection.Reference.Get().ToReference<BlueprintFeatureSelectionReference>(),
            m_Features = [
                FeatureRefs.Toughness.Reference.Get().ToReference<BlueprintFeatureReference>(),
                FeatureRefs.CombatExpertiseFeature.Reference.Get().ToReference<BlueprintFeatureReference>(),
                FeatureRefs.Dodge.Reference.Get().ToReference<BlueprintFeatureReference>(),
                FeatureRefs.Improved_Initiative.Reference.Get().ToReference<BlueprintFeatureReference>(),
                FeatureRefs.PowerAttackFeature.Reference.Get().ToReference<BlueprintFeatureReference>(),
                FeatureRefs.CleaveFeature.Reference.Get().ToReference<BlueprintFeatureReference>(),
                FeatureRefs.CombatCasting.Reference.Get().ToReference<BlueprintFeatureReference>(),
            ]
        };

        UnitConfigurator.New(UnitName, Guid)
            .AddClassLevels(
                levels: 9,
                characterClass: CharacterClassRefs.OutsiderClass.ToString(),
                raceStat: StatType.Constitution,
                skills: [StatType.SkillPerception, StatType.SkillStealth],
                selections: [unitSelections])
            .AddBuffOnEntityCreated(BuffRefs.Unlootable.ToString())
            .AddFacts([
                UnitFactRefs.NaturalArmor8.ToString(),

                FeatureRefs.SubtypeDemon.ToString(),
                FeatureRefs.SubtypeExtraplanar.ToString(),
                FeatureRefs.DemonOfMagicFeature.ToString(),

                FeatureRefs.DRColdIronOrGood10.ToString(),
                FeatureRefs.SpellResistance11plusCR.ToString(),
                FeatureRefs.NabasuDeathStealingGazeFeature.ToString(),
                FeatureRefs.NabasuGrowthPoint.ToString(),
                FeatureRefs.NegativeEnergyAssociation.ToString(),
                FeatureRefs.Airborne.ToString(),

                AbilityRefs.Enervation.ToString(),
                AbilityRefs.HoldPersonMass.ToString(),
                AbilityRefs.VampiricTouch.ToString()
                ])
            .SetAlignment(Alignment.ChaoticEvil)
            .SetPrefab(Prefab.PrefabID)
            .SetFaction(FactionRefs.Summoned.ToString())
            .SetType(UnitType)
            .SetSize(Size.Medium)
            .SetBrain(nabasuStandartBrain)
            .AddToAlternativeBrains(nabasuHoldPersonBrain)
            .SetBody(unitBody)
            .SetVisual(unitVisual)
            .SetSkills(unitSkills)
            .SetBaseAttackBonus(9)
            .SetStrength(22)
            .SetDexterity(17)
            .SetConstitution(22)
            .SetIntelligence(15)
            .SetWisdom(16)
            .SetCharisma(19)
            .SetMaxHP(0)
            .SetSpeed(35.Feet())
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
        internal static readonly string PrefabID = "{a51486d1-52ce-4ff4-920f-9d84a3363a4a}";

        private static readonly string SourcePrefabID = "a7534f92d250de24eb8e50f8ccd887e1";

        internal static void Configure()
        {
            SummonDemonVisual.ConfigureUnit(
                unitName: UnitName,
                newPrefabID: PrefabID,
                sourcePrefabID: SourcePrefabID,
                fxSize: SummonDemonVisual.FxSize.Medium);
        }
    }
}