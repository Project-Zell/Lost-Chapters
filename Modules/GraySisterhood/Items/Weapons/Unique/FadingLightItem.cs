using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.Configurators.Items.Ecnchantments;
using BlueprintCore.Blueprints.Configurators.Items.Weapons;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.Enums;
using Kingmaker.Enums.Damage;
using Kingmaker.RuleSystem;
using Kingmaker.RuleSystem.Rules.Damage;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Components;
using LostChapters.Modules.GraySisterhood.Enchantments;
using LostChapters.Modules.GraySisterhood.Feats;
using UnityEngine;

namespace LostChapters.Modules.GraySisterhood.Items.Weapons.Unique;

internal class FadingLightItem
{
    public static readonly string Guid = "{983c84ab-3345-4c7f-b7fb-ab7fc4fb9d06}";

    private static readonly string ItemName = "FadingLightItem";
    private static readonly string DisplayName = "FadingLightItem.Name";
    private static readonly string Description = "FadingLightItem.Description";

    //icon and model and cost
    private static readonly Sprite Icon = ItemWeaponRefs.HolyElderFlamingLongswordPlus5.Reference.Get().Icon;

    internal static void Configure()
    {
        Enchantment.Configure();

        ItemWeaponConfigurator.New(ItemName, Guid)
            .CopyFrom(ItemWeaponRefs.HolyElderFlamingLongswordPlus5, typeof(WeaponVisualParameters))
            .SetCost(cost: 8500)
            .SetCR(cR: 6)
            .SetType(WeaponTypeRefs.Longsword.ToString())
            .SetSize(Size.Medium)
            .SetEnchantments(enchantments: [
                Enchantment.Guid,
                BenevolentWeaponEnchantment.Reference,
                WeaponEnchantmentRefs.Holy.ToString(),
                WeaponEnchantmentRefs.Enhancement3.ToString()])
            .SetDisplayNameText(DisplayName)
            .SetDescriptionText(Description)
            .SetIcon(Icon)
            .Configure();
    }

    internal class Enchantment
    {
        public static readonly string Guid = "{c9983405-5451-45b4-813a-d89b2c3a4b5c}";

        private static readonly string EnchantmentName = "FadingLightItem.Enchantment";

        internal static void Configure()
        {
            Feature.Configure();

            WeaponEnchantmentConfigurator.New(EnchantmentName, Guid)
                .AddUnitFactEquipment(blueprint: Feature.Guid)
                .Configure();
        }
    }

    internal class Feature
    {
        public static readonly string Guid = "{837d45fd-478e-4e8c-ae71-a0a1c3159da4}";

        private static readonly string FeatureName = "FadingLightItem.Feature";

        internal static void Configure()
        {
            var duration = ContextDuration.FixedDice(diceType: DiceType.One);
            var action = ActionsBuilder.New().Conditional(conditions: ConditionsBuilder.New().CasterHasFact(Guid),
                ifTrue: ActionsBuilder.New().ApplyBuff(buff: BuffRefs.IceBodyBuff.Reference.Get(), asChild: true, isNotDispelable: true, durationValue: duration));

            FeatureConfigurator.New(FeatureName, Guid)
                .AddAbilityUseTrigger(
                    abilities: [AidAnotherFeature.AttackAbility.Guid, SwiftAid.AttackAbility.Guid],
                    actionsOnTarget: true,
                    action: action)
                .SetHideInUI()
                .Configure();
        }
    }

    internal class Buff
    {
        public static readonly string Guid = "{9811523f-8c24-4cdd-a3c3-f11ca3a8aa7b}";

        private static readonly string BuffName = "FadingLightItem.Buff";

        internal static void Configure()
        {
            BuffConfigurator.New(BuffName, Guid)
                .AdditionalDiceOnAttack(
                    attackType: AdditionalDiceOnAttack.WeaponOptions.OnlyWeaponAttacks,
                    rangeType: WeaponRangeType.Melee,
                    value: new ContextDiceValue()
                    {
                        DiceType = DiceType.D6,
                        DiceCountValue = 2,
                    },
                    damageType: new DamageTypeDescription()
                    {
                        Type = DamageType.Energy,
                        Energy = DamageEnergyType.Divine,
                    })
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(Icon)
                .Configure();
        }
    }
}
