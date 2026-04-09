using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using Kingmaker.UnitLogic.FactLogic;

namespace LostChapters.Modules.HellknightCodex.PrestigeClasses.Hellknight.Discipline;

internal class FearsomenessFeature
{
    private static readonly string FeatGuid = "936015b4-3931-444e-98fb-8ad72041100c";

    private static readonly string FeatureName = "FearsomenessFeature";
    private static readonly string DisplayName = $"{FeatureName}.Name";
    private static readonly string Description = $"{FeatureName}.Description";

    internal static void Configure()
    {
        FeatureConfigurator.New(FeatureName, FeatGuid)
            .AddToFeatureSelection(HellknightDisciplineSelection.Guid)
            .AddMechanicsFeature(AddMechanicsFeature.MechanicsFeatureType.HellknightFearsomeness)
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .Configure();
    }
}
