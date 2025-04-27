using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.UI.MVVM._ConsoleView.InfoWindow;
using Kingmaker.Visual;
using LostChapters.Modules.GraySisterhood.Components;
using LostChapters.Modules.GraySisterhood.Feats.HellknightCodex;

namespace LostChapters.Modules.GraySisterhood.Feats
{
    internal class HellhoundCompanionUnit
    {
        public static readonly string Guid = "d6ed9b34-a6dc-40d4-80ec-4498e26317da";

        private const string UnitName = "HellhoundCompanion";
        private const string UnitLocalizedName = "Hellhound.BuffName";

        public static void Configure()
        {
            var unitBody = new BlueprintUnit.UnitBody
            {
                m_PrimaryHand = ItemWeaponRefs.Bite1d6.Reference.Get().ToReference<BlueprintItemEquipmentHandReference>(),
                m_PrimaryHandAlternative1 = ItemWeaponRefs.Bite1d6.Reference.Get().ToReference<BlueprintItemEquipmentHandReference>(),
                m_PrimaryHandAlternative2 = ItemWeaponRefs.Bite1d6.Reference.Get().ToReference<BlueprintItemEquipmentHandReference>(),
                m_PrimaryHandAlternative3 = ItemWeaponRefs.Bite1d6.Reference.Get().ToReference<BlueprintItemEquipmentHandReference>(),
            };

            UnitConfigurator.New(UnitName, Guid)
                .CopyFrom(UnitRefs.HellhoundSummoned.ToString())
                .AddComponent<ResetSpawnFxOnStartOnLocationChange>()
                .SetFaction(FactionRefs.Neutrals.ToString())
                .SetBody(unitBody)
                .AddClassLevels(characterClass: HellhoundAnimalClass.Reference, levels: 5)
                .SetStrength(23)
                .SetDexterity(23)
                .SetConstitution(18)
                .SetIntelligence(6)
                .SetWisdom(12)
                .SetCharisma(8)
                .SetAddFacts([
                    HellhoundFeature.Configure(),
                    FeatureRefs.TripDefenseFourLegs.ToString(),
                    FeatureRefs.AnimalCompanionNaturalArmor.ToString()])
                .SetLocalizedName(UnitRefs.CR3_HellhoundStandard.Reference.Get().LocalizedName)
                .SetPortrait(null)
                .Configure();
        }
    }

    internal class HellhoundFeature
    {
        public static readonly string Guid = "32d3caf2-fb13-4e0a-8d86-fb9dbde664d5";

        private const string FeatName = "HellhoundFeature";

        internal static BlueprintFeature Configure()
        {
            return FeatureConfigurator.New(FeatName, Guid)
                .SetHideInUI(true)
                .Configure();
        }
    }
}
