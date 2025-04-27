using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using LostChapters.Modules.GraySisterhood.Components;
using LostChapters.Modules.GraySisterhood.Feats.Selection;

namespace LostChapters.Modules.GraySisterhood.Feats.HellknightDiscipline
{
    internal class SeekingJusticeFeature
    {
        public static readonly string Guid = "53de467d-7494-48a0-b4bf-1bb0c909b6d9";

        private const string FeatName = "SeekingJustice";
        private const string DisplayName = "SeekingJustice.BuffName";
        private const string Description = "SeekingJustice.LocalizedDescription";

        public static void Configure()
        {
            FeatureConfigurator.New(FeatName, Guid)
                .AddComponent<SeekingJustice>()
                .AddToFeatureSelection(HellknightDisciplineSelection.Guid)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }
}
