using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.References;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.Visual.Particles;
using LostChapters.Modules.GraySisterhood.Components;
using LostChapters.Modules.HellknightCodex.Components;
using LostChapters.Modules.HellknightCodex.PrestigeClasses.Hellknight.Discipline;
using System.Drawing;
using static LostChapters.Modules.GraySisterhood.Feats.AidAnotherFeature;

namespace LostChapters.Modules.HellknightCodex.AnimalCompanions.Hellhound;

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

        //var ability = AbilityConfigurator.New("Hellhound.Text.Bruh.WhatAnActualFuckHappened", "95r90asxcz82-zxc-poiii0-293999s0135490132sudczx123asdzx")
        //    .CopyFrom(AbilityRefs.EyebiteAbility.ToString())
        //    //.AddComponent<TestInventoryCharacter>()
        //    .Configure();

        HellhoundClass.Configure();


        UnitConfigurator.For(UnitRefs.BlizzardServantUnit)
            .AddDisableAllFx()
            .Configure();

        var hellhound = UnitConfigurator.New(UnitName, Guid)
            .CopyFrom(UnitRefs.HellhoundSummoned.ToString())
            //.AddDisableClassAdditionalVisualSettings()
            //.AddDisableAllFx()
            .AddComponent<ResetSpawnFxOnStartOnLocationChange>()
            .SetFaction(FactionRefs.Player.ToString())
            .SetBody(unitBody)
            .AddClassLevels(characterClass: HellhoundClass.Guid, levels: 5)
            //.AddPregenDollSettings()
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
            .SetLocalizedName(UnitRefs.HellhoundSummoned.Reference.Get().LocalizedName)
            //.SetPortrait(null)
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
