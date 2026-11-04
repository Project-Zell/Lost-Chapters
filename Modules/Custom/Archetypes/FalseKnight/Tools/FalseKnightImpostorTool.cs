using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.Classes.Selection;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Utility;
using LostChapters.Modules.Custom.Archetypes.FalseKnight.FallenOrder;
using System.Collections.Generic;
using System.Linq;

namespace LostChapters.Modules.Custom.Archetypes.FalseKnight.Tools;

internal class FalseKnightImpostorTool
{
    public static void CreateAndAddToImpostorSelection(string guid, BlueprintProgression orderProgression)
    {
        List<Blueprint<BlueprintUnitFactReference>> facts = [.. orderProgression.LevelEntries
            .Where(entry => entry.Level == 2)
            .SelectMany(entry => entry.m_Features)
            .Select(feat => (Blueprint<BlueprintUnitFactReference>)feat.Guid)];

        var firstFeat = facts.FirstOrDefault(feat => string.IsNullOrEmpty(feat.Reference.Get().m_DisplayName) is false).Reference.Get();

        var feature = FeatureConfigurator.New($"{orderProgression.m_DisplayName}Impostor", guid)
            .AddFacts(facts)
            .SetIcon(orderProgression.m_Icon)
            .SetDisplayName(firstFeat.m_DisplayName)
            .SetDescription(firstFeat.m_Description)
            .Configure();

        FeatureSelectionConfigurator.For(ImpostorFeature.Guid)
            .AddToAllFeatures([feature])
            .Configure();
    }
}