using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using LostChapters.Modules.Custom.Archetypes.Demonologist.SummonUnits;

namespace LostChapters.Modules.Custom.Archetypes.Demonologist.SummonAbilities;

internal class SummonDemonIFeature
{
    public static readonly string Guid = "{e2e431bf-3f2a-493e-96cd-524cc6e60d68}";

    private static readonly string FeatureName = "SummonDemonIFeature";
    private static readonly string DisplayName = $"{FeatureName}.Name";
    private static readonly string Description = $"{FeatureName}.Description";

    private static readonly string Icon = $"{CustomModule.IconPath}/summondemon1.png";

    internal static void Configure()
    {
        QuasitSummonUnit.Configure();
        
        SummonDemonISingle.Configure();

        FeatureConfigurator.New(FeatureName, Guid)
            .AddFacts([SummonDemonISingle.Guid])
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .SetIcon(Icon)
            .Configure();
    }

    internal class SummonDemonISingle
    {
        public static readonly string Guid = "{f5ed109f-3b24-4718-8c1e-02e4561067d1}";

        private static readonly string AbilityName = $"{FeatureName}.MajorAbility";
        private static readonly string DisplayName = $"{AbilityName}.Name";
        private static readonly string Description = $"{AbilityName}.Description";

        internal static void Configure()
        {
            SummonAbilityHelper.CreateSummonAbility(
                guid: Guid,
                name: AbilityName,
                displayName: DisplayName,
                description: Description,
                icon: Icon,
                summonUnitID: QuasitSummonUnit.Guid,
                countType: SummonAbilityHelper.SummonCountType.single);
        }
    }
}
