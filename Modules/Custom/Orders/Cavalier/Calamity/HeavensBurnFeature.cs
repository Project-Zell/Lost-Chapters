using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using BlueprintCore.Utils.Types;
using Kingmaker.UnitLogic.Buffs.Blueprints;

namespace LostChapters.Modules.Custom.Orders.Cavalier.Calamity
{
    internal class HeavensBurnFeature
    {
        public static readonly string Guid = "{cc3d3411-cb11-4452-8266-c6dacff44903}";

        private static readonly string FeatureName = "HeavensBurn";
        private static readonly string DisplayName = "HeavensBurn.Name";
        private static readonly string Description = "HeavensBurn.Description";

        internal static void Configure()
        {
            CooldownBuff.Configure();

            var value = ContextValues.Rank();
            var rankConfig = ContextRankConfigs.ClassLevel(classes: [CharacterClassRefs.CavalierClass.ToString()], min: 1, max: 20);
            var action = ActionsBuilder.New().Conditional(ConditionsBuilder.New().CasterHasFact(CooldownBuff.Guid, negate: true),
                ifTrue: ActionsBuilder.New()
                    .ApplyBuffPermanent(buff: CooldownBuff.Guid, toCaster: true, isNotDispelable: true).OnContextCaster(
                        ActionsBuilder.New().CastSpell(spell: AbilityRefs.ShieldOfDawn.ToString(), overrideSpellLevel: 20)));

            FeatureConfigurator.New(FeatureName, Guid)
                .AddContextRankConfig(rankConfig)
                .AddInitiatorAttackWithWeaponTrigger(
                    reduceHPToZero: true,
                    action: action)
                .SetIsClassFeature(true)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }

        internal class CooldownBuff
        {
            public static readonly string Guid = "{5bb9f0a8-a5d4-4871-a4e6-be4810478a39}";

            private static readonly string BuffName = "HeavensBurn.CooldownBuff";

            internal static void Configure()
            {
                BuffConfigurator.New(BuffName, Guid)
                    .SetFlags(BlueprintBuff.Flags.StayOnDeath | BlueprintBuff.Flags.HiddenInUi)
                    .AddCombatStateTrigger(combatEndActions: ActionsBuilder.New().RemoveSelf())
                    .SetDisplayName(DisplayName)
                    .SetDescription(Description)
                    .Configure();
            }
        }
    }
}
