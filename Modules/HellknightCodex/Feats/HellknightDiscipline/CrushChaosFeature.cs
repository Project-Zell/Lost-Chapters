using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using BlueprintCore.Utils.Types;
using Kingmaker.Enums;
using Kingmaker.RuleSystem;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using LostChapters.Modules.GraySisterhood.Feats.Selection;

namespace LostChapters.Modules.GraySisterhood.Feats.HellknightDiscipline
{
    internal class CrushChaosFeature
    {
        public static readonly string Guid = "77bbca1e-c34a-4a5d-984f-aa39b680dbfe";

        private const string FeatName = "CrushChaos";
        private const string DisplayName = "CrushChaos.BuffName";
        private const string Description = "CrushChaos.LocalizedDescription";

        public static void Configure()
        {
            FeatureConfigurator.New(FeatName, Guid)
                .AddToFeatureSelection(HellknightDisciplineSelection.Guid)
                .AddPrerequisiteFeature(FeatureRefs.SmiteChaosFeature.ToString())
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();

            var stunAction = ActionsBuilder.New()
                .Conditional(
                    ConditionsBuilder.New().CasterHasFact(Guid).HasBuff(buff: CrushChaosCooldownBuff.GetReference(), negate: true).Alignment(AlignmentComponent.Chaotic),
                        ifTrue: ActionsBuilder.New().ApplyBuff(
                            buff: BuffRefs.Stunned.ToString(),
                            durationValue: ContextDuration.VariableDice(diceCount: 1, diceType: DiceType.D2)))
                .ApplyBuffPermanent(buff: CrushChaosCooldownBuff.GetReference())
                .Build();

            AbilityConfigurator.For(AbilityRefs.SmiteChaosAbility.ToString())
                .AddAbilityExecuteActionOnCast(actions: stunAction)
                .Configure();
        }

        internal class CrushChaosCooldownBuff
        {
            public static readonly string Guid = "9ce85cc7-1a99-45b2-b986-ae2da0737d1a";

            private const string BuffName = "CrushChaos.CooldownBuff";
#nullable enable
            private static BlueprintBuff? Reference;
#nullable disable

            public static BlueprintBuff GetReference() => Reference ??= CreateBuff();
            private static BlueprintBuff CreateBuff()
            {
                return BuffConfigurator.New(BuffName, Guid)
                    .SetFlags([BlueprintBuff.Flags.HiddenInUi, BlueprintBuff.Flags.RemoveOnRest])
                    .Configure();
            }
        }
    }
}
