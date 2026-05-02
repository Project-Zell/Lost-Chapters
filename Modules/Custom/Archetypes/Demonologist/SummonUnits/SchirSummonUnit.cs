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

internal class SchirSummonUnit
{
    internal static readonly string Guid = "{dabf0315-e669-461b-b9a6-e1fcd3ea13c6}";

    internal static readonly string UnitName = "SchirSummonUnit";
    internal static readonly string DisplayName = $"{UnitName}.Name";

    private static readonly BlueprintUnit BaseUnit = UnitRefs.CR4_SchirStandard.Reference.Get();
    private static readonly string UnitType = UnitTypeRefs.DemonSchir.ToString();

    internal static void Configure()
    {
        Prefab.Configure();

        var unitBody = BaseUnit.Body;
        var unitVisual = BaseUnit.Visual;

        var unitSkills = new BlueprintUnit.UnitSkills()
        {
            Acrobatics = 10,
            Physique = 11,
            Diplomacy = 9,
            Perception = 13,
            LoreNature = 2
        };

        var dumbMonsterBrain = "5abc8884c6f15204c8604cb01a2efbab";
        var shirBrainCharger = "03b1498395ad7eb458ca2ae541cf8d18";

        AssetLink<PrefabLink> assetLink = SummonDemonVisual.SmallDismemberFx.Guid;
        var prefabLink = assetLink.Get();

        unitVisual.BloodPuddleFx = prefabLink;
        unitVisual.DismemberFx = prefabLink;

        var unitSelections = new SelectionEntry()
        {
            m_Selection = FeatureSelectionRefs.BasicFeatSelection.Reference.Get().ToReference<BlueprintFeatureSelectionReference>(),
            m_Features = [
                FeatureRefs.IronWill.Reference.Get().ToReference<BlueprintFeatureReference>(),
                FeatureRefs.PowerAttackFeature.Reference.Get().ToReference<BlueprintFeatureReference>()]
        };

        UnitConfigurator.New(UnitName, Guid)
            .AddClassLevels(
                levels: 6,
                characterClass: CharacterClassRefs.OutsiderClass.ToString(),
                raceStat: StatType.Constitution,
                skills: [StatType.SkillPerception, StatType.SkillStealth],
                selections: [unitSelections])
            .AddBuffOnEntityCreated(BuffRefs.Unlootable.ToString())
            .AddFacts([
                UnitFactRefs.NaturalArmor7.ToString(),

                FeatureRefs.SubtypeDemon.ToString(),
                FeatureRefs.SubtypeExtraplanar.ToString(),
                FeatureRefs.DemonOfStrengthFeature.ToString(),

                FeatureRefs.DRColdIronOrGood5.ToString(),
                FeatureRefs.SpellResistance11plusCR.ToString(),
                
                FeatureRefs.Schir_DiseaseFeature.ToString(),
                FeatureRefs.Schir_PowerfulChargeFeature.ToString(),

                BuffRefs.SeeInvisibilitytBuff.ToString(),

                AbilityRefs.ProtectionFromGood.ToString(),
                AbilityRefs.ExpeditiousRetreat.ToString(),
            ])
            .SetAlignment(Alignment.ChaoticEvil)
            .SetPrefab(Prefab.PrefabID)
            .SetFaction(FactionRefs.Summoned.ToString())
            .SetType(UnitType)
            .SetSize(Size.Medium)
            .SetBrain(dumbMonsterBrain)
            .AddToAlternativeBrains(shirBrainCharger)
            .SetBody(unitBody)
            .SetVisual(unitVisual)
            .SetSkills(unitSkills)
            .SetBaseAttackBonus(5)
            .SetStrength(17)
            .SetDexterity(14)
            .SetConstitution(15)
            .SetIntelligence(8)
            .SetWisdom(5)
            .SetCharisma(6)
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
        internal static readonly string PrefabID = "{6158d055-9f0f-434b-96f4-185da8d29f12}";

        private static readonly string SourcePrefabID = "8d71692bbaf847044a90d6519b1b9e91";

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