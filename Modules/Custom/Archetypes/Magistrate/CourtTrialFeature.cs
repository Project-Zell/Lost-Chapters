using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.Components.Replacements;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using BlueprintCore.Utils;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.UnitLogic.Abilities.Components.TargetCheckers;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Commands.Base;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.Visual.Animation.Kingmaker.Actions;
using LostChapters._test;
using LostChapters.Modules.Other;

namespace LostChapters.Modules.Custom.Archetypes.Magistrate;

internal class CourtTrialFeature
{
    public static readonly string Guid = "{26a637b5-c37b-4ac8-84d0-b4ea683b1f54}";

    private static readonly string BaseName = "CourtTrial";

    private static readonly string FeatureName = $"{BaseName}Feature";
    private static readonly string DisplayName = $"{FeatureName}.Name";
    private static readonly string Description = $"{FeatureName}.Description";

    //private static readonly Sprite Icon = $"{_Module.IconPath}/ .png";

    internal static void Configure()
    {
        VerdictAbility.Configure();

        Ability.Configure();

        var action = ActionsBuilder.New().ContextSpendResource(resource: VerdictAbility.Resource.Guid, value: 10);

        FeatureConfigurator.New(FeatureName, Guid)
            .AddFacts([Ability.Guid, VerdictAbility.Guid])
            .AddAbilityResources(resource: AbilityResourceRefs.CavalierChallengeResource.ToString(), restoreAmount: true)
            .AddCombatStateTrigger(combatEndActions: action)
            .AddRestTrigger(action: action)
            .SetHideInCharacterSheetAndLevelUp(true)
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .Configure();
    }

    internal class Ability
    {
        public static readonly string Guid = "{1f50fd85-cf2a-402d-9da4-3dde8449515e}";

        private static readonly string AbilityName = $"{FeatureName}.Ability";

        internal static void Configure()
        {
            Buff.Configure();

            var action = ActionsBuilder.New()
                .ApplyBuffPermanent(buff: BuffRefs.CavalierChallengeBuffTarget.ToString(), asChild: true)
                .ApplyBuffPermanent(buff: Buff.Guid, asChild: true);

            AbilityConfigurator.New(AbilityName, Guid)
                .CopyFrom(blueprint: AbilityRefs.CavalierChallengeAbility,
                    typeof(AbilityResourceLogic),
                    typeof(AbilityTargetHasFact),
                    typeof(AbilityTargetIsAlly))
                .AddAbilityEffectRunAction(actions: action)
                .SetType(AbilityType.Extraordinary)
                .SetRange(AbilityRange.Long)
                .SetCanTargetEnemies(true)
                .SetShouldTurnToTarget(true)
                .SetAnimation(UnitAnimationActionCastSpell.CastAnimationStyle.Omni)
                .SetActionType(UnitCommand.CommandType.Swift)
                .AddToAvailableMetamagic(Metamagic.Heighten | Metamagic.CompletelyNormal)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }

    internal class Buff
    {
        public static readonly string Guid = "{c557f87d-dd0e-4492-9ca4-9fc82efbee2d}";

        private static readonly string BuffName = $"{FeatureName}.Buff";
        internal static void Configure()
        {
            var restoreResource = ActionsBuilder.New().OnContextCaster(
                ActionsBuilder.New()
                .RestoreResource(resource: AbilityResourceRefs.CavalierChallengeResource.ToString(), value: 1)
                .RestoreResource(resource: VerdictAbility.Resource.Guid, value: 1)
                .ApplyBuffWithDurationSeconds(BuffRefs.BlessBuff.ToString(), durationSeconds: 3));

            var aligmentCondition = ConditionsBuilder.New().Alignment(AlignmentComponent.Lawful);
            var hasFactCondition = ConditionsBuilder.New().CasterHasFact(fact: ReprimandFeature.Guid);

            var onHitAction = ActionsBuilder.New().Conditional(aligmentCondition, ifTrue: restoreResource);
            var turnAction = ActionsBuilder.New().Conditional(hasFactCondition, ifTrue: restoreResource);

            var supressBuff = new SuppressBuffsFixed()
            {
                m_Buffs = [BlueprintTool.GetRef<BlueprintBuffReference>(BuffRefs.CavalierChallengeBuffTarget.ToString())]
            };

            BuffConfigurator.New(BuffName, Guid)
                .AddComponent<LinkBuffRemoval>(x =>
                {
                    x.Target = BlueprintTool.Get<BlueprintBuff>(BuffRefs.CavalierChallengeBuffTarget.ToString());
                })
                .AddRunActionOnTurnStart(turnAction)
                .AddTargetAttackWithWeaponTrigger(actionsOnAttacker: onHitAction, onlyOnFirstAttack: true, onlyHit: true, onlyMelee: true)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(BuffRefs.BlessBuff.Reference.Get().Icon)
                .Configure();
        }
    }
}