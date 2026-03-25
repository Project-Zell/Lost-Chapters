using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.Configurators.Items.Armors;
using BlueprintCore.Blueprints.Configurators.Items.Ecnchantments;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.BasicEx;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints.Items.Armors;
using Kingmaker.Enums;
using Kingmaker.RuleSystem;
using LostChapters.Modules.GraySisterhood.Feats;
using UnityEngine;
using Kingmaker.Designers.Mechanics.Facts;

namespace LostChapters.Modules.GraySisterhood.Items.Armors.Unique;

internal class SwornProtectorItem
{
    public static readonly string Guid = "{50613baf-7244-462a-ae9c-90fe51ae29e4}";

    private static readonly string ItemName = "SwornProtectorItem";
    private static readonly string DisplayName = $"{ItemName}.Name";
    private static readonly string Description = $"{ItemName}.Description";

    private static readonly Sprite Icon = ItemArmorRefs.ChainmailOfComraderyItem.Reference.Get().Icon;

    internal static void Configure()
    {
        Enchantment.Configure();

        ItemArmorConfigurator.New(ItemName, Guid)
            .CopyFrom(blueprint: ItemArmorRefs.ChainmailOfComraderyItem.ToString(), typeof(ArmorVisualParameters))
            .AddEquipmentRestrictionClass(clazz: CharacterClassRefs.DragonClass.ToString(), not: true)
            .SetType(ArmorTypeRefs.ChainmailType.ToString())
            .SetSize(Size.Medium)
            .SetEnchantments([
                ArmorEnchantmentRefs.ArmorEnhancementBonus2.ToString(),
                Enchantment.Guid])
            .SetCost(0)
            .SetCR(0)
            .SetDestructible(true)
            .SetDisplayNameText(DisplayName)
            .SetDescriptionText(Description)
            .SetIcon(Icon)
            .Configure();
    }

    internal class Enchantment
    {
        public static readonly string Guid = "{a7f944b1-7409-42e7-9007-afaedd2e4eb9}";

        private static readonly string EnchantmentName = $"{ItemName}.Enchantment";

        internal static void Configure()
        {
            Feature.Configure();

            ArmorEnchantmentConfigurator.New(EnchantmentName, Guid)
                .AddUnitFactEquipment(Feature.Guid)
                .Configure();
        }
    }

    internal class Feature
    {
        public static readonly string Guid = "{f65e5a4f-3659-4065-bda8-49aad379b8ed}";

        private static readonly string FeatureName = $"{ItemName}.Name";

        internal static void Configure()
        {
            Buff.Configure();
            
            var duration = ContextDuration.FixedDice(DiceType.One);
            var action = ActionsBuilder.New().ApplyBuff(Buff.Guid, duration);

            FeatureConfigurator.New(FeatureName, Guid)
                .AddAbilityUseTrigger(
                    abilities: [AidAnotherFeature.ArmorClassAbility.Guid, SwiftAid.ArmorClassAbility.Guid],
                    actionsOnTarget: true,
                    action: action)
                .Configure();
        }
    }

    internal class Buff
    {
        public static readonly string Guid = "{6df1291f-ee3f-4983-9b73-2bb174840908}";

        private static readonly string BuffName = $"{ItemName}.Buff";

        internal static void Configure()
        {
            EffectBuff.Configure();

            var duration = ContextDuration.FixedDice(DiceType.One);
            var action = ActionsBuilder.New().ApplyBuff(EffectBuff.Guid, duration);
            var conditionalAction = ActionsBuilder.New().Conditional(ConditionsBuilder.New().IsEnemy(), ifTrue: action);

            BuffConfigurator.New(BuffName, Guid)
                .AddTargetBeforeAttackRollTrigger(actionsOnAttacker: action)
                .AddAbilityUseTargetTrigger(action: conditionalAction, dontCheckType: true, toCaster: true)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(Icon)
                .Configure();
        }
    }

    internal class EffectBuff
    {
        public static readonly string Guid = "{0ad700e4-3663-4441-a51e-b8f05c04e696}";

        private static readonly string BuffName = $"{ItemName}.EffectBuff";
        internal static void Configure()
        {
            var action = ActionsBuilder.New().Conditional(ConditionsBuilder.New().HasBuff(Buff.Guid, negate: true),
                ifTrue: ActionsBuilder.New().RemoveSelf());

            BuffConfigurator.New(BuffName, Guid)
                .AddModifyD20(
                    rule: RuleType.AttackRoll,
                    rollsAmount: 1,
                    takeBest: false)
                .AddInitiatorAttackWithWeaponTrigger(
                    triggerBeforeAttack: true,
                    onlyHit: true,
                    action: action)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(Icon)
                .Configure();
        }
    }
}
