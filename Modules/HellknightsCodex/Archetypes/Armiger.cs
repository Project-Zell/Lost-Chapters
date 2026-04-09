using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using LostChapters.Modules.HellknightCodex.PrestigeClasses.Hellknight;

namespace LostChapters.Modules.HellknightCodex.Archetypes;

internal class Armiger
{
    public static void Configure()
    {
        ProgressionConfigurator.For(ProgressionRefs.FighterProgression)
            .AddToUIDeterminatorsGroup([FeatureRefs.ArmigerStudiousSquireFeature.ToString(), HellknightOrderSelectionFeature.Guid])
            .Configure();

        var ardentIcon = FeatureRefs.GrimGrandeur.Reference.Get().Icon;

        FeatureConfigurator.For(FeatureRefs.ArmigerArdentFeature)
            .SetIcon(ardentIcon)
            .Configure();

        ArchetypeConfigurator.For(ArchetypeRefs.ArmigerArchetype)
            .RemoveFromAddFeatures(level: 01, features: FeatureSelectionRefs.HellKnightOrderSelection.ToString())
            .AddToAddFeatures(level: 01, features: HellknightOrderSelectionFeature.Guid)
            .AddToAddFeatures(level: 03, features: HellknightDisciplineSelection.Guid)
            .AddToAddFeatures(level: 07, features: HellknightDisciplineSelection.Guid)
            .AddToAddFeatures(level: 11, features: HellknightDisciplineSelection.Guid)
            .AddToAddFeatures(level: 15, features: HellknightDisciplineSelection.Guid)
            .AddToAddFeatures(level: 19, features: HellknightDisciplineSelection.Guid)
            .Configure();
    }
}
