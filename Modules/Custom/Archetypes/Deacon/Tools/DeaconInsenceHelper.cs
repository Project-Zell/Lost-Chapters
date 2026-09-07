using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.Classes.Selection;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using BlueprintCore.Utils.Types;
using JetBrains.Annotations;

namespace LostChapters.Modules.Custom.Archetypes.Deacon.Tools;

public static class DeaconInsenceHelper
{
    public enum TargetType { Ally, Enemy, Self }

    private readonly static string BaseName = "DeaconInsence";

    private readonly static string MinorFeatureKey = "MinorFeature";
    private readonly static string MajorFeatureKey = "MajorFeature";

    private readonly static string ProgressionKey = "Progression";
    private readonly static string DisplayNameKey = ".Name";
    private readonly static string DescriptionKey = ".Description";

    internal static readonly string NormalIcon = $"{CustomModule.IconPath}/{DeaconArchetype.BaseName}/{BaseName}.png".ToLower();
    internal static readonly string InfusedIcon = $"{CustomModule.IconPath}/{DeaconArchetype.BaseName}/{BaseName}Infused.png".ToLower();

    internal static void CreateInsence(string domainGuid, string baseName, string minorFeatureGuid, string majorFeatureGuid, string extraIncenceGuid,
        (string buffGuid, TargetType type)[] minorBuffs, (string buffGuid, TargetType type)[] majorBuffs)
    {
        var minorName = $"{baseName}{MinorFeatureKey}";
        var minorDisplayName = $"{minorName}{DisplayNameKey}";
        var minorDescription = $"{minorName}{DescriptionKey}";

        ConfigureBaseFeature(
            domain: domainGuid,
            featureName: minorName, 
            featureGuid: minorFeatureGuid, 
            displayName: minorDisplayName,
            description: minorDescription);

        var majorName = $"{baseName}{MajorFeatureKey}";
        var majorDisplayName = $"{majorName}{DisplayNameKey}";
        var majorDescription = $"{majorName}{DescriptionKey}";
        
        ConfigureBaseFeature(
            domain: domainGuid, 
            featureName: majorName, 
            featureGuid: majorFeatureGuid,
            displayName: majorDisplayName,
            description: majorDescription, 
            prerequisite: minorFeatureGuid);

        var area = AbilityAreaEffectConfigurator.For(CenserBurnerFeature.AbilityArea.Guid);

        SetupAreaEffect(minorDisplayName, minorDescription, area, minorBuffs, minorFeatureGuid, majorFeatureGuid, isMinor: true);
        SetupAreaEffect(majorDisplayName, majorDescription, area, majorBuffs, minorFeatureGuid, majorFeatureGuid, isMinor: false);

        area.Configure();

        FeatureSelectionConfigurator.For(BlessedIncenseSelector.Guid)
            .AddToAllFeatures([minorFeatureGuid, majorFeatureGuid])
            .Configure();

        ConfigureExtraIncense(baseName, domainGuid, extraIncenceGuid, minorFeatureGuid, majorFeatureGuid);
    }

    private static void ConfigureBaseFeature(string domain, string featureName, string featureGuid, string displayName, string description, [CanBeNull] string prerequisite = null)
    {
        var configurator = FeatureConfigurator.New(featureName, featureGuid)
            .AddPrerequisiteFeature(domain, hideInUI: true)
            .SetIsClassFeature(true)
            .SetDisplayName(displayName)
            .SetDescription(description);

        if (prerequisite != null)
        {
            configurator.AddPrerequisiteFeature(prerequisite).AddPrerequisiteFeature(IncenseInsufionFeature.Guid).SetIcon(InfusedIcon);
        }
        else
        {
            configurator.SetIcon(NormalIcon);
        }

        configurator.Configure();
    }

    private static void SetupAreaEffect(string displayName, string description,
        AbilityAreaEffectConfigurator area, (string buffGuid, TargetType type)[] buffContainers, 
        string minorFeatureGuid, string majorFeatureGuid, bool isMinor)
    {
        foreach (var (buffGuid, type) in buffContainers)
        {
            var condition = type switch
            {
                TargetType.Ally => ConditionsBuilder.New().IsAlly(),
                TargetType.Enemy => ConditionsBuilder.New().IsEnemy(),
                TargetType.Self => ConditionsBuilder.New().IsCaster(),
                _ => null
            };

            if (condition == null)
                continue;

            condition.CasterHasFact(minorFeatureGuid).CasterHasFact(majorFeatureGuid, negate: isMinor);

            area.AddAbilityAreaEffectBuff(buff: buffGuid, condition: condition);

            BuffConfigurator.For(buffGuid)
                .SetDisplayName(displayName)
                .SetDescription(description)
                .SetIcon(NormalIcon)
                .Configure();
        }
    }

    private static void ConfigureExtraIncense(string baseName, string domainGuid, string progressionGuid, string minorFeatureGuid, string majorFeatureGuid)
    {
        var progressionName = $"{baseName}{ProgressionKey}";
        var progressionDisplayName = $"{progressionName}{DisplayNameKey}";
        var progressionDescription = $"{progressionName}{DescriptionKey}";

        var removeFeaturesEntryBuilder = LevelEntryBuilder.New()
            .AddEntry(level: 01, features: minorFeatureGuid)
            .AddEntry(level: 10, features: majorFeatureGuid);

        ProgressionConfigurator.New(progressionName, progressionGuid)
            .AddPrerequisiteNoFeature(feature: domainGuid, checkInProgression: true, hideInUI: true)
            .SetClasses(classes: CharacterClassRefs.WarpriestClass.ToString())
            .SetArchetypes(archetypes: DeaconArchetype.Guid)
            .SetLevelEntries(removeFeaturesEntryBuilder)
            .SetUIGroups(UIGroupBuilder.New().AddGroup([minorFeatureGuid, majorFeatureGuid]))
            .SetGiveFeaturesForPreviousLevels(true)
            .SetIsClassFeature(true)
            .SetDisplayName(progressionDisplayName)
            .SetDescription(progressionDescription)
            .Configure();

        FeatureSelectionConfigurator.For(ImposibleIncenseSelector.Guid)
            .AddToAllFeatures([progressionName])
            .Configure();
    }
}