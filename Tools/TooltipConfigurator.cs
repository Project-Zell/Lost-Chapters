using BlueprintCore.Blueprints.Configurators.Encyclopedia;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Encyclopedia;
using Kingmaker.Blueprints.Encyclopedia.Blocks;
using Kingmaker.Blueprints.Facts;
using Kingmaker.Blueprints.Root.Strings;
using Kingmaker.Localization;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using System.Linq;
using UnityEngine;

namespace LostChapters.Tools
{
    internal static class TooltipConfigurator
    {
        private static readonly LogWrapper Logger = LogWrapper.Get("LostChapters");
        public enum AbilityType { Spell, Ability }

        private static void CreateAbilityTooltip(string key, BlueprintFact ability, AbilityType abilityType = AbilityType.Spell)
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


            foreach (var categoryEntry in root.LocalizedTexts.GlossaryAbilities[0].Entries.ToList())
            {
                Logger.Info($"Key - {categoryEntry.Key}, Name - {categoryEntry.Name}, Description - {categoryEntry.Description}. Blueprint - {categoryEntry.Blueprint.NameSafe()}");
            }

            foreach(var categoryEntry in root.LocalizedTexts.GlossaryAbilities[1].Entries.ToList())
            {
                Logger.Info($"Key - {categoryEntry.Key}, Name - {categoryEntry.Name}, Description - {categoryEntry.Description}. Blueprint - {categoryEntry.Blueprint.NameSafe()}");
            }

            root.LocalizedTexts.GlossaryAbilities[categoryIndex].Entries = [.. categoryEntries];
        }

        /// <summary>
        /// Use assigned key value in {g|key}<b>tooltip</b>{/g} to call an ability or spell tooltip.
        /// <para><i>Ex</i>: CreateAbilityTooltip("MyMod_Blur", AbilityRefs.Blur.Reference); =>
        /// <i>To use</i>: {g|MyMod_Blur}<b>blur</b>{/g}. </para>
        /// </summary>
        public static void CreateAbilityTooltip(string key, BlueprintAbility ability)
        {
            CreateAbilityTooltip(key, ability, AbilityType.Ability);
        }

        /// <summary>
        /// Use assigned key value in {g|key}<b>tooltip</b>{/g} to call a feature tooltip.
        /// <para><i>Ex</i>: CreateAbilityTooltip("MyMod_WarBlessing", FeatureRefs.WarBlessingFeature.Reference); =>
        /// <i>To use</i>: {g|MyMod_WarBlessing}<b>war blessing</b>{/g}. </para>
        /// </summary>
        public static void CreateFeatureTooltip(string key, BlueprintFeature feature)
        {
            CreateAbilityTooltip(key, feature, AbilityType.Ability);
        }

        /// <summary>
        /// Use assigned key value in {g|key}<b>tooltip</b>{/g} to call an encyclopedia page tooltip.
        /// <para>The localization file should include "#.Title" and "#.TextBlock"</para>
        /// <para><i>Ex</i>: CreateEncyclopediaTooltip("MyMod:Credits", guid); => <i>To use</i>: {g|MyMod:Credits}<b>Credits</b>{/g} with MyMod:Credits.Title and MyMod:Credits.TextBlock.</para>
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
