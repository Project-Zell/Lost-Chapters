using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.Enums;

namespace LostChapters.Modules.HellknightCodex.Archetypes.Deacon.Incense
{
    internal class ScalykindDomainIncense
    {
        private static readonly string IncenceName = "SerpentsBreath";
        private static readonly string Domain = FeatureRefs.ScalykindDomainAllowed.ToString();
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
            public static readonly string Guid = "{89d9d8c3-1dc7-4b33-956e-b6b4d1b1b5f7}";

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
            public static readonly string Guid = "{a1b57ffb-06b1-480e-91e9-781d0e8f6fb6}";

            private static readonly string BuffName = $"{IncenceName}.MinorBuff";
            private static readonly string DisplayName = $"{BuffName}.Name";
            private static readonly string Description = $"{BuffName}.Description";

            internal static void Configure()
            {
                BuffConfigurator.New(BuffName, Guid)
                    .AddACBonusAgainstWeaponGroup(fighterGroup: WeaponFighterGroup.Natural)
                    .AddSavingThrowBonusAgainstDescriptor(spellDescriptor: SpellDescriptor.Poison, value: -2, modifierDescriptor: ModifierDescriptor.Alchemical)
                    .SetDisplayName(DisplayName)
                    .SetDescription(Description)
                    .Configure();
            }
        }

        internal class MajorFeature
        {
            public static readonly string Guid = "{5ac329e1-2077-42ae-b26c-77e2afbca8be}";

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
            public static readonly string Guid = "{9c5fbf68-5d4a-4b38-813e-8e2e7adc0f9d}";

            private static readonly string BuffName = $"{IncenceName}.MajorBuff";
            private static readonly string DisplayName = $"{BuffName}.Name";
            private static readonly string Description = $"{BuffName}.Description";

            internal static void Configure()
            {
                BuffConfigurator.New(BuffName, Guid)
                    .AddSavingThrowBonusAgainstDescriptor(spellDescriptor: SpellDescriptor.Poison, value: -4, modifierDescriptor: ModifierDescriptor.Alchemical)
                    .SetDisplayName(DisplayName)
                    .SetDescription(Description)
                    .Configure();
            }
        }
    }
}
