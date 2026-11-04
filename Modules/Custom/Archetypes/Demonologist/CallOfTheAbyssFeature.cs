using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Commands.Base;
using Kingmaker.Visual.Animation.Kingmaker.Actions;
using LostChapters.Tools;

namespace LostChapters.Modules.Custom.Archetypes.Demonologist;

internal class CallOfTheAbyssFeature
{
    public static readonly string Guid = "{bfabd869-e103-479c-8944-16055c16c0ae}";

    private static readonly string BaseName = "CallOfTheAbyss";

    private static readonly string FeatureName = $"{BaseName}Feature";
    private static readonly string DisplayName = $"{FeatureName}.Name";
    private static readonly string Description = $"{FeatureName}.Description";

    //private static readonly Sprite Icon = $"{_Module.IconPath}/ .png";

    internal static void Configure()
    {
        Ability.Configure();
        DemonSummonRageBuff.Configure();

        FeatureConfigurator.New(FeatureName, Guid)
            .AddFacts([Ability.Guid])
            .SetHideInCharacterSheetAndLevelUp(true)
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            //.SetIcon(Icon)
            .Configure();
    }

    internal class Ability
    {
        public static readonly string Guid = "{bd1ee7dc-8998-448b-8057-20d101a08333}";

        private static readonly string AbilityName = $"{BaseName}Ability";

        internal static void Configure()
        {
            Buff.Configure();

            var action = ActionsBuilder.New().ApplyBuffPermanent(Buff.Guid);
            var resource = AbilityResourceRefs.ArcanistArcaneReservoirResource.ToString();

            var ability = AbilityConfigurator.New(AbilityName, Guid)
                .AddAbilityCasterHasNoFacts([Buff.Guid])
                .AddAbilityResourceLogic(requiredResource: resource, isSpendResource: true, amount: 1)
                .AddAbilityEffectRunAction(action)
                .SetType(AbilityType.Supernatural)
                .SetCanTargetSelf(true)
                .SetRange(AbilityRange.Personal)
                .SetAnimation(UnitAnimationActionCastSpell.CastAnimationStyle.Omni)
                .SetActionType(UnitCommand.CommandType.Free)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();

            TooltipConfigurator.CreateAbilityTooltip(key: $"LC_{BaseName}", ability: ability);
        }
    }

    internal class Buff
    {
        public static readonly string Guid = "{642e95ad-e185-490a-a4df-91c6a9f8eedc}";

        private static readonly string BuffName = $"{BaseName}Buff";

        internal static void Configure()
        {
            BuffConfigurator.New(BuffName, Guid)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }
}
