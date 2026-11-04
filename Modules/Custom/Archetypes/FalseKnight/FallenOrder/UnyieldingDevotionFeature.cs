using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Commands.Base;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.Visual.Animation.Kingmaker.Actions;
using UnityEngine;

namespace LostChapters.Modules.Custom.Archetypes.FalseKnight.FallenOrder;

internal class UnyieldingDevotionFeature
{
    public static readonly string Guid = "{87693bd2-0891-4f44-a298-e78bb29b4231}";

    private static readonly string BaseName = "UnyieldingDevotion";

    private static readonly string FeatureName = $"{BaseName}Feature";
    private static readonly string DisplayName = $"{FeatureName}.Name";
    private static readonly string Description = $"{FeatureName}.Description";

    //private static readonly Sprite Icon = $"{_Module.IconPath}/ .png";

    internal static void Configure()
    {
        Ability.Configure();
        Resource.Configure();

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
        public static readonly string Guid = "{bd5d0d04-c67c-4cb6-9224-5c02c1d8c536}";

        private static readonly string AbilityName = $"{BaseName}Ability";

        internal static void Configure()
        {
            FalseKnightUnitGreatsword.Configure();
            FalseKnightUnitShortSword.Configure();
            FalseKnightUnitBannerBearer.Configure();

            var count = new ContextDiceValue { DiceCountValue = 0, BonusValue = 1 };
            var duration = ContextDuration.Fixed(value: 1, rate: DurationRate.Minutes);

            var spawnAction = ActionsBuilder.New()
                .SpawnMonster(monster: FalseKnightUnitGreatsword.Guid, countValue: count, durationValue: duration, offset: new Vector3(0.75f, 0, -0.75f))
                .SpawnMonster(monster: FalseKnightUnitShortSword.Guid, countValue: count, durationValue: duration, offset: new Vector3(-0.75f, 0, -0.75f))
                .SpawnMonster(monster: FalseKnightUnitBannerBearer.Guid, countValue: count, durationValue: duration);

            AbilityConfigurator.New(AbilityName, Guid)
                .AddAbilityResourceLogic(amount: 1, isSpendResource: true, requiredResource: Resource.Guid)
                .AddAbilityEffectRunAction(spawnAction)
                .SetType(AbilityType.Extraordinary)
                .SetRange(AbilityRange.Close)
                .AddSpellComponent(SpellSchool.Conjuration)
                .AddSpellDescriptorComponent(SpellDescriptor.Summoning)
                .SetActionType(UnitCommand.CommandType.Standard)
                .SetAnimation(UnitAnimationActionCastSpell.CastAnimationStyle.Point)
                .SetCanTargetSelf(true)
                .SetCanTargetPoint(true)
                .SetIsFullRoundAction(true)
                .SetAvailableMetamagic([Metamagic.Extend, Metamagic.Quicken, Metamagic.Heighten, Metamagic.Reach, Metamagic.CompletelyNormal])
                .SetLocalizedDuration("6250ccf0-1ed0-460f-8ce7-094c2da7e198")
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }

    internal class Resource
    {
        public static readonly string Guid = "{311a4d1d-2971-44d9-a46b-2e0f20225586}";

        private static readonly string ResourceName = $"{BaseName}Resource";

        internal static void Configure()
        {
            var builder = ResourceAmountBuilder.New(baseValue: 1)
                .IncreaseByLevelStartPlusDivStep(classes: [CharacterClassRefs.CavalierClass.ToString()], startingLevel: 19, bonusPerStep: 1)
                .Build();

            AbilityResourceConfigurator.New(ResourceName, Guid)
                .SetMaxAmount(builder)
                .Configure();
        }
    }
}