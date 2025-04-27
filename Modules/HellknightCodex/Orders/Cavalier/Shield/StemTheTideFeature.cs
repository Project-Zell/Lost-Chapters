using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;

namespace LostChapters.Modules.GraySisterhood.Orders.Cavalier.Shield;

internal class StemTheTideFeature
{
    public static readonly string Guid = "{af63be2f-b9c0-4442-9847-a7fc822707cb}";

    private static readonly string FeatureName = "StemTheTide";
    private static readonly string DisplayName = "StemTheTide.Name";
    private static readonly string Description = "StemTheTide.Description";

    public static void Configure()
    {
        var condition = ConditionsBuilder.New().CasterHasFact(null);

        FeatureConfigurator.New(FeatureName, Guid)
            //.AddAttackBonusConditional()
            //.AddFacts([StandStill.Guid])
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .Configure();
    }
}
