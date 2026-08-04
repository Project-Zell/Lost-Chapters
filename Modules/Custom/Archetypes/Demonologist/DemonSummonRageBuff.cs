using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;

namespace LostChapters.Modules.Custom.Archetypes.Demonologist;

internal class DemonSummonRageBuff
{
    public static readonly string Guid = "{8e0bd389-2c81-454d-8168-4c678047649a}";

    private static readonly string BaseName = "DemonSummonRage";

    private static readonly string BuffName = $"{BaseName}Buff";
    private static readonly string DisplayName = $"{BuffName}.Name";
    private static readonly string Description = $"{BuffName}.Description";

    //private static readonly Sprite Icon = $"{_Module.IconPath}/ .png";

    internal static void Configure()
    {
        BuffConfigurator.New(BuffName, Guid)
            .AddFactsFromCaster(featureFromSelection: true, selection: FeatureSelectionRefs.RagePowerSelection.ToString())
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            //.AddFeatureTagsComponent()
            //.SetIcon(Icon)
            .Configure();
    }
}
