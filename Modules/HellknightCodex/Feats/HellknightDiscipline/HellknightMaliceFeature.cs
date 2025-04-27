using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using LostChapters.Modules.GraySisterhood.Components;
using LostChapters.Modules.GraySisterhood.Feats.Selection;

namespace LostChapters.Modules.GraySisterhood.Feats.HellknightDiscipline
{
    internal class HellknightMaliceFeature
    {
        public static readonly string FeatGuid = "663afdee-8b29-4de9-ac5d-50c66a0c62e7";

        private const string FeatName = "HellknightMalice";
        private const string DisplayName = "HellknightMalice.BuffName";
        private const string Description = "HellknightMalice.LocalizedDescription";

        public static void Configure()
        {
            FeatureConfigurator.New(FeatName, FeatGuid)
                .AddToFeatureSelection(HellknightDisciplineSelection.Guid)
                .AddComponent<HellknightMalice>()
                .AddFeatureTagsComponent(FeatureTag.ClassSpecific | FeatureTag.Attack | FeatureTag.Damage)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }
}
