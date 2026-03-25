using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils.Types;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.UnitLogic.Abilities.Components.TargetCheckers;
using Kingmaker.UnitLogic.Commands.Base;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.Visual.Animation.Kingmaker.Actions;

namespace LostChapters.Modules.GraySisterhood.Archetypes.SisterInArms;

internal class HalfheartedChallengeFeature
{
    public static readonly string Guid = "{1187991c-a0c3-49ff-b939-5486bb7402aa}";

    private static readonly string FeatureName = "HalfheartedChallenge";
    private static readonly string DisplayName = "HalfheartedChallenge.Name";
    private static readonly string Description = "HalfheartedChallenge.Description";

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
            .Configure();
    }

    internal class Ability
    {
        public static readonly string Guid = "{5ab12ea3-8674-4b88-94b0-798d8570813e}";

        private static readonly string AbilityName = "HalfheartedChallenge.Ability";

        internal static void Configure()
        {
            var damageConfig = ContextRankConfigs.ClassLevel(classes: [CharacterClassRefs.CavalierClass.ToString()], max: 10, min: 1)
                .WithDiv2Progression();

            AbilityConfigurator.New(AbilityName, Guid)
                .CopyFrom(blueprint: AbilityRefs.CavalierChallengeAbility,
                    typeof(AbilityEffectRunAction),
                    typeof(AbilityResourceLogic),
                    typeof(ContextCalculateSharedValue),
                    typeof(AbilityTargetHasFact),
                    typeof(AbilityTargetIsAlly))
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
                .Configure();
        }
    }
}


