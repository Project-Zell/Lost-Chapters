using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using Kingmaker.EntitySystem.Stats;
using LostChapters.Modules.GraySisterhood.Feats.Selection;

namespace LostChapters.Modules.GraySisterhood.Feats.HellknightDiscipline
{
    internal class HellknightZealFeature
    {
        public static readonly string Guid = "5f52ba44-fc10-4a9e-bad4-ff292ffabf4b";

        private const string FeatName = "HellknightZeal";
        private const string DisplayName = "HellknightZeal.BuffName";
        private const string Description = "HellknightZeal.LocalizedDescription";

        public static void Configure()
        {
            FeatureConfigurator.New(FeatName, Guid)
                .AddToFeatureSelection(HellknightDisciplineSelection.Guid)
                .AddPrerequisiteStatValue(stat: StatType.BaseAttackBonus, value: 5)
                .AddDerivativeStatBonus(baseStat: StatType.Charisma, derivativeStat: StatType.Initiative)
                .AddRecalculateOnStatChange(stat: StatType.Charisma)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }
}
