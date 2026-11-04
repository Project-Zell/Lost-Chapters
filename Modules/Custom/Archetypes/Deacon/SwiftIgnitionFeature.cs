using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.UnitLogic.Commands.Base;
using Kingmaker.Blueprints.Classes;

namespace LostChapters.Modules.Custom.Archetypes.Deacon;

internal class SwiftIgnitionFeature
{
    public static readonly string Guid = "{28bcdabd-8a92-4f0b-9bfd-4c939abbb2f3}";

    private static readonly string BaseName = "SwiftIgnition";

    private static readonly string FeatureName = $"{BaseName}Feature";
    private static readonly string DisplayName = $"{FeatureName}.Name";
    private static readonly string Description = $"{FeatureName}.Description";

    //private static readonly Sprite Icon = $"{_Module.IconPath}/ .png";

    internal static void Configure()
    {
        FeatureConfigurator.New(FeatureName, Guid, [FeatureGroup.Feat])
            .AddPrerequisiteArchetypeLevel(
                characterClass: CharacterClassRefs.WarpriestClass.ToString(),
                archetype: DeaconArchetype.Guid,
                level: 8)
            .AddChangeActivatableAbilitiesCommandType(
                activatableAbilities: [CenserBurnerFeature.ActivatableAbility.Guid],
                newCommandType: UnitCommand.CommandType.Swift)
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .AddFeatureTagsComponent(FeatureTag.ClassSpecific)
            //.SetIcon(Icon)
            .Configure();
    }
}