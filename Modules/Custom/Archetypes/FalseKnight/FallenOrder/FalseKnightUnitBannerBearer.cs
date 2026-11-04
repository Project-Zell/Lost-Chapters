using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Enums;
using LostChapters.Modules.Custom.Archetypes.FalseKnight.Tools;

namespace LostChapters.Modules.Custom.Archetypes.FalseKnight.FallenOrder;

internal class FalseKnightUnitBannerBearer
{
    public static readonly string Guid = "{f478592a-b1b3-433a-aa5a-0dde5e736ad9}";

    private static readonly string UnitName = "FalseKnightUnitBannerBearer";
    private static readonly string DisplayName = $"{UnitName}.Name";

    internal static void Configure()
    {
        var body = new BlueprintUnit.UnitBody
        {
            m_EmptyHandWeapon = BlueprintTool.GetRef<BlueprintItemWeaponReference>(ItemWeaponRefs.ArmorFist1d6.ToString()),
            m_PrimaryHand = BlueprintTool.GetRef<BlueprintItemEquipmentHandReference>(ItemWeaponRefs.LightHammerPlus3.ToString()),
            m_SecondaryHand = BlueprintTool.GetRef<BlueprintItemEquipmentHandReference>(ItemShieldRefs.TowerShieldItemPlus3.ToString()),
            m_Armor = BlueprintTool.GetRef<BlueprintItemArmorReference>(ItemArmorRefs.FullplateStandartPlus3.ToString()),
            m_Shoulders = BlueprintTool.GetRef<BlueprintItemEquipmentShouldersReference>(ItemEquipmentShouldersRefs.CloakOfResistance3.ToString()),
        };

        var skills = new BlueprintUnit.UnitSkills
        {
            Physique = 14,
            KnowledgeWorld = 14,
            Diplomacy = 14,
            Perception = 8,
            Acrobatics = 6
        };

        var weaponFocus = new SelectionEntry()
        {
            IsParametrizedFeature = true,
            m_ParametrizedFeature = BlueprintTool.GetRef<BlueprintParametrizedFeatureReference>(ParametrizedFeatureRefs.WeaponFocus.ToString()),
            ParamWeaponCategory = WeaponCategory.LightHammer
        };

        FalseKnightSummonUnitHelper.CreateSummonUnit(
            unitName: UnitName,
            guid: Guid,
            displayName: DisplayName,
            prefabID: UnitRefs.EmberQ3_Crusader03.Reference.Get().Prefab.AssetId,
            raceID: RaceRefs.HumanRace.ToString(),
            gender: Gender.Male,
            alignment: Alignment.LawfulNeutral,
            stats: (24, 18, 20, 12, 14, 12),
            unitBody: body,
            unitSkills: skills,
            feats: [
                BlueprintTool.GetRef<BlueprintFeatureReference>(FeatureRefs.Dodge.ToString()),
                BlueprintTool.GetRef<BlueprintFeatureReference>(FeatureRefs.Toughness.ToString()),
                BlueprintTool.GetRef<BlueprintFeatureReference>(FeatureRefs.ShieldFocus.ToString()),
                BlueprintTool.GetRef<BlueprintFeatureReference>(FeatureRefs.ShieldFocusGreater.ToString()),
                BlueprintTool.GetRef<BlueprintFeatureReference>(FeatureRefs.ShakeItOff.ToString()),
                BlueprintTool.GetRef<BlueprintFeatureReference>(FeatureRefs.PreciseStrike.ToString()),
                BlueprintTool.GetRef<BlueprintFeatureReference>(ParametrizedFeatureRefs.WeaponFocus.ToString())],
            facts: [
                BlueprintTool.GetRef<BlueprintUnitFactReference>(BuffRefs.HeroismBuff.ToString()),
                BlueprintTool.GetRef<BlueprintUnitFactReference>(FeatureRefs.CavalierBanner.ToString()),
                BlueprintTool.GetRef<BlueprintUnitFactReference>(FeatureRefs.CavalierBannerGreater.ToString())],
            selectionEntries: [weaponFocus]);
    }
}
