using BlueprintCore.Blueprints.Configurators.Classes;
using BlueprintCore.Blueprints.References;
using LostChapters.Modules.GraySisterhood.Feats;

namespace LostChapters.Tweaks
{
    internal class AnimalCompanionTweaks
    {
        public static void Configure()
        {
            HellhoundCompanionRestriction();
        }

        private static void HellhoundCompanionRestriction()
        {
            CharacterClassConfigurator.For(CharacterClassRefs.AnimalCompanionClass.ToString())
                .AddPrerequisiteNoFeature(feature: HellhoundFeature.Guid, hideInUI: true)
                .SetHideIfRestricted(true)
                .Configure(true);
        }
    }
}
