using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using BlueprintCore.Utils;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.PubSubSystem;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.UnitLogic.Mechanics.Properties;
using LostChapters.Components;
using System.Collections.Generic;
namespace LostChapters.Modules.Custom.Archetypes.Demonologist;

internal class HellsWhisperFeature
{
    public static readonly string Guid = "{b0a65f1d-4765-4068-a3f2-3424194b8802}";

    private static readonly string BaseName = "HellsWhisper";

    private static readonly string FeatureName = $"{BaseName}Feature";
    private static readonly string DisplayName = $"{FeatureName}.Name";
    private static readonly string Description = $"{FeatureName}.Description";

    internal static readonly string Icon = $"{CustomModule.IconPath}/{DemonologistArchetype.BaseName}/{BaseName}.png".ToLower();

    internal static void Configure()
    {
        Buff.Configure();

        var mythicDemonPathSummonPool = BlueprintTool.Get<BlueprintSummonPool>("b833c7342783c3a4eaf116b830eb0129");
        var demonologistSummonPool = BlueprintTool.Get<BlueprintSummonPool>(DemonologistSummonPool.Guid);

        var savingThrow = new SavingThrowBonusFromSummonPool()
        {
            SummonPools = [mythicDemonPathSummonPool, demonologistSummonPool],
            SavingThrowType = SavingThrowType.Will,
            BonusMod = -1
        };

        FeatureConfigurator.New(FeatureName, Guid)
            .AddComponent(savingThrow)
            .AddOnSpawnBuff(
                buff: Buff.Guid,
                isInfinity: true,
                ifHaveFact: Guid,
                checkSummonedUnitFact: true,
                ifSummonHaveFact: FeatureRefs.SubtypeDemon.ToString(),
                checkDescriptor: true,
                spellDescriptor: SpellDescriptor.Summoning)
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .SetIcon(Icon)
            .Configure();
    }

    internal class Buff
    {
        public static readonly string Guid = "{0e688168-73d0-4ffa-884e-9b177d561c3d}";

        private static readonly string BuffName = $"{BaseName}Buff";

        internal static void Configure()
        {
            var baseDC = ContextValues.Constant(10);
            var hitDiceDC = ContextValues.Property(UnitProperty.Level, toCaster: true);
            
            var duration = ContextDuration.Fixed(value: 1);

            List<(ConditionsBuilder conditions, ContextValue modifier)> bonus =
            [
                (ConditionsBuilder.New(), hitDiceDC),
            ];

            var condition = ConditionsBuilder.New().Alignment(AlignmentComponent.Good);

            var action = ActionsBuilder.New().OnContextCaster(targetAsCaster: true, actions: ActionsBuilder.New()
                    .SavingThrow(type: SavingThrowType.Will, customDC: baseDC, conditionalDCModifiers: bonus,
                        onResult: ActionsBuilder.New().ConditionalSaved(
                            failed: ActionsBuilder.New().Conditional(condition,
                                ifTrue: ActionsBuilder.New().ApplyBuff(buff: BuffRefs.Confusion.ToString(), durationValue: duration),
                                ifFalse: ActionsBuilder.New().ApplyBuff(buff: BuffRefs.Staggered.ToString(), durationValue: duration)))));

            BuffConfigurator.New(BuffName, Guid)
                .AddDeathActions(deathTrigger: DeathActions.DeathTrigger.OnUnitDeath, actions: action)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(Icon)
                .Configure();
        }
    }
}