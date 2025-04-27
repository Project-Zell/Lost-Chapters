using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using LostChapters.Modules.GraySisterhood.Feats.Selection;

namespace LostChapters.Modules.GraySisterhood.Archetypes
{
    internal class Armiger
    {
        public static void Configure()
        {
            ProgressionConfigurator.For(ProgressionRefs.FighterProgression)
                .AddToUIDeterminatorsGroup([FeatureRefs.ArmigerStudiousSquireFeature.ToString(),
                    FeatureSelectionRefs.HellKnightOrderSelection.ToString()])
                .Configure(true);

            var ardentIcon = FeatureRefs.GrimGrandeur.Reference.Get().Icon;

            FeatureConfigurator.For(FeatureRefs.ArmigerArdentFeature)
                .SetIcon(ardentIcon)
                .Configure();

            ArchetypeConfigurator.For(ArchetypeRefs.ArmigerArchetype)
                .AddToAddFeatures(level: 03, features: HellknightDisciplineSelection.Guid)
                .AddToAddFeatures(level: 07, features: HellknightDisciplineSelection.Guid)
                .AddToAddFeatures(level: 11, features: HellknightDisciplineSelection.Guid)
                .AddToAddFeatures(level: 15, features: HellknightDisciplineSelection.Guid)
                .AddToAddFeatures(level: 19, features: HellknightDisciplineSelection.Guid)
                .Configure();
        }
    }
}
