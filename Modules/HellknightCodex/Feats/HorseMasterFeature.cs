using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.EntitySystem.Stats;
using System.Collections.Generic;

namespace LostChapters.Modules.GraySisterhood.Feats
{
    public class HorseMasterFeature
    {
        private static readonly string FeatName = "HorseMaster";
        private static readonly string FeatGuid = "30de41dd-afeb-428b-bc9c-e83170d987d7";

        private static readonly string DisplayName = "HorseMaster.BuffName";
        private static readonly string Description = "HorseMaster.LocalizedDescription";
        private static readonly string Icon = "assets/icons/horsemaster.png";

        public static void Configure()
        {
            var animalCompanionHorsePrerequisite = new List<Blueprint<BlueprintFeatureReference>>
            {
                FeatureRefs.AnimalCompanionFeatureHorse.ToString(),
                FeatureRefs.AnimalCompanionFeatureHorse_PreorderBonus.ToString(),
                FeatureRefs.GhostRiderAnimalCompanionFeatureHorse.ToString()
            };

            FeatureConfigurator.New(FeatName, FeatGuid, [FeatureGroup.Feat, FeatureGroup.MountedCombatFeat])
                .AddPrerequisiteFeaturesFromList(animalCompanionHorsePrerequisite)
                .AddPrerequisiteClassLevel(CharacterClassRefs.CavalierClass.ToString(), 4)
                .AddPrerequisiteStatValue(StatType.SkillMobility, 6)
                .AddCompanionBoon(20, FeatureRefs.AnimalCompanionRank.ToString())
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(Icon)
                .AddFeatureTagsComponent(FeatureTag.Mounted | FeatureTag.ClassSpecific)
                .Configure();

            FeatureConfigurator.For(FeatureRefs.CompanionBoon.ToString())
                .AddPrerequisiteNoFeature(FeatGuid)
                .Configure();
        }
    }
}
