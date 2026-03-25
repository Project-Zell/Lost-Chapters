using BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using LostChapters.Modules.HellknightCodex.Archetypes.Deacon;

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
                .AddToUIGroups(new Blueprint<BlueprintFeatureBaseReference>[] { DeaconIncenseFeature.Guid, DeaconIncenseSelector.Guid })
                .Configure();

        }
    }
}
