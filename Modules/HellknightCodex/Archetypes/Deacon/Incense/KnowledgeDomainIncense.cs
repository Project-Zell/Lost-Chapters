using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;

namespace LostChapters.Modules.HellknightCodex.Archetypes.Deacon.Incense;

internal class KnowledgeDomainIncense
{
    private static readonly string IncenceName = "VisionaryMist";
    private static readonly string Domain = FeatureRefs.KnowledgeDomainAllowed.ToString();
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
        public static readonly string Guid = "{18cb7946-94b9-4f6d-b137-8919da4b38dd}";

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
        public static readonly string Guid = "{bb75a261-66e4-46ad-800f-de34903251fe}";

        private static readonly string BuffName = $"{IncenceName}.MinorBuff";
        private static readonly string DisplayName = $"{BuffName}.Name";
        private static readonly string Description = $"{BuffName}.Description";

        internal static void Configure()
        {
            BuffConfigurator.New(BuffName, Guid)
                .AddStatBonus(descriptor: ModifierDescriptor.Alchemical, stat: StatType.Intelligence, value: 2)
                .AddSavingThrowBonusAgainstDescriptor(spellDescriptor: SpellDescriptor.Disease, value: 2, modifierDescriptor: ModifierDescriptor.Alchemical)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }

    internal class MajorFeature
    {
        public static readonly string Guid = "{fc3c8ac8-90a2-4874-8711-419f987713fe}";

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
        public static readonly string Guid = "{95000e0f-0a0d-448b-ad7a-edf8e25b3471}";

        private static readonly string BuffName = $"{IncenceName}.MajorBuff";
        private static readonly string DisplayName = $"{BuffName}.Name";
        private static readonly string Description = $"{BuffName}.Description";

        internal static void Configure()
        {
            BuffConfigurator.New(BuffName, Guid)
                .AddStatBonus(descriptor: ModifierDescriptor.Alchemical, stat: StatType.Intelligence, value: 4)
                .AddSavingThrowBonusAgainstDescriptor(spellDescriptor: SpellDescriptor.Disease, value: 4, modifierDescriptor: ModifierDescriptor.Alchemical)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }
}
