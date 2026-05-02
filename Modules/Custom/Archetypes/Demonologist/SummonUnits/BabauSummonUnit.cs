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

internal class BabauSummonUnit
{
    internal static readonly string Guid = "{351ca3a1-69bd-435b-a045-00e79feaeea5}";

    internal static readonly string UnitName = "BabauSummonUnit";
    internal static readonly string DisplayName = $"{UnitName}.Name";

    private static readonly BlueprintUnit BaseUnit = UnitRefs.CR6_BabauStandard.Reference.Get();
    private static readonly string UnitType = UnitTypeRefs.DemonBabau.ToString();

    internal static void Configure()
    {
        Prefab.Configure();

        var unitBody = BaseUnit.Body;
        var unitVisual = BaseUnit.Visual;

        var unitSkills = new BlueprintUnit.UnitSkills()
        {
            Acrobatics = 11,
            Physique = 12,
            Thievery = 11,
            Perception = 19,
            Stealth = 18,
        };

        var dumbMonsterBrain = "5abc8884c6f15204c8604cb01a2efbab";
        var babauDispelBrain = "4181d81cb6539d7499b766a39654c013";

        AssetLink<PrefabLink> assetLink = SummonDemonVisual.SmallDismemberFx.Guid;
        var prefabLink = assetLink.Get();

        unitVisual.BloodPuddleFx = prefabLink;
        unitVisual.DismemberFx = prefabLink;

        var unitSelections = new SelectionEntry()
        {
            m_Selection = FeatureSelectionRefs.BasicFeatSelection.Reference.Get().ToReference<BlueprintFeatureSelectionReference>(),
            m_Features = [
                FeatureRefs.CombatReflexes.Reference.Get().ToReference<BlueprintFeatureReference>(),
                FeatureRefs.Improved_Initiative.Reference.Get().ToReference<BlueprintFeatureReference>(),
                FeatureRefs.IronWill.Reference.Get().ToReference<BlueprintFeatureReference>(),
                FeatureRefs.SkillFocusStealth.Reference.Get().ToReference<BlueprintFeatureReference>()]
        };

        UnitConfigurator.New(UnitName, Guid)
            .AddClassLevels(
                levels: 7,
                characterClass: CharacterClassRefs.OutsiderClass.ToString(),
                raceStat: StatType.Constitution,
                skills: [StatType.SkillPerception, StatType.SkillStealth],
                selections: [unitSelections])
            .AddBuffOnEntityCreated(BuffRefs.Unlootable.ToString())
            .AddFacts([
                UnitFactRefs.NaturalArmor8.ToString(),

                FeatureRefs.SubtypeDemon.ToString(),
                FeatureRefs.SubtypeExtraplanar.ToString(),
                FeatureRefs.DemonOfSlaughterFeature.ToString(),

                FeatureRefs.DRColdIronOrGood10.ToString(),
                FeatureRefs.SpellResistance11plusCR.ToString(),
                FeatureRefs.BabauSneakAttackFeature.ToString(),
                FeatureRefs.BabauProtectiveSlimeFeature.ToString(),

                BuffRefs.SeeInvisibilitytBuff.ToString(),

                AbilityRefs.DispelMagic.ToString()
            ])
            .SetAlignment(Alignment.ChaoticEvil)
            .SetPrefab(Prefab.PrefabID)
            .SetFaction(FactionRefs.Summoned.ToString())
            .SetType(UnitType)
            .SetSize(Size.Medium)
            .SetBrain(dumbMonsterBrain)
            .SetAlternativeBrains(babauDispelBrain)
            .SetBody(unitBody)
            .SetVisual(unitVisual)
            .SetSkills(unitSkills)
            .SetBaseAttackBonus(7)
            .SetStrength(21)
            .SetDexterity(13)
            .SetConstitution(20)
            .SetIntelligence(14)
            .SetWisdom(13)
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
        internal static readonly string PrefabID = "{87706d2b-64e6-4e74-9bf6-b85bba03e2e5}";

        private static readonly string SourcePrefabID = "cd82e8b7ae98b2e4f912f4106581a9f0";

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