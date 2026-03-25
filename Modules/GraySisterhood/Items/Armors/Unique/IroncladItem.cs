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
using Kingmaker.RuleSystem;
using LostChapters.Modules.GraySisterhood.Feats;
using UnityEngine;

namespace LostChapters.Modules.GraySisterhood.Items.Armors.Unique;

internal class IroncladItem
{
    public static readonly string Guid = "{2a99cdca-8a0c-406c-998a-d24d6fd2b7ab}";

    private static readonly string ItemName    = "IroncladItem";
    private static readonly string DisplayName = "IroncladItem.Name";
    private static readonly string Description = "IroncladItem.Description";

    private static readonly Sprite Icon = ItemArmorRefs.AdamantineFullplateStandartPlus3.Reference.Get().Icon;

    internal static void Configure()
    {
        Enchantment.Configure();

        ItemArmorConfigurator.New(ItemName, Guid)
            .CopyFrom(ItemArmorRefs.AdamantineFullplateStandartPlus3, typeof(ArmorVisualParameters))
            .SetType(ArmorTypeRefs.FullplateType.ToString())
            .SetEnchantments([
                ArmorEnchantmentRefs.ArmorEnhancementBonus5.ToString(),
                Enchantment.Guid])
            .SetCost(0)
            .SetDisplayNameText(DisplayName)
            .SetDescriptionText(Description)
            .SetIcon(Icon)
            .Configure();
    }

    internal class Enchantment
    {
        public static readonly string Guid = "{5a33a36f-3141-42f5-9181-b4f44e3df0e9}";

        private static readonly string FeatureName = "IroncladItem.Enchantment";

        internal static void Configure()
        {
            Feature.Configure();

            ArmorEnchantmentConfigurator.New(FeatureName, Guid) 
                .AddUnitFactEquipment(blueprint: Feature.Guid)
                .Configure();
        }
    }

    internal class Feature
    {
        public static readonly string Guid = "{35b4b307-f3ce-4de1-a7cd-2c45b5fda795}";

        private static readonly string FeatureName = "IroncladItem.Feature";

        internal static void Configure()
        {
            Buff.Configure();

            var duration = ContextDuration.FixedDice(DiceType.D2);

            var condition = ConditionsBuilder.New().HasFact(Buff.Guid);

            var action = ActionsBuilder.New().Conditional(condition,
                ifFalse: ActionsBuilder.New()
                    .ApplyBuff(
                        buff: BuffRefs.IronBodyBuff.ToString(),
                        durationValue: duration,
                        asChild: true))
                    .ApplyBuffPermanent(
                        buff: Buff.Guid,
                        asChild: true);

            FeatureConfigurator.New(FeatureName, Guid) 
                .AddAbilityUseTrigger(
                    abilities: [AidAnotherFeature.ArmorClassAbility.Guid, SwiftAid.ArmorClassAbility.Guid],
                    actionsOnTarget: true,
                    action:  action)
                .Configure();
        }
    }

    internal class Buff
    {
        public static readonly string Guid = "{adc30250-e6f4-4d84-a33c-85facc19c2df}";

        private static readonly string BuffName = "IroncladItem.Buff";

        internal static void Configure()
        {
            BuffConfigurator.New(BuffName, Guid)
                .AddRemoveWhenCombatEnded()
                .Configure();
        }
    }
}
