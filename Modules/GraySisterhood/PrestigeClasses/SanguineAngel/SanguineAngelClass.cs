using BlueprintCore.Blueprints.Configurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using HarmonyLib;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items.Armors;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.RuleSystem;
using Kingmaker.UnitLogic.Alignments;
using LostChapters.Tools;

namespace LostChapters.Modules.GraySisterhood.PrestigeClasses.SanguineAngel;

internal class SanguineAngelClass
{
    public static readonly string Guid = "{dafc96d2-89a0-40c5-9b1f-9a6dea1abe36}";

    private static readonly string ClassName = "SanguineAngel";
    private static readonly string DisplayName = "SanguineAngel.Name";
    private static readonly string Description = "SanguineAngel.Description";

    internal static void Configure()
    {
        Progression.Configure();

        var genderCondition = Toolbox.GenderCondition(Gender.Female);

        var characterClass = CharacterClassConfigurator.New(ClassName, Guid)
            .AddPrerequisiteAlignment(alignment: AlignmentMaskType.LawfulEvil | AlignmentMaskType.LawfulNeutral | AlignmentMaskType.NeutralEvil, checkInProgression: true)
            .AddPrerequisiteProficiency(weaponProficiencies: [], armorProficiencies: [ArmorProficiencyGroup.Heavy])
            .AddPrerequisiteStatValue(stat: StatType.BaseAttackBonus, value: 5)
            .AddPrerequisiteFeature(FeatureRefs.ShieldBashFeature.ToString())
            .AddPrerequisiteFeature(FeatureRefs.IronWill.ToString())
            .AddPrerequisiteParametrizedWeaponFeature(feature: ParametrizedFeatureRefs.WeaponFocus.ToString(), weaponCategory: WeaponCategory.Longsword)
            .AddPrerequisiteCondition(condition: genderCondition, uIText: "Gender: Female")
            .SetSkillPoints(2)
            .SetHitDie(DiceType.D10)
            .SetPrestigeClass(true)
            .SetBaseAttackBonus(StatProgressionRefs.BABFull.ToString())
            .SetFortitudeSave(StatProgressionRefs.SavesPrestigeHigh.ToString())
            .SetReflexSave(StatProgressionRefs.SavesPrestigeLow.ToString())
            .SetWillSave(StatProgressionRefs.SavesPrestigeHigh.ToString())
            .SetProgression(Progression.Guid)
            .SetClassSkills(StatType.SkillAthletics, StatType.SkillKnowledgeWorld, StatType.SkillPerception, StatType.SkillPersuasion)
            .SetLocalizedName(DisplayName)
            .SetLocalizedDescription(Description)
            .Configure();

        var rootProgression = ResourcesLibrary.GetRoot().Progression;
        rootProgression.m_CharacterClasses = rootProgression.m_CharacterClasses.AddToArray(characterClass.ToReference<BlueprintCharacterClassReference>());
    }

    internal class Progression
    {
        public static readonly string Guid = "{134fb601-973a-40f7-93dc-7c970ce2c7f5}";
        private static readonly string Name = "SanguineAngel.Progression";

        internal static void Configure()
        {
            AngelOfDeathFeature.Configure();
            EyeOfAlertnessFeature.Configure();
            HardenedHeartFeature.Configure();
            HollownessFeature.Configure();
            MaidensShieldFeature.Configure();
            MystiqueFeature.Configure();
            TyrantsDisciplineFeatureSelection.Configure();
            QueensArcenalFeature.Configure();
            VengefulSpiritFeature.Configure();

            ProgressionConfigurator.New(Name, Guid)
                .SetClasses(SanguineAngelClass.Guid)
                
                .AddToLevelEntry(level: 01, features: [VengefulSpiritFeature.Guid, HardenedHeartFeature.Guid, MaidensShieldFeature.Guid])
                .AddToLevelEntry(level: 02, features: [TyrantsDisciplineFeatureSelection.Guid])
                .AddToLevelEntry(level: 03, features: QueensArcenalFeature.Guid)
                .AddToLevelEntry(level: 04, features: [TyrantsDisciplineFeatureSelection.Guid, FeatureRefs.ArmorTraining.ToString()])
                .AddToLevelEntry(level: 05, features: [EyeOfAlertnessFeature.Guid])
                .AddToLevelEntry(level: 06, features: [TyrantsDisciplineFeatureSelection.Guid, QueensArcenalFeature.Guid])
                .AddToLevelEntry(level: 07, features: [MystiqueFeature.Guid])
                .AddToLevelEntry(level: 08, features: [TyrantsDisciplineFeatureSelection.Guid, FeatureRefs.ArmorTraining.ToString()])
                .AddToLevelEntry(level: 09, features: [HollownessFeature.Guid, QueensArcenalFeature.Guid])
                .AddToLevelEntry(level: 10, features: [TyrantsDisciplineFeatureSelection.Guid, AngelOfDeathFeature.Guid])

                .SetUIDeterminatorsGroup(VengefulSpiritFeature.Guid, HardenedHeartFeature.Guid)

                .SetIsClassFeature(true)
                .Configure();
        }
    }
}
