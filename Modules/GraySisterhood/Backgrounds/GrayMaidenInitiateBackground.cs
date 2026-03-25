using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using Kingmaker.EntitySystem.Stats;
using LostChapters.Modules.GraySisterhood.Feats;

namespace LostChapters.Modules.GraySisterhood.Backgrounds
{
    internal class GrayMaidenInitiateBackground
    {
        public static readonly string Guid = "{80f4eb8c-35cd-42cd-8624-5ce6c1df863b}";

        private static readonly string FeatureName = "GrayMaidenInitiateBackground";
        private static readonly string DisplayName = "GrayMaidenInitiateBackground.Name";
        private static readonly string Description = "GrayMaidenInitiateBackground.Description";

        public static void Configure()
        {
            FeatureConfigurator.New(FeatureName, Guid)
                .AddClassSkill(StatType.SkillPersuasion)
                .AddBackgroundClassSkill(StatType.SkillPersuasion)
                .AddFacts([GrayMaidensTrainingFeature.Guid, FeatureRefs.LongswordProficiency.Reference.Get(), FeatureRefs.BucklerProficiency.Reference.Get()])
                .AddToFeatureSelection(FeatureSelectionRefs.BackgroundsRegionalSelection.ToString())
                .SetIsClassFeature(true)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }
}
