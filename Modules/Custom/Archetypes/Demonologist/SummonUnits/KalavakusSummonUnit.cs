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

internal class KalavakusSummonUnit
{
    internal static readonly string Guid = "{8d45f9be-4a06-4878-bdf9-168c877a79c5}";

    internal static readonly string UnitName = "KalavakusSummonUnit";
    internal static readonly string DisplayName = $"{UnitName}.Name";

    private static readonly BlueprintUnit BaseUnit = UnitRefs.CR10_KalavakusStandard.Reference.Get();
    private static readonly string UnitType = UnitTypeRefs.DemonKalavakus.ToString();

    internal static void Configure()
    {
        Prefab.Configure();

        var unitBody = BaseUnit.Body;
        var unitVisual = BaseUnit.Visual;

        var unitSkills = new BlueprintUnit.UnitSkills()
        {
            Acrobatics = 14,
            Physique = 19,
            Diplomacy = 16,
            KnowledgeWorld = 15,
            Perception = 24,
            Stealth = 14,
            UseMagicDevice = 16,
        };

        var kalavakusStandartBrain = "3499bc2b20a0b97429b01fa68312cc19";
        var kalavakusChargerBrain = "3b3d7e67a7931a74795de1fd493b9a79";
        var kalavakusCasterBrain = "ffe18c67a760f9444a70ad292a7370a4";
        var kalavakusDisarmBrain = "a90924fd3825d7b4db56e949f964cd14";
        var kalavakusTripBrain = "d3f2824685ac20c498bd55e38ee4a567";
        var kalavakusBullRushBrain = "393c21f1e00d02c4d9066f1bf65d5cd6";

        AssetLink<PrefabLink> assetLink = SummonDemonVisual.MediumDismemberFx.Guid;
        var prefabLink = assetLink.Get();

        unitVisual.BloodPuddleFx = prefabLink;
        unitVisual.DismemberFx = prefabLink;

        var unitSelections = new SelectionEntry()
        {
            m_Selection = FeatureSelectionRefs.BasicFeatSelection.Reference.Get().ToReference<BlueprintFeatureSelectionReference>(),
            m_Features = [
                FeatureRefs.CombatExpertiseFeature.Reference.Get().ToReference<BlueprintFeatureReference>(),
                FeatureRefs.ImprovedBullRush.Reference.Get().ToReference<BlueprintFeatureReference>(),
                FeatureRefs.ImprovedDisarm.Reference.Get().ToReference<BlueprintFeatureReference>(),
                FeatureRefs.ImprovedTrip.Reference.Get().ToReference<BlueprintFeatureReference>(),
                FeatureRefs.PowerAttackFeature.Reference.Get().ToReference<BlueprintFeatureReference>(),
                ]
        };

        UnitConfigurator.New(UnitName, Guid)
            .AddClassLevels(
                levels: 13,
                characterClass: CharacterClassRefs.OutsiderClass.ToString(),
                raceStat: StatType.Constitution,
                skills: [StatType.SkillPerception, StatType.SkillStealth],
                selections: [unitSelections])
            .AddBuffOnEntityCreated(BuffRefs.Unlootable.ToString())
            .AddFacts([
                UnitFactRefs.NaturalArmor14.ToString(),

                FeatureRefs.SubtypeDemon.ToString(),
                FeatureRefs.SubtypeExtraplanar.ToString(),
                FeatureRefs.DemonOfStrengthFeature.ToString(),

                FeatureRefs.DRGood10.ToString(),
                FeatureRefs.SpellResistance11plusCR.ToString(),
                FeatureRefs.Kalavakus_Feature_Horns.ToString(),
                FeatureRefs.Kalavakus_Feature_PowerfulChargeFeature.ToString(),

                AbilityRefs.Command.ToString(),
                AbilityRefs.CommandGreater.ToString(),
                AbilityRefs.DominatePerson.ToString(),
                AbilityRefs.Haste.ToString(),
                AbilityRefs.Kalavakus_Ability_EnslaveSoul.ToString(),
                ])
            .SetAlignment(Alignment.ChaoticEvil)
            .SetPrefab(Prefab.PrefabID)
            .SetFaction(FactionRefs.Summoned.ToString())
            .SetType(UnitType)
            .SetSize(Size.Medium)
            .SetBrain(kalavakusStandartBrain)
            .SetAlternativeBrains([kalavakusChargerBrain, kalavakusCasterBrain, kalavakusDisarmBrain, kalavakusTripBrain, kalavakusBullRushBrain])
            .SetBody(unitBody)
            .SetVisual(unitVisual)
            .SetSkills(unitSkills)
            .SetBaseAttackBonus(10)
            .SetStrength(22)
            .SetDexterity(13)
            .SetConstitution(24)
            .SetIntelligence(15)
            .SetWisdom(17)
            .SetCharisma(16)
            .SetMaxHP(0)
            .SetSpeed(30.Feet())
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
        internal static readonly string PrefabID = "{c4eb48d0-0bc4-48bd-aed7-49addaeb6158}";

        private static readonly string SourcePrefabID = "db68b3208721d624ea1061f18fc29122";

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