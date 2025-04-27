using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.Classes.Selection;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;

namespace LostChapters.Modules.GraySisterhood.Feats.HellknightCodex
{
    internal class InfiltratorCodex
    {
        public static readonly string Guid = "7cd5408d-d819-4de0-9d1a-b56b7c75d861";

        private const string CodexName = "InfiltratorCodex";
        private const string DisplayName = "InfiltratorCodex.BuffName";
        private const string Description = "InfiltratorCodex.Description";

        public static BlueprintProgression CreateCodex()
        {
            return ProgressionConfigurator.New(CodexName, Guid)
                .SetClasses([CharacterClassRefs.HellknightClass.ToString(), CharacterClassRefs.HellknightSigniferClass.ToString()])
                .AddToLevelEntry(2, FeatureRefs.SneakAttack.ToString())
                .AddToLevelEntry(5, FeatureRefs.SneakAttack.ToString())
                .AddToLevelEntry(8, FeatureRefs.SneakAttack.ToString())
                .AddToLevelEntry(10, InfiltratorCodexFinalFeatureSelection.CreateFeatureSelection())
                .SetRanks(3)
                .SetUIGroups(UIGroupBuilder.New()
                    .AddGroup(new Blueprint<BlueprintFeatureBaseReference>[] { FeatureRefs.SneakAttack.ToString(), InfiltratorCodexFinalFeatureSelection.Guid }))
                .SetIsClassFeature(true)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }

    internal class InfiltratorCodexFinalFeatureSelection
    {
        public static readonly string Guid = "9b1f4f69-50fb-49b9-a0f4-4b1d0b497f43";

        private const string FeatSelectionName = "InfiltratorCodex.DeaconIncenseDC";
        private const string DisplayName = "InfiltratorCodex.DeaconIncenseDC.BuffName";
        private const string Description = "InfiltratorCodex.DeaconIncenseDC.LocalizedDescription";

        internal static BlueprintFeatureSelection CreateFeatureSelection()
        {
            return FeatureSelectionConfigurator.New(FeatSelectionName, Guid)
                .SetAllFeatures(
                    FeatureRefs.FocusingAttackConfused.ToString(),
                    FeatureRefs.FocusingAttackShaken.ToString(),
                    FeatureRefs.FocusingAttackSickened.ToString(),
                    FeatureRefs.SlowReactions.ToString(),
                    FeatureRefs.WeakeningWoundFeature.ToString(),
                    FeatureRefs.BlindingStrike.ToString(),
                    FeatureRefs.ConfoundingBlades.ToString(),
                    FeatureRefs.CripplingStrike.ToString(),
                    FeatureRefs.DispellingAttack.ToString(),
                    FeatureRefs.WearyingStrike.ToString(),
                    FeatureRefs.ExecutionerPainfulStrike.ToString())
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.TricksterInvisibilityAlmostGreater.Reference.Get().Icon)
                .Configure();
        }
    }
}
