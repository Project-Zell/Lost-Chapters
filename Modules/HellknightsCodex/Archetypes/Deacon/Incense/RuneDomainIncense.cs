using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.RuleSystem.Rules;
using QuickGraph;

namespace LostChapters.Modules.HellknightCodex.Archetypes.Deacon.Incense;

internal class RuneDomainIncense
{
    private static readonly string IncenceName = "RunicDust";
    private static readonly string Domain = FeatureRefs.RuneDomainAllowed.ToString();
    //private static readonly Sprite Icon = $"{_Module.IconPath}/ .png";

    internal static void Configure()
    {
        MinorFeature.Configure();
        MajorFeature.Configure();

        AbilityAreaEffectConfigurator.For(DeaconIncenseFeature.AbilityArea.Guid)
            .AddAbilityAreaEffectBuff(
                buff: MinorBuff.Guid,
                condition: ConditionsBuilder.New().IsAlly(negate: true).CasterHasFact(MinorFeature.Guid).CasterHasFact(MajorFeature.Guid, negate: true))
            .AddAbilityAreaEffectBuff(
                buff: MajorBuff.Guid,
                condition: ConditionsBuilder.New().IsAlly(negate: true).CasterHasFact(MinorFeature.Guid).CasterHasFact(MajorFeature.Guid))
            .Configure();
    }

    internal class MinorFeature
    {
        public static readonly string Guid = "{9219320b-69a2-4e23-80d9-9be94d9397de}";

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
        public static readonly string Guid = "{6cb1bb25-06d5-4a59-b504-edaaef5b2dd2}";

        private static readonly string BuffName = $"{IncenceName}.MinorBuff";
        private static readonly string DisplayName = $"{BuffName}.Name";
        private static readonly string Description = $"{BuffName}.Description";

        internal static void Configure()
        {
            BuffConfigurator.New(BuffName, Guid)
                .AddStatBonus(stat: StatType.SaveWill, value: -1, descriptor: ModifierDescriptor.Alchemical)
                .AddStatBonus(stat: StatType.SaveReflex, value: -1, descriptor: ModifierDescriptor.Alchemical)
                .AddStatBonus(stat: StatType.SaveFortitude, value: -1, descriptor: ModifierDescriptor.Alchemical)
                .AddCMDBonus(value: -2, descriptor: ModifierDescriptor.Alchemical)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }

    internal class MajorFeature
    {
        public static readonly string Guid = "{83b478af-6b89-4b35-a6d5-31a35f5b0c4a}";

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
        public static readonly string Guid = "{4a0c52a8-5019-4a2a-a0d2-1656df9c4eb7}";

        private static readonly string BuffName = $"{IncenceName}.MajorBuff";
        private static readonly string DisplayName = $"{BuffName}.Name";
        private static readonly string Description = $"{BuffName}.Description";

        internal static void Configure()
        {
            BuffConfigurator.New(BuffName, Guid)
                .AddStatBonus(stat: StatType.SaveWill, value: -2, descriptor: ModifierDescriptor.Alchemical)
                .AddStatBonus(stat: StatType.SaveReflex, value: -2, descriptor: ModifierDescriptor.Alchemical)
                .AddStatBonus(stat: StatType.SaveFortitude, value: -2, descriptor: ModifierDescriptor.Alchemical)
                .AddCMDBonus(value: -4, descriptor: ModifierDescriptor.Alchemical)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }
}
