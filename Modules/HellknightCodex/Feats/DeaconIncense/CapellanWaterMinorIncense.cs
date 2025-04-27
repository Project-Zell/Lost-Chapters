using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using Kingmaker.UI.GenericSlot;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using LostChapters.Modules.GraySisterhood.Archetypes;
using LostChapters.Modules.GraySisterhood.Archetypes.ClassFeatures;
using LostChapters.Modules.GraySisterhood.Feats.Selection;

namespace LostChapters.Modules.GraySisterhood.Feats.DeaconIncense
{
    internal class CapellanWaterMinorIncense
    {
        public static readonly string Guid = "b834a776-e1cb-4ee7-ad66-122bada744b7";

        private const string IncenseName = "WaterMinorIncense";
        private const string DisplayName = "WaterMinorIncense.BuffName";
        private const string Description = "WaterMinorIncense.LocalizedDescription";

        public static void Configure()
        {
            AbilityAreaEffectConfigurator.For(CapellanIncenseClassFeature.AreaRef)
                .AddAbilityAreaEffectBuff(
                    buff: CapellanWaterMinorIncenseNormalBuff.GetReference(),
                    condition: ConditionsBuilder.New().IsAlly().CasterHasFact(Guid).CasterHasFact(fact: Deacon.FeatGuid, negate: true))
                .AddAbilityAreaEffectBuff(
                    buff: CapellanWaterMinorIncenseStrongBuff.GetReference(),
                    condition: ConditionsBuilder.New().IsAlly().CasterHasFact(Guid).CasterHasFact(fact: Deacon.FeatGuid))
                .Configure();

            FeatureConfigurator.New(IncenseName, Guid)
                .AddToFeatureSelection(CapellanIncenseSelector.Guid)
                .SetIcon(AbilityRefs.HauntingMists.Reference.Get().Icon)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }

    internal class CapellanWaterMinorIncenseNormalBuff
    {
        public static readonly string Guid = "286152e9-bc76-47f3-baad-1668355ef1fc";

        private const string BuffName = "WaterMinorIncense.NormalBuff";
        private const string DisplayName = "WaterMinorIncense.NormalBuff.BuffName";
        private const string Description = "WaterMinorIncense.NormalBuff.LocalizedDescription";

#nullable enable
        private static BlueprintBuff? Reference;
#nullable disable

        public static BlueprintBuff GetReference() => Reference ??= CreateBuff();

        private static BlueprintBuff CreateBuff()
        {
            return BuffConfigurator.New(BuffName, Guid)
                .AddBuffEnchantAnyWeapon(enchantmentBlueprint: WeaponEnchantmentRefs.Frost.ToString(), slot: EquipSlotBase.SlotType.PrimaryHand)
                .AddBuffEnchantAnyWeapon(enchantmentBlueprint: WeaponEnchantmentRefs.Frost.ToString(), slot: EquipSlotBase.SlotType.SecondaryHand)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.HauntingMists.Reference.Get().Icon)
                .Configure();
        }
    }

    internal class CapellanWaterMinorIncenseStrongBuff
    {
        public static readonly string Guid = "bc341345-078a-4034-8aa4-9df2ad5c9fa5";

        private const string BuffName = "WaterMinorIncense.StrongBuff";
        private const string DisplayName = "WaterMinorIncense.NormalBuff.BuffName";
        private const string Description = "WaterMinorIncense.NormalBuff.LocalizedDescription";

#nullable enable
        private static BlueprintBuff? Reference;
#nullable disable

        public static BlueprintBuff GetReference() => Reference ??= CreateBuff();

        private static BlueprintBuff CreateBuff()
        {
            return BuffConfigurator.New(BuffName, Guid)
                .AddBuffEnchantAnyWeapon(enchantmentBlueprint: WeaponEnchantmentRefs.Ice2d6.ToString(), slot: EquipSlotBase.SlotType.PrimaryHand)
                .AddBuffEnchantAnyWeapon(enchantmentBlueprint: WeaponEnchantmentRefs.Ice2d6.ToString(), slot: EquipSlotBase.SlotType.SecondaryHand)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.HauntingMists.Reference.Get().Icon)
                .Configure();
        }
    }
}
