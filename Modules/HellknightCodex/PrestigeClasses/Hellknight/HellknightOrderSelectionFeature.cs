using BlueprintCore.Blueprints.CustomConfigurators.Classes.Selection;
using BlueprintCore.Blueprints.References;

namespace LostChapters.Modules.HellknightCodex.PrestigeClasses.Hellknight;

internal class HellknightOrderSelectionFeature
{
    public static readonly string Guid = "{c872fb7a-a9a2-4203-bc17-7c5672d76714}";

    private static readonly string FeatureName = "HellknightOrderSelection";
    private static readonly string DisplayName = "HellknightOrderSelection.Name";
    private static readonly string Description = "HellknightOrderSelection.Description";

    internal static void Configure()
    {
        HellknightInitialOrderSelectionFeature.Configure();
        HellknightFakeOrderSelectionFeature.Configure();

        FeatureSelectionConfigurator.New(FeatureName, Guid)
            .AddToAllFeatures([HellknightInitialOrderSelectionFeature.Guid, HellknightFakeOrderSelectionFeature.Guid])
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            //.SetIcon(Icon)
            .Configure();
    }

    public class HellknightInitialOrderSelectionFeature
    {
        public static readonly string Guid = "{de9c933f-f67b-49d3-a182-eaf81e76d980}";

        private static readonly string FeatureName = "HellknightInitialOrderSelection";

        internal static void Configure()
        {
            FeatureSelectionConfigurator.New(FeatureName, Guid)
                .SetIsClassFeature(true)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                //.SetIcon(Icon)
                .Configure();
        }
    }

    public class HellknightFakeOrderSelectionFeature
    {
        public static readonly string Guid = "{4e6cd9ad-d390-4142-aa54-ada0900928f3}";

        private static readonly string FeatureName = "HellknightFakeOrderSelection";

        internal static void Configure()
        {
            FeatureSelectionConfigurator.New(FeatureName, Guid)
                .AddPrerequisiteFeature(FeatureSelectionRefs.HellKnightOrderSelection.ToString())
                .SetIsClassFeature(true)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                //.SetIcon(Icon)
                .Configure();
        }
    }
}
