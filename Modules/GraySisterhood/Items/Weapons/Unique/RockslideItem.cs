using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.Configurators.Items.Ecnchantments;
using BlueprintCore.Blueprints.Configurators.Items.Weapons;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.Mechanics;
using LostChapters.Modules.GraySisterhood.Components;
using LostChapters.Modules.GraySisterhood.Enchantments;
using LostChapters.Modules.GraySisterhood.Feats;
using UnityEngine;

namespace LostChapters.Modules.GraySisterhood.Items.Weapons.Unique;

internal class RockslideItem
{
    public static readonly string Guid = "{5f9e0f4d-048d-494e-bd12-98b280c0fb8c}";

    private static readonly string ItemName    = "RockslideItem";
    private static readonly string DisplayName = "RockslideItem.Name";
    private static readonly string Description = "RockslideItem.Description";

    private static readonly Sprite Icon = ItemWeaponRefs.EarthBreakerHolyItem.Reference.Get().Icon;

    internal static void Configure()
    {
        Enchantment.Configure();
        Fact.Configure();
        Buff.Configure();   

        ItemWeaponConfigurator.New(ItemName, Guid)
            .SetType(WeaponTypeRefs.EarthBreaker.ToString())
            .CopyFrom(ItemWeaponRefs.EarthBreakerHolyItem, typeof(WeaponVisualParameters))
            .SetCost(cost: 200000)
            .SetCR(cR: 20)
            .SetSize(Size.Medium)
            .SetEnchantments(enchantments: [
                BenevolentWeaponEnchantment.Reference,
                Enchantment.Guid,
                WeaponEnchantmentRefs.DruchiteWeaponEnchantment.ToString(),
                WeaponEnchantmentRefs.Enhancement5.ToString()])
            .SetDisplayNameText(DisplayName)
            .SetIcon(Icon)
            .Configure();
    }

    internal class Enchantment
    {
        public static readonly string Guid = "{49fea1bb-9ef5-420a-9516-35104877397b}";

        private static readonly string EnchantmentName = "RockslideItem.Enchantment";

        internal static void Configure()
        {
            WeaponEnchantmentConfigurator.New(EnchantmentName, Guid)
                .AddUnitFactEquipment(Fact.Guid)
                .Configure();
        }
    }

    internal class Buff
    {
        public static readonly string Guid = "{f8b3b7a6-ab12-466b-af46-28ec5d6e7f63}";

        private static readonly string BuffName = "RockslideItem.Buff";

        internal static void Configure()
        {
            BuffConfigurator.New(BuffName, Guid)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(Icon)
                .Configure();
        }
    }

    internal class Fact
    {
        public static readonly string Guid = "{4fb8173b-fbdc-4ac5-bb75-0d05f6521fe6}";

        private static readonly string FactName = "RockslideItem.Fact";

        internal static void Configure()
        {
            FeatureConfigurator.New(FactName, Guid)
                .AddStatBonus(ModifierDescriptor.Anomaly, stat: Kingmaker.EntitySystem.Stats.StatType.Strength, value: 100)
                .AddComponent<Rockslide>()
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(Icon)
                .Configure();

            var duration = ContextDuration.Fixed(1, DurationRate.Rounds);

            var action = ActionsBuilder.New()
                .Conditional(
                    ConditionsBuilder.New().CasterHasFact(Guid),
                    ifTrue: ActionsBuilder.New().ApplyBuff(buff: Buff.Guid, durationValue: duration))
                .Build();

            AbilityConfigurator.For(AidAnotherFeature.AttackAbility.Guid)
                .AddAbilityExecuteActionOnCast(actions: action)
                .Configure();

            AbilityConfigurator.For(SwiftAid.AttackAbility.Guid)
                .AddAbilityExecuteActionOnCast(actions: action)
                .Configure();
        }
    }
}
