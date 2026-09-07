using BlueprintCore.Blueprints.Configurators.Classes.Spells;
using BlueprintCore.Blueprints.CustomConfigurators.Classes.Spells;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.EntitySystem.Stats;
using LostChapters.Modules.Custom.Archetypes.Demonologist.SummonAbilities;
using LostChapters.Tools;
using System.Collections.Generic;

namespace LostChapters.Modules.Custom.Archetypes.Demonologist.Tools;

internal class DemonologistSpellbook
{
    public static readonly string Guid = "{4d07c969-d1d7-401e-b80e-834a42ae56eb}";

    private static readonly string BaseName = "Demonologist";
    
    private static readonly string LocalizedName = $"{BaseName}Archetype.Name";
    private static readonly string SpellbookName = $"{BaseName}Spellbook";

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

        HellknightSigniferDemonologist.Configure();
        ArcaneTricksterDemonologist.Configure();
        DragonDiscipleDemonologist.Configure();
        EldritchKnightDemonologist.Configure();
        LoremasterDemonologist.Configure();
        MysticTheurgeDemonologist.Configure();
    }

    internal class SpellList
    {
        public static readonly string Guid = "{bbf96c20-4e04-4e90-b42e-7899585a0406}";

        private static readonly string SpellListName = $"{BaseName}SpellList";

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
                AbilityRefs.SummonMonsterIXBase.Reference.Get().AssetGuid
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
                .ModifySpellsByLevel(SpellbookHelper.AddSpellsToList(spellsToAdd))
                .ModifySpellsByLevel(SpellbookHelper.RemoveSpellsFromList(spellsToRemove))
                .SetFilterBySchool(true)
                .Configure();
        }
    }

    internal class HellknightSigniferDemonologist
    {
        public static readonly string Guid = "{80d87212-a6c2-4c46-8219-65e57397b584}";

        private static readonly string SpellbookName = $"HellknightSignifer{BaseName}";

        internal static void Configure()
        {
            var spellbookSelectionDescription = "eb71d1c5-c890-4c44-8790-2fb8c3621e55";

            DemonologistSpellbookHelper.CreateSpellbookForPrestiegeClass(
                guid: Guid,
                name: SpellbookName,
                requiredSpellLevel: 3,
                descriptionKey: spellbookSelectionDescription,
                classSpellbookGuid: FeatureSelectionRefs.HellknightSigniferSpellbook.ToString(),
                spellbookToRestrict: FeatureReplaceSpellbookRefs.HellknightSigniferArcanist.Reference,
                featureGroup: FeatureGroup.HellknightSigniferSpellbook,
                spellbookDisplayName: LocalizedName);
        }
    }

    internal class ArcaneTricksterDemonologist
    {
        public static readonly string Guid = "{0c9ecf30-6073-4a30-b866-9d441a86c77a}";

        private static readonly string SpellbookName = $"ArcaneTrickster{BaseName}";

        internal static void Configure()
        {
            var spellbookSelectionDescription = "bf9c1e4a-5753-4705-9617-1a54ac291dfc";

            DemonologistSpellbookHelper.CreateSpellbookForPrestiegeClass(
                guid: Guid,
                name: SpellbookName,
                requiredSpellLevel: 3,
                descriptionKey: spellbookSelectionDescription,
                classSpellbookGuid: FeatureSelectionRefs.ArcaneTricksterSpellbookSelection.ToString(),
                spellbookToRestrict: FeatureReplaceSpellbookRefs.ArcaneTricksterArcanist.Reference,
                featureGroup: FeatureGroup.ArcaneTricksterSpellbook,
                spellbookDisplayName: LocalizedName);
        }
    }


    //Dosent Work
    internal class DragonDiscipleDemonologist
    {
        public static readonly string Guid = "{af92e937-beaf-4f9b-81e1-2467d1b927a8}";

        private static readonly string SpellbookName = $"DragonDisciple{BaseName}";

        internal static void Configure()
        {
            var spellbookSelectionDescription = "9a186e08-9d9e-4dfb-98b9-d35127bad905";

            DemonologistSpellbookHelper.CreateSpellbookForPrestiegeClass(
                guid: Guid,
                name: SpellbookName,
                requiredSpellLevel: 2,
                descriptionKey: spellbookSelectionDescription,
                classSpellbookGuid: FeatureSelectionRefs.DragonDiscipleSpellbookSelection.ToString(),
                spellbookToRestrict: FeatureReplaceSpellbookRefs.DragonDiscipleArcanist.Reference,
                featureGroup: FeatureGroup.DragonDiscipleSpellbook,
                spellbookDisplayName: LocalizedName);
        }
    }

    internal class EldritchKnightDemonologist
    {
        public static readonly string Guid = "{dc81d52a-c6cd-4903-a0da-7d1e6b68b22c}";

        private static readonly string SpellbookName = $"EldritchKnight{BaseName}";

        internal static void Configure()
        {
            var spellbookSelectionDescription = "cf828ba6-8a11-48b0-aa36-2d7972b51a5f";

            DemonologistSpellbookHelper.CreateSpellbookForPrestiegeClass(
                guid: Guid,
                name: SpellbookName,
                requiredSpellLevel: 2,
                descriptionKey: spellbookSelectionDescription,
                classSpellbookGuid: FeatureSelectionRefs.EldritchKnightSpellbookSelection.ToString(),
                spellbookToRestrict: FeatureReplaceSpellbookRefs.EldritchKnightArcanist.Reference,
                featureGroup: FeatureGroup.EldritchKnightSpellbook,
                spellbookDisplayName: LocalizedName);
        }
    }

    internal class LoremasterDemonologist
    {
        public static readonly string Guid = "{52275f80-9931-4d4c-b8c7-1b309b7636cb}";

        private static readonly string SpellbookName = $"Loremaster{BaseName}";

        internal static void Configure()
        {
            var spellbookSelectionDescription = "c213f6d4-9760-4939-a9fe-9d34f9747240";

            DemonologistSpellbookHelper.CreateSpellbookForPrestiegeClass(
                guid: Guid,
                name: SpellbookName,
                requiredSpellLevel: 3,
                descriptionKey: spellbookSelectionDescription,
                classSpellbookGuid: FeatureSelectionRefs.LoremasterSpellbookSelection.ToString(),
                spellbookToRestrict: FeatureReplaceSpellbookRefs.LoremasterArcanist.Reference,
                featureGroup: FeatureGroup.MythicAdditionalProgressions,
                spellbookDisplayName: LocalizedName);
        }
    }

    internal class MysticTheurgeDemonologist
    {
        public static readonly string Guid = "{fa52c542-438b-4d57-b0c3-ce7ae7299186}";

        private static readonly string SpellbookName = $"MysticTheurge{BaseName}";

        internal static void Configure()
        {
            var spellbookSelectionDescription = "801d1633-efa1-4ed2-83d1-337231705ae7";

            DemonologistSpellbookHelper.CreateSpellbookForPrestiegeClass(
                guid: Guid,
                name: SpellbookName,
                requiredSpellLevel: 2,
                descriptionKey: spellbookSelectionDescription,
                classSpellbookGuid: FeatureSelectionRefs.MysticTheurgeArcaneSpellbookSelection.ToString(),
                spellbookToRestrict: FeatureReplaceSpellbookRefs.MysticTheurgeArcanist.Reference,
                featureGroup: FeatureGroup.MysticTheurgeArcaneSpellbook,
                spellbookDisplayName: LocalizedName);
        }
    }
}