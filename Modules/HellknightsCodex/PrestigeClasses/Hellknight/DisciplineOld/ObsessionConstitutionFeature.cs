using BlueprintCore.Blueprints.CustomConfigurators.Classes;

namespace LostChapters.Modules.HellknightCodex.PrestigeClasses.Hellknight.DisciplineOld
{
    internal class ObsessionConstitutionFeature
    {
        public static readonly string FeatGuid = "4df854e2-067d-4a2f-a618-1d2b739db166";

        private const string FeatName = "ObsessionConstitution";
        private const string DisplayName = "ObsessionConstitution.BuffName";
        private const string Description = "ObsessionConstitution.LocalizedDescription";

        public static void Configure()
        {
            FeatureConfigurator.New(FeatName, FeatGuid)
                .AddToFeatureSelection(HellknightDisciplineSelection.Guid)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }
}
