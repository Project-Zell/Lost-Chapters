using BlueprintCore.Blueprints.Configurators.Classes;
using BlueprintCore.Blueprints.References;
using LostChapters.Modules.HellknightCodex.AnimalCompanions.Hellhound;

namespace LostChapters.Tweaks;

internal class AnimalCompanionTweaks
{
    public static void Configure()
    {
        HellhoundCompanionRestriction();
    }

    private static void HellhoundCompanionRestriction()
    {
        CharacterClassConfigurator.For(CharacterClassRefs.AnimalCompanionClass.ToString())
            //.AddPrerequisiteNoFeature(feature: HellhoundFeature.Guid, hideInUI: false)
            //.SetHideIfRestricted(true)
            .Configure(true);
    }
}
