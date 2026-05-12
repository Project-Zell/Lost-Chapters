using Kingmaker.Blueprints;
using System.Linq;

namespace LostChapters.Tools;

internal static class BlueprintUnitHelper
{
    internal static UnitVisualParams GetUnitVisual(BlueprintUnit unit)
    {
        var visualParams = unit.Visual;

        return new UnitVisualParams
        {
            BloodType = visualParams.BloodType,
            FootprintType = visualParams.FootprintType,
            FootprintScale = visualParams.FootprintScale,

            ArmorFx = visualParams.ArmorFx,
            BloodPuddleFx = visualParams.BloodPuddleFx,
            DismemberFx = visualParams.DismemberFx,
            RipLimbsApartFx = visualParams.RipLimbsApartFx,

            IsNotUseDismember = visualParams.IsNotUseDismember,
            IsBlockChangeClothColor = visualParams.IsBlockChangeClothColor,

            m_Barks = visualParams.m_Barks,

            ReachFXThresholdBonus = visualParams.ReachFXThresholdBonus,

            DefaultArmorSoundType = visualParams.DefaultArmorSoundType,
            FootstepSoundSizeType = visualParams.FootstepSoundSizeType,
            FootSoundType = visualParams.FootSoundType,
            FootSoundSize = visualParams.FootSoundSize,
            BodySoundType = visualParams.BodySoundType,
            BodySoundSize = visualParams.BodySoundSize,

            FoleySoundPrefix = visualParams.FoleySoundPrefix,
            NoFinishingBlow = visualParams.NoFinishingBlow,
            ImportanceOverride = visualParams.ImportanceOverride,
            SilentCaster = visualParams.SilentCaster
        };
    }

    internal static BlueprintUnit.UnitBody GetUnitBody(BlueprintUnit unit)
    {
        var unitBody = unit.Body;

        return new BlueprintUnit.UnitBody
        {
            DisableHands = unitBody.DisableHands,
            ActiveHandSet = unitBody.ActiveHandSet,

            m_EmptyHandWeapon = unitBody.m_EmptyHandWeapon,

            m_PrimaryHand = unitBody.m_PrimaryHand,
            m_SecondaryHand = unitBody.m_SecondaryHand,

            m_PrimaryHandAlternative1 = unitBody.m_PrimaryHandAlternative1,
            m_SecondaryHandAlternative1 = unitBody.m_SecondaryHandAlternative1,

            m_PrimaryHandAlternative2 = unitBody.m_PrimaryHandAlternative2,
            m_SecondaryHandAlternative2 = unitBody.m_SecondaryHandAlternative2,

            m_PrimaryHandAlternative3 = unitBody.m_PrimaryHandAlternative3,
            m_SecondaryHandAlternative3 = unitBody.m_SecondaryHandAlternative3,

            m_AdditionalLimbs = unitBody.m_AdditionalLimbs?.ToArray(),
            m_AdditionalSecondaryLimbs = unitBody.m_AdditionalSecondaryLimbs?.ToArray(),

            m_Armor = unitBody.m_Armor,
            m_Shirt = unitBody.m_Shirt,
            m_Belt = unitBody.m_Belt,
            m_Head = unitBody.m_Head,
            m_Glasses = unitBody.m_Glasses,
            m_Feet = unitBody.m_Feet,
            m_Gloves = unitBody.m_Gloves,
            m_Neck = unitBody.m_Neck,
            m_Ring1 = unitBody.m_Ring1,
            m_Ring2 = unitBody.m_Ring2,
            m_Wrist = unitBody.m_Wrist,
            m_Shoulders = unitBody.m_Shoulders,

            m_QuickSlots = unitBody.m_QuickSlots?.ToArray()
        };
    }

    internal static BlueprintUnit.UnitSkills GetUnitSkills(BlueprintUnit unit)
    {
        var skills = unit.Skills;

        return new BlueprintUnit.UnitSkills
        {
            Acrobatics = skills.Acrobatics,
            Physique = skills.Physique,
            Diplomacy = skills.Diplomacy,
            Thievery = skills.Thievery,
            LoreNature = skills.LoreNature,
            Perception = skills.Perception,
            Stealth = skills.Stealth,
            UseMagicDevice = skills.UseMagicDevice,
            LoreReligion = skills.LoreReligion,
            KnowledgeWorld = skills.KnowledgeWorld,
            KnowledgeArcana = skills.KnowledgeArcana
        };
    }
}
