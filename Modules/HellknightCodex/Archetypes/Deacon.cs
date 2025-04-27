using BlueprintCore.Blueprints.Configurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using LostChapters.Modules.GraySisterhood.Archetypes.ClassFeatures;
using LostChapters.Modules.GraySisterhood.Feats.Selection;

namespace LostChapters.Modules.GraySisterhood.Archetypes
{
    internal class Deacon
    {
        public static string Guid => ArchetypeGuid;

        private static readonly string Archetype = "Deacon";
        private static readonly string ArchetypeGuid = "c5992d58-4318-4eb1-9f3e-692eb9615525";

        private static readonly string ArchetypeDisplayName = "Deacon.BuffName";
        private static readonly string ArchetypeDescription = "Deacon.LocalizedDescription";

        private static readonly string FeatName = "FeatCap";
        public static readonly string FeatGuid = "43ec0de7-628a-4cfa-914b-b9d1204a6eb0";

        private static readonly string FeatDisplayName = "FeatCap.BuffName";
        private static readonly string FeatDescription = "FeatCap.LocalizedDescription";

        public static void Configure()
        {
            var cap = FeatureConfigurator.New(FeatName, FeatGuid)
                .SetDescription(FeatDescription)
                .SetDisplayName(FeatDisplayName)
                .Configure();

            ArchetypeConfigurator.New(Archetype, ArchetypeGuid, CharacterClassRefs.WarpriestClass)
                .AddToRemoveFeatures(04, FeatureRefs.SacredWeaponEnchantFeature.ToString())
                .AddToRemoveFeatures(08, FeatureRefs.SacredWeaponEnchantPlus2.ToString())
                .AddToRemoveFeatures(12, FeatureRefs.SacredWeaponEnchantPlus3.ToString())
                .AddToRemoveFeatures(16, FeatureRefs.SacredWeaponEnchantPlus4.ToString())
                .AddToRemoveFeatures(20, FeatureRefs.SacredWeaponEnchantPlus5.ToString())
                .AddToRemoveFeatures(07, FeatureRefs.SacredArmorFeature.ToString())
                .AddToRemoveFeatures(10, FeatureRefs.SacredArmorEnchantPlus2.ToString())
                .AddToRemoveFeatures(13, FeatureRefs.SacredArmorEnchantPlus3.ToString())
                .AddToRemoveFeatures(16, FeatureRefs.SacredArmorEnchantPlus4.ToString())
                .AddToRemoveFeatures(19, FeatureRefs.SacredArmorEnchantPlus5.ToString())
                .AddToRemoveFeatures(01, FeatureSelectionRefs.BlessingSelection.ToString())
                .AddToRemoveFeatures(01, FeatureSelectionRefs.SecondBlessingSelection.ToString())
                .AddToAddFeatures(01, CapellanIncenseClassFeature.CreateCapellanIncense())
                .AddToAddFeatures(04, CapellanIncenseSelector.Guid)
                .AddToAddFeatures(07, CapellanIncenseSelector.Guid)
                .AddToAddFeatures(10, CapellanIncenseSelector.Guid)
                .AddToAddFeatures(13, CapellanIncenseSelector.Guid)
                .AddToAddFeatures(16, CapellanIncenseSelector.Guid)
                .AddToAddFeatures(19, CapellanIncenseSelector.Guid)
                .AddToAddFeatures(10, cap)
                .SetLocalizedName(ArchetypeDisplayName)
                .SetLocalizedDescription(ArchetypeDescription)
                .Configure();
        }
    }
}
