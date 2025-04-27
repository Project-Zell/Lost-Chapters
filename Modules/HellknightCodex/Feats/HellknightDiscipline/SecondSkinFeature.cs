using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Utils.Types;
using Kingmaker.Enums;
using Kingmaker.EntitySystem.Stats;
using LostChapters.Modules.GraySisterhood.Feats.Selection;

namespace LostChapters.Modules.GraySisterhood.Feats.HellknightDiscipline
{
    internal class SecondSkinFeature
    {
        public static readonly string Guid = "ca9c2629-3ae0-4394-8f60-ee874215616f";

        private const string FeatName = "SecondSkin";
        private const string DisplayName = "SecondSkin.BuffName";
        private const string Description = "SecondSkin.LocalizedDescription";

        public static void Configure()
        {
            FeatureConfigurator.New(FeatName, Guid)
                .AddToFeatureSelection(HellknightDisciplineSelection.Guid)
                .AddContextStatBonus(StatType.SkillMobility, value: ContextValues.Rank(AbilityRankType.StatBonus))
                .AddContextStatBonus(StatType.SkillStealth, value: ContextValues.Rank(AbilityRankType.StatBonus))
                .AddContextStatBonus(StatType.SkillThievery, value: ContextValues.Rank(AbilityRankType.StatBonus))
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }
}
