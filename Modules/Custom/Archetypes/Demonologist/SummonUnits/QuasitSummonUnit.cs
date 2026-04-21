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

internal class QuasitSummonUnit
{
    internal static readonly string Guid = "{50687770-4858-4a1a-9a56-a613addcffed}";

    internal static readonly string UnitName = "QuasitSummonUnit";
    internal static readonly string DisplayName = $"{UnitName}.Name";

    private static readonly BlueprintUnit BaseUnit = UnitRefs.CR2_QuasitStandard.Reference.Get();
    private static readonly string UnitType = UnitTypeRefs.DemonQuasit.ToString();

    internal static void Configure()
    {
        Prefab.Configure();

        var unitBody = BaseUnit.Body;
        var unitVisual = BaseUnit.Visual;

        var unitSkills = new BlueprintUnit.UnitSkills()
        {
            Acrobatics = 20,
            Diplomacy = 6,
            KnowledgeWorld = 6,
            Perception = 7,
            Stealth = 16,
        };

        var quasitBrainStandart = "a4fb2441561d0d948b393494bc4b8346";

        AssetLink<PrefabLink> assetLink = Prefab.DismemberFxID;
        var prefabLink = assetLink.Get();

        unitVisual.BloodPuddleFx = prefabLink;
        unitVisual.DismemberFx = prefabLink;

        var unitSelections = new SelectionEntry()
        {
            m_Selection = FeatureSelectionRefs.BasicFeatSelection.Reference.Get().ToReference<BlueprintFeatureSelectionReference>(),
            m_Features = [
                FeatureRefs.Improved_Initiative.Reference.Get().ToReference<BlueprintFeatureReference>(),
                FeatureRefs.WeaponFinesse.Reference.Get().ToReference<BlueprintFeatureReference>()]
        };

        UnitConfigurator.New(UnitName, Guid)
            .AddClassLevels(
                levels: 2,
                characterClass: CharacterClassRefs.OutsiderClass.ToString(),
                raceStat: StatType.Constitution,
                skills: [StatType.SkillPerception, StatType.SkillStealth],
                selections: [unitSelections])
            .AddBuffOnEntityCreated(BuffRefs.Unlootable.ToString())
            .AddFacts([
                UnitFactRefs.NaturalArmor2.ToString(),

                FeatureRefs.SubtypeDemon.ToString(),
                FeatureRefs.DRColdIronOrGood5.ToString(),
                FeatureRefs.SubtypeExtraplanar.ToString(),
                FeatureRefs.SpellResistance11plusCR.ToString(),
                FeatureRefs.Airborne.ToString(),
                FeatureRefs.FastHealing.ToString(),
                FeatureRefs.QuasitPoisonFeature.ToString(),
                FeatureRefs.DemonOfMagicFeature.ToString(),

                AbilityRefs.CauseFear.ToString()
            ])
            .SetAlignment(Alignment.ChaoticEvil)
            .SetPrefab(Prefab.PrefabID)
            .SetFaction(FactionRefs.Summoned.ToString())
            .SetType(UnitType)
            .SetSize(Size.Tiny)
            .SetBrain(quasitBrainStandart)
            .SetBody(unitBody)
            .SetVisual(unitVisual)
            .SetSkills(unitSkills)
            .SetBaseAttackBonus(2)
            .SetStrength(9)
            .SetDexterity(17)
            .SetConstitution(13)
            .SetIntelligence(16)
            .SetWisdom(14)
            .SetCharisma(16)
            .SetMaxHP(0)
            .SetSpeed(50.Feet())
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
        internal static readonly string PrefabID = "{d04e8017-72fe-4cbc-9fcf-b910c637aee0}";
        internal static readonly string DismemberFxID = "{ac66885d-8708-4e0f-b2e0-71598b9737c9}";

        private static readonly string SourcePrefabID = "da63033598ff6f5439bb6b25445931d6";

        internal static void Configure()
        {
            DemonologistSummons.Configure(unitName: UnitName, newPrefabID: PrefabID, sourcePrefabID: SourcePrefabID, dismemberFxID: DismemberFxID);
        }
    }
}
