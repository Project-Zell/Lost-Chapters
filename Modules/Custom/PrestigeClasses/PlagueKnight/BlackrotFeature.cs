using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.Configurators.Items.Ecnchantments;
using BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.UnitLogic.ActivatableAbilities;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Commands.Base;
using Kingmaker.UnitLogic.Mechanics;
using LostChapters._wip;

namespace LostChapters.Modules.Custom.PrestigeClasses.PlagueKnight;

internal class BlackrotFeature
{
    public static readonly string Guid = "{aede104c-f1f8-444e-9add-aab3c4f10a91}";

    private static readonly string FeatureName = "BlackrotFeature";
    private static readonly string DisplayName = $"{FeatureName}.Name";
    private static readonly string Description = $"{FeatureName}.Description";

    private static readonly string Icon = $"{CustomModule.IconPath}/blackrot.png";
    public static void Configure()
    {
        Ability.Configure();
        Resource.Configure();

        FeatureConfigurator.New(FeatureName, Guid)
            .AddFacts([Ability.Guid, Resource.Guid])
            .SetRanks(5)
            .SetIcon(Icon)
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .Configure();
    }

    internal class Ability
    {
        public static readonly string Guid = "{18c2b835-0e56-487e-916c-70cd3a8a3325}";

        private static readonly string AbilityName = $"{FeatureName}.Ability";
        private static readonly string DisplayName = $"{AbilityName}.Name";
        private static readonly string Description = $"{AbilityName}.Description";

        //private static readonly Sprite Icon = $"{_Module.IconPath}/ .png";

        internal static void Configure()
        {
            Buff.Configure();

            ActivatableAbilityConfigurator.New(AbilityName, Guid)
                .SetBuff(Buff.Guid)
                //.SetDeactivateIfCombatEnded(true)
                //.SetDeactivateIfOwnerUnconscious(true)
                //.SetActivationType(AbilityActivationType.Immediately)
                //.SetActivateWithUnitCommand(UnitCommand.CommandType.Free)
                //.SetActivateOnUnitAction(AbilityActivateOnUnitActionType.Attack)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(Icon)
                .Configure();
        }
    }

    internal class Buff
    {
        public static readonly string Guid = "{66149e5c-7d03-416f-8f45-739050a5b665}";

        private static readonly string BuffName = $"{FeatureName}.Buff";
        private static readonly string DisplayName = $"{BuffName}.Name";
        private static readonly string Description = $"{BuffName}.Description";

        internal static void Configure()
        {
            Enchantment.Configure();

            BuffConfigurator.New(BuffName, Guid)
                .AddBuffEnchantAnyWeapon(Enchantment.Guid)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(Icon)
                .Configure();
        }
    }

    internal class Enchantment
    {
        public static readonly string Guid = "{8ed82aa1-66e1-4230-bcaf-18d1aa9ce4f8}";

        private static readonly string EnchantmentName = $"{FeatureName}.Enchantment";
        private static readonly string DisplayName = $"{EnchantmentName}.Name";
        private static readonly string Description = $"{EnchantmentName}.Description";

        internal static void Configure()
        {
            DiseaseBuff.Configure();

            var duration = ContextDuration.Fixed(value: 1, rate: DurationRate.Minutes);
            var action = ActionsBuilder.New().ApplyBuff(buff: DiseaseBuff.Guid, durationValue: duration);

            WeaponEnchantmentConfigurator.New(EnchantmentName, Guid)
                .AddInitiatorAttackWithWeaponTrigger(action: action, onlyHit: true, onlyOnFirstAttack: true, triggerBeforeAttack: true)
                .SetWeaponFxPrefab("bfafef74d59950242915a8e294e6fac0")
                .SetEnchantName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }

    internal class Resource
    {
        public static readonly string Guid = "{eb532a5a-87d3-4d24-9091-d34a36e316b0}";

        private static readonly string ResourceName = $"{ResourceName}.Resource";

        //private static readonly Sprite Icon = $"{_Module.IconPath}/ .png";

        internal static void Configure()
        {
            var resource = ResourceAmountBuilder.New(3).IncreaseByLevel(classes: [PlagueKnightClass.Guid], bonusPerLevel: 2);

            AbilityResourceConfigurator.New(ResourceName, Guid)
                .SetMaxAmount(resource)
                .Configure();
        }
    }

    internal class DiseaseBuff
    {
        public static readonly string Guid = "{911d764e-4704-4545-be34-f2794980b29b}";

        private static readonly string BuffName = $"{FeatureName}.DiseaseBuff";
        private static readonly string DisplayName = $"{BuffName}.Name";
        private static readonly string Description = $"{BuffName}.Description";

        //private static readonly Sprite Icon = $"{_Module.IconPath}/ .png";

        internal static void Configure()
        {
            var duration = ContextDuration.Fixed(value: 1, isExtendable: true);
            var actions = ActionsBuilder.New().ApplyBuff(buff: BuffRefs.Sickened.ToString(), durationValue: duration);

            var blackrot = new Blackrot() { ActionsOnSavingThrowFailed = actions.Build() };

            BuffConfigurator.New(BuffName, Guid)
                .AddComponent(blackrot)
                .AddSpellDescriptorComponent(descriptor: SpellDescriptor.Disease)
                .AddSavingThrowBonusAgainstDescriptor
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetStacking(StackingType.Replace)
                //.SetIcon(Icon)
                .Configure();
        }
    }
}