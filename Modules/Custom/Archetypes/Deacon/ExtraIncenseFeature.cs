using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using LostChapters.Components;

namespace LostChapters.Modules.Custom.Archetypes.Deacon;

internal class ExtraIncenseFeature
{
    public static readonly string Guid = "{c9d2aee8-7566-49fd-8c2d-ac4191fa2446}";

    private static readonly string BaseName = "ExtraIncense";

    private static readonly string FeatureName = $"{BaseName}Feature";
    private static readonly string DisplayName = $"{FeatureName}.Name";
    private static readonly string Description = $"{FeatureName}.Description";

    //private static readonly Sprite Icon = $"{_Module.IconPath}/ .png";

    internal static void Configure()
    {
        FeatureConfigurator.New(FeatureName, Guid, [FeatureGroup.Feat])
            .AddComponent<PrerequisiteHasArchetype>(prerequisite =>
            {
                prerequisite.CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(CharacterClassRefs.WarpriestClass.ToString());
                prerequisite.Archetype = BlueprintTool.GetRef<BlueprintArchetypeReference>(DeaconArchetype.Guid);
            })
            .AddIncreaseResourceAmount(resource: CenserBurnerFeature.Resource.Guid, value: 6)
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .AddFeatureTagsComponent(FeatureTag.ClassSpecific)
            .SetRanks(10)
            //.SetIcon(Icon)
            .Configure();
    }
}