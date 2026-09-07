using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using LostChapters.Modules.Custom.Archetypes.Magistrate.Components;

namespace LostChapters.Modules.Custom.Archetypes.Magistrate;

internal class VerdictAbility
{
    public static readonly string Guid = "{c3c50bb6-d259-4cec-9d08-2ce63a1f7a64}";

    private static readonly string FeatureName = "VerdictAbility";
    private static readonly string DisplayName = $"{FeatureName}.Name";
    private static readonly string Description = $"{FeatureName}.Description";

    //private static readonly Sprite Icon = $"{_Module.IconPath}/ .png";

    internal static void Configure()
    {
        Resource.Configure();
        BaseAbility.Configure();

        FeatureConfigurator.New(FeatureName, Guid)
            .AddFacts([BaseAbility.Guid, Resource.Guid])
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            //.AddFeatureTagsComponent()
            //.SetIcon(Icon)
            .Configure();
    }

    internal class Resource
    {
        public static readonly string Guid = "{63e57a50-6c41-43dc-b190-ca5b9614cee3}";

        private static readonly string ResourceName = $"{FeatureName}.Resource";

        internal static void Configure()
        {
            var amount = ResourceAmountBuilder.New(10);

            AbilityResourceConfigurator.New(ResourceName, Guid)
                .SetMaxAmount(amount)
                .Configure();
        }
    }

    internal class BaseAbility
    {
        public static readonly string Guid = "{331bef9a-b7bb-4262-b03e-f84d6ecb7100}";

        private static readonly string AbilityName = $"{FeatureName}.BaseAbility";
        private static readonly string DisplayName = $"{AbilityName}.Name";
        private static readonly string Description = $"{AbilityName}.Description";

        //private static readonly Sprite Icon = $"{_Module.IconPath}/ .png";

        internal static void Configure()
        {
            SlowVariant.Configure();
            StealthVariant.Configure();
            EmotionsVariant.Configure();

            AbilityConfigurator.New(AbilityName, Guid)
                .AddAbilityVariants([SlowVariant.Ability.Guid, StealthVariant.Ability.Guid, EmotionsVariant.Ability.Guid])
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                //.AddFeatureTagsComponent()
                //.SetIcon(Icon)
                .Configure();
        }
    }

    internal class SlowVariant
    {
        internal static void Configure()
        {
            Ability.Configure();
            Buff.Configure();
        }

        internal class Ability
        {
            public static readonly string Guid = "{b75549e6-ec1a-40ff-bfc8-ba74b1ee1f69}";

            private static readonly string AbilityName = $"{FeatureName}.SlowVariant";
            private static readonly string DisplayName = $"{AbilityName}.Name";
            private static readonly string Description = $"{AbilityName}.Description";

            internal static void Configure()
            {
                MagistrateVerdictAbilityVariantConfigurator.CreateAbility(
                    abilityName: AbilityName,
                    abilityGuid: Guid,
                    buffGuid: Buff.Guid,
                    displayName: DisplayName,
                    description: Description);
            }
        }

        internal class Buff
        {
            public static readonly string Guid = "{b26e0e6a-5c44-4bc9-8f70-945ee47953e7}";

            private static readonly string BuffName = $"{FeatureName}.SlowVariant.Buff";
            private static readonly string DisplayName = $"{BuffName}.Name";
            private static readonly string Description = $"{BuffName}.Description";

            internal static void Configure()
            {
                BuffConfigurator.New(BuffName, Guid)
                    .SetDisplayName(DisplayName)
                    .SetDescription(Description)
                    //.AddFeatureTagsComponent()
                    //.SetIcon(Icon)
                    .Configure();
            }
        }
    }

    internal class StealthVariant
    {
        internal static void Configure()
        {
            Ability.Configure();
            Buff.Configure();
        }

        internal class Ability
        {
            public static readonly string Guid = "{d0184c4e-0b6c-4d65-adaf-c87a5dbdf378}";

            private static readonly string AbilityName = $"{FeatureName}.StealthVariant";
            private static readonly string DisplayName = $"{AbilityName}.Name";
            private static readonly string Description = $"{AbilityName}.Description";

            internal static void Configure()
            {
                MagistrateVerdictAbilityVariantConfigurator.CreateAbility(
                    abilityName: AbilityName,
                    abilityGuid: Guid,
                    buffGuid: Buff.Guid,
                    displayName: DisplayName,
                    description: Description);
            }
        }

        internal class Buff
        {
            public static readonly string Guid = "{83769d41-a5a4-4c3b-a1fa-4694a5fc1cac}";

            private static readonly string BuffName = $"{FeatureName}.StealthVariant.Buff";
            private static readonly string DisplayName = $"{BuffName}.Name";
            private static readonly string Description = $"{BuffName}.Description";

            internal static void Configure()
            {
                BuffConfigurator.New(BuffName, Guid)
                    .SetDisplayName(DisplayName)
                    .SetDescription(Description)
                    //.AddFeatureTagsComponent()
                    //.SetIcon(Icon)
                    .Configure();
            }
        }

    }

    internal class EmotionsVariant
    {
        internal static void Configure()
        {
            Ability.Configure();
            Buff.Configure();
        }

        internal class Ability
        {
            public static readonly string Guid = "{7b509590-79e4-4a3c-af52-bb0e92a454d4}";

            private static readonly string AbilityName = $"{FeatureName}.EmotionsVariant";
            private static readonly string DisplayName = $"{AbilityName}.Name";
            private static readonly string Description = $"{AbilityName}.Description";

            internal static void Configure()
            {
                MagistrateVerdictAbilityVariantConfigurator.CreateAbility(
                    abilityName: AbilityName,
                    abilityGuid: Guid,
                    buffGuid: Buff.Guid,
                    displayName: DisplayName,
                    description: Description);
            }
        }

        internal class Buff
        {
            public static readonly string Guid = "{337df95e-7d65-4421-b1eb-3ef635ebc5f2}";

            private static readonly string BuffName = $"{FeatureName}.EmotionsVariant.Buff";
            private static readonly string DisplayName = $"{BuffName}.Name";
            private static readonly string Description = $"{BuffName}.Description";

            internal static void Configure()
            {
                BuffConfigurator.New(BuffName, Guid)
                    .SetDisplayName(DisplayName)
                    .SetDescription(Description)
                    //.AddFeatureTagsComponent()
                    //.SetIcon(Icon)
                    .Configure();
            }
        }
    }
}