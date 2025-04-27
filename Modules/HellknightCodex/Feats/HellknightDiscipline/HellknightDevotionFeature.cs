using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using LostChapters.Modules.GraySisterhood.Feats.Selection;

namespace LostChapters.Modules.GraySisterhood.Feats.HellknightDiscipline
{
    internal class HellknightDevotionFeature
    {
        public static readonly string Guid = "83cf0aa3-662a-4899-ba52-4bc8cc40c30e";

        private const string FeatName = "HellknightDevotion";
        private const string DisplayName = "HellknightDevotion.BuffName";
        private const string Description = "HellknightDevotion.LocalizedDescription";

        public static void Configure()
        {
            FeatureConfigurator.New(FeatName, Guid)
                .AddToFeatureSelection(HellknightDisciplineSelection.Guid)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .AddFeatureTagsComponent(FeatureTag.ClassSpecific)
                .Configure();
        }
    }
}
