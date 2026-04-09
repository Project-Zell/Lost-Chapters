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
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Mechanics;

namespace LostChapters.Modules.HellknightCodex.PrestigeClasses.Hellknight.Discipline;

internal class CrushChaosFeature
{
    public static readonly string Guid = "{1c36c5e0-9ea8-4020-81ef-b86d94d65df6}";

    private static readonly string FeatureName = "CrushChaosFeature";
    private static readonly string DisplayName = $"{FeatureName}.Name";
    private static readonly string Description = $"{FeatureName}.Description";

    internal static void Configure()
    {
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
                        buff: BuffRefs.Stunned.ToString(),
                        durationValue: ContextDuration.Variable(value: 1, rate: DurationRate.Rounds)))
            .ApplyBuff(
                buff: CooldownBuff.Guid,
                durationValue: ContextDuration.Variable(value: 1, rate: DurationRate.Days));

        AbilityConfigurator.For(AbilityRefs.SmiteChaosAbility.ToString())
            .AddAbilityExecuteActionOnCast(actions: action)
            .Configure();
    }

    internal class CooldownBuff
    {
        public static readonly string Guid = "{1cd2eb47-7370-47a3-8940-90b564568687}";

        private static readonly string BuffName = $"{FeatureName}.CooldownBuff";

        internal static void Configure()
        {
            BuffConfigurator.New(BuffName, Guid)
                .SetFlags([BlueprintBuff.Flags.HiddenInUi, BlueprintBuff.Flags.RemoveOnRest])
                .Configure();
        }
    }
}
