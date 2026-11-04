using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.Configurators.UnitLogic.Properties;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using BlueprintCore.Utils.Types;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.RuleSystem;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Properties;

namespace LostChapters.Modules.Custom.Archetypes.FalseKnight.FallenOrder;

internal class RevenantFeature
{
    public static readonly string Guid = "{3bb6991c-9f2c-436d-a39d-5fd20ae44083}";

    private static readonly string BaseName = "Revenant";

    private static readonly string FeatureName = $"{BaseName}Feature";
    private static readonly string DisplayName = $"{FeatureName}.Name";
    private static readonly string Description = $"{FeatureName}.Description";

    internal static void Configure()
    {
        SelfBuff.Configure();
        CooldownBuff.Configure();

        FeatureConfigurator.New(FeatureName, Guid)
            .AddFacts([SelfBuff.Guid])
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .Configure();
    }

    internal class SelfBuff
    {
        public static readonly string Guid = "{53887ac6-1aaf-4e79-a074-1df8b6d6da88}";

        private static readonly string BuffName = $"{BaseName}SelfBuff";

        internal static void Configure()
        {
            UnitProperty.Configure();

            var dc = ContextValues.CustomProperty(UnitProperty.Guid, true);
            dc.ValueType = ContextValueType.CasterCustomProperty;

            var buffDuration = ContextDuration.FixedDice(diceType: DiceType.One, rate: DurationRate.Minutes);
            var cooldownDuration = ContextDuration.FixedDice(diceType: DiceType.One, rate: DurationRate.Days);

            var condition = ConditionsBuilder.New()
                .HasBuffFromCaster(buff: BuffRefs.CavalierChallengeBuffTarget.ToString())
                .HasBuffFromCaster(buff: CooldownBuff.Guid, negate: true);

            var onFail = ActionsBuilder.New().ApplyBuff(buff: BuffRefs.CrushingDespairBuff.ToString(), buffDuration);
;
            var action = ActionsBuilder.New()
                .Conditional(condition, ifTrue: ActionsBuilder.New().SavingThrow(SavingThrowType.Will, customDC: dc, onResult:
                    ActionsBuilder.New().ConditionalSaved(failed: onFail))
                .ApplyBuff(buff: CooldownBuff.Guid, durationValue: cooldownDuration, asChild: true, isNotDispelable: true));

            BuffConfigurator.New(BuffName, Guid)
                .AddInitiatorAttackWithWeaponTrigger(action: action, onlyHit: true)
                .SetFlags(BlueprintBuff.Flags.HiddenInUi)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }

    internal class UnitProperty
    {
        public static readonly string Guid = "{2b439634-7801-4bfa-9dda-a04fa8425cf9}";

        private static readonly string PropertyName = $"{BaseName}UnitProperty";

        internal static void Configure()
        {
            var settings = new PropertySettings()
            {
                m_Progression = PropertySettings.Progression.Div2
            };

            UnitPropertyConfigurator.New(PropertyName, Guid)
                .AddStatValueGetter(stat: StatType.Charisma, valueType: StatValueGetter.ReturnType.Bonus)
                .AddClassLevelGetter(clazz: CharacterClassRefs.CavalierClass.ToString(), settings: settings)
                .SetBaseValue(10)
                .Configure();
        }
    }

    internal class CooldownBuff
    {
        public static readonly string Guid = "{f4dc5ac2-719f-44b7-b450-ec4f85acf6a2}";

        private static readonly string BuffName = $"{BaseName}CooldownBuff";

        internal static void Configure()
        {
            BuffConfigurator.New(BuffName, Guid)
                .SetFlags(BlueprintBuff.Flags.HiddenInUi)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }
}