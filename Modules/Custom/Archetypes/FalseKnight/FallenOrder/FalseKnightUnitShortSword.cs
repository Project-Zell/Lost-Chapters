using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Enums;
using LostChapters.Modules.Custom.Archetypes.FalseKnight.Tools;

namespace LostChapters.Modules.Custom.Archetypes.FalseKnight.FallenOrder;

internal class FalseKnightUnitShortSword
{
    public static readonly string Guid = "{0d693aec-d4f3-4fc3-9e5c-cf1010f34bbc}";

    private static readonly string UnitName = "FalseKnightUnitShortSword";
    private static readonly string DisplayName = $"{UnitName}.Name";

    internal static void Configure()
    {
        var body = new BlueprintUnit.UnitBody
        {
            m_EmptyHandWeapon = BlueprintTool.GetRef<BlueprintItemWeaponReference>(ItemWeaponRefs.ArmorFist1d6.ToString()),
            m_PrimaryHand = BlueprintTool.GetRef<BlueprintItemEquipmentHandReference>(ItemWeaponRefs.ShortswordPlus3.ToString()),
            m_SecondaryHand = BlueprintTool.GetRef<BlueprintItemEquipmentHandReference>(ItemWeaponRefs.ShortswordPlus3.ToString()),
            m_Armor = BlueprintTool.GetRef<BlueprintItemArmorReference>(ItemArmorRefs.FullplateStandartPlus3.ToString()),
            m_Shoulders = BlueprintTool.GetRef<BlueprintItemEquipmentShouldersReference>(ItemEquipmentShouldersRefs.CloakOfResistance3.ToString()),
        };

        var skills = new BlueprintUnit.UnitSkills
        {
            Physique = 14,
            KnowledgeWorld = 8,
            Diplomacy = 6,
            Perception = 14,
            Acrobatics = 14
        };

        var weaponFocus = new SelectionEntry()
        {
            IsParametrizedFeature = true,
            m_ParametrizedFeature = BlueprintTool.GetRef<BlueprintParametrizedFeatureReference>(ParametrizedFeatureRefs.WeaponFocus.ToString()),
            ParamWeaponCategory = WeaponCategory.Shortsword
        };

        FalseKnightSummonUnitHelper.CreateSummonUnit(
            unitName: UnitName,
            guid: Guid,
            displayName: DisplayName,
            prefabID: UnitRefs.EmberQ3_Crusader01.Reference.Get().Prefab.AssetId,
            raceID: RaceRefs.HumanRace.ToString(),
            gender: Gender.Male,
            alignment: Alignment.NeutralGood,
            stats: (15, 28, 14, 12, 14, 12),
            unitBody: body,
            unitSkills: skills,
            feats: [
                BlueprintTool.GetRef<BlueprintFeatureReference>(FeatureRefs.WeaponFinesse.ToString()),
                BlueprintTool.GetRef<BlueprintFeatureReference>(FeatureRefs.PiranhaStrikeFeature.ToString()),
                BlueprintTool.GetRef<BlueprintFeatureReference>(FeatureRefs.TwoWeaponFighting.ToString()),
                BlueprintTool.GetRef<BlueprintFeatureReference>(FeatureRefs.TwoWeaponFightingGreater.ToString()),
                BlueprintTool.GetRef<BlueprintFeatureReference>(FeatureRefs.Improved_Initiative.ToString()),
                BlueprintTool.GetRef<BlueprintFeatureReference>(FeatureRefs.ShakeItOff.ToString()),
                BlueprintTool.GetRef<BlueprintFeatureReference>(FeatureRefs.PreciseStrike.ToString()),
                BlueprintTool.GetRef<BlueprintFeatureReference>(ParametrizedFeatureRefs.WeaponFocus.ToString())],
            facts: [
                BlueprintTool.GetRef<BlueprintUnitFactReference>(BuffRefs.HeroismBuff.ToString())],
            selectionEntries: [weaponFocus]);
    }
}
