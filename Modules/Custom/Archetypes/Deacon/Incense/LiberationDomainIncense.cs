using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Designers.EventConditionActionSystem.Actions;
using Kingmaker.Enums;

namespace LostChapters.Modules.Custom.Archetypes.Deacon.Incense;

internal class LiberationDomainIncense
{
    private static readonly string BaseName = "CleansingShroud";
    private static readonly string Domain = FeatureRefs.LiberationDomainAllowed.ToString();
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
        public static readonly string Guid = "{13ce9b89-145b-47b3-86d5-754d268861da}";

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
            public static readonly string Guid = "{df2218ce-6612-4ac0-b5e5-e798520cd4fd}";

            private static readonly string BuffName = $"{FeatureName}Buff";
            private static readonly string DisplayName = $"{BuffName}.Name";
            private static readonly string Description = $"{BuffName}.Description";

            internal static void Configure()
            {
                BuffConfigurator.New(BuffName, Guid)
                    .AddDispelCasterLevelCheckBonus(value: 1)
                    .AddSavingThrowBonusAgainstDescriptor(spellDescriptor: SpellDescriptor.MovementImpairing, value: 2, modifierDescriptor: ModifierDescriptor.Alchemical)
                    .SetDisplayName(DisplayName)
                    .SetDescription(Description)
                    .Configure();
            }
        }
    }

    internal class MajorFeature
    {
        public static readonly string Guid = "{a215b0d2-4e1f-4a65-b734-2bf947c4c0cc}";

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
            public static readonly string Guid = "{bae71125-3f5e-4e78-9e32-5cce6b37070e}";

            private static readonly string BuffName = $"{FeatureName}Buff";
            private static readonly string DisplayName = $"{BuffName}.Name";
            private static readonly string Description = $"{BuffName}.Description";

            internal static void Configure()
            {
                BuffConfigurator.New(BuffName, Guid)
                    .AddDispelCasterLevelCheckBonus(value: 2)
                    .AddSavingThrowBonusAgainstDescriptor(spellDescriptor: SpellDescriptor.MovementImpairing, value: 4, modifierDescriptor: ModifierDescriptor.Alchemical)
                    .SetDisplayName(DisplayName)
                    .SetDescription(Description)
                    .Configure();
            }
        }
    }
}
