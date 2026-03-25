using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Blueprints.Configurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.References;
using HarmonyLib;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Designers.EventConditionActionSystem.Conditions;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.RuleSystem;
using Kingmaker.UI.ServiceWindow;
using Kingmaker.UnitLogic.Abilities.Blueprints;

namespace LostChapters.Modules.HellknightCodex.AnimalCompanions.Hellhound;

internal class HellhoundClass
{
    public static readonly string Guid = "{6af97e5c-e30b-40c1-b312-3ca578b5fe2a}";

    private static readonly string ClassName = "HellhoundClass";
    private static readonly string LocalizedName = $"{ClassName}.LocalizedName";
    private static readonly string LocalizedDescription = $"{ClassName}.LocalizedDescription";

    public static void Configure()
    {
        HellhoundClassProgression.CreateProgression();
        HellhoundHellbiteFeature.Configure();
        HellhoundHellfireFeature.Configure();
        HellhoundCapstoneFeature.Configure();
        HellhoundSmartFeature.Configure();
        

        var hellhoundClass = CharacterClassConfigurator.New(ClassName, Guid)
            .AddPrerequisiteIsPet(checkInProgression: true, group: Prerequisite.GroupType.Any, hideInUI: true)
            .SetProgression(HellhoundClassProgression.Guid)
            .AddPrerequisiteFeature(HellhoundFeature.Guid)
            .SetSkillPoints(4)
            .SetHitDie(DiceType.D10)
            .SetBaseAttackBonus(StatProgressionRefs.BABMedium.ToString())
            .SetFortitudeSave(StatProgressionRefs.SavesHigh.ToString())
            .SetReflexSave(StatProgressionRefs.SavesHigh.ToString())
            .SetWillSave(StatProgressionRefs.SavesLow.ToString())
            .SetClassSkills([
                StatType.SkillAthletics,
                StatType.SkillMobility,
                StatType.SkillStealth,
                StatType.SkillPerception,
                StatType.SkillPersuasion])
            .SetLocalizedName(LocalizedName)
            .SetLocalizedDescription(LocalizedDescription)
            .SetHideIfRestricted(true)
            .Configure();

        var rootProgression = ResourcesLibrary.GetRoot().Progression;
        rootProgression.m_PetClasses = rootProgression.m_PetClasses.AddToArray(hellhoundClass.ToReference<BlueprintCharacterClassReference>());
    }
}



internal class HellhoundHellbiteFeature
{
    public static readonly string Guid = "087859fa-c21a-4a94-ac55-fe9d092e3fc0";

    private const string FeatName = "HellhoundHellbite";
    private const string DisplayName = "HellhoundHellbite.BuffName";
    private const string Description = "HellhoundHellbite.LocalizedDescription";

    internal static void Configure()
    {
        FeatureConfigurator.New(FeatName, Guid)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .Configure();
    }
}

internal class HellhoundHellfireFeature
{
    public static readonly string Guid = "28ab7a50-9ee9-4e04-a844-d75f9757bafc";

    private const string FeatName = "HellhoundHellfire";
    private const string DisplayName = "HellhoundHellfire.BuffName";
    private const string Description = "HellhoundHellfire.LocalizedDescription";

    internal static void Configure()
    {
        FeatureConfigurator.New(FeatName, Guid)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .Configure();
    }
}

internal class HellhoundSmartFeature
{
    public static readonly string Guid = "40a0b136-ea71-408c-9a4b-d74facaf0c53";

    private const string FeatName = "HellhoundSmart";
    private const string DisplayName = "HellhoundSmart.BuffName";
    private const string Description = "HellhoundSmart.LocalizedDescription";

    internal static void Configure()
    {
        FeatureConfigurator.New(FeatName, Guid)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .Configure();
    }
}

internal class HellhoundCapstoneFeature
{
    public static readonly string Guid = "5bf4205b-d3a6-4c1c-9beb-00aae9082e82";

    private const string FeatName = "HellhoundCapstone";
    private const string DisplayName = "HellhoundCapstone.BuffName";
    private const string Description = "HellhoundCapstone.LocalizedDescription";

    internal static void Configure()
    {
        FeatureConfigurator.New(FeatName, Guid)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .Configure();
    }
}
