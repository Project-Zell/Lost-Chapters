using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.Blueprints.Classes.Selection;
using LostChapters.Modules.GraySisterhood.Feats.Selection;

namespace LostChapters.Modules.GraySisterhood.Feats.HellknightDiscipline
{
    internal class FearsomenessFeature
    {
        private static readonly string FeatGuid = "936015b4-3931-444e-98fb-8ad72041100c";

        private const string FeatName = "Fearsomeness";
        private const string DisplayName = "Fearsomeness.BuffName";
        private const string Description = "Fearsomeness.LocalizedDescription";

        public static void Configure()
        {
            FeatureConfigurator.New(FeatName, FeatGuid)
                .AddToFeatureSelection(HellknightDisciplineSelection.Guid)
                .AddMechanicsFeature(AddMechanicsFeature.MechanicsFeatureType.HellknightFearsomeness)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .AddFeatureTagsComponent(FeatureTag.Skills | FeatureTag.Attack | FeatureTag.ClassSpecific)
                .Configure();
        }
    }
}
