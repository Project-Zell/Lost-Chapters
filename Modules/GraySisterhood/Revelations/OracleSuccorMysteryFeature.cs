using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.EntitySystem.Stats;
using LostChapters.Modules.GraySisterhood.Revelations.Succor;
using LostChapters.Modules.GraySisterhood.Spells;
using LostChapters.Revelations;

namespace LostChapters.Modules.GraySisterhood.Revelations;

internal class OracleSuccorMysteryFeature
{
    public static readonly string Guid = "{13b82901-7edb-40e2-98f4-7583c46f74c0}";

    private static readonly string FeatureName = "SuccorMystery";
    private static readonly string DisplayName = "SuccorMystery.Name";
    private static readonly string Description = "SuccorMystery.Description";

    public static void Configure()
    {
        CurseOfDampeningRevelation.Configure();
        EnhancedInflictionsRevelation.Configure();
        OracleSuccorFinalRevelation.Configure();
        PerfectAid.Configure();
        PitifulFoeRevelation.Configure();
        ShieldOfSuccorRevelation.Configure();
        TeamworkMasteryRevelation.Configure();

        Spells.Configure();

        FeatureConfigurator.New(FeatureName, Guid, FeatureGroup.OracleMystery)
            .AddFeatureOnClassLevel(
                level: 20,
                clazz: CharacterClassRefs.OracleClass.ToString(),
                feature: OracleSuccorFinalRevelation.Guid,
                additionalClasses: [CharacterClassRefs.ArcanistClass.ToString()],
                archetypes: [ArchetypeRefs.MagicDeceiver.ToString()])
            .AddFeatureOnClassLevel(
                level: 2,
                clazz: CharacterClassRefs.OracleClass.ToString(),
                feature: Spells.Guid)
            .AddClassSkill(StatType.SkillMobility)
            .AddClassSkill(StatType.SkillLoreNature)
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .Configure();

        DivineHerbalistVariation.Configure();
        EnlightenedPhilosopherVariation.Configure();

        SetupRevelations();
    }

    internal static void SetupRevelations()
    {
        var baseMystery = BlueprintTool.Get<BlueprintFeature>(Guid).ToReference<BlueprintFeatureReference>();
        var divineHerbalistMystery = BlueprintTool.Get<BlueprintFeature>(DivineHerbalistVariation.Guid).ToReference<BlueprintFeatureReference>();
        var enlightenedPhilosopherMystery = BlueprintTool.Get<BlueprintFeature>(EnlightenedPhilosopherVariation.Guid).ToReference<BlueprintFeatureReference>();

        FeatureConfigurator.For(FeatureRefs.OracleRevelationCombatHealer)
            .EditComponent(delegate (PrerequisiteFeaturesFromList prerequisite)
            {
                prerequisite.m_Features = CommonTool.Append(prerequisite.m_Features, [baseMystery, divineHerbalistMystery , enlightenedPhilosopherMystery]);
            })
            .Configure();

        FeatureConfigurator.For(FeatureRefs.OracleRevelationEnhancedCures)
            .EditComponent(delegate (PrerequisiteFeaturesFromList prerequisite)
            {
                prerequisite.m_Features = CommonTool.Append(prerequisite.m_Features, [baseMystery, divineHerbalistMystery, enlightenedPhilosopherMystery]);
            })
            .Configure();

        FeatureConfigurator.For(FeatureRefs.OracleRevelationSoulSiphon)
            .EditComponent(delegate (PrerequisiteFeaturesFromList prerequisite)
            {
                prerequisite.m_Features = CommonTool.Append(prerequisite.m_Features, [baseMystery, divineHerbalistMystery, enlightenedPhilosopherMystery]);
            })
            .Configure();

        FeatureConfigurator.For(FeatureRefs.OracleRevelationSpiritBoost)
            .EditComponent(delegate (PrerequisiteFeaturesFromList prerequisite)
            {
                prerequisite.m_Features = CommonTool.Append(prerequisite.m_Features, [baseMystery, divineHerbalistMystery, enlightenedPhilosopherMystery]);
            })
            .Configure();
    }

    internal class Spells
    {
        public static readonly string Guid = "{df6d73b9-f579-4674-9b9d-3c51fdd15ba0}";

        private static readonly string FeatureName = "SuccorMystery.Spells";
        private static readonly string DisplayName = "SuccorMystery.Spells.Name";
        private static readonly string Description = "SuccorMystery.Spells.Description";

        public static void Configure()
        {
            var oracleClass = CharacterClassRefs.OracleClass.ToString();

            FeatureConfigurator.New(FeatureName, Guid)
                .AddKnownSpell(spellLevel: 1, characterClass: oracleClass, spell: AbilityRefs.RayOfEnfeeblement.ToString())
                .AddKnownSpell(spellLevel: 2, characterClass: oracleClass, spell: ShieldOfFortification.Guid)
                .AddKnownSpell(spellLevel: 3, characterClass: oracleClass, spell: AbilityRefs.Heroism.ToString())
                .AddKnownSpell(spellLevel: 4, characterClass: oracleClass, spell: ShieldOfFortificationGreater.Guid)
                .AddKnownSpell(spellLevel: 5, characterClass: oracleClass, spell: AbilityRefs.Stoneskin.ToString())
                .AddKnownSpell(spellLevel: 6, characterClass: oracleClass, spell: AbilityRefs.HeroismGreater.ToString())
                .AddKnownSpell(spellLevel: 7, characterClass: oracleClass, spell: AbilityRefs.StoneskinCommunal.ToString())
                .AddKnownSpell(spellLevel: 8, characterClass: oracleClass, spell: AbilityRefs.ProtectionFromSpells.ToString())
                .AddKnownSpell(spellLevel: 9, characterClass: oracleClass, spell: AbilityRefs.HeroicInvocation.ToString())
                .SetHideInCharacterSheetAndLevelUp(true)
                .SetIsClassFeature(true)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }

    internal class DivineHerbalistVariation
    {
        public static readonly string Guid = "{b6ff86f2-050a-4c80-b242-c5a71ab0cb33}";

        private static readonly string FeatureName = "SuccorMystery.DivineHerbalist";

        public static void Configure()
        {
            FeatureConfigurator.New(FeatureName, Guid, FeatureGroup.DivineHerbalistMystery)
                .AddFeatureOnClassLevel(
                    level: 20,
                    clazz: CharacterClassRefs.OracleClass.ToString(),
                    feature: OracleSuccorFinalRevelation.Guid,
                    additionalClasses: [CharacterClassRefs.ArcanistClass.ToString()],
                    archetypes: [ArchetypeRefs.MagicDeceiver.ToString()])
                .AddFeatureOnClassLevel(
                    level: 2,
                    clazz: CharacterClassRefs.OracleClass.ToString(),
                    feature: Spells.Guid)
                .SetIsClassFeature(true)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }

    internal class EnlightenedPhilosopherVariation
    {
        public static readonly string Guid = "{bbf36351-59c4-4c78-a8e1-30f3a7cc9ba6}";

        private static readonly string FeatureName = "SuccorMystery.EnlightenedPhilosopher";

        public static void Configure()
        {
            Spells.Configure();

            FeatureConfigurator.New(FeatureName, Guid, FeatureGroup.EnlightenedPhilosopherMystery)
                .AddFeatureOnClassLevel(
                    level: 2,
                    clazz: CharacterClassRefs.OracleClass.ToString(),
                    feature: Spells.Guid)
                .AddClassSkill(StatType.SkillMobility)
                .AddClassSkill(StatType.SkillLoreNature)
                .SetIsClassFeature(true)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }

        internal class Spells
        {
            public static readonly string Guid = "{c80f858a-6fe6-4cf4-893a-5d686518ceaf}";

            private static readonly string FeatureName = "SuccorMystery.EnlightenedPhilosopher.Spells";
            private static readonly string DisplayName = "SuccorMystery.Spells.Name";
            private static readonly string Description = "SuccorMystery.Spells.Description";

            public static void Configure()
            {
                var oracleClass = CharacterClassRefs.OracleClass.ToString();

                FeatureConfigurator.New(FeatureName, Guid)
                    .AddKnownSpell(spellLevel: 1, characterClass: oracleClass, spell: AbilityRefs.RayOfEnfeeblement.ToString())
                    .AddKnownSpell(spellLevel: 2, characterClass: oracleClass, spell: AbilityRefs.OwlsWisdom.ToString())
                    .AddKnownSpell(spellLevel: 3, characterClass: oracleClass, spell: AbilityRefs.RemoveBlindness.ToString())
                    .AddKnownSpell(spellLevel: 4, characterClass: oracleClass, spell: AbilityRefs.ConfusionSpell.ToString())
                    .AddKnownSpell(spellLevel: 5, characterClass: oracleClass, spell: AbilityRefs.TrueSeeing.ToString())
                    .AddKnownSpell(spellLevel: 6, characterClass: oracleClass, spell: AbilityRefs.OwlsWisdomMass.ToString())
                    .AddKnownSpell(spellLevel: 7, characterClass: oracleClass, spell: AbilityRefs.TrueSeeingCommunal.ToString())
                    .AddKnownSpell(spellLevel: 8, characterClass: oracleClass, spell: AbilityRefs.MindBlank.ToString())
                    .AddKnownSpell(spellLevel: 9, characterClass: oracleClass, spell: AbilityRefs.MindBlankCommunal.ToString())
                    .SetHideInCharacterSheetAndLevelUp(true)
                    .SetIsClassFeature(true)
                    .SetDisplayName(DisplayName)
                    .SetDescription(Description)
                    .Configure();
            }
        }
    }
}
