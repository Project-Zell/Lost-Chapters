using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using Kingmaker.Blueprints.Classes.Spells;
using LostChapters._wip;
using LostChapters.Modules.Custom.PrestigeClasses.PlagueKnight.Components;

namespace LostChapters.Modules.Custom.PrestigeClasses.PlagueKnight;

internal class IncubatingPainFeature
{
    public static readonly string Guid = "{a7f60bf5-9878-48be-9767-58b3bbf66f5a}";

    private static readonly string FeatureName = "IncubatingPainFeature";
    private static readonly string DisplayName = $"{FeatureName}.Name";
    private static readonly string Description = $"{FeatureName}.Description";

    //private static readonly Sprite Icon = $"{_Module.IconPath}/ .png";

    internal static void Configure()
    {
        var descriptor = SpellDescriptor.Disease;
        var attackBonus = new AttackBonusFromSpellDescriptorCountOnTarget() { spellDescriptor = descriptor };
        var damageBonus = new DamageBonusFromSpellDescriptorCountOnTarget() { spellDescriptor = descriptor };

        FeatureConfigurator.New(FeatureName, Guid)
            .AddComponent(attackBonus)
            .AddComponent(damageBonus)
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            //.AddFeatureTagsComponent()
            //.SetIcon(Icon)
            .Configure();
    }
}
