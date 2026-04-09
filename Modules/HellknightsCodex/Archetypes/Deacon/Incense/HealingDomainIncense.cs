using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using BlueprintCore.Utils.Types;
using Kingmaker.RuleSystem;
using Kingmaker.UnitLogic.Mechanics;

namespace LostChapters.Modules.HellknightCodex.Archetypes.Deacon.Incense;

internal class HealingDomainIncense
{
    private static readonly string IncenceName = "LifesBreath";
    private static readonly string Domain = FeatureRefs.HealingDomainAllowed.ToString();
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
        public static readonly string Guid = "{413ce19b-775f-46d7-8e56-101d1ecce843}";

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
        public static readonly string Guid = "{7870faa5-2c09-478c-b233-ff8842a6bf6c}";

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

            BuffConfigurator.New(BuffName, Guid)
                .AddNewRoundTrigger(newRoundActions: ActionsBuilder.New().OnOwner(ActionsBuilder.New().HealTarget(value: diceValue)))
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }

    internal class MajorFeature
    {
        public static readonly string Guid = "{2e896e0d-b2be-4b29-9de9-223a58ef305b}";

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
        public static readonly string Guid = "{1a4bd3a2-0c98-4975-9d53-1fa4948519cd}";

        private static readonly string BuffName = $"{IncenceName}.MajorBuff";
        private static readonly string DisplayName = $"{BuffName}.Name";
        private static readonly string Description = $"{BuffName}.Description";

        internal static void Configure()
        {
            var diceValue = new ContextDiceValue
            {
                DiceType = DiceType.D6,
                DiceCountValue = 2,
                BonusValue = 0
            };

            BuffConfigurator.New(BuffName, Guid)
                .AddNewRoundTrigger(newRoundActions: ActionsBuilder.New().OnOwner(ActionsBuilder.New().HealTarget(value: diceValue)))
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }
}
