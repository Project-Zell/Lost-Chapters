using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Enums;

namespace LostChapters.Modules.GraySisterhood.PrestigeClasses.SanguineAngel;

internal class HollownessFeature
{
    public static readonly string Guid = "{a659e431-a310-4b8b-b510-8e1e233c3a35}";

    private static readonly string FeatureName = "Hollowness";
    private static readonly string DisplayName = "Hollowness.Name";
    private static readonly string Description = "Hollowness.Description";

    internal static void Configure()
    {
        FeatureConfigurator.New(FeatureName, Guid)
            .AddFacts([FeatureRefs.Diehard.ToString()])
            .AddSavingThrowBonusAgainstDescriptor(spellDescriptor: SpellDescriptor.Emotion, value: 4, modifierDescriptor: ModifierDescriptor.Profane)
            .AddBuffDescriptorImmunity(descriptor: SpellDescriptor.Fear)
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .Configure();
    }
}
