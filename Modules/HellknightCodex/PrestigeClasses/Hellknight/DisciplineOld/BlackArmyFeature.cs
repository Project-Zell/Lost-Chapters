using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.Classes.Selection;
using LostChapters.Modules.HellknightCodex.Components;

namespace LostChapters.Modules.HellknightCodex.PrestigeClasses.Hellknight.DisciplineOld;

internal class BlackArmyFeature
{
    public static readonly string Guid = "04aa192f-b84b-4ecd-9edf-6b47540ee2ce";

    private static readonly string FeatureName = "BlackArmy";
    private static readonly string DisplayName = $"{FeatureName}.Name";
    private static readonly string Description = $"{FeatureName}.Description";

    public static void Configure()
    {
        FeatureConfigurator.New(FeatureName, Guid)
            .AddToFeatureSelection(HellknightDisciplineSelection.Guid)
            .AddPrerequisiteClassLevel(characterClass: CharacterClassRefs.HellknightClass.ToString(), level: 6, group: Prerequisite.GroupType.Any)
            .AddPrerequisiteClassLevel(characterClass: CharacterClassRefs.HellknightSigniferClass.ToString(), level: 6, group: Prerequisite.GroupType.Any)
            .AddComponent<BlackArmy>()
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .AddFeatureTagsComponent(FeatureTag.Damage | FeatureTag.SavingThrows | FeatureTag.ClassSpecific)
            .Configure();
    }
}
