using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.Buffs.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostChapters.Modules.HellknightCodex.Archetypes.Deacon.Incense;

internal class GloryDomainIncense
{
    private static readonly string IncenceName = "WhiteSmoke";
    private static readonly string Domain = FeatureRefs.GloryDomainAllowed.ToString();
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
        public static readonly string Guid = "{d1d15494-b76d-435b-bb25-b1f64c28ec25}";

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
        public static readonly string Guid = "{a348245d-7711-44fd-a62a-51c699c3d64d}";

        private static readonly string BuffName = $"{IncenceName}.MinorAllyBuff";
        private static readonly string DisplayName = $"{BuffName}.Name";
        private static readonly string Description = $"{BuffName}.Description";

        internal static void Configure()
        {
            BuffConfigurator.New(BuffName, Guid)
                .AddSavingThrowBonusAgainstDescriptor(value: -2, spellDescriptor: SpellDescriptor.Fear, modifierDescriptor: ModifierDescriptor.Alchemical)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }

    internal class MinorEnemyBuff
    {
        public static readonly string Guid = "{e005acba-a82a-484f-a185-3994f166770c}";

        private static readonly string BuffName = $"{IncenceName}.MinorEnemyBuff";
        private static readonly string DisplayName = $"{BuffName}.Name";
        private static readonly string Description = $"{BuffName}.Description";

        internal static void Configure()
        {
            BuffConfigurator.New(BuffName, Guid)
                .AddAttackBonusConditional(bonus: 2, descriptor: ModifierDescriptor.Alchemical)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }

    internal class MajorFeature
    {
        public static readonly string Guid = "{6a54a175-171c-482e-950a-6d8dcdc8e857}";

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
        public static readonly string Guid = "{c65fb6b9-b456-494a-a422-d1857dd83ae9}";

        private static readonly string BuffName = $"{IncenceName}.MajorAllyBuff";
        private static readonly string DisplayName = $"{BuffName}.Name";
        private static readonly string Description = $"{BuffName}.Description";

        internal static void Configure()
        {
            BuffConfigurator.New(BuffName, Guid)
                .AddSavingThrowBonusAgainstDescriptor(value: 4, spellDescriptor: SpellDescriptor.Fear, modifierDescriptor: ModifierDescriptor.Alchemical)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }

    internal class MajorEnemyBuff
    {
        public static readonly string Guid = "{9bf259b9-4bce-40d3-9fb6-1c669eefe194}";

        private static readonly string BuffName = $"{IncenceName}.MajorEnemyBuff";
        private static readonly string DisplayName = $"{BuffName}.Name";
        private static readonly string Description = $"{BuffName}.Description";

        internal static void Configure()
        {
            BuffConfigurator.New(BuffName, Guid)
                .AddAttackBonusConditional(bonus: -4, descriptor: ModifierDescriptor.Alchemical)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }
}
