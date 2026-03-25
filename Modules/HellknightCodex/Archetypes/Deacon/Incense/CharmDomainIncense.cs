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

internal class CharmDomainIncense
{
    private static readonly string IncenceName = "AlluringMist";
    private static readonly string Domain = FeatureRefs.CharmDomainAllowed.ToString();
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
                buff: MajorAllyBuff.Guid,
                condition: ConditionsBuilder.New().IsAlly().CasterHasFact(MinorFeature.Guid).CasterHasFact(MajorFeature.Guid))
            .AddAbilityAreaEffectBuff(
                buff: MinorEnemyBuff.Guid,
                condition: ConditionsBuilder.New().IsAlly(negate: true).CasterHasFact(MinorFeature.Guid).CasterHasFact(MajorFeature.Guid, negate: true))
            .AddAbilityAreaEffectBuff(
                buff: MajorEnemyBuff.Guid,
                condition: ConditionsBuilder.New().IsAlly(negate: true).CasterHasFact(MinorFeature.Guid).CasterHasFact(MajorFeature.Guid))
            .Configure();
    }

    internal class MinorFeature
    {
        public static readonly string Guid = "{1e0414e5-907d-4ad8-a0f2-d7c0a8896866}";

        private static readonly string FeatureName = $"{IncenceName}.MinorFeature";
        private static readonly string DisplayName = $"{FeatureName}.Name";
        private static readonly string Description = $"{FeatureName}.Description";

        internal static void Configure()
        {
            MinorAllyBuff.Configure();
            MinorEnemyBuff.Configure();

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
        public static readonly string Guid = "{2bfd380f-6003-4698-a43c-e8568c28f4eb}";

        private static readonly string BuffName = $"{IncenceName}.MinorAllyBuff";
        private static readonly string DisplayName = $"{BuffName}.Name";
        private static readonly string Description = $"{BuffName}.Description";

        internal static void Configure()
        {
            BuffConfigurator.New(BuffName, Guid)
                .AddStatBonus(descriptor: ModifierDescriptor.Alchemical, stat: StatType.Charisma, value: 2)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }

    internal class MinorEnemyBuff
    {
        public static readonly string Guid = "{92599e7d-cbe8-419a-9277-da2da21714de}";

        private static readonly string BuffName = $"{IncenceName}.MinorEnemyBuff";
        private static readonly string DisplayName = $"{BuffName}.Name";
        private static readonly string Description = $"{BuffName}.Description";

        internal static void Configure()
        {
            BuffConfigurator.New(BuffName, Guid)
                .AddSavingThrowBonusAgainstDescriptor(spellDescriptor: SpellDescriptor.MindAffecting, value: -2, modifierDescriptor: ModifierDescriptor.Alchemical)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }

    internal class MajorFeature
    {
        public static readonly string Guid = "{57955b3a-2563-4468-9cfc-79e987eaf2c9}";

        private static readonly string FeatureName = $"{IncenceName}.MajorFeature";
        private static readonly string DisplayName = $"{FeatureName}.Name";
        private static readonly string Description = $"{FeatureName}.Description";

        internal static void Configure()
        {
            MajorAllyBuff.Configure();
            MajorEnemyBuff.Configure();

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
        public static readonly string Guid = "{cf872af6-a970-460f-8288-2fe143b6eb2c}";

        private static readonly string BuffName = $"{IncenceName}.MajorAllyBuff";
        private static readonly string DisplayName = $"{BuffName}.Name";
        private static readonly string Description = $"{BuffName}.Description";

        internal static void Configure()
        {
            BuffConfigurator.New(BuffName, Guid)
                .AddStatBonus(descriptor: ModifierDescriptor.Alchemical, stat: StatType.Charisma, value: 4)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }

    internal class MajorEnemyBuff
    {
        public static readonly string Guid = "{83de1d72-62a3-4625-84d2-8cd6658d6045}";

        private static readonly string BuffName = $"{IncenceName}.MajorEnemyBuff";
        private static readonly string DisplayName = $"{BuffName}.Name";
        private static readonly string Description = $"{BuffName}.Description";

        internal static void Configure()
        {
            BuffConfigurator.New(BuffName, Guid)
                .AddSavingThrowBonusAgainstDescriptor(spellDescriptor: SpellDescriptor.MindAffecting, value: -4, modifierDescriptor: ModifierDescriptor.Alchemical)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }
}
