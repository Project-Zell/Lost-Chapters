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

internal class VrockSummonUnit
{
    internal static readonly string Guid = "{908010d9-a3ce-4a30-a111-63a0743992ea}";

    internal static readonly string UnitName = "VrockSummonUnit";
    internal static readonly string DisplayName = $"{UnitName}.Name";

    private static readonly BlueprintUnit BaseUnit = UnitRefs.CR9_VrockStandard.Reference.Get();
    private static readonly string UnitType = UnitTypeRefs.DemonVrok.ToString();

    internal static void Configure()
    {
        Prefab.Configure();

        var unitBody = BaseUnit.Body;
        var unitVisual = BaseUnit.Visual;

        var unitSkills = new BlueprintUnit.UnitSkills()
        {
            Acrobatics = 12,
            Diplomacy = 15,
            KnowledgeWorld = 14,
            Perception = 23,
            Stealth = 10,
            LoreNature = 15
        };

        var vrockStandartBrain = "83d56a8f8d4dcac4fa49b7e9a9a71ce1";
        var vrockScreechBrain = "5b7db8f177efbc54383ffbebf5c59da8";
        var vrockDumbBrain = "6142d1a9597232f449cc8874c2e11a3b";
        var vrockTeleportBrain = "163091998e2ae2344bd0d93c3c8f7fea";

        AssetLink<PrefabLink> assetLink = SummonDemonVisual.SmallDismemberFx.Guid;
        var prefabLink = assetLink.Get();

        unitVisual.BloodPuddleFx = prefabLink;
        unitVisual.DismemberFx = prefabLink;

        var unitSelections = new SelectionEntry()
        {
            m_Selection = FeatureSelectionRefs.BasicFeatSelection.Reference.Get().ToReference<BlueprintFeatureSelectionReference>(),
            m_Features = [
                FeatureRefs.CombatExpertiseFeature.Reference.Get().ToReference<BlueprintFeatureReference>(),
                FeatureRefs.CleaveFeature.Reference.Get().ToReference<BlueprintFeatureReference>(),
                FeatureRefs.Improved_Initiative.Reference.Get().ToReference<BlueprintFeatureReference>(),
                FeatureRefs.LightningReflexes.Reference.Get().ToReference<BlueprintFeatureReference>(),
                FeatureRefs.PowerAttackFeature.Reference.Get().ToReference<BlueprintFeatureReference>(),
                FeatureRefs.Toughness.Reference.Get().ToReference<BlueprintFeatureReference>(),
            ]
        };

        UnitConfigurator.New(UnitName, Guid)
            .AddClassLevels(
                levels: 9,
                characterClass: CharacterClassRefs.OutsiderClass.ToString(),
                raceStat: StatType.Constitution,
                skills: [StatType.SkillPerception],
                selections: [unitSelections])
            .AddBuffOnEntityCreated(BuffRefs.Unlootable.ToString())
            .AddFacts([
                UnitFactRefs.NaturalArmor11.ToString(),

                FeatureRefs.SubtypeDemon.ToString(),
                FeatureRefs.SubtypeExtraplanar.ToString(),
                FeatureRefs.DemonOfMagicFeature.ToString(),

                FeatureRefs.DRGood10.ToString(),
                FeatureRefs.SpellResistance11plusCR.ToString(),
                FeatureRefs.Airborne.ToString(),

                FeatureRefs.HeadLocatorFeature.ToString(),

                AbilityRefs.VrockSporesAbility.ToString(),
                AbilityRefs.VrockStunningScreechAbility.ToString(),
                AbilityRefs.MirrorImage.ToString(),
                AbilityRefs.Heroism.ToString(),
                AbilityRefs.Vrock_Ability_GreaterTeleport.ToString(),
                ])
            .SetAlignment(Alignment.ChaoticEvil)
            .SetPrefab(Prefab.PrefabID)
            .SetFaction(FactionRefs.Summoned.ToString())
            .SetType(UnitType)
            .SetSize(Size.Medium)
            .SetBrain(vrockStandartBrain)
            .SetAlternativeBrains([vrockScreechBrain, vrockDumbBrain, vrockTeleportBrain])
            .SetBody(unitBody)
            .SetVisual(unitVisual)
            .SetSkills(unitSkills)
            .SetBaseAttackBonus(9)
            .SetStrength(21)
            .SetDexterity(15)
            .SetConstitution(25)
            .SetIntelligence(14)
            .SetWisdom(16)
            .SetCharisma(16)
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
        internal static readonly string PrefabID = "{6331f8a2-822c-42f9-9317-ea6bc2a7330e}";

        private static readonly string SourcePrefabID = "f1d670fe8dc2598499a4ec7cae2f1c89";

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