using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.Classes.Selection;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints.Classes;
using Kingmaker.RuleSystem;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Commands.Base;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.Visual.Animation.Kingmaker.Actions;
using LostChapters.Modules.Custom.Archetypes.FalseKnight.Components;

namespace LostChapters.Modules.Custom.Archetypes.FalseKnight;

internal class VersatileTacticsFeature
{
    public static readonly string Guid = "{6a5c7c8e-69b8-46b2-a4c9-e2143a3d9c7e}";

    private static readonly string BaseName = "VersatileTactics";

    private static readonly string FeatureName = $"{BaseName}Feature";
    private static readonly string DisplayName = $"{FeatureName}.Name";
    private static readonly string Description = $"{FeatureName}.Description";

    //private static readonly Sprite Icon = $"{_Module.IconPath}/ .png";

    internal static void Configure()
    {
        Ability.Configure();
        Resource.Configure();
        FeatureSelection.Configure();

        FeatureConfigurator.New(FeatureName, Guid)
            .AddFacts([Ability.Guid])
            .AddAbilityResources(resource: Resource.Guid, restoreAmount: true)
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            //.SetIcon(Icon)
            .Configure();
    }

    internal class Ability
    {
        public static readonly string Guid = "{61735c8f-5d05-420d-a593-9725f2ee4336}";

        private static readonly string AbilityName = $"{BaseName}Ability";

        internal static void Configure()
        {
            Buff.Configure();

            var duration = ContextDuration.FixedDice(diceType: DiceType.One, rate: DurationRate.Minutes);
            var action = ActionsBuilder.New().ApplyBuff(buff: Buff.Guid, durationValue: duration);

            AbilityConfigurator.New(AbilityName, Guid)
                .AddAbilityResourceLogic(amount: 1, isSpendResource: true, requiredResource: Resource.Guid)
                .AddAbilityEffectRunAction(action)
                .SetType(AbilityType.Extraordinary)
                .SetRange(AbilityRange.Personal)
                .SetCanTargetSelf(true)
                .SetShouldTurnToTarget(true)
                .SetAnimation(UnitAnimationActionCastSpell.CastAnimationStyle.Omni)
                .SetActionType(UnitCommand.CommandType.Swift)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                //.SetIcon(Icon)
                .Configure();
        }
    }

    internal class Resource
    {
        public static readonly string Guid = "{91376b60-9782-49c3-b8b3-c25fc6cab34f}";

        private static readonly string ResourceName = $"{BaseName}Resource";

        internal static void Configure()
        {
            var builder = ResourceAmountBuilder.New(baseValue: 1)
                .IncreaseByLevelStartPlusDivStep(classes: [CharacterClassRefs.CavalierClass.ToString()], levelsPerStep: 4, bonusPerStep: 1)
                .Build();

            AbilityResourceConfigurator.New(ResourceName, Guid)
                .SetMaxAmount(builder)
                .Configure();
        }
    }

    internal class Buff
    {
        public static readonly string Guid = "{11dfd49e-21ad-49f7-969a-c709cf53421e}";

        private static readonly string BuffName = $"{BaseName}Buff";

        internal static void Configure()
        {
            BuffConfigurator.New(BuffName, Guid)
                .AddComponent<VersatileTactics>()
                .AddMechanicsFeature(AddMechanicsFeature.MechanicsFeatureType.SoloTactics)
                .SetIsClassFeature(true)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                //.SetIcon(Icon)
                .Configure();
        }
    }

    internal class FeatureSelection
    {
        public static readonly string Guid = "{71731a4d-e8d6-46fa-a815-93490a6be18f}";

        private static readonly string FeatureName = $"{BaseName}TeamworkFeatureSelection";
        private static readonly string DisplayName = $"{FeatureName}.Name";
        private static readonly string Description = $"{FeatureName}.Description";

        public static void Configure()
        {
            var features = FeatureSelectionRefs.TeamworkFeat.Reference.Get().m_AllFeatures;

            var selector = FeatureSelectionConfigurator.New(FeatureName, Guid)
                .SetGroup(FeatureGroup.TeamworkFeat)
                .SetIsClassFeature(true)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                //.SetIcon(Icon)
                .Configure(true);

            selector.m_AllFeatures = features;
        }
    }
}