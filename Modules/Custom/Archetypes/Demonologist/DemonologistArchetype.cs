using BlueprintCore.Blueprints.Configurators.Classes.Spells;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.Classes.Spells;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.EntitySystem.Stats;
using LostChapters.Modules.Custom.Archetypes.Demonologist.SummonAbilities;
using LostChapters.Tools;
using System.Collections.Generic;

namespace LostChapters.Modules.Custom.Archetypes.Demonologist;

internal class DemonologistArchetype
{
    public static readonly string Guid = "{836a4435-0f42-42d7-b413-d566a9ae0f7d}";

    private static readonly string ArchetypeName = "DemonologistArchetype";
    private static readonly string LocalizedName = $"{ArchetypeName}.Name";
    private static readonly string Description   = $"{ArchetypeName}.Description";

    internal static void Configure()
    {
        //Continue spellbook?

        DemonologistSummonPool.Configure();
        DemonicStudiesFeature.Configure();
        DemonologistSummons.Configure();
        CallOfTheAbyssFeature.Configure();
        DemonologistRagePowerSelection.Configure();
        HellsWhisperFeature.Configure();

        Spellbook.Configure();

        var parentClass = CharacterClassRefs.ArcanistClass;

        var removeFeaturesEntryBuilder = LevelEntryBuilder.New()
            .AddEntry(level: 01, features: FeatureSelectionRefs.ArcanistExploitSelection.ToString())
            .AddEntry(level: 03, features: FeatureSelectionRefs.ArcanistExploitSelection.ToString());

        var addFeaturesEntryBuilder = LevelEntryBuilder.New()
            .AddEntry(level: 01, features: DemonicStudiesFeature.Guid)
            .AddEntry(level: 01, features: HellsWhisperFeature.Guid)
            .AddEntry(level: 03, features: CallOfTheAbyssFeature.Guid);

        ArchetypeConfigurator.New(ArchetypeName, Guid, parentClass)
            .SetAddFeatures(addFeaturesEntryBuilder)
            .SetRemoveFeatures(removeFeaturesEntryBuilder)
            .SetReplaceSpellbook(Spellbook.Guid)
            .SetLocalizedName(LocalizedName)
            .SetLocalizedDescription(Description)
            .Configure();

        ProgressionConfigurator.For(ProgressionRefs.ArcanistProgression)
            .AddToUIGroups([DemonicStudiesFeature.Guid, CallOfTheAbyssFeature.Guid, DemonologistRagePowerSelection.Guid])
            .Configure();
    }

    internal class Spellbook
    {
        public static readonly string Guid = "{4d07c969-d1d7-401e-b80e-834a42ae56eb}";

        private static readonly string SpellbookName = $"{ArchetypeName}.Spellbook";

        internal static void Configure()
        {
            SpellList.Configure();

            SpellbookConfigurator.New(SpellbookName, Guid)
                .SetSpellList(SpellList.Guid)
                .SetSpellsPerDay(SpellsTableRefs.ArcanistSpellsPerDayTable.ToString())
                .SetSpellSlots(SpellsTableRefs.ArcanistSpellSlots.ToString())
                .SetCharacterClass(CharacterClassRefs.ArcanistClass.ToString())
                .SetCastingAttribute(StatType.Intelligence)
                .SetSpontaneous(true)
                .SetSpellsPerLevel(2)
                .SetCanCopyScrolls(true)
                .SetIsArcane(true)
                .SetIsArcanist(true)
                .SetName("69a0d6d0-66f0-4462-8ad3-b551c9777a0a")
                .Configure();
        }
    }

    internal class SpellList
    {
        public static readonly string Guid = "{bbf96c20-4e04-4e90-b42e-7899585a0406}";

        private static readonly string SpellListName = $"{ArchetypeName}.SpellList";

        internal static void Configure()
        {
            HashSet<BlueprintGuid> spellsToRemove = 
            [
                AbilityRefs.SummonMonsterISingle.Reference.Get().AssetGuid,
                AbilityRefs.SummonMonsterIIBase.Reference.Get().AssetGuid,
                AbilityRefs.SummonMonsterIIIBase.Reference.Get().AssetGuid,
                AbilityRefs.SummonMonsterIVBase.Reference.Get().AssetGuid,
                AbilityRefs.SummonMonsterVBase.Reference.Get().AssetGuid,
                AbilityRefs.SummonMonsterVIBase.Reference.Get().AssetGuid,
                AbilityRefs.SummonMonsterVIIBase.Reference.Get().AssetGuid,
                AbilityRefs.SummonMonsterVIIIBase.Reference.Get().AssetGuid,
                AbilityRefs.SummonMonsterIXBase.Reference.Get().AssetGuid,

                AbilityRefs.HoldPerson.Reference.Get().AssetGuid,
                AbilityRefs.HoldPersonMass.Reference.Get().AssetGuid,
                AbilityRefs.DominatePerson.Reference.Get().AssetGuid
            ];

            (int level, HashSet<string> spells)[] spellsToAdd = [
                (1, [SummonDemonI.Single.Guid]),
                (2, [SummonDemonII.BaseAbility.Guid]),
                (3, [SummonDemonIII.BaseAbility.Guid]),
                (4, [SummonDemonIV.BaseAbility.Guid]),
                (5, [SummonDemonV.BaseAbility.Guid]),
                (6, [SummonDemonVI.BaseAbility.Guid]),
                (7, [SummonDemonVII.BaseAbility.Guid]),
                (8, [SummonDemonVIII.BaseAbility.Guid]),
                (9, [SummonDemonIX.BaseAbility.Guid])
            ];

            var spellList = BlueprintTool.Get<BlueprintSpellList>(SpellListRefs.WizardSpellList.ToString());

            SpellListConfigurator.New(SpellListName, Guid)
                .SetSpellsByLevel(SpellbookHelper.GetSpellLevelListsFromSpellBook(spellList))
                .ModifySpellsByLevel(SpellbookHelper.RemoveSpellsFromList(spellsToRemove))
                .ModifySpellsByLevel(SpellbookHelper.AddSpellsToList(spellsToAdd))
                .SetFilterBySchool(true)
                .Configure();
        }
    }
}