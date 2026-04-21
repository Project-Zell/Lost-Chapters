using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using LostChapters.Modules.GraySisterhood.Components;

namespace LostChapters.Modules.GraySisterhood.Archetypes.SisterInArms;

internal class DedicatedCommanderFeature
{
    public static readonly string Guid = "{244c72f1-792f-4a73-922a-3a13ba0d5d16}";

    private static readonly string FeatureName = "DedicatedCommander";
    private static readonly string DisplayName = "DedicatedCommander.Name";
    private static readonly string Description = "DedicatedCommander.Description";

    private static readonly string Icon = $"{GraySisterhoodModule.IconsPath}/dedicatedcommander.png";

    internal static void Configure()
    {
        FeatureConfigurator.New(FeatureName, Guid)
            .AddComponent<DedicatedCommander>()
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .SetIcon(Icon)
            .Configure();
    }
}
