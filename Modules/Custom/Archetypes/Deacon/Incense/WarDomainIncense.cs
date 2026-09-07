using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using Kingmaker.Enums;

namespace LostChapters.Modules.Custom.Archetypes.Deacon.Incense;

internal class WarDomainIncense
{
    private static readonly string BaseName = "WarboundMist";
    private static readonly string Domain = FeatureRefs.WarDomainAllowed.ToString();
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
        public static readonly string Guid = "{ddbfffd9-105b-4979-9c6c-bca615040c19}";

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
            public static readonly string Guid = "{a7f7634b-617e-4bbc-a0b4-b693f5249ab8}";

            private static readonly string BuffName = $"{FeatureName}Buff";
            private static readonly string DisplayName = $"{BuffName}.Name";
            private static readonly string Description = $"{BuffName}.Description";

            internal static void Configure()
            {
                BuffConfigurator.New(BuffName, Guid)
                    .AddAttackTypeAttackBonus(value: 2, descriptor: ModifierDescriptor.Alchemical, type: WeaponRangeType.Melee)
                    .AddAttackTypeAttackBonus(value: 2, descriptor: ModifierDescriptor.Alchemical, type: WeaponRangeType.MeleeNormal)
                    .AddAttackTypeAttackBonus(value: 2, descriptor: ModifierDescriptor.Alchemical, type: WeaponRangeType.MeleeTouch)
                    .SetDisplayName(DisplayName)
                    .SetDescription(Description)
                    .Configure();
            }
        }
    }

    internal class MajorFeature
    {
        public static readonly string Guid = "{ec7c30a6-8221-4086-a3ab-a1666ea2120d}";

        private static readonly string FeatureName = $"{BaseName}.MajorFeature";
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
            public static readonly string Guid = "{6a268ead-eb80-49c0-9cbb-ba24ef1b8fcd}";

            private static readonly string BuffName = $"{FeatureName}Buff";
            private static readonly string DisplayName = $"{BuffName}.Name";
            private static readonly string Description = $"{BuffName}.Description";

            internal static void Configure()
            {
                BuffConfigurator.New(BuffName, Guid)
                    .AddAttackTypeAttackBonus(value: 4, descriptor: ModifierDescriptor.Alchemical, type: WeaponRangeType.Melee)
                    .AddAttackTypeAttackBonus(value: 4, descriptor: ModifierDescriptor.Alchemical, type: WeaponRangeType.MeleeNormal)
                    .AddAttackTypeAttackBonus(value: 4, descriptor: ModifierDescriptor.Alchemical, type: WeaponRangeType.MeleeTouch)
                    .SetDisplayName(DisplayName)
                    .SetDescription(Description)
                    .Configure();
            }
        }
    }
}
