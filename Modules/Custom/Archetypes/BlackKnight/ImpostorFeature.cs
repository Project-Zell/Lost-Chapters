using BlueprintCore.Blueprints.CustomConfigurators.Classes.Selection;
using BlueprintCore.Blueprints.References;
using LostChapters.Tools;

namespace LostChapters.Modules.Custom.Archetypes.BlackKnight;

internal class ImpostorFeature
{
    public static readonly string Guid = "{d0c9b52f-faf9-4dd1-82b2-e813fb2a4036}";

    private static readonly string FeatureName = "Impostor";
    private static readonly string DisplayName = "Impostor.Name";
    private static readonly string Description = "Impostor.Description";

    //private static readonly string Icon = $"{CustomModule.IconPath}/ .png";

    public static readonly string OrderOfTheLionGuid = "{dc7249d9-1b33-4ce9-a20f-ccd235a5a9ae}";
    public static readonly string OrderOfTheStarGuid = "{d21ebb03-a312-45b8-8158-5eae7baeea00}";
    public static readonly string OrderOfTheSwordGuid = "{4336a964-d8d9-4c18-98f1-1e5e61178002}";
    public static readonly string OrderOfTheShroudGuid = "{852da633-d2f9-47b7-a058-44280aeaba53}";
    public static readonly string OrderOfTheCockatriceGuid = "{64b1e2b5-c716-4841-af57-48eaddef505a}";

    internal static void Configure()
    {
        FeatureSelectionConfigurator.New(FeatureName, Guid)
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            //.SetIcon(Icon)
            .Configure();

        BlackKnightImpostorConfigurator.AddFeatureToImpostorSelection(
            order: ProgressionRefs.CavalierOrderOfTheLionProgression.Reference,
            features: [FeatureRefs.CavalierLionsCall.Reference.Get()],
            guid: OrderOfTheLionGuid);

        BlackKnightImpostorConfigurator.AddFeatureToImpostorSelection(
            order: ProgressionRefs.CavalierOrderOfTheStarProgression.Reference,
            features: [FeatureRefs.CavalierCalling.Reference.Get(), FeatureRefs.CavalierCallingChannelFeature.Reference.Get()],
            guid: OrderOfTheStarGuid);

        BlackKnightImpostorConfigurator.AddFeatureToImpostorSelection(
            order: ProgressionRefs.CavalierOrderOfTheSwordProgression.Reference,
            selection: FeatureSelectionRefs.CavalierByMyHonorSelection.Reference,
            guid: OrderOfTheSwordGuid);

        BlackKnightImpostorConfigurator.AddFeatureToImpostorSelection(
            order: ProgressionRefs.CavalierOrderOfTheShroudProgression.Reference,
            features: [FeatureRefs.CavalierSpiritualShield.Reference.Get()],
            guid: OrderOfTheShroudGuid);

        BlackKnightImpostorConfigurator.AddFeatureToImpostorSelection(
            order: ProgressionRefs.CavalierOrderOfTheCockatriceProgression.Reference,
            features: [FeatureRefs.DazzlingDisplayIgnoreWeaponNeed.Reference.Get(), FeatureRefs.CavalierBraggart.Reference.Get()],
            guid: OrderOfTheCockatriceGuid);
    }
}
