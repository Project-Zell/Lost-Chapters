using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.BasicEx;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.Configurators.Items.Ecnchantments;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using Kingmaker.Designers.Mechanics.EquipmentEnchants;
using Kingmaker.Enums.Damage;
using Kingmaker.RuleSystem;
using Kingmaker.RuleSystem.Rules.Damage;
using Kingmaker.UI.GenericSlot;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.Utility;
using LostChapters.Modules.HellknightCodex.PrestigeClasses.Hellknight;

namespace LostChapters.Modules.HellknightsCodex.PrestigeClasses.Hellknight.Discipline;

internal class DiabolicalBladeFeature
{
    public static readonly string Guid = "{4227449c-70da-47f6-b45a-6cc5f1699ce4}";

    private static readonly string FeatureName = "DiabolicalBladeFeature";
    private static readonly string DisplayName = $"{FeatureName}.Name";
    private static readonly string Description = $"{FeatureName}.Description";

    internal static void Configure()
    {
        //Bloodboiler Item
        //Hit dice is equal to character level?

        FeatureConfigurator.New(FeatureName, Guid)
            .AddToFeatureSelection(HellknightDisciplineSelection.Guid)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .Configure();

    }

    internal class Buff
    {
        public static readonly string Guid = "{ea9272c5-c7e4-4a06-8abe-736df557ad20}";

        private static readonly string BuffName = "DiabolicalBladeFeature";
        private static readonly string DisplayName = $"{FeatureName}.Name";
        private static readonly string Description = $"{FeatureName}.Description";

        internal static void Configure()
        {
            BuffConfigurator.New(BuffName, Guid)
                .AddBuffEnchantAnyWeapon(Enchantment.Guid, EquipSlotBase.SlotType.PrimaryHand)
                .SetIsClassFeature(true)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                //.AddFeatureTagsComponent()
                //.SetIcon(Icon)
                .Configure();
        }
    }

    internal class Enchantment
    {
        public static readonly string Guid = "{0358ab5d-2896-45de-8147-6e44b5fe265e}";

        private static readonly string EnchantmentName = $"{FeatureName}.Enchantment";
        private static readonly string DisplayName = $"{EnchantmentName}.Name";
        private static readonly string Description = $"{EnchantmentName}.Description";

        internal static void Configure()
        {
            //var sourceFx = "91e5a56dd421a2941984a36a2af164b6";
            //var newFx = "ea68e52c-aeea-4418-b93c-f257378f11d8";

            //AssetTool.RegisterDynamicPrefabLink(newFx, sourceFx, ModifyFx);

            var action = ActionsBuilder.New().CastSpell(Ability.Guid).MarkForceDismemberOwner();

            WeaponEnchantmentConfigurator.New(EnchantmentName, Guid)
                .AddInitiatorAttackWithWeaponTrigger(reduceHPToZero: true, action: action)
                .AddWeaponEnergyDamageDice(element: DamageEnergyType.Fire, energyDamageDice: new DiceFormula(rollsCount: 2, diceType: DiceType.D6))
                .AddIgnoreResistanceForDamageFromEnchantment(type: IgnoreResistanceForDamageFromEnchantment.IgnoreType.ReductionAndImmunities)
                .SetWeaponFxPrefab("91e5a56dd421a2941984a36a2af164b6")
                .SetEnchantName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }

    internal class Ability
    {
        public static readonly string Guid = "{46e3843b-7c6e-4430-a351-350cca1b3e64}";

        private static readonly string AbilityName = $"{FeatureName}.Ability";
        private static readonly string DisplayName = $"{AbilityName}.Name";
        private static readonly string Description = $"{AbilityName}.Description";

        //private static readonly Sprite Icon = $"{_Module.IconPath}/ .png";

        internal static void Configure()
        {
            var diceValue = new ContextDiceValue()
            {
                DiceType = DiceType.D6,
                DiceCountValue = 2,
                BonusValue = 0,
            };

            var action = ActionsBuilder.New().DealDamage(
                damageType: new DamageTypeDescription()
                {
                    Type = DamageType.Energy,
                    Energy = DamageEnergyType.Fire, 
                },
                value: diceValue,
                isAoE: true, 
                ignoreCritical: true);

            AbilityConfigurator.New(AbilityName, Guid)
                .AddAbilityEffectRunAction(action)
                .AddAbilityTargetsAround(radius: 20.Feet(), targetType: TargetType.Enemy, spreadSpeed: 20.Feet())
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                //.AddFeatureTagsComponent()
                //.SetIcon(Icon)
                .Configure();
        }
    }
}
