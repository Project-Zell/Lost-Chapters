using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using Kingmaker.Enums;
using LostChapters.Modules.Custom.Archetypes.Deacon;

namespace LostChapters.Modules.Custom.Archetypes.Deacon.Incense
{
    internal class ProtectionDomainIncense
    {
        private static readonly string BaseName = "ImpenetrableFog";
        private static readonly string Domain = FeatureRefs.ProtectionDomainAllowed.ToString();
        //private static readonly Sprite Icon = $"{_Module.IconPath}/ .png";

        internal static void Configure()
        {
            MinorFeature.Configure();
            MajorFeature.Configure();

            AbilityAreaEffectConfigurator.For(CenserBurnerFeature.AbilityArea.Guid)
                .AddAbilityAreaEffectBuff(
                    buff: MinorFeature.Buff.Guid,
                    condition: ConditionsBuilder.New().IsAlly().CasterHasFact(MinorFeature.Guid).CasterHasFact(MajorFeature.Guid, negate: true))
                .AddAbilityAreaEffectBuff(
                    buff: MajorFeature.Buff.Guid,
                    condition: ConditionsBuilder.New().IsAlly().CasterHasFact(MinorFeature.Guid).CasterHasFact(MajorFeature.Guid))
                .Configure();
        }

        internal class MinorFeature
        {
            public static readonly string Guid = "{5758f80b-0249-4d6d-ae7a-99cabec0fcc3}";

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
                public static readonly string Guid = "{8d161665-9032-4835-94f4-509eee8a6797}";

                private static readonly string BuffName = $"{FeatureName}MinorBuff";
                private static readonly string DisplayName = $"{BuffName}.Name";
                private static readonly string Description = $"{BuffName}.Description";

                internal static void Configure()
                {
                    BuffConfigurator.New(BuffName, Guid)
                        .AddACBonusAgainstTarget(value: 2, descriptor: ModifierDescriptor.Alchemical)
                        .SetDisplayName(DisplayName)
                        .SetDescription(Description)
                        .Configure();
                }
            }
        }

        internal class MajorFeature
        {
            public static readonly string Guid = "{c5178e09-9c49-4705-b06b-d35c9bc0978f}";

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
                public static readonly string Guid = "{69ffe6c4-eb8b-4fd0-a08e-8e7b0b4759cd}";

                private static readonly string BuffName = $"{FeatureName}Buff";
                private static readonly string DisplayName = $"{BuffName}.Name";
                private static readonly string Description = $"{BuffName}.Description";

                internal static void Configure()
                {
                    BuffConfigurator.New(BuffName, Guid)
                        .AddACBonusAgainstTarget(value: 4, descriptor: ModifierDescriptor.Alchemical)
                        .SetDisplayName(DisplayName)
                        .SetDescription(Description)
                        .Configure();
                }
            }
        }
    }
}
