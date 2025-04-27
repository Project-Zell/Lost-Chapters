using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Utils.Types;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.RuleSystem;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.UnitLogic.Commands.Base;
using Kingmaker.Utility;
using Kingmaker.Visual.Animation.Kingmaker.Actions;

namespace LostChapters.Modules.GraySisterhood.Orders.Cavalier.Dragon
{
    internal class StrategyFeature
    {
        public static readonly string FeatureGuid  = "{37dceec1-ea7d-4dec-bd27-e7fa8a1d6586}";

        private static readonly string FeatureName = "Strategy";
        private static readonly string DisplayName = "Strategy.Name";
        private static readonly string Description = "Strategy.Description";

        private static readonly string Icon = $"{GraySisterhoodModule.IconPath}/strategy.png";

        private static readonly string FX_AssedID = "d541609d507424640a84153b89abf210";

        internal static void Configure()
        {
            Resource.Configure();
            Ability.Configure();
            ArmorBuff.Configure();
            AttackBuff.Configure();
            SpeedBuff.Configure();

            FeatureConfigurator.New(FeatureName, FeatureGuid)
                .AddFacts([Ability.Guid])
                .AddCombatStateTrigger(combatEndActions: ActionsBuilder.New().RestoreResource(Resource.Guid))
                .AddAbilityResources(resource: Resource.Guid, restoreAmount: true)
                .SetIsClassFeature(true)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }

        internal class Resource
        {
            public static readonly string Guid = "{e8110145-61bb-4665-85fc-94066f604743}";

            private static readonly string ResourceName = "Strategy.Resource";

            internal static void Configure()
            {
                AbilityResourceConfigurator.New(ResourceName, Guid)
                    .SetMaxAmount(builder: ResourceAmountBuilder.New(1))
                    .Configure();
            }
        }

        internal class Ability
        {
            public static readonly string Guid = "{a079aea1-54a2-47ed-b2b1-6736ea64d44a}";

            private static readonly string AbilityName = "Strategy.Ability";

            internal static void Configure()
            {
                var oneRoundDuration = ContextDuration.FixedDice(DiceType.Zero, bonus: 1);

                AbilityConfigurator.New(AbilityName, Guid)
                    .AddAbilityTargetsAround(targetType: TargetType.Ally, radius: 30.Feet(), spreadSpeed: 15.Feet())
                    .AddAbilityApplyFact(
                        facts: [ArmorBuff.Guid, AttackBuff.Guid, SpeedBuff.Guid],
                        hasDuration: true,
                        duration: oneRoundDuration)
                    .AddAbilityResourceLogic(requiredResource: Resource.Guid, isSpendResource: true, amount: 1)
                    .AddHideDCFromTooltip()
                    .SetType(AbilityType.Extraordinary)
                    .SetCanTargetSelf(true)
                    .SetCanTargetFriends(true)
                    .SetShouldTurnToTarget(true)
                    .SetIgnoreSpellResistanceForAlly(true)
                    .SetCanTargetPoint(false)
                    .SetRange(AbilityRange.Personal)
                    .SetActionType(UnitCommand.CommandType.Standard)
                    .SetAnimation(UnitAnimationActionCastSpell.CastAnimationStyle.Omni)
                    //.SetIcon(BuffRefs.Shout)
                    .SetDisplayName(DisplayName)
                    .SetDescription(Description)
                    .Configure();
            }
        }

        internal class ArmorBuff
        {
            public static readonly string Guid = "{8a09a693-ef59-4372-a2cc-8a4aea1a014e}";

            private static readonly string BuffName = "Strategy.ArmorBuff";
            private static readonly string DisplayName = "Strategy.ArmorBuff.Name";
            private static readonly string Description = "Strategy.ArmorBuff.Description";

            private static readonly string Icon = $"{GraySisterhoodModule.IconPath}/strategyarmor.png";

            public static void Configure()
            {
                BuffConfigurator.New(BuffName, Guid)
                    .SetFxOnStart(FX_AssedID)
                    .AddContextStatBonus(stat: StatType.AC, value: 2, descriptor: ModifierDescriptor.Dodge)
                    .SetDisplayName(DisplayName)
                    .SetDescription(Description)
                    .SetIcon(Icon)
                    .Configure();
            }
        }

        internal class AttackBuff
        {
            public static readonly string Guid = "{957d84c3-a000-4629-b1de-c5e68b370281}";

            private static readonly string BuffName    = "Strategy.AttackBuff";
            private static readonly string DisplayName = "Strategy.AttackBuff.Name";
            private static readonly string Description = "Strategy.AttackBuff.Description";

            private static readonly string Icon = $"{GraySisterhoodModule.IconPath}/strategyattack.png";

            public static void Configure()
            {
                BuffConfigurator.New(BuffName, Guid)
                    .SetFxOnStart(FX_AssedID)
                    .AddContextStatBonus(stat: StatType.AdditionalAttackBonus, value: 2, descriptor: ModifierDescriptor.Competence)
                    .SetDisplayName(DisplayName)
                    .SetDescription(Description)
                    .SetIcon(Icon)
                    .Configure();
            }
        }

        internal class SpeedBuff
        {
            public static readonly string Guid = "{72b87c41-ce0d-4c63-805a-36b13c349422}";

            private static readonly string BuffName    = "Strategy.SpeedBuff";
            private static readonly string DisplayName = "Strategy.SpeedBuff.Name";
            private static readonly string Description = "Strategy.SpeedBuff.Description";

            private static readonly string Icon = $"{GraySisterhoodModule.IconPath}/strategyspeed.png";

            public static void Configure()
            {
                BuffConfigurator.New(BuffName, Guid)
                    .SetFxOnStart(FX_AssedID)
                    .AddContextStatBonus(stat: StatType.Speed, value: 30, descriptor: ModifierDescriptor.Competence)
                    .SetDisplayName(DisplayName)
                    .SetDescription(Description)
                    .SetIcon(Icon)
                    .Configure();
            }
        }
    }
}
