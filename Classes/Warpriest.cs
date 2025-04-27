using BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using LostChapters.Modules.GraySisterhood.Archetypes.ClassFeatures;
using LostChapters.Modules.GraySisterhood.Feats.Selection;

namespace LostChapters.Classes
{
    internal class Warpriest
    {
        public static void Configure()
        {
            FeatureConfigurator.For(FeatureRefs.WarpriestSacredWeaponBaseDamageFeature)
                .SetIcon(AbilityRefs.BlessWeapon.Reference.Get().Icon)
                .Configure();

            ActivatableAbilityConfigurator.For(ActivatableAbilityRefs.WarpriestSacredWeaponSwitch)
                .SetIcon(AbilityRefs.BlessWeapon.Reference.Get().Icon)
                .Configure();

            ProgressionConfigurator.For(ProgressionRefs.WarpriestProgression)
                .AddToUIDeterminatorsGroup(new Blueprint<BlueprintFeatureBaseReference>[] {
                    FeatureRefs.WarpriestSacredWeapon.ToString() })
                .AddToUIGroups(new Blueprint<BlueprintFeatureBaseReference>[] { CapellanIncenseClassFeature.FeatGuid, CapellanIncenseSelector.Guid })
                .Configure();

        }
    }
}
