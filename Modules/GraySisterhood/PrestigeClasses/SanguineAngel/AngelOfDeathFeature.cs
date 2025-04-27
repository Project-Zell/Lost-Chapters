using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using Kingmaker.Enums.Damage;

namespace LostChapters.Modules.GraySisterhood.PrestigeClasses.SanguineAngel;

internal class AngelOfDeathFeature
{
    public static readonly string Guid = "{c41f984c-f258-4f42-a9f8-c148784c82e4}";

    private static readonly string FeatureName = "AngelOfDeath";
    private static readonly string DisplayName = "AngelOfDeath.Name";
    private static readonly string Description = "AngelOfDeath.Description";

    internal static void Configure()
    {
        FeatureConfigurator.New(FeatureName, Guid)
            .AddFacts([FeatureRefs.OutsiderType.ToString(), BuffRefs.WingsAngelBlack.ToString()])
            .AddBuffMovementSpeed(value: 20)
            .AddDamageResistanceEnergy(type: DamageEnergyType.Fire, value: 30)
            .AddRecalculateConcealment(ignorePartial: true)
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .Configure();
    }
}
