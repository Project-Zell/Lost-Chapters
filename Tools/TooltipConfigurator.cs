using BlueprintCore.Blueprints.Configurators.Encyclopedia;
using BlueprintCore.Blueprints.References;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Encyclopedia;
using Kingmaker.Blueprints.Encyclopedia.Blocks;
using Kingmaker.Blueprints.Root.Strings;
using Kingmaker.Localization;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using System.Linq;
using UnityEngine;

namespace LostChapters.Tools
{
    internal static class TooltipConfigurator
    {
        public enum AbilityType { Spell, Ability }

        /// <summary>
        /// Use assigned key value in {g|key}<b>tooltip</b>{/g} to call an ability tooltip.
        /// <para>Ex: CreateAbilityTooltip("MyMod:AcidFog", AbilityRefs.AcidFog) => {g|MyMod:AcidFog}<b>Acid Fog</b>{/g}.</para>
        /// </summary>
        public static void CreateAbilityTooltip(string key, BlueprintAbility ability, AbilityType abilityType = AbilityType.Spell)
        {
            var reference = ability.ToReference<BlueprintScriptableObjectReference>();
            var entry = new GlossaryEntry
            {
                Key = key,
                Blueprint = reference,
            };

            var root = RootRefs.BlueprintRoot.Reference.Get();
            var categoryIndex = abilityType is AbilityType.Ability ? 0 : 1;
            var categoryEntries = root.LocalizedTexts.GlossaryAbilities[categoryIndex].Entries.ToList();
            categoryEntries.Add(entry);

            root.LocalizedTexts.GlossaryAbilities[categoryIndex].Entries = [.. categoryEntries];
        }

        /// <summary>
        /// Use assigned key value in {g|key}<b>tooltip</b>{/g} to call an encyclopedia page tooltip.
        /// <para>The localization file should include "#.Title" and "#.TextBlock"</para>
        /// <para>Ex: CreateEncyclopediaTooltip("MyMod:Credits", guid) => {g|MyMod:Credits}<b>Credits</b>{/g} with MyMod:Credits.Title and MyMod:Credits.TextBlock.</para>
        /// <para>Optional: Assign a <i>parentChapter</i> to the page so it appears under that chapter in the Encyclopedia menu.</para>
        /// </summary>
        public static void CreateEncyclopediaTooltip(string key, string guid, BlueprintEncyclopediaChapter parentChapter = null)
        {
            var encyclopediaPageName = $"{key}.Page";
            var encyclopediaPageTitle = $"{key}.Title";
            var encyclopediaPageDescription = $"{key}.TextBlock";

            var textBlock = ScriptableObject.CreateInstance<BlueprintEncyclopediaBlockText>();
            textBlock.Text = new LocalizedString() { Key = encyclopediaPageDescription };

            var encyclopediaPage = EncyclopediaPageConfigurator.New(encyclopediaPageName, guid)
                .SetTitle(encyclopediaPageTitle)
                .AddToBlocks(textBlock)
                .Configure();

            var entry = new GlossaryEntry
            {
                Blueprint = encyclopediaPage.ToReference<BlueprintScriptableObjectReference>(),
                Key = key,
            };

            var root = RootRefs.BlueprintRoot.Reference.Get();
            var categoryEntries = root.LocalizedTexts.Glossaries[0].Entries.ToList();
            categoryEntries.Add(entry);

            root.LocalizedTexts.Glossaries[0].Entries = [.. categoryEntries];

            if (parentChapter is null)
                return;

            EncyclopediaChapterConfigurator.For(parentChapter)
                .AddToChildPages(encyclopediaPage)
                .Configure();
        }
    }
}
