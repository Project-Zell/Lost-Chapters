using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Blueprints.Configurators.Items.Weapons;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using BlueprintCore.Utils.Assets;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.ResourceLinks;
using Kingmaker.RuleSystem;
using Kingmaker.RuleSystem.Rules.Damage;
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
            Diplomacy = 6,
            Acrobatics = 20,
            KnowledgeWorld = 6,
            Perception = 7,
            Stealth = 16,
        };

        var quasitBrainStandart = "a4fb2441561d0d948b393494bc4b8346";

        AssetLink<PrefabLink> assetLink = SummonDemonVisual.SmallDismemberFx.Guid;
        var prefabLink = assetLink.Get();

        unitVisual.BloodPuddleFx = prefabLink;
        unitVisual.DismemberFx = prefabLink;

        var quasitBite = BlueprintTool.Get<BlueprintItemWeapon>(ItemWeaponRefs.Bite1d8.ToString()).ToReference<BlueprintItemWeaponReference>();
        var quasitClaw = BlueprintTool.Get<BlueprintItemWeapon>(ItemWeaponRefs.Claw1d6.ToString()).ToReference<BlueprintItemWeaponReference>();

        unitBody.m_AdditionalLimbs = [quasitBite, quasitClaw, quasitClaw];

        var unitSelections = new SelectionEntry()
        {
            m_Selection = FeatureSelectionRefs.BasicFeatSelection.Reference.Get().ToReference<BlueprintFeatureSelectionReference>(),
            m_Features = [
                FeatureRefs.Improved_Initiative.Reference.Get().ToReference<BlueprintFeatureReference>(),
                FeatureRefs.WeaponFinesse.Reference.Get().ToReference<BlueprintFeatureReference>()]
        };

        UnitConfigurator.New(UnitName, Guid)
            .AddClassLevels(
                levels: 1,
                characterClass: CharacterClassRefs.OutsiderClass.ToString(),
                raceStat: StatType.Constitution,
                skills: [StatType.SkillPerception, StatType.SkillStealth],
                selections: [unitSelections])
            .AddBuffOnEntityCreated(BuffRefs.Unlootable.ToString())
            .AddBuffOnEntityCreated(SummonDemonVisual.SummonedDemonFx.Guid)
            .AddFacts([
                UnitFactRefs.NaturalArmor2.ToString(),

                FeatureRefs.SubtypeDemon.ToString(),
                FeatureRefs.SubtypeExtraplanar.ToString(),
                FeatureRefs.DemonOfMagicFeature.ToString(),

                FeatureRefs.DRColdIronOrGood5.ToString(),
                FeatureRefs.SpellResistance5plusCR.ToString(),
                
                FeatureRefs.Airborne.ToString(),
                FeatureRefs.QuasitPoisonFeature.ToString(),

                BuffRefs.FastHealing2.ToString()
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
            .SetBaseAttackBonus(1)
            .SetStrength(8)
            .SetDexterity(14)
            .SetConstitution(11)
            .SetIntelligence(11)
            .SetWisdom(12)
            .SetCharisma(11)
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
        internal static readonly string PrefabID = "{d04e8017-72fe-4cbc-9fcf-b910c637aee0}";

        private static readonly string SourcePrefabID = "da63033598ff6f5439bb6b25445931d6";

        internal static void Configure()
        {
            SummonDemonVisual.ConfigureUnit(
                unitName: UnitName,
                newPrefabID: PrefabID,
                sourcePrefabID: SourcePrefabID,
                fxSize: SummonDemonVisual.FxSize.Small,
                unitScaleMod: 0.7f);
        }
    }
}