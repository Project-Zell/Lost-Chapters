using BlueprintCore.Blueprints.Configurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using HarmonyLib;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items.Armors;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.RuleSystem;
using LostChapters.Modules.GraySisterhood.PrestigeClasses.SanguineAngel;

namespace LostChapters.Modules.Custom.PrestigeClasses.PlagueKnight;

internal class PlagueKnightClass
{
    public readonly static string Guid = "{4933b493-9cb3-4cb9-af02-3324bd102e75}";

    private readonly static string ClassName = "PlagueKnight";
    private readonly static string DisplayName = "PlagueKnight.Name";
    private readonly static string Description = "PlagueKnight.Description";

    internal static void Configure()
    {
        //l2/l4/l6/l8/l10 - Blackrot - Weapon Buff, get target sickened, usable for amount on turns per day
        //l1 - Harbinger of Blight - Select a disease, you permanently diseased and apply this deasese when striking enemy with Blackrot
        //l5 - Incubating Pain - You no longer suffer penaltys from the desease
        //l10 - Requiem  - You gain bonuses instead of penaltys from a desease
        //l3 - Infestation - Aura -4 penalty to diseace saves for all creatures in 15f.

        //Mythic Weapon Buff - permannent buff
        //Mythic Plague Bearer - can select additional disease
        //Bewildering Injury

        Progression.Configure();

        var characterClass = CharacterClassConfigurator.New(ClassName, Guid)
            //.AddPrerequisiteAlignment(alignment: AlignmentMaskType.LawfulEvil | AlignmentMaskType.LawfulNeutral | AlignmentMaskType.NeutralEvil, checkInProgression: true)
            .AddPrerequisiteProficiency(weaponProficiencies: [], armorProficiencies: [ArmorProficiencyGroup.Heavy])
            //.AddPrerequisiteStatValue(stat: StatType.BaseAttackBonus, value: 5)
            //.AddPrerequisiteFeature(FeatureRefs.ShieldBashFeature.ToString())
            //.AddPrerequisiteFeature(FeatureRefs.IronWill.ToString())
            .SetSkillPoints(2)
            .SetHitDie(DiceType.D10)
            .SetPrestigeClass(true)
            .SetBaseAttackBonus(StatProgressionRefs.BABFull.ToString())
            .SetFortitudeSave(StatProgressionRefs.SavesPrestigeHigh.ToString())
            .SetReflexSave(StatProgressionRefs.SavesPrestigeLow.ToString())
            .SetWillSave(StatProgressionRefs.SavesPrestigeHigh.ToString())
            .SetProgression(Progression.Guid)
            .SetClassSkills(StatType.SkillAthletics, StatType.SkillMobility, StatType.SkillKnowledgeArcana, StatType.SkillLoreNature, StatType.SkillPersuasion)
            .SetLocalizedName(DisplayName)
            .SetLocalizedDescription(Description)
            .Configure();

        var rootProgression = ResourcesLibrary.GetRoot().Progression;
        rootProgression.m_CharacterClasses = rootProgression.m_CharacterClasses.AddToArray(characterClass.ToReference<BlueprintCharacterClassReference>());
    }

    internal class Progression
    {
        public static readonly string Guid = "{78788eb0-6936-41f2-89d4-d0f1435e38a4}";
        private static readonly string Name = "PlagueKnight.Progression";

        internal static void Configure()
        {
            BlackrotFeature.Configure();
            RatSwarmFeature.Configure();
            HarbingerOfBlightFeature.Configure();

            ProgressionConfigurator.New(Name, Guid)
                .SetClasses(PlagueKnightClass.Guid)
                .AddToLevelEntry(level: 01, features: HarbingerOfBlightFeature.Guid)
                .AddToLevelEntry(level: 02, features: BlackrotFeature.Guid)
                .AddToLevelEntry(level: 04, features: BlackrotFeature.Guid)
                .AddToLevelEntry(level: 06, features: BlackrotFeature.Guid)
                .AddToLevelEntry(level: 08, features: BlackrotFeature.Guid)
                .AddToLevelEntry(level: 10, features: BlackrotFeature.Guid)
                .SetIsClassFeature(true)
                .Configure();
        }
    }
}
