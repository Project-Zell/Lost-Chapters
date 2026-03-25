using BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.UnitLogic.ActivatableAbilities;
using Kingmaker.UnitLogic.FactLogic;

namespace LostChapters.Modules.Custom.Archetypes.BlackKnight;

internal class RevenantFeature
{
    //Get blur against challenged target

    public static readonly string Guid = "";

    private static readonly string FeatureName = "";
    private static readonly string DisplayName = ".Name";
    private static readonly string Description = ".Description";

    //private static readonly string Icon = $"{CustomModule.IconPath}/ .png";

    internal static void Configure()
    {
        FeatureConfigurator.New(FeatureName, Guid)
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            //.SetIcon(Icon)
            .Configure();

        var s = new SiezeTheMoment();

        var abilityGroup = (ActivatableAbilityGroup)63208;

        var siezeBuff = BuffConfigurator.New("SizeBuff", "{0-1-1-2}")
            .Configure();

        ActivatableAbilityConfigurator.New("Size", "{0-0-1-2")
            .SetGroup(abilityGroup)
            .SetWeightInGroup(1)
            .Configure();

        ActivatableAbilityConfigurator.New("Preci", "{0-0-1-3")
            .SetGroup(abilityGroup)
            .SetWeightInGroup(1)
            .Configure();
    }
}
