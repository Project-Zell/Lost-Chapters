using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.Mechanics.Components;
using LostChapters.Tools.Glossaries;

namespace LostChapters.Modules.Custom.Archetypes.FalseKnight.FallenOrder;

internal class FallenOrderProgression
{
    public static readonly string Guid = "{82aca15c-357a-4d92-88d6-3a2e62a82190}";

    private static readonly string BaseName = "FallenOrder";

    private static readonly string Progression = $"{BaseName}Progression";
    private static readonly string DisplayName = $"{Progression}.Name";
    private static readonly string Description = $"{Progression}.Description";

    public static void Configure()
    {
        Challenge.Configure();
        ImpostorFeature.Configure();
        RevenantFeature.Configure();
        UnyieldingDevotionFeature.Configure();

        ProgressionConfigurator.New(Progression, Guid)
            .AddToLevelEntry(level: 01, features: Challenge.Guid)
            .AddToLevelEntry(level: 02, features: ImpostorFeature.Guid)
            .AddToLevelEntry(level: 08, features: RevenantFeature.Guid)
            .AddToLevelEntry(level: 15, features: UnyieldingDevotionFeature.Guid)
            .SetClasses(CharacterClassRefs.CavalierClass.ToString())
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .Configure();
    }

    internal class Challenge
    {
        public static readonly string Guid = "{25c96df7-b2ec-4db1-ac49-f77ca28bd5d5}";

        private static readonly string FeatureName = $"{BaseName}Challenge";
        private static readonly string DisplayName = GenericAbilityGlossary.Challenge;
        private static readonly string Description = $"{FeatureName}.Description";

        internal static void Configure()
        {
            var condition = ConditionsBuilder.New()
                .HasBuffFromCaster(BuffRefs.CavalierChallengeBuffTarget.ToString())
                .HasBuffWithDescriptor(spellDescriptor: SpellDescriptor.Fear);

            var config = ContextRankConfigs
                .ClassLevel(classes: [CharacterClassRefs.CavalierClass.ToString()]);

            config.m_Progression = ContextRankProgression.OnePlusDivStep;
            config.m_StepLevel = 4;

            var value = ContextValues.Rank();

            FeatureConfigurator.New(FeatureName, Guid)
                .AddAttackBonusConditional(bonus: value, conditions: condition, descriptor: ModifierDescriptor.Competence)
                .AddContextRankConfig(config)
                .SetIsClassFeature(true)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }
}