using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.EntitySystem.Stats;
using LostChapters.Tools;

namespace LostChapters.Modules.GraySisterhood.Feats;

internal class HarryingPartnersFeature
{
    public static readonly string Guid = "{ec86c96c-603b-43a1-bf9b-399146b32131}";

    public static readonly string CavalierBuffGuid = "{5b40ea9f-1cc1-44b7-9986-d1bd9c406f2b}";
    public static readonly string VanguardBuffGuid = "{f21448d1-5c62-42f3-99a3-50fe8ede3442}";
    public static readonly string VanguardAbilityGuid = "{0c035520-bac6-4d53-850c-316b1bfcfbab}";
    public static readonly string PackRagerBuffGuid = "{30447db6-de1c-49b5-8520-a6a363e9533e}";
    public static readonly string PackRagerAreaGuid = "{267eeda8-122f-462d-a229-25ce3f3c086b}";
    public static readonly string PackRagerAreaBuffGuid = "{7443d8ab-c7aa-410b-8211-1ba484116606}";
    public static readonly string PackRagerToggleBuffGuid = "{739d4d39-5f82-43c0-ad3f-ba4a61f9bd6b}";
    public static readonly string PackRagerToggleGuid = "{4ebe30f5-df58-4e86-b13f-f06b2168d360}";
    public static readonly string ForesterAbilityGuid = "{bc34a9dc-f0bb-4d08-b180-935dc23fc273}";

    private static readonly string FeatureName = "HarryingPartners";
    private static readonly string DisplayName = "HarryingPartners.Name";
    private static readonly string Description = "HarryingPartners.Description";

    private static readonly string Icon = $"{GraySisterhoodModule.IconPath}/harryingpartners.png";

    public static void Configure()
    {
        var feature = FeatureConfigurator.New(FeatureName, Guid, FeatureGroup.Feat, FeatureGroup.CombatFeat, FeatureGroup.TeamworkFeat)
            .AddPrerequisiteStatValue(stat: StatType.BaseAttackBonus, value: 6)
            .AddPrerequisiteStatValue(stat: StatType.Intelligence, value: 3)
            .AddFeatureTagsComponent(featureTags: FeatureTag.Teamwork | FeatureTag.Attack | FeatureTag.Defense)
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
            .AddFeatureTagsComponent(FeatureTag.Teamwork | FeatureTag.Melee | FeatureTag.Attack | FeatureTag.Defense)
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            //.SetIcon(Icon)
            .Configure();

        feature.AddAsDLCTeamworkFeat(foresterAbilityGuid: ForesterAbilityGuid, vanguardBuffGuid: VanguardBuffGuid);
    }
}
