using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Enums;

namespace LostChapters.Modules.GraySisterhood.Feats
{
    internal class ReapingStalker
    {
        private static readonly string FeatName = "ReapingStalker";
        private static readonly string FeatGuid = "b94c0624-cece-4357-a65c-f338420e4d62";

        private static readonly string DisplayName = "ReapingStalker.BuffName";
        private static readonly string Description = "ReapingStalker.LocalizedDescription";

        public static void Configure()
        {
            FeatureConfigurator.New(FeatName, FeatGuid, FeatureGroup.SlayerTalent)
                .AddPrerequisiteFeature(FeatureRefs.AdvanceTalents.ToString())
                .AddWeaponSizeChange(category: WeaponCategory.Scythe, checkWeaponCategory: true, sizeCategoryChange: 1)
                .AddWeaponSizeChange(category: WeaponCategory.Sickle, checkWeaponCategory: true, sizeCategoryChange: 1)
                .AddWeaponTypeCriticalEdgeIncrease(weaponType: WeaponTypeRefs.Scythe.Reference.GetBlueprint())
                .AddWeaponTypeCriticalEdgeIncrease(weaponType: WeaponTypeRefs.Sickle.Reference.GetBlueprint())
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .AddFeatureTagsComponent(FeatureTag.Attack | FeatureTag.Critical | FeatureTag.Melee)
                .Configure();
        }
    }
}
