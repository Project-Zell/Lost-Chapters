using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using Kingmaker.Enums;
using LostChapters.Modules.HellknightsCodex.Archetypes.Deacon;

namespace LostChapters.Modules.HellknightCodex.Archetypes.Deacon.Incense;

internal class CommunityDomainIncense
{
    private static readonly string IncenceName = "FocusingFog";
    private static readonly string Domain = FeatureRefs.CommunityDomainAllowed.ToString();
    //private static readonly Sprite Icon = $"{_Module.IconPath}/ .png";

    internal static void Configure()
    {
        MinorFeature.Configure();
        MajorFeature.Configure();

        AbilityAreaEffectConfigurator.For(DeaconIncenseFeature.AbilityArea.Guid)
            .AddAbilityAreaEffectBuff(
                buff: MinorAllyBuff.Guid,
                condition: ConditionsBuilder.New().IsAlly().CasterHasFact(MinorFeature.Guid).CasterHasFact(MajorFeature.Guid, negate: true))
            .AddAbilityAreaEffectBuff(
                buff: MajorSelfBuff.Guid,
                condition: ConditionsBuilder.New().IsCaster().CasterHasFact(MinorFeature.Guid).CasterHasFact(MajorFeature.Guid))
            .AddAbilityAreaEffectBuff(
                buff: MajorAllyBuff.Guid,
                condition: ConditionsBuilder.New().IsAlly().CasterHasFact(MinorFeature.Guid).CasterHasFact(MajorFeature.Guid))
            .AddAbilityAreaEffectBuff(
                buff: MajorSelfBuff.Guid,
                condition: ConditionsBuilder.New().IsCaster().CasterHasFact(MinorFeature.Guid).CasterHasFact(MajorFeature.Guid))
            .Configure();
    }

    internal class MinorFeature
    {
        public static readonly string Guid = "{fa9e4c5f-49cb-4267-8a14-a40550673b23}";

        private static readonly string FeatureName = $"{IncenceName}.MinorFeature";
        private static readonly string DisplayName = $"{FeatureName}.Name";
        private static readonly string Description = $"{FeatureName}.Description";

        internal static void Configure()
        {
            MinorAllyBuff.Configure();
            MinorSelfBuff.Configure();

            FeatureConfigurator.New(FeatureName, Guid)
                .AddPrerequisiteFeature(Domain, hideInUI: true)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                //.SetIcon(Icon)
                .Configure();
        }
    }

    internal class MinorAllyBuff
    {
        public static readonly string Guid = "{3ed6df31-1bc5-4a09-a27e-b36a56b9e735}";

        private static readonly string BuffName = $"{IncenceName}.MinorAllyBuff";
        private static readonly string DisplayName = $"{BuffName}.Name";
        private static readonly string Description = $"{BuffName}.Description";

        internal static void Configure()
        {
            BuffConfigurator.New(BuffName, Guid)
                .AddAttackTypeAttackBonus(value: 2, descriptor: ModifierDescriptor.Alchemical, type: WeaponRangeType.Ranged)
                .AddAttackTypeAttackBonus(value: 2, descriptor: ModifierDescriptor.Alchemical, type: WeaponRangeType.RangedNormal)
                .AddAttackTypeAttackBonus(value: 2, descriptor: ModifierDescriptor.Alchemical, type: WeaponRangeType.RangedTouch)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }

    internal class MinorSelfBuff
    {
        public static readonly string Guid = "{faefb3f7-6ede-4ca3-9164-381f14a0784d}";

        private static readonly string BuffName = $"{IncenceName}.MinorSelfBuff";
        private static readonly string DisplayName = $"{BuffName}.Name";
        private static readonly string Description = $"{BuffName}.Description";

        internal static void Configure()
        {
            BuffConfigurator.New(BuffName, Guid)
                .AddAttackTypeAttackBonus(value: 1, descriptor: ModifierDescriptor.Alchemical, type: WeaponRangeType.Ranged)
                .AddAttackTypeAttackBonus(value: 1, descriptor: ModifierDescriptor.Alchemical, type: WeaponRangeType.RangedNormal)
                .AddAttackTypeAttackBonus(value: 1, descriptor: ModifierDescriptor.Alchemical, type: WeaponRangeType.RangedTouch)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }

    internal class MajorFeature
    {
        public static readonly string Guid = "{b4902fdb-dd2e-4753-9e72-13bb71c6113f}";

        private static readonly string FeatureName = $"{IncenceName}.MajorFeature";
        private static readonly string DisplayName = $"{FeatureName}.Name";
        private static readonly string Description = $"{FeatureName}.Description";

        internal static void Configure()
        {
            MajorAllyBuff.Configure();
            MajorSelfBuff.Configure();

            FeatureConfigurator.New(FeatureName, Guid)
                .AddPrerequisiteFeature(Domain, hideInUI: true)
                .AddPrerequisiteFeature(MinorFeature.Guid)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                //.SetIcon(Icon)
                .Configure();
        }
    }

    internal class MajorAllyBuff
    {
        public static readonly string Guid = "{aad7e750-fcac-4602-bd25-859bdfab3c96}";

        private static readonly string BuffName = $"{IncenceName}.MajorAllyBuff";
        private static readonly string DisplayName = $"{BuffName}.Name";
        private static readonly string Description = $"{BuffName}.Description";

        internal static void Configure()
        {
            BuffConfigurator.New(BuffName, Guid)
                .AddAttackTypeAttackBonus(value: 4, descriptor: ModifierDescriptor.Alchemical, type: WeaponRangeType.Ranged)
                .AddAttackTypeAttackBonus(value: 4, descriptor: ModifierDescriptor.Alchemical, type: WeaponRangeType.RangedNormal)
                .AddAttackTypeAttackBonus(value: 4, descriptor: ModifierDescriptor.Alchemical, type: WeaponRangeType.RangedTouch)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }

    internal class MajorSelfBuff
    {
        public static readonly string Guid = "{1fe59cc4-f823-4b12-9183-adcaf11672d7}";

        private static readonly string BuffName = $"{IncenceName}.MajorSelfBuff";
        private static readonly string DisplayName = $"{BuffName}.Name";
        private static readonly string Description = $"{BuffName}.Description";

        internal static void Configure()
        {
            BuffConfigurator.New(BuffName, Guid)
                .AddAttackTypeAttackBonus(value: 2, descriptor: ModifierDescriptor.Alchemical, type: WeaponRangeType.Ranged)
                .AddAttackTypeAttackBonus(value: 2, descriptor: ModifierDescriptor.Alchemical, type: WeaponRangeType.RangedNormal)
                .AddAttackTypeAttackBonus(value: 2, descriptor: ModifierDescriptor.Alchemical, type: WeaponRangeType.RangedTouch)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }
}
