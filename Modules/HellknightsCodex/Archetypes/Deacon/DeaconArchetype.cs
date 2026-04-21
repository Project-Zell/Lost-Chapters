using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils.Types;
using LostChapters.Modules.HellknightsCodex.Archetypes.Deacon;

namespace LostChapters.Modules.HellknightCodex.Archetypes.Deacon;

internal class DeaconArchetype
{
    private static readonly string Guid = "{0ff62c42-b326-4a5c-ad5a-c54974f3cddf}";

    private static readonly string ArchetypeName = "Deacon";
    private static readonly string LocalizedName = $"{ArchetypeName}.Name";
    private static readonly string Description   = $"{ArchetypeName}.Description";

    public static void Configure()
    {
        DeaconIncenseFeature.Configure();
        DeaconIncenseSelector.Configure();
        DeaconImposibleIncenseSelector.Configure();

        var removeFeaturesEntryBuilder = LevelEntryBuilder.New()
            .AddEntry(level: 01, features: FeatureSelectionRefs.BlessingSelection.ToString())
            .AddEntry(level: 01, features: FeatureSelectionRefs.SecondBlessingSelection.ToString())
            .AddEntry(level: 04, features: FeatureRefs.SacredWeaponEnchantFeature.ToString())
            .AddEntry(level: 07, features: FeatureRefs.SacredArmorFeature.ToString())
            .AddEntry(level: 08, features: FeatureRefs.SacredWeaponEnchantPlus2.ToString())
            .AddEntry(level: 10, features: FeatureRefs.SacredArmorEnchantPlus2.ToString())
            .AddEntry(level: 12, features: FeatureRefs.SacredWeaponEnchantPlus3.ToString())
            .AddEntry(level: 13, features: FeatureRefs.SacredArmorEnchantPlus3.ToString())
            .AddEntry(level: 16, features: FeatureRefs.SacredWeaponEnchantPlus4.ToString())
            .AddEntry(level: 16, features: FeatureRefs.SacredArmorEnchantPlus4.ToString())
            .AddEntry(level: 19, features: FeatureRefs.SacredArmorEnchantPlus5.ToString())
            .AddEntry(level: 20, features: FeatureRefs.SacredWeaponEnchantPlus5.ToString());

        var addFeaturesEntryBuilder = LevelEntryBuilder.New()
            .AddEntry(level: 01, features: DeaconIncenseFeature.Guid)
            .AddEntry(level: 04, features: DeaconIncenseSelector.Guid)
            .AddEntry(level: 07, features: DeaconIncenseSelector.Guid)
            .AddEntry(level: 10, features: DeaconIncenseSelector.Guid)
            .AddEntry(level: 13, features: DeaconIncenseSelector.Guid)
            .AddEntry(level: 16, features: DeaconIncenseSelector.Guid)
            .AddEntry(level: 19, features: DeaconIncenseSelector.Guid);

        ArchetypeConfigurator.New(ArchetypeName, Guid, CharacterClassRefs.WarpriestClass)
            //.SetClassSkills([StatType.SkillPersuasion, StatType.SkillAthletics, StatType.SkillMobility, StatType.SkillStealth])
            .SetReplaceClassSkills(true)
            .SetAddFeatures(addFeaturesEntryBuilder)
            .SetRemoveFeatures(removeFeaturesEntryBuilder)
            .SetLocalizedName(LocalizedName)
            .SetLocalizedDescription(Description)
            .Configure();

        ProgressionConfigurator.For(ProgressionRefs.WarpriestProgression)
            .AddToUIGroups([DeaconIncenseFeature.Guid, DeaconIncenseSelector.Guid])
            .Configure();
    }
}
