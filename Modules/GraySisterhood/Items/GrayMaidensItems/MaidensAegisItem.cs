using BlueprintCore.Blueprints.Configurators.Items.Armors;
using BlueprintCore.Blueprints.Configurators.Items.Ecnchantments;
using BlueprintCore.Blueprints.Configurators.Items.Shields;
using BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using BlueprintCore.Conditions.Builder.KingdomEx;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.ActivatableAbilities;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.Utility;
using UnityEngine;

namespace LostChapters.Modules.GraySisterhood.Items.GrayMaidensItems;

internal class MaidensAegisItem
{
    public static readonly string Guid = "{14de154e-d3f6-494d-a233-003a862b86da}";

    private static readonly string ItemName    = "MaidensAegisItem";
    private static readonly string DisplayName = "MaidensAegisItem.Name";
    private static readonly string Description = "MaidensAegisItem.Description";

    private static readonly Sprite Icon = ItemShieldRefs.HeavyShieldItemPlus1RedWhite.Reference.Get().Icon;

    internal static void Configure()
    {
        MaidensAegisArmorItem.Configure();

        ItemShieldConfigurator.New(ItemName, Guid)
            .CopyFrom(ItemShieldRefs.HeavyShieldItemPlus1RedWhite.ToString())
            .SetArmorComponent(MaidensAegisArmorItem.Guid)
            .SetDisplayNameText(DisplayName)
            .SetDescriptionText(Description)
            .SetIcon(Icon)
            .Configure();
    }

    internal class MaidensAegisArmorItem
    {
        public static readonly string Guid = "{481ae296-ec17-4515-91a7-f0fb53d29af4}";

        private static readonly string ItemName = "MaidenAegisItem.Armor";

        internal static void Configure()
        {
            Enchantment.Configure();

            ItemArmorConfigurator.New(ItemName, Guid)
                .CopyFrom(ItemArmorRefs.HeavyShieldArmorItem.ToString())
                .SetEnchantments([
                    ArmorEnchantmentRefs.ShieldEnhancementBonus2.ToString(),
                    Enchantment.Guid])
                .Configure();
        }
    }

    internal class Enchantment
    {
        public static readonly string Guid = "{a64ebaa4-aaa0-4c5f-ac59-4e0d94df7c6c}";

        private static readonly string EnchantmentName = "MaidenAegisItem.Enchantment";

        internal static void Configure()
        {
            ActivatableAbility.Configure();

            ArmorEnchantmentConfigurator.New(EnchantmentName, Guid)
                .AddUnitFactEquipment(ActivatableAbility.Guid)
                .Configure();
        }
    }

    internal class ActivatableAbility
    {
        public static readonly string Guid = "{8e164134-1d20-4d40-9647-ec7db7b20e0f}";

        private static readonly string AbilityName = "MaidenAegisItem.ActivatableAbility";

        internal static void Configure()
        {
            AreaBuff.Configure();

            ActivatableAbilityConfigurator.New(AbilityName, Guid)
                .SetBuff(AreaBuff.Guid)
                .SetActivationType(AbilityActivationType.WithUnitCommand)
                .SetDeactivateIfOwnerUnconscious()
                .SetDisplayName(AbilityName)
                .SetDescription(Description)
                .SetIcon(Icon)
                .Configure();
        }
    }

    internal class AreaBuff
    {
        public static readonly string Guid = "{7b0d0d27-895c-4548-8712-0ffcc49bbd01}";

        private static readonly string BuffName = "MaidenAegisItem.AreaBuff";

        internal static void Configure()
        {
            AbilityAreaEffect.Configure();

            BuffConfigurator.New(BuffName, Guid)
                .AddAreaEffect(areaEffect: AbilityAreaEffect.Guid)
                .AddStatBonus(descriptor: ModifierDescriptor.ShieldEnhancement, stat: StatType.AC, value: -2)
                .SetFlags(BlueprintBuff.Flags.HiddenInUi)
                .Configure();
        }
    }

    internal class AbilityAreaEffect
    {
        public static readonly string Guid = "{805a032d-20a9-4862-b867-2dcf1ede5b73}";

        private static readonly string AreaEffectName = "MaidenAegisItem.AbilityAreaEffect";

        internal static void Configure()
        {
            Buff.Configure();

            var condition = ConditionsBuilder.New().IsCaster(true);

            AbilityAreaEffectConfigurator.New(AreaEffectName, Guid)
                .AddAbilityAreaEffectBuff(buff: Buff.Guid, condition: condition)
                .SetTargetType(BlueprintAbilityAreaEffect.TargetType.Ally)
                .SetShape(AreaEffectShape.Cylinder)
                .SetSize(15.Feet())
                .Configure();
        }
    }

    internal class Buff
    {
        public static readonly string Guid = "{f8294185-04d6-436d-b631-0a2e6ef28dfa}";

        private static readonly string BuffName = "MaidenAegisItem.Buff";

        internal static void Configure()
        {
            BuffConfigurator.New(BuffName, Guid)
                .AddStatBonus(descriptor: ModifierDescriptor.Shield, stat: StatType.AC, value: 2)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(Icon)
                .Configure();
        }
    }
}
