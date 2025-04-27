using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using Kingmaker.Blueprints.Classes;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Blueprints.Classes.Selection;
using LostChapters.Tools;
using LostChapters.Modules.Custom.Components;
using LostChapters.Modules.GraySisterhood;

namespace LostChapters.Modules.Custom.Feats;

internal class ScarredLegionFeature
{
    public static readonly string Guid = "{37c40013-fad7-4134-b293-ee5406326e90}";

    public static readonly string CavalierBuffGuid = "{0c8869a5-4bb8-4005-b04a-5ff358910629}";
    public static readonly string VanguardBuffGuid = "{ab14242f-c79c-4a4a-934f-f1cef1d36aba}";
    public static readonly string VanguardAbilityGuid = "{d60f770e-15cc-4cf9-8aaa-558d9d8f1869}";
    public static readonly string PackRagerBuffGuid = "{05029a65-dbee-4e1b-ad8d-5d5c0c7ecc00}";
    public static readonly string PackRagerAreaGuid = "{ddc3a678-82eb-46f8-9caf-ccce07803495}";
    public static readonly string PackRagerAreaBuffGuid = "{4d5ab775-eb64-43da-a472-febc484cc489}";
    public static readonly string PackRagerToggleBuffGuid = "{3b6e385d-a9ed-4d7c-92a4-2f606e9c0c94}";
    public static readonly string PackRagerToggleGuid = "{53555301-c88b-428a-abf6-dbdfa159d8b5}";
    public static readonly string ForesterAbilityGuid = "{2105cf8e-8176-43e6-b84e-f001560f21cb}";

    private static readonly string FeatureName = "ScarredLegion";
    private static readonly string DisplayName = "ScarredLegion.Name";
    private static readonly string Description = "ScarredLegion.Description";

    private static readonly string Icon = $"{GraySisterhoodModule.IconPath}/scarredlegion.png";

    internal static void Configure()
    {
        var feature = FeatureConfigurator.New(FeatureName, Guid, FeatureGroup.Feat, FeatureGroup.CombatFeat, FeatureGroup.TeamworkFeat)
            .AddPrerequisiteStatValue(stat: StatType.Intelligence, value: 3)
            .AddStatBonus(stat: StatType.CheckIntimidate, value: 2)
            .AddComponent<ScarredLegion>()
            .AddSavesFixerRecalculate()
            .AddAsTeamworkFeat(
                cavalierBuffGuid: CavalierBuffGuid,
                vanguardBuffGuid: VanguardBuffGuid,
                vanguardAbilityGuid: VanguardAbilityGuid,
                packRagerBuffGuid: PackRagerBuffGuid,
                packRagerAreaGuid: PackRagerAreaGuid,
                packRagerAreaBuffGuid: PackRagerAreaBuffGuid,
                packRagerToggleBuffGuid: PackRagerToggleBuffGuid,
                packRagerToggleGuid: PackRagerToggleGuid)
            .AddToFeatureSelection(FeatureSelectionRefs.DevilbanePriestTeamworkFeatSelection.ToString())
            .AddFacts([CavalierBuffGuid])
            .SetIsClassFeature(true)
            .AddFeatureTagsComponent(FeatureTag.Teamwork | FeatureTag.SavingThrows | FeatureTag.Skills)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            //.SetIcon(Icon)
            .Configure();

        feature.AddAsDLCTeamworkFeat(foresterAbilityGuid: ForesterAbilityGuid, vanguardBuffGuid: VanguardBuffGuid);
    }
}
