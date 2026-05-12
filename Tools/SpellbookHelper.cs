using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Spells;
using System;
using System.Collections.Generic;

namespace LostChapters.Tools;

internal static class SpellbookHelper
{
    internal static SpellLevelList[] GetSpellLevelListsFromSpellBook(BlueprintSpellList spellbook)
    {
        var spells = spellbook.SpellsByLevel;
        var spellList = new SpellLevelList[spells.Length];

        for (int i = 0; i < spells.Length; i++)
        {
            var spell = spells[i];
            var copy = new SpellLevelList(spell.SpellLevel) { m_Spells = [.. spell.m_Spells]};
            spellList[i] = copy;
        }
        return spellList;
    }

    internal static Action<SpellLevelList> RemoveSpellFromLevel(int spellLevel, BlueprintGuid spellAssetGuid)
    {
        return spellLevelList =>
        {
            if ((spellLevelList.SpellLevel == spellLevel) is false)
                return;

            spellLevelList.m_Spells.RemoveAll(spell => spell.Guid == spellAssetGuid);
            spellLevelList.m_SpellsFiltered = null;
        };
    }

    internal static Action<SpellLevelList> AddSpellToLevel(int spellLevel, string spellGuid)
    {
        return spellLevelList =>
        {
            if ((spellLevelList.SpellLevel == spellLevel) is false)
                return;

            spellLevelList.m_Spells.Add(BlueprintTool.GetRef<BlueprintAbilityReference>(spellGuid));
            spellLevelList.m_SpellsFiltered = null;
        };
    }

    internal static Action<SpellLevelList> RemoveSpellsFromList(HashSet<BlueprintGuid> spellsToRemove)
    {
        return spellLevelList =>
        {
            spellLevelList.m_Spells.RemoveAll(spell => spell != null && spellsToRemove.Contains(spell.Guid));
            spellLevelList.m_SpellsFiltered = null;
        };
    }

    internal static Action<SpellLevelList> AddSpellsToList((int level, HashSet<string> spells)[] spellsToAdd)
    {
        return spellLevelList =>
        {
            foreach(var spells in spellsToAdd)
            {
                if ((spellLevelList.SpellLevel == spells.level) is false)
                    continue;

                foreach(var spell in spells.spells)
                {
                    spellLevelList.m_Spells.Add(BlueprintTool.GetRef<BlueprintAbilityReference>(spell));
                }
            }
            spellLevelList.m_SpellsFiltered = null;
        };
    }
}
