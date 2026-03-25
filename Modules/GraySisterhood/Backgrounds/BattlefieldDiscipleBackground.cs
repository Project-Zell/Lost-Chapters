using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using LostChapters.Modules.GraySisterhood.Feats;

namespace LostChapters.Modules.GraySisterhood.Backgrounds;

internal class BattlefieldDiscipleBackground
{
    public static readonly string Guid = "{474652fb-b450-499a-a5ca-1fc7d8e83e4f}";

    private static readonly string FeauretName = "BattlefieldDiscipleBackground";
    private static readonly string DisplayName = "BattlefieldDiscipleBackground.Name";
    private static readonly string Description = "BattlefieldDiscipleBackground.Description";

    internal static void Configure()
    {
        FeatureConfigurator.New(FeauretName, Guid)
            .AddClassSkill(StatType.SkillAthletics)
            .AddBackgroundClassSkill(StatType.SkillAthletics)
            .AddFacts([FeatureRefs.ShortswordProficiency.Reference.Get(), FeatureRefs.LongswordProficiency.Reference.Get()])
            .AddToFeatureSelection(FeatureSelectionRefs.BackgroundsWarriorSelection.ToString())
            .AddStatBonus(stat: StatType.SaveWill, value: 1, descriptor: ModifierDescriptor.UntypedStackable)
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .Configure();
    }
}
