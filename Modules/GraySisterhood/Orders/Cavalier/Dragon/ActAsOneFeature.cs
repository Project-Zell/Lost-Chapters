using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.UnitLogic.Commands.Base;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.Visual.Animation.Kingmaker.Actions;
using LostChapters.Modules.GraySisterhood.Components;

namespace LostChapters.Modules.GraySisterhood.Orders.Cavalier.Dragon
{
    internal class ActAsOneFeature
    {
        public static readonly string Guid = "{820f372e-0524-48fe-9a20-ca2f037477de}";

        private static readonly string FeatureName = "ActAsOne";
        private static readonly string DisplayName = "ActAsOne.Name";
        private static readonly string Description = "ActAsOne.Description";

        private static readonly string ResourceName = "ActAsOne.Recource";

        internal static readonly string Icon = "assets/graysisterhood/icons/actasone.png";

        internal static void Configure()
        {
            Resource.Configure();
            Ability.Configure();
            Buff.Configure();

            FeatureConfigurator.New(FeatureName, Guid)
                .AddFacts([Ability.Guid])
                .AddCombatStateTrigger(combatEndActions: ActionsBuilder.New().RestoreResource(Resource.Guid))
                .AddAbilityResources(resource: Resource.Guid, restoreAmount: true)
                .SetIsClassFeature(true)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(Icon)
                .Configure();
        }

        internal class Resource
        {
            public static readonly string Guid = "{7572d29f-8746-437b-a8bc-aebc2d1318b7}";

            internal static void Configure()
            {
                AbilityResourceConfigurator.New(ResourceName, Guid)
                    .SetMaxAmount(builder: ResourceAmountBuilder.New(1))
                    .Configure();
            }
        }

        internal class Ability
        {
            public static readonly string Guid = "{36f872bd-ae8c-4b52-8373-43a681aed526}";

            private static readonly string AbilityName = "ActAsOne.Ability";

            internal static void Configure()
            {
                AbilityConfigurator.New(AbilityName, Guid)
                    .AddComponent<ActAsOne>()
                    .AddAbilityCustomCharge()
                    .AddAbilityResourceLogic(requiredResource: Resource.Guid, isSpendResource: true, amount: 1)
                    .AddAbilityRequirementHasItemInHands(type: AbilityRequirementHasItemInHands.RequirementType.HasMeleeWeapon, excludeLimbs: true)
                    .AddAbilityRequirementHasCondition(conditions: [UnitCondition.DifficultTerrain], mountConditions: [UnitCondition.DifficultTerrain], not: true)
                    .AddAbilityRequirementCanMove()
                    .AddHideDCFromTooltip()
                    .SetType(AbilityType.Physical)
                    .SetRange(AbilityRange.DoubleMove)
                    .AllowTargeting(point: false, enemies: true, friends: false, self: false)
                    .SetShouldTurnToTarget(true)
                    .SetEffectOnEnemy(AbilityEffectOnUnit.Harmful)
                    .SetAnimation(UnitAnimationActionCastSpell.CastAnimationStyle.Immediate)
                    .SetActionType(UnitCommand.CommandType.Standard)
                    .SetIcon(Icon)
                    .SetDisplayName(DisplayName)
                    .SetDescription(Description)
                    .Configure();
            }
        }

        internal class Buff
        {
            public static readonly string Guid = "{d2abeb06-1877-490e-95be-898fbb74bb7f}";

            private static readonly string BuffName = "ActAsOne.Buff";
            private static readonly string DisplayName = "ActAsOne.Buff.Name";
            private static readonly string Description = "ActAsOne.Buff.Description";

            internal static void Configure()
            {
                BuffConfigurator.New(BuffName, Guid)
                    .SetFxOnStart("749bb96fb50ee5b4685645472d718465")
                    .AddContextStatBonus(stat: StatType.AC, value: 2, descriptor: ModifierDescriptor.Dodge)
                    .AddContextStatBonus(stat: StatType.AdditionalAttackBonus, value: 2, descriptor: ModifierDescriptor.UntypedStackable)
                    .AddMechanicsFeature(AddMechanicsFeature.MechanicsFeatureType.Pounce)
                    .SetIcon(Icon)
                    .SetDisplayName(DisplayName)
                    .SetDescription(Description)
                    .Configure();
            }
        }
    }
}
