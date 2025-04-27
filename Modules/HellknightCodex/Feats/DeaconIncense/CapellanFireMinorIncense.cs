using BlueprintCore.Blueprints.Configurators.Items.Ecnchantments;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using Kingmaker.Blueprints.Items.Ecnchantments;
using Kingmaker.Enums.Damage;
using Kingmaker.RuleSystem;
using Kingmaker.UI.GenericSlot;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using LostChapters.Modules.GraySisterhood.Archetypes;
using LostChapters.Modules.GraySisterhood.Archetypes.ClassFeatures;
using LostChapters.Modules.GraySisterhood.Feats.Selection;

namespace LostChapters.Modules.GraySisterhood.Feats.DeaconIncense
{
    internal class CapellanFireMinorIncense
    {
        public static readonly string Guid = "b634e3ff-b360-4fec-b5e4-81bc66bbfe53";

        private const string IncenseName = "FireMinorIncense";
        private const string DisplayName = "FireMinorIncense.BuffName";
        private const string Description = "FireMinorIncense.LocalizedDescription";

        public static void Configure()
        {
            AbilityAreaEffectConfigurator.For(CapellanIncenseClassFeature.AreaRef)
                .AddAbilityAreaEffectBuff(
                    buff: CapellanFireMinorIncenseNormalBuff.GetReference(),
                    condition: ConditionsBuilder.New().IsAlly().CasterHasFact(Guid).CasterHasFact(fact: Deacon.FeatGuid, negate: true))
                .AddAbilityAreaEffectBuff(
                    buff: CapellanFireMinorIncenseStrongBuff.GetReference(),
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

    internal class CapellanFireMinorIncenseNormalEnchantment
    {
        public static readonly string Guid = "a3ecb3ea-2d53-4328-9c85-3b0121e76b65";

        private const string EnchantmentName = "FireMinorIncense.NormalEnchantment";

#nullable enable
        private static BlueprintWeaponEnchantment? Reference;
#nullable disable

        public static BlueprintWeaponEnchantment GetReference() => Reference ??= CreateEnchantment();

        private static BlueprintWeaponEnchantment CreateEnchantment()
        {
            return WeaponEnchantmentConfigurator.New(EnchantmentName, Guid)
                .AddWeaponEnergyDamageDice(
                    element: DamageEnergyType.Fire,
                    energyDamageDice: new DiceFormula(diceType: DiceType.D6, rollsCount: 1))
                .Configure();
        }
    }

    internal class CapellanFireMinorIncenseNormalBuff
    {
        public static readonly string Guid = "14edb3f5-85e8-4c4d-82dd-e2dea7c2a373";

        private const string BuffName = "FireMinorIncense.NormalBuff";
        private const string DisplayName = "FireMinorIncense.NormalBuff.BuffName";
        private const string Description = "FireMinorIncense.NormalBuff.LocalizedDescription";

#nullable enable
        private static BlueprintBuff? Reference;
#nullable disable

        public static BlueprintBuff GetReference() => Reference ??= CreateBuff();

        private static BlueprintBuff CreateBuff()
        {
            return BuffConfigurator.New(BuffName, Guid)
                .AddBuffEnchantAnyWeapon(enchantmentBlueprint: WeaponEnchantmentRefs.Flaming.ToString(), slot: EquipSlotBase.SlotType.PrimaryHand)
                .AddBuffEnchantAnyWeapon(enchantmentBlueprint: WeaponEnchantmentRefs.Flaming.ToString(), slot: EquipSlotBase.SlotType.SecondaryHand)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.HauntingMists.Reference.Get().Icon)
                .Configure();
        }
    }

    internal class CapellanFireMinorIncenseStrongBuff
    {
        public static readonly string Guid = "1ef1548f-d231-4026-8df2-0545f488fd23";

        private const string BuffName = "FireMinorIncense.StrongBuff";
        private const string DisplayName = "FireMinorIncense.NormalBuff.BuffName";
        private const string Description = "FireMinorIncense.NormalBuff.LocalizedDescription";

#nullable enable
        private static BlueprintBuff? Reference;
#nullable disable

        public static BlueprintBuff GetReference() => Reference ??= CreateBuff();

        private static BlueprintBuff CreateBuff()
        {
            return BuffConfigurator.New(BuffName, Guid)
                .AddBuffEnchantAnyWeapon(enchantmentBlueprint: WeaponEnchantmentRefs.Brass.ToString(), slot: EquipSlotBase.SlotType.PrimaryHand)
                .AddBuffEnchantAnyWeapon(enchantmentBlueprint: WeaponEnchantmentRefs.Brass.ToString(), slot: EquipSlotBase.SlotType.SecondaryHand)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.HauntingMists.Reference.Get().Icon)
                .Configure();
        }
    }
}

