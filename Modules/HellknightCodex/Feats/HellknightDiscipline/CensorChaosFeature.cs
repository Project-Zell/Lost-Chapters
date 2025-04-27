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
    internal class CensorChaosFeature
    {
        public static readonly string Guid = "99e22d89-e766-4613-9b72-e459b55fcd1b";

        private static readonly string FeatureName = "CensorChaos";
        private static readonly string DisplayName = "CensorChaos.Name";
        private static readonly string Description = "CensorChaos.Description";

        public static void Configure()
        {
            FeatureConfigurator.New(FeatureName, Guid)
                .AddToFeatureSelection(HellknightDisciplineSelection.Guid)
                .AddPrerequisiteFeature(FeatureRefs.SmiteChaosFeature.ToString())
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();

            CensorBuff.Patch();

            var censorAction = ActionsBuilder.New()
                .Conditional(
                    ConditionsBuilder.New().CasterHasFact(Guid).HasBuff(buff: CensorChaosCooldownBuff.GetReference(), negate: true).Alignment(AlignmentComponent.Chaotic),
                        ifTrue: ActionsBuilder.New().ApplyBuff(
                            buff: BuffRefs.HellknightDisciplineCensorBuff.ToString(),
                            durationValue: ContextDuration.VariableDice(diceCount: 1, diceType: DiceType.D4)))
                .ApplyBuffPermanent(buff: CensorChaosCooldownBuff.GetReference())
                .Build();

            AbilityConfigurator.For(AbilityRefs.SmiteChaosAbility.ToString())
                .AddAbilityExecuteActionOnCast(actions: censorAction)
                .Configure();
        }

        internal class CensorBuff
        {
            private const string Description = "Censor.LocalizedDescription";

            public static void Patch()
            {
                BuffConfigurator.For(BuffRefs.HellknightDisciplineCensorBuff.ToString())
                    .SetIcon(AbilityRefs.ResonatingWord.Reference.Get().Icon)
                    .SetDescription(Description)
                    .Configure(true);
            }
        }

        internal class CensorChaosCooldownBuff
        {
            public static readonly string Guid = "dc1fce0a-de75-4e30-b04c-b024530d5fca";

            private const string BuffName = "CensorChaos.CooldownBuff";
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
