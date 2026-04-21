using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.BasicEx;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Conditions.Builder;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using BlueprintCore.Conditions.Builder.ContextEx;
using BlueprintCore.Utils.Types;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.Enums.Damage;
using Kingmaker.RuleSystem;
using Kingmaker.RuleSystem.Rules.Damage;
using Kingmaker.UnitLogic.Mechanics;

namespace LostChapters.Modules.HellknightsCodex.PrestigeClasses.Hellknight.Discipline;

internal class WrackingGraspFeature
{
    public static readonly string Guid = "{162467e3-f72c-47d1-85b3-b9ddc5e26f80}";

    private static readonly string FeatureName = "WrackingGraspFeature";
    private static readonly string DisplayName = $"{FeatureName}.Name";
    private static readonly string Description = $"{FeatureName}.Description";

    //private static readonly Sprite Icon = $"{_Module.IconPath}/ .png";

    internal static void Configure()
    {
        Ability.Configure();

        FeatureConfigurator.New(FeatureName, Guid)
            .AddFacts([Ability.Guid])
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            //.AddFeatureTagsComponent()
            //.SetIcon(Icon)
            .Configure();
    }

    internal class Ability
    {
        public static readonly string Guid = "{c0fd5cc1-5a6f-4329-b7df-997a63f8bfdd}";

        private static readonly string AbilityName = $"{FeatureName}.Ability";
        private static readonly string DisplayName = $"{AbilityName}.Name";
        private static readonly string Description = $"{AbilityName}.Description";

        //private static readonly Sprite Icon = $"{_Module.IconPath}/ .png";

        internal static void Configure()
        {
            var baseValue = new ContextDiceValue()
            {
                DiceType = DiceType.D6,
                DiceCountValue = 1,
            };

            var value = new ContextDiceValue()
            {
                DiceType = DiceType.D10,
                DiceCountValue = ContextValues.Rank(AbilityRankType.Default),
                BonusValue = ContextValues.Rank(AbilityRankType.StatBonus)
            };

            var diceCountConfig = ContextRankConfigs.ClassLevel(
                classes: [CharacterClassRefs.HellknightClass.ToString(), CharacterClassRefs.HellknightSigniferClass.ToString()], min: 0, max: 10,
                type: AbilityRankType.Default);

            var bonusConfig = ContextRankConfigs.StatBonus(
                stat: StatType.Charisma, 
                modDescriptor: ModifierDescriptor.UntypedStackable, 
                type: AbilityRankType.StatBonus);

            var damageType = new DamageTypeDescription()
            {
                Type = DamageType.Energy,
                Energy = DamageEnergyType.Fire,
            };

            var action = ActionsBuilder.New().Conditional(ConditionsBuilder.New().Alignment(alignment: AlignmentComponent.Chaotic),
                ifTrue: ActionsBuilder.New().DealDamage(value: value, damageType: damageType, disableSneakDamage: true, ignoreCritical: true),
                ifFalse:ActionsBuilder.New().DealDamage(
                    value: baseValue, 
                    damageType: damageType, 
                    disableSneakDamage: true, 
                    ignoreCritical: true, 
                    ignoreUnitModifiers: true));
            
            AbilityConfigurator.New(AbilityName, Guid)
                .AddAbilityEffectRunAction(action)
                .AddContextRankConfig(bonusConfig)
                .AddContextRankConfig(diceCountConfig)
                .SetRange(AbilityRange.Touch)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                //.AddFeatureTagsComponent()
                //.SetIcon(Icon)
                .Configure();
        }
    }
}
