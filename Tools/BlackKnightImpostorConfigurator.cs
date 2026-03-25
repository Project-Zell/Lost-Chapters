using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.Classes.Selection;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using LostChapters.Modules.Custom.Archetypes.BlackKnight;
using System.Collections.Generic;

namespace LostChapters.Tools;

internal class BlackKnightImpostorConfigurator
{
    public static void AddFeatureToImpostorSelection(BlueprintProgression order, List<Blueprint<BlueprintUnitFactReference>> features, string guid)
    {
        var name = order.m_DisplayName;

        var impostorFeature = FeatureConfigurator.New($"Impostor.{name}", guid)
            .AddFacts(features)
            .SetIcon(order.Icon)
            .SetDisplayName(name)
            .SetDescription("Impostor.Description")
            .Configure();

        FeatureSelectionConfigurator.For(ImpostorFeature.Guid)
            .AddToAllFeatures([impostorFeature])
            .Configure();
    }

    public static void AddFeatureToImpostorSelection(BlueprintProgression order, BlueprintFeatureSelection selection, string guid)
    {
        var name = order.m_DisplayName;

        var impostorFeature = FeatureSelectionConfigurator.New($"Impostor.{name}", guid)
            .AddFacts([selection])
            .SetIcon(order.Icon)
            .SetDisplayName(name)
            .SetDescription("Impostor.Description")
            .Configure();

        impostorFeature.m_AllFeatures = selection.Features;

        FeatureSelectionConfigurator.For(ImpostorFeature.Guid)
            .AddToAllFeatures([impostorFeature])
            .Configure();
    }
}
