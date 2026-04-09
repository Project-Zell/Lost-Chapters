using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using BlueprintCore.Utils.Types;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Commands.Base;
using Kingmaker.Visual.Animation.Kingmaker.Actions;
using UnityEngine;

namespace LostChapters.Modules.Custom.Archetypes.CircuitJudge;

internal class ConvictionFeature
{
    public static readonly string Guid = "{07242349-0c63-4bb6-8e24-d26a9673f04e}";

    private static readonly string FeatureName = "SentenceFeature";
    private static readonly string DisplayName = $"{FeatureName}.Name";
    private static readonly string Description = $"{FeatureName}.Description";

    private static readonly Sprite Icon = FeatureRefs.FiendishQuarryFeature.Reference.Get().Icon;

    internal static void Configure()
    {
        Ability.Configure();

        FeatureConfigurator.New(FeatureName, Guid)
            .AddFacts([Ability.Guid])
            .AddAbilityResources(resource: AbilityResourceRefs.CavalierChallengeResource.ToString(), restoreAmount: true)
            .SetHideInCharacterSheetAndLevelUp(true)
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .SetIcon(Icon)
            .Configure();
    }

    internal class Ability
    {
        public static readonly string Guid = "{1ce649e1-2e00-437b-b8ff-d0c676ca0deb}";

        private static readonly string AbilityName = $"{FeatureName}.Ability";

        internal static void Configure()
        {
            Buff.Configure();

            var damageConfig = ContextRankConfigs.ClassLevel(classes: [CharacterClassRefs.CavalierClass.ToString()], max: 10, min: 1)
                .WithDiv2Progression();

            var action = ActionsBuilder.New().Conditional(
                    ConditionsBuilder.New().Alignment(alignment: Kingmaker.Enums.AlignmentComponent.Lawful, negate: true),
                        ifTrue: ActionsBuilder.New().ApplyBuffPermanent(null));

            AbilityConfigurator.New(AbilityName, Guid)
                .AddAbilityEffectRunAction(action)
                .AddAbilityResourceLogic(amount: 1, requiredResource: AbilityResourceRefs.CavalierChallengeResource.ToString())
                .AddAbilityTargetHasFact(checkedFacts: [BuffRefs.CavalierKnightsChallengeBuffTarget.ToString()], inverted: true, fromCaster: true)
                .AddContextCalculateSharedValue(valueType: AbilitySharedValue.Damage)
                .AddAbilityTargetIsAlly(not: true)
                .AddContextRankConfig(damageConfig)
                .SetType(AbilityType.Extraordinary)
                .SetRange(AbilityRange.Long)
                .SetCanTargetEnemies(true)
                .SetShouldTurnToTarget(true)
                .SetAnimation(UnitAnimationActionCastSpell.CastAnimationStyle.Omni)
                .SetActionType(UnitCommand.CommandType.Swift)
                .AddToAvailableMetamagic(Metamagic.Heighten | Metamagic.CompletelyNormal)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(Icon)
                .Configure();
        }
    }

    internal class Buff
    {
        public static readonly string Guid = "{8a3c4dcf-b5f0-4e43-9386-dcf85cfc740a}";

        private static readonly string BuffName = $"{FeatureName}.Buff";
        private static readonly string DisplayName = $"{BuffName}.Name";
        private static readonly string Description = $"{BuffName}.Description";

        //private static readonly Sprite Icon = $"{_Module.IconPath}/ .png";

        internal static void Configure()
        {
            SelfBuff.Configure();

            var onActivatedAction = ActionsBuilder.New().ApplyBuffPermanent(buff: SelfBuff.Guid, toCaster: true, asChild: true, sameDuration: true);
            var onDeactivatedAction = ActionsBuilder.New().RemoveBuff(buff: SelfBuff.Guid, toCaster: true);

            BuffConfigurator.New(BuffName, Guid)
                .AddFactContextActions(activated: onActivatedAction, deactivated: onDeactivatedAction)
                .AddUniqueBuff()
                .SetIsClassFeature(true)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                //.AddFeatureTagsComponent()
                .SetIcon(Icon)
                .Configure();
        }
    }

    internal class SelfBuff
    {
        public static readonly string Guid = "{e53708aa-c2e6-4cc6-b9e4-26906f107bcb}";

        private static readonly string BuffName = $"{FeatureName}.SelfBuff";

        internal static void Configure()
        {
            var bonus = ContextValues.Shared(AbilitySharedValue.Damage);

            BuffConfigurator.New(BuffName, Guid)
                .AddDamageBonusAgainstFactOwner(checkedFact: Buff.Guid, bonus: bonus)
                .SetIsClassFeature(true)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                //.AddFeatureTagsComponent()
                //.SetIcon(Icon)
                .Configure();
        }
    }
}
