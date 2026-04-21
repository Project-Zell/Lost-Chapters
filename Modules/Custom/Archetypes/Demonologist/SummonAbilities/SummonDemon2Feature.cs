using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.RuleSystem;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Commands.Base;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.Visual.Animation.Kingmaker.Actions;
using LostChapters.Modules.Custom.Archetypes.Demonologist.SummonUnits;

namespace LostChapters.Modules.Custom.Archetypes.Demonologist.SummonAbilities;

internal class SummonDemon2Feature
{
    public static readonly string Guid = "{075bf4c0-4e2e-40f6-a142-706afd61c3de}";

    private static readonly string FeatureName = "SummonDemon2Feature";
    private static readonly string DisplayName = $"{FeatureName}.Name";
    private static readonly string Description = $"{FeatureName}.Description";

    //private static readonly Sprite Icon = $"{_Module.IconPath}/ .png";

    internal static void Configure()
    {
        QuasitSummonUnit.Configure();
        MajorAbility.Configure();

        FeatureConfigurator.New(FeatureName, Guid)
            .AddFacts([MajorAbility.Guid])
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            //.SetIcon(Icon)
            .Configure();
    }

    internal class MajorAbility
    {
        public static readonly string Guid = "{d2a944d8-1ddb-4779-bf9f-8a365d87b7f7}";

        private static readonly string AbilityName = $"{FeatureName}.MajorAbility";
        private static readonly string DisplayName = $"{AbilityName}.Name";
        private static readonly string Description = $"{AbilityName}.Description";

        //private static readonly Sprite Icon = $"{_Module.IconPath}/ .png";

        internal static void Configure()
        {
            var duration = ContextDuration.FixedDice(DiceType.Zero, bonus: 2);
            var rageDuration = ContextDuration.FixedDice(DiceType.Zero, bonus: 1);

            var count = new ContextDiceValue()
            {
                DiceCountValue = 0,
                BonusValue = 1
            };

            var action = ActionsBuilder.New().ApplyBuff(SummonDemonVisual.Guid, duration)
                .ApplyBuff(BuffRefs.StandartRageBuff.ToString(), duration);

            var spawnAction = ActionsBuilder.New()
                .SpawnMonsterUsingSummonPool(
                    monster: QuasitSummonUnit.Guid,
                    summonPool: "d94c93e7240f10e41ae41db4c83d1cbe",
                    afterSpawn: action,
                    countValue: count,
                    durationValue: duration);

            var config = ContextRankConfigs.CasterLevel(min: 0, max: 20);

            AbilityConfigurator.New(AbilityName, Guid)
                .AddAbilityEffectRunAction(spawnAction)
                .AddContextRankConfig(config)
                .AddSpellComponent(SpellSchool.Conjuration)
                .AddSpellDescriptorComponent(SpellDescriptor.Summoning)
                .SetType(AbilityType.Spell)
                .SetRange(AbilityRange.Close)
                .SetActionType(UnitCommand.CommandType.Standard)
                .SetCanTargetPoint(true)
                .SetCanTargetSelf(true)
                .SetAnimation(UnitAnimationActionCastSpell.CastAnimationStyle.Point)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }
}
