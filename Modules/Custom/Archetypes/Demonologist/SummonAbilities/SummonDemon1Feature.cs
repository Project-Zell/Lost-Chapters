using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.AVEx;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using BlueprintCore.Utils.Assets;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.RuleSystem;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Commands.Base;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.Visual.Animation.Kingmaker.Actions;
using Kingmaker.Visual.Particles;
using LostChapters.Modules.Custom.Archetypes.Demonologist.SummonUnits;
using UnityEngine;

namespace LostChapters.Modules.Custom.Archetypes.Demonologist.SummonAbilities;

internal class SummonDemon1Feature
{
    public static readonly string Guid = "{e2e431bf-3f2a-493e-96cd-524cc6e60d68}";

    private static readonly string FeatureName = "SummonDemon1Feature";
    private static readonly string DisplayName = $"{FeatureName}.Name";
    private static readonly string Description = $"{FeatureName}.Description";

    //private static readonly Sprite Icon = $"{_Module.IconPath}/ .png";

    internal static void Configure()
    {
        DretchSummonUnit.Configure();
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
        public static readonly string Guid = "{f5ed109f-3b24-4718-8c1e-02e4561067d1}";

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
                .Conditional(ConditionsBuilder.New().CasterHasFact(CallOfTheAbyssFeature.Buff.Guid),
                    ifTrue: ActionsBuilder.New().ApplyBuff(DemonSummonRageBuff.Guid, duration).ApplyBuff(BuffRefs.StandartRageBuff.ToString(), duration)
                .RemoveBuff(toCaster: true, onlyFromCaster: true, buff: CallOfTheAbyssFeature.Buff.Guid));

            var spawnAction = ActionsBuilder.New()
                .SpawnMonsterUsingSummonPool(
                    monster: DretchSummonUnit.Guid,
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
