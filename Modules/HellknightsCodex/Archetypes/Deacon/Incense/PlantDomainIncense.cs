using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using BlueprintCore.Utils.Types;
using Kingmaker.Enums.Damage;
using Kingmaker.RuleSystem;
using Kingmaker.RuleSystem.Rules.Damage;
using Kingmaker.UnitLogic.Mechanics;
using LostChapters.Modules.HellknightsCodex.Archetypes.Deacon;

namespace LostChapters.Modules.HellknightCodex.Archetypes.Deacon.Incense;

internal class PlantDomainIncense
{
    private static readonly string IncenceName = "BrambleMist";
    private static readonly string Domain = FeatureRefs.PlantDomainAllowed.ToString();
    //private static readonly Sprite Icon = $"{_Module.IconPath}/ .png";

    internal static void Configure()
    {
        MinorFeature.Configure();
        MajorFeature.Configure();

        AbilityAreaEffectConfigurator.For(DeaconIncenseFeature.AbilityArea.Guid)
            .AddAbilityAreaEffectBuff(
                buff: MinorBuff.Guid,
                condition: ConditionsBuilder.New().IsAlly().CasterHasFact(MinorFeature.Guid).CasterHasFact(MajorFeature.Guid, negate: true))
            .AddAbilityAreaEffectBuff(
                buff: MajorBuff.Guid,
                condition: ConditionsBuilder.New().IsAlly().CasterHasFact(MinorFeature.Guid).CasterHasFact(MajorFeature.Guid))
            .Configure();
    }

    internal class MinorFeature
    {
        public static readonly string Guid = "{c445d1a3-5abd-4202-ac10-333b2ac8732b}";

        private static readonly string FeatureName = $"{IncenceName}.MinorFeature";
        private static readonly string DisplayName = $"{FeatureName}.Name";
        private static readonly string Description = $"{FeatureName}.Description";

        internal static void Configure()
        {
            MinorBuff.Configure();

            FeatureConfigurator.New(FeatureName, Guid)
                .AddPrerequisiteFeature(Domain, hideInUI: true)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                //.SetIcon(Icon)
                .Configure();
        }
    }

    internal class MinorBuff
    {
        public static readonly string Guid = "{1812bda6-0601-4ab8-9fae-c211d92fb779}";

        private static readonly string BuffName = $"{IncenceName}.MinorBuff";
        private static readonly string DisplayName = $"{BuffName}.Name";
        private static readonly string Description = $"{BuffName}.Description";

        internal static void Configure()
        {
            var diceValue = new ContextDiceValue
            {
                DiceType = DiceType.D6,
                DiceCountValue = 1,
                BonusValue = 0
            };

            var damageType = new DamageTypeDescription
            {
                Type = DamageType.Physical,
                Physical = new DamageTypeDescription.PhysicalData 
                { 
                    Form = PhysicalDamageForm.Piercing
                }
            };

            BuffConfigurator.New(BuffName, Guid)
                .AddTargetAttackRollTrigger(
                    actionsOnAttacker: ActionsBuilder.New().DealDamage(damageType: damageType, value: diceValue, ignoreCritical: true),
                    onlyHit: true,
                    onlyMelee: true,
                    notReach: true,
                    doNotPassAttackRoll: true)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }

    internal class MajorFeature
    {
        public static readonly string Guid = "{75558868-fb0d-418d-a3a9-9c8cb1ea6cf1}";

        private static readonly string FeatureName = $"{IncenceName}.MajorFeature";
        private static readonly string DisplayName = $"{FeatureName}.Name";
        private static readonly string Description = $"{FeatureName}.Description";

        internal static void Configure()
        {
            MajorBuff.Configure();

            FeatureConfigurator.New(FeatureName, Guid)
                .AddPrerequisiteFeature(Domain, hideInUI: true)
                .AddPrerequisiteFeature(MinorFeature.Guid)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                //.SetIcon(Icon)
                .Configure();
        }
    }

    internal class MajorBuff
    {
        public static readonly string Guid = "{86897bb0-f8ad-4475-a897-ead822e1e114}";

        private static readonly string BuffName = $"{IncenceName}.MajorBuff";
        private static readonly string DisplayName = $"{BuffName}.Name";
        private static readonly string Description = $"{BuffName}.Description";

        internal static void Configure()
        {
            var diceValue = new ContextDiceValue
            {
                DiceType = DiceType.D6,
                DiceCountValue = 1,
                BonusValue = ContextValues.Rank()
            };

            var damageType = new DamageTypeDescription
            {
                Type = DamageType.Physical,
                Physical = new DamageTypeDescription.PhysicalData
                {
                    Form = PhysicalDamageForm.Piercing
                }
            };

            var config = ContextRankConfigs.ClassLevel([CharacterClassRefs.WarpriestClass.ToString()], min: 0, max: 10).WithDiv2Progression();

            BuffConfigurator.New(BuffName, Guid)
                .AddTargetAttackRollTrigger(
                    actionsOnAttacker: ActionsBuilder.New().DealDamage(damageType: damageType, value: diceValue, ignoreCritical: true),
                    onlyHit: true,
                    onlyMelee: true,
                    notReach: true,
                    doNotPassAttackRoll: true)
                .AddContextRankConfig(config)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }

}
