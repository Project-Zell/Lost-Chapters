using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Utils.Types;
using Kingmaker.RuleSystem;
using Kingmaker.UnitLogic.FactLogic;

namespace LostChapters.Modules.Custom.Orders.Cavalier.BlueRose;

internal class InnerPeaceFeature
{
    public static readonly string Guid = "{96a5a2a6-48c2-486a-9c4b-151ea1b7f98e}";

    private static readonly string FeatureName = "InnerPeace";
    private static readonly string DisplayName = "InnerPeace.Name";
    private static readonly string Description = "InnerPeace.Description";

    internal static void Configure()
    {
        Buff.Configure();

        FeatureConfigurator.New(FeatureName, Guid)
            .AddCombatStateTrigger(
                combatStartActions: ActionsBuilder.New().ApplyBuffPermanent(Buff.Guid),
                combatEndActions: ActionsBuilder.New().RemoveBuff(Buff.Guid))
            .AddNewRoundTrigger(newRoundActions: ActionsBuilder.New().ApplyBuffPermanent(Buff.Guid))
            .AddTargetAttackWithWeaponTrigger(
                waitForAttackResolve: true,
                actionOnSelf: ActionsBuilder.New().RemoveBuff(Buff.Guid))
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .Configure();
    }

    internal class Buff
    {
        public static readonly string Guid = "{698e5059-b5b2-430e-98a2-b9bc48519faa}";

        private static readonly string BuffName = "InnerPeace.ArmorClassBuff";

        internal static void Configure()
        {
            BuffConfigurator.New(BuffName, Guid)
                .AddIncomingDamageAndHealingModifier(
                    modifierPercents: -50,
                    aoeEntry: IncomingDamageAndHealingModifier.EntryType.OnlyFalse,
                    type: IncomingDamageAndHealingModifier.ModifyingType.OnlyDamage)
                .SetDisplayName(DisplayName)
                .Configure();
        }
    }
}
