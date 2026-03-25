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
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.Enums.Damage;
using Kingmaker.ResourceLinks;
using Kingmaker.RuleSystem;
using LostChapters.Modules.GraySisterhood.Enchantments;
using UnityEngine;

namespace LostChapters.Modules.GraySisterhood.Items.Weapons.Unique;

internal class GutSkewerItem
{
    public static readonly string Guid = "{d6caa30e-64c2-4e20-ab43-b74dbb0204c9}";

    private static readonly string ItemName    = "GutSkewerItem";
    private static readonly string DisplayName = "GutSkewerItem.Name";
    private static readonly string Description = "GutSkewerItem.Description";

    //icon and model and cost
    private static readonly Sprite Icon = ItemWeaponRefs.MithralShortspearPlus3LycanthropeBaneItem.Reference.Get().Icon;

    internal static void Configure()
    {
        Enchantment.Configure();
        Buff.Configure();

        ItemWeaponConfigurator.New(ItemName, Guid)
            .CopyFrom(blueprint: ItemWeaponRefs.MithralShortspearPlus3LycanthropeBaneItem, typeof(WeaponVisualParameters))
            .SetType(WeaponTypeRefs.Shortspear.ToString())
            .SetSize(Size.Medium)
            .SetCost(cost: 43750)
            .SetCR(cR: 16)
            .SetEnchantments(enchantments: [
                Enchantment.Guid,
                BenevolentWeaponEnchantment.Reference,
                WeaponEnchantmentRefs.DruchiteWeaponEnchantment.ToString(),
                WeaponEnchantmentRefs.Enhancement2.ToString()])
            .SetDisplayNameText(DisplayName)
            .SetDescriptionText(Description)
            .SetIcon(Icon)
            .Configure();
    }

    internal class Enchantment
    {
        public static readonly string Guid = "{0a828443-d8ba-4885-8d1d-ab497bd9c96f}";

        private static readonly string EnchantmentName = "GutSkewer.Enchantment";

        internal static void Configure()
        {
            var duration = ContextDuration.VariableDice(diceType: DiceType.D3, diceCount: 1);
            var condition = ConditionsBuilder.New().HasBuff(buff: Buff.Guid, negate: true).IsFlatFooted();
            var action = ActionsBuilder.New().Conditional(conditions: condition,
                ifTrue: ActionsBuilder.New().SavingThrow(type: SavingThrowType.Fortitude, customDC: 21, 
                    onResult: ActionsBuilder.New().ConditionalSaved(
                        failed: ActionsBuilder.New().ApplyBuff(buff: Buff.Guid, durationValue: duration, isNotDispelable: true))));

            WeaponEnchantmentConfigurator.New(EnchantmentName, Guid)
                .AddInitiatorAttackWithWeaponTrigger(action: action, onlyHit: true)
                .Configure();
        }
    }

    internal class Buff
    {
        public static readonly string Guid = "{c1cd526d-9433-4718-b5cd-e2045b40d135}";

        private static readonly string BuffName = "GutSkewer.Buff";
        internal static void Configure()
        {
            BuffConfigurator.New(BuffName, Guid)
                .AddDamageTypeVulnerability(formType: PhysicalDamageForm.Slashing, physcicalForm: true, physcicalAlignment: true)
                .SetDisplayName(BuffName)
                .SetDescription(Description)
                .SetIcon(Icon)
                .Configure();
        }
    }
}