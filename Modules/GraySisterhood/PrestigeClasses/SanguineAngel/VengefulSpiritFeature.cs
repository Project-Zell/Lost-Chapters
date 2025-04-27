using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;

namespace LostChapters.Modules.GraySisterhood.PrestigeClasses.SanguineAngel;

internal class VengefulSpiritFeature
{
    public static readonly string Guid = "{636b0fb1-ba72-4b7b-a645-05e2bebc1a99}";

    private static readonly string FeatureName = "VengefulSpirit";
    private static readonly string DisplayName = "VengefulSpirit.Name";
    private static readonly string Description = "VengefulSpirit.Description";

    internal static void Configure()
    {
        FeatureConfigurator.New(FeatureName, Guid)
            .AddClassLevelsForPrerequisites(
                fakeClass: CharacterClassRefs.FighterClass.ToString(),
                actualClass: SanguineAngelClass.Guid,
                forSelection: FeatureSelectionRefs.BasicFeatSelection.ToString(),
                modifier: 1)
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .Configure();
    }
}
