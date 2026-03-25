using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.Configurators.Items.Ecnchantments;
using BlueprintCore.Blueprints.Configurators.Items.Weapons;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.Enums;
using Kingmaker.RuleSystem;
using LostChapters.Modules.GraySisterhood.Enchantments;
using UnityEngine;

namespace LostChapters.Modules.GraySisterhood.Items.Weapons.Unique;

internal class BladeBreakerItem
{
    public static readonly string Guid = "{35beb1de-f17f-4a48-99c7-546c96dd476f}";

    private static readonly string ItemName    = "BladeBreakerItem";
    private static readonly string DisplayName = "BladeBreakerItem.Name";
    private static readonly string Description = "BladeBreakerItem.Description";

    //icon and model and cost
    private static readonly Sprite Icon = ItemWeaponRefs.AgileLightMacePlus3Item.Reference.Get().Icon;

    internal static void Configure()
    {
        Enchantment.Configure();
        Buff.Configure();

        ItemWeaponConfigurator.New(ItemName, Guid)
            .CopyFrom(blueprint: ItemWeaponRefs.AgileLightMacePlus3Item, typeof(WeaponVisualParameters))
            .SetType(WeaponTypeRefs.LightMace.ToString())
            .SetSize(Size.Medium)
            .SetCost(cost: 52500)
            .SetCR(cR: 10)
            .SetEnchantments(enchantments: [
                Enchantment.Guid,
                BenevolentWeaponEnchantment.Reference,
                WeaponEnchantmentRefs.Enhancement3.ToString()])
            .SetDisplayNameText(DisplayName)
            .SetDescriptionText(Description)
            .SetIcon(Icon)
            .Configure();
    }

    internal class Enchantment
    {
        public static readonly string Guid = "{c3d14a9f-ad5c-418d-97f2-9819f087afdf}";

        private static readonly string EnchantmentName = "BladeBreaker.Enchantment";

        internal static void Configure()
        {
            var duration = ContextDuration.FixedDice(DiceType.One);
            var condition = ConditionsBuilder.New().HasBuff(buff: Buff.Guid, negate: true);
            var action = ActionsBuilder.New().Conditional(conditions: condition,
                ifTrue: ActionsBuilder.New().ApplyBuff(buff: Buff.Guid, durationValue: duration, isNotDispelable: true));

            WeaponEnchantmentConfigurator.New(EnchantmentName, Guid)
                .AddInitiatorAttackWithWeaponTrigger(action: action, onlyOnFirstAttack: true, onlyHit: true)
                .Configure();
        }
    }

    internal class Buff
    {
        public static readonly string Guid = "{e9f91bc8-b59b-40a4-ab70-339e6cfb0743}";

        private static readonly string BuffName = "BladeBreaker.Buff";
        internal static void Configure()
        {
            BuffConfigurator.New(BuffName, Guid)
                .AddAttackBonusConditional(bonus: -2, conditions: 
                    ConditionsBuilder.New().IsWeaponEquipped(rangeType: WeaponRangeType.Melee, bothHandsAreEmpty: false))
                .SetDisplayName(BuffName)
                .SetDescription(Description)
                .SetIcon(Icon)
                .Configure();
        }
    }
}
