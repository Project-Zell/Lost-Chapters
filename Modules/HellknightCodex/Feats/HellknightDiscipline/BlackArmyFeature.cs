using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.EntitySystem.Stats;
using LostChapters.Modules.GraySisterhood.Components;
using LostChapters.Modules.GraySisterhood.Feats.Selection;

namespace LostChapters.Modules.GraySisterhood.Feats.HellknightDiscipline
{
    internal class BlackArmyFeature
    {
        public static readonly string Guid = "04aa192f-b84b-4ecd-9edf-6b47540ee2ce";

        private static readonly string Name = "BlackArmy";
        private static readonly string DisplayName = "BlackArmy.BuffName";
        private static readonly string Description = "BlackArmy.LocalizedDescription";

        public static void Configure()
        {
            FeatureConfigurator.New(Name, Guid)
                .AddToFeatureSelection(HellknightDisciplineSelection.Guid)
                .AddPrerequisiteStatValue(stat: StatType.BaseAttackBonus, value: 10)
                .AddComponent<BlackArmy>()
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .AddFeatureTagsComponent(FeatureTag.Damage | FeatureTag.SavingThrows | FeatureTag.ClassSpecific)
                .Configure();
        }
    }
}
