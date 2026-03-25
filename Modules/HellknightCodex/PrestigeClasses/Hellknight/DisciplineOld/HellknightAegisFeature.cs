using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using LostChapters.Modules.HellknightCodex.Components;

namespace LostChapters.Modules.HellknightCodex.PrestigeClasses.Hellknight.DisciplineOld
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
