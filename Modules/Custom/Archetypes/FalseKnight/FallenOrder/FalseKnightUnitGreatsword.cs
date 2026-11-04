using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Enums;
using LostChapters.Modules.Custom.Archetypes.FalseKnight.Tools;

namespace LostChapters.Modules.Custom.Archetypes.FalseKnight.FallenOrder;

internal class FalseKnightUnitGreatsword
{
    public static readonly string Guid = "{077601a1-e541-426f-a908-5c0f975162e3}";

    private static readonly string UnitName = "FalseKnightUnitGreatsword";
    private static readonly string DisplayName = $"{UnitName}.Name";

    internal static void Configure()
    {
        var body = new BlueprintUnit.UnitBody
        {
            m_EmptyHandWeapon = BlueprintTool.GetRef<BlueprintItemWeaponReference>(ItemWeaponRefs.ArmorFist1d6.ToString()),
            m_PrimaryHand = BlueprintTool.GetRef<BlueprintItemEquipmentHandReference>(ItemWeaponRefs.GreatswordPlus3.ToString()),
            m_Armor = BlueprintTool.GetRef<BlueprintItemArmorReference>(ItemArmorRefs.FullplateStandartPlus3.ToString()),
            m_Shoulders = BlueprintTool.GetRef<BlueprintItemEquipmentShouldersReference>(ItemEquipmentShouldersRefs.CloakOfResistance3.ToString()),
        };

        var skills = new BlueprintUnit.UnitSkills
        {
            Physique = 14,
            KnowledgeWorld = 6,
            Diplomacy = 14,
            Perception = 8,
            Acrobatics = 14
        };

        var weaponFocus = new SelectionEntry()
        {
            IsParametrizedFeature = true,
            m_ParametrizedFeature = BlueprintTool.GetRef<BlueprintParametrizedFeatureReference>(ParametrizedFeatureRefs.WeaponFocus.ToString()),
            ParamWeaponCategory = WeaponCategory.Greatsword
        };

        var improvedCritical = new SelectionEntry()
        {
            IsParametrizedFeature = true,
            m_ParametrizedFeature = BlueprintTool.GetRef<BlueprintParametrizedFeatureReference>(ParametrizedFeatureRefs.ImprovedCritical.ToString()),
            ParamWeaponCategory = WeaponCategory.Greatsword
        };

        FalseKnightSummonUnitHelper.CreateSummonUnit(
            unitName: UnitName,
            guid: Guid,
            displayName: DisplayName,
            prefabID: UnitRefs.EmberQ3_Crusader02.Reference.Get().Prefab.AssetId,
            raceID: RaceRefs.HumanRace.ToString(),
            gender: Gender.Male,
            alignment: Alignment.NeutralGood,
            stats: (26, 16, 16, 12, 16, 12),
            unitBody: body,
            unitSkills: skills,
            feats: [
                BlueprintTool.GetRef<BlueprintFeatureReference>(FeatureRefs.PowerAttackFeature.ToString()),
                BlueprintTool.GetRef<BlueprintFeatureReference>(FeatureRefs.FuriousFocus.ToString()),
                BlueprintTool.GetRef<BlueprintFeatureReference>(FeatureRefs.DreadfulCarnage.ToString()),
                BlueprintTool.GetRef<BlueprintFeatureReference>(FeatureRefs.CornugonSmash.ToString()),
                BlueprintTool.GetRef<BlueprintFeatureReference>(FeatureRefs.ShakeItOff.ToString()),
                BlueprintTool.GetRef<BlueprintFeatureReference>(FeatureRefs.PreciseStrike.ToString()),
                BlueprintTool.GetRef<BlueprintFeatureReference>(ParametrizedFeatureRefs.ImprovedCritical.ToString()),
                BlueprintTool.GetRef<BlueprintFeatureReference>(ParametrizedFeatureRefs.WeaponFocus.ToString())],
            facts: [
                BlueprintTool.GetRef<BlueprintUnitFactReference>(BuffRefs.HeroismBuff.ToString())],
            selectionEntries: [weaponFocus, improvedCritical]);
    }
}