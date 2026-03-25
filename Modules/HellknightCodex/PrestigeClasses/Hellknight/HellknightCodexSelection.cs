using BlueprintCore.Blueprints.CustomConfigurators.Classes.Selection;
using Kingmaker.UI.MVVM._PCView.ServiceWindows.Inventory;
using LostChapters.Modules.HellknightCodex.PrestigeClasses.Hellknight.Codex;

namespace LostChapters.Modules.HellknightCodex.PrestigeClasses.Hellknight;

internal class HellknightCodexSelection
{
    public static readonly string Guid = "{93466c1d-caef-4427-a711-d97de89d0e31}";

    private static readonly string FeatureName = "HellknightCodexSelection";
    private static readonly string DisplayName = $"{FeatureName}.Name";
    private static readonly string Description = $"{FeatureName}.Description";

    //private static readonly Sprite Icon = $"{_Module.IconPath}/ .png";

    internal static void Configure()
    {
        DelegatedJudgmentProgression.Configure();
        ImposingPresenceProgression.Configure();
        MercilessnessProgression.Configure();
        TrackerCodexProgression.Configure();

        FeatureSelectionConfigurator.New(FeatureName, Guid)
            .AddToAllFeatures([
                DelegatedJudgmentProgression.Guid,
                ImposingPresenceProgression.Guid,
                MercilessnessProgression.Guid,
                TrackerCodexProgression.Guid,
                ])
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            //.AddFeatureTagsComponent()
            //.SetIcon(Icon)
            .Configure();
    }
}
