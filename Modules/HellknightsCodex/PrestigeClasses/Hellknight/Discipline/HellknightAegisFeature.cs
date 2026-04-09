using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using LostChapters.Modules.HellknightCodex.Components;

namespace LostChapters.Modules.HellknightCodex.PrestigeClasses.Hellknight.Discipline;

internal class HellknightAegisFeature
{
    public static readonly string Guid = "{7fb73be5-04a0-49f2-ae82-48d846c2ce2f}";

    private static readonly string FeatureName = "HellknightAegisFeature";
    private static readonly string DisplayName = $"{FeatureName}.Name";
    private static readonly string Description = $"{FeatureName}.Description";

    public static void Configure()
    {
        FeatureConfigurator.New(FeatureName, Guid)
            .AddToFeatureSelection(HellknightDisciplineSelection.Guid)
            .AddComponent<HellknightAegis>()
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .Configure();
    }
}
