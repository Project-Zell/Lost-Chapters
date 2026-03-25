using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using BlueprintCore.Utils.Types;
using Kingmaker.Enums;
using Kingmaker.RuleSystem;
using Kingmaker.RuleSystem.Rules.Damage;
using Kingmaker.UnitLogic.Mechanics;

namespace LostChapters.Modules.GraySisterhood.PrestigeClasses.SanguineAngel
{
    internal class MercilessMassacreFeature
    {
        public static readonly string Guid = "{d65c18c6-85e4-4d68-8180-21f2e486f6b8}";

        private static readonly string FeatureName = "MercilessMassacre";
        private static readonly string DisplayName = "MercilessMassacre.Name";
        private static readonly string Description = "MercilessMassacre.Description";

        internal static void Configure()
        {
            var contextValue = ContextValues.Rank();
            var rankConfig = ContextRankConfigs.ClassLevel([SanguineAngelClass.Guid], min: 1, max: 10);

            var contextDiceValue = new ContextDiceValue()
            {
                DiceType = DiceType.D8,
                DiceCountValue = 1,
                BonusValue = contextValue,
            };

            var damageType = new DamageTypeDescription()
            {
                Type = DamageType.Direct,
            };

            var dealDamage = ActionsBuilder.New().DealDamage(
                damageType: damageType,
                value: contextDiceValue,
                ignoreCritical: true);

            var action = ActionsBuilder.New().Conditional(
                ConditionsBuilder.New().HasFact(BuffRefs.Shaken.ToString()).HasFact(BuffRefs.Frightened.ToString()).UseOr(),
                ifTrue: dealDamage);

            FeatureConfigurator.New(FeatureName, Guid)
                .AddInitiatorAttackWithWeaponTrigger(
                    action: action,
                    onlyHit: true,
                    onlyOnFirstHit: true,
                    checkWeaponRangeType: true,
                    rangeType: WeaponRangeType.Melee)
                .AddContextRankConfig(rankConfig)
                .SetIsClassFeature(true)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }
}
