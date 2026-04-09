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
using Kingmaker.UnitLogic.Mechanics;

namespace LostChapters.Modules.HellknightCodex.PrestigeClasses.Hellknight.Discipline;

internal class CensorChaosFeature
{
    public static readonly string Guid = "{970dfa32-11c1-4d40-89a3-613f061f76ba}";

    private static readonly string FeatureName = "CensorChaosFeature";
    private static readonly string DisplayName = $"{FeatureName}.Name";
    private static readonly string Description = $"{FeatureName}.Description";

    internal static void Configure()
    {
        CensorPatch.Configure();
        CooldownBuff.Configure();

        FeatureConfigurator.New(FeatureName, Guid)
            .AddToFeatureSelection(HellknightDisciplineSelection.Guid)
            .AddPrerequisiteFeature(FeatureRefs.SmiteChaosFeature.ToString())
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .Configure();

        var action = ActionsBuilder.New()
            .Conditional(
                ConditionsBuilder.New().CasterHasFact(Guid).HasBuff(buff: CooldownBuff.Guid, negate: true).Alignment(AlignmentComponent.Chaotic),
                    ifTrue: ActionsBuilder.New().ApplyBuff(
                        buff: BuffRefs.HellknightDisciplineCensorBuff.ToString(),
                        durationValue: ContextDuration.VariableDice(diceCount: 1, diceType: DiceType.D4)))
            .ApplyBuff(
                buff: CooldownBuff.Guid,
                durationValue: ContextDuration.Variable(value: 1, rate: DurationRate.Days));

        AbilityConfigurator.For(AbilityRefs.SmiteChaosAbility.ToString())
            .AddAbilityExecuteActionOnCast(actions: action)
            .Configure();
    }

    internal class CensorPatch
    {
        private static readonly string Description = "Censor.Description";

        internal static void Configure()
        {
            BuffConfigurator.For(BuffRefs.HellknightDisciplineCensorBuff.ToString())
                .SetIcon(AbilityRefs.ResonatingWord.Reference.Get().Icon)
                .SetDescription(Description)
                .Configure();
        }
    }

    internal class CooldownBuff
    {
        public static readonly string Guid = "{b6ae4ea4-d66a-4a2a-9bb1-e3447d3ca18c}";

        private static readonly string BuffName = $"{FeatureName}.CooldownBuff";

        internal static void Configure()
        {
            BuffConfigurator.New(BuffName, Guid)
                .SetFlags([BlueprintBuff.Flags.HiddenInUi, BlueprintBuff.Flags.RemoveOnRest])
                .Configure();
        }
    }
}
