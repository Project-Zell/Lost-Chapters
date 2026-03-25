using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using BlueprintCore.Utils.Types;
using Kingmaker.RuleSystem;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Mechanics;

namespace LostChapters.Modules.Custom.Orders.Cavalier.BlueRose;

internal class LacerationFeature
{
    public static readonly string Guid = "{1925b664-f6ac-45b6-90b8-f184f5def603}";

    private static readonly string FeatureName = "Laceration";
    private static readonly string DisplayName = "Laceration.Name";
    private static readonly string Description = "Laceration.Description";

    public static void Configure()
    {
        CooldownBuff.Configure();

        var duration = ContextDuration.FixedDice(DiceType.Zero, bonus: 10);

        var condition = ConditionsBuilder.New()
            .HasBuffFromCaster(CooldownBuff.Guid, negate: true)
            .HasBuffFromCaster(BuffRefs.CavalierChallengeBuffTarget.ToString());

        var bleedAction = ActionsBuilder.New().Conditional(condition,
            ifTrue: ActionsBuilder.New().ApplyBuff(BuffRefs.Bleed2d6Buff.ToString(), duration));

        var sickenedAction = ActionsBuilder.New().Conditional(condition,
            ifTrue: ActionsBuilder.New().ApplyBuff(BuffRefs.Sickened.ToString(), duration));

        var cooldownAction = ActionsBuilder.New().Conditional(condition,
            ifTrue: ActionsBuilder.New().ApplyBuff(
                buff: CooldownBuff.Guid,
                isNotDispelable: true,
                durationValue: ContextDuration.FixedDice(DiceType.Zero, bonus: 24, rate: DurationRate.Hours)));

        FeatureConfigurator.New(FeatureName, Guid)
            .AddInitiatorAttackWithWeaponTrigger(onlyHit: true, action: bleedAction)
            .AddInitiatorAttackWithWeaponTrigger(onlyHit: true, action: sickenedAction)
            .AddInitiatorAttackWithWeaponTrigger(onlyHit: true, action: cooldownAction)
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .Configure();
    }

    internal class CooldownBuff
    {
        public static readonly string Guid = "{162feea5-6ee9-40b4-9e1f-33bf33612f5a}";

        private static readonly string BuffName = "Laceration.CooldownBuff";

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
