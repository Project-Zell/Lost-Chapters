using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using LostChapters.Modules.GraySisterhood.Components;
using LostChapters.Modules.GraySisterhood.Feats.Selection;

namespace LostChapters.Modules.GraySisterhood.Feats.HellknightDiscipline
{
    internal class HellknightAegisFeature
    {
        public static readonly string Guid = "abd571ff-3306-4fbd-bfaf-df8d11568d40";

        private const string FeatName = "HellknightAegis";
        private const string DisplayName = "HellknightAegis.BuffName";
        private const string Description = "HellknightAegis.LocalizedDescription";

        public static void Configure()
        {
            FeatureConfigurator.New(FeatName, Guid)
                .AddToFeatureSelection(HellknightDisciplineSelection.Guid)
                .AddComponent<HellknightAegis>()
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }
}
