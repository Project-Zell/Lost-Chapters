using BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.UnitLogic.ActivatableAbilities;
using Kingmaker.UnitLogic.FactLogic;

namespace LostChapters.Modules.Custom.Archetypes.BlackKnight;

internal class RevenantFeature
{
    //Get blur against challenged target

    public static readonly string Guid = "{3bb6991c-9f2c-436d-a39d-5fd20ae44083}";

    private static readonly string BaseName = "Revenant";

    private static readonly string FeatureName = $"{BaseName}Feature";
    private static readonly string DisplayName = $"{FeatureName}.Name";
    private static readonly string Description = $"{FeatureName}.Description";

    //private static readonly string Icon = $"{CustomModule.IconPath}/ .png";

    internal static void Configure()
    {
        ConditionsBuilder.New().HasBuffFromCaster(buff: BuffRefs.CavalierChallengeBuffTarget.ToString());

        FeatureConfigurator.New(FeatureName, Guid)
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            //.SetIcon(Icon)
            .Configure();
    }
}
