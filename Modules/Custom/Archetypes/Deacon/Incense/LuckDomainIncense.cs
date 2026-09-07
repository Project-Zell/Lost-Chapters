using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using Kingmaker.Designers.Mechanics.Facts;

namespace LostChapters.Modules.Custom.Archetypes.Deacon.Incense;

internal class LuckDomainIncense
{
    private static readonly string BaseName = "FatefulWhispers";
    private static readonly string Domain = FeatureRefs.LuckDomainAllowed.ToString();
    //private static readonly Sprite Icon = $"{_Module.IconPath}/ .png";

    internal static void Configure()
    {
        MinorFeature.Configure();
        MajorFeature.Configure();

        AbilityAreaEffectConfigurator.For(CenserBurnerFeature.AbilityArea.Guid)
            .AddAbilityAreaEffectBuff(
                buff: MinorFeature.Buff.Guid,
                condition: ConditionsBuilder.New().IsAlly().CasterHasFact(MinorFeature.Guid))
            .AddAbilityAreaEffectBuff(
                buff: MajorFeature.Buff.Guid,
                condition: ConditionsBuilder.New().IsAlly(negate: true).CasterHasFact(MajorFeature.Guid))
            .Configure();
    }

    internal class MinorFeature
    {
        public static readonly string Guid = "{0805bbd9-51aa-41fa-8023-b65692545ef0}";

        private static readonly string FeatureName = $"{BaseName}MinorFeature";
        private static readonly string DisplayName = $"{FeatureName}.Name";
        private static readonly string Description = $"{FeatureName}.Description";

        internal static void Configure()
        {
            Buff.Configure();

            FeatureConfigurator.New(FeatureName, Guid)
                .AddPrerequisiteFeature(Domain, hideInUI: true)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                //.SetIcon(Icon)
                .Configure();
        }

        internal class Buff
        {
            public static readonly string Guid = "{7b0cd6a2-8f03-49dc-a8d6-b99a88038fec}";

            private static readonly string BuffName = $"{FeatureName}Buff";
            private static readonly string DisplayName = $"{BuffName}.Name";
            private static readonly string Description = $"{BuffName}.Description";

            internal static void Configure()
            {
                BuffConfigurator.New(BuffName, Guid)
                    .AddModifyD20(rule: RuleType.SavingThrow | RuleType.SkillCheck, rollsAmount: 1, takeBest: true)
                    .SetDisplayName(DisplayName)
                    .SetDescription(Description)
                    .Configure();
            }
        }
    }

    internal class MajorFeature
    {
        public static readonly string Guid = "{416ab08d-0610-47c7-b697-776f0616d650}";

        private static readonly string FeatureName = $"{BaseName}MajorFeature";
        private static readonly string DisplayName = $"{FeatureName}.Name";
        private static readonly string Description = $"{FeatureName}.Description";

        internal static void Configure()
        {
            Buff.Configure();

            FeatureConfigurator.New(FeatureName, Guid)
                .AddPrerequisiteFeature(Domain, hideInUI: true)
                .AddPrerequisiteFeature(MinorFeature.Guid)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                //.SetIcon(Icon)
                .Configure();
        }

        internal class Buff
        {
            public static readonly string Guid = "{3f2e8aea-ad83-44f6-9325-406422acc807}";

            private static readonly string BuffName = $"{FeatureName}Buff";
            private static readonly string DisplayName = $"{BuffName}.Name";
            private static readonly string Description = $"{BuffName}.Description";

            internal static void Configure()
            {
                BuffConfigurator.New(BuffName, Guid)
                    .AddModifyD20(rule: RuleType.SavingThrow | RuleType.SkillCheck, rollsAmount: 1, takeBest: false)
                    .SetDisplayName(DisplayName)
                    .SetDescription(Description)
                    .Configure();
            }
        }
    }
}
