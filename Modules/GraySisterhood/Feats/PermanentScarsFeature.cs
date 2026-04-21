using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Enums.Damage;

namespace LostChapters.Modules.GraySisterhood.Feats;

internal class PermanentScarsFeature
{
    public static readonly string Guid = "{431f6d1f-544e-45c6-975f-0ee01d0206c3}";

    private static readonly string FeatureName = "PermanentScarsFeature";
    private static readonly string DisplayName = "PermanentScarsFeature.Name";
    private static readonly string Description = "PermanentScarsFeature.Description";

    public void Configure()
    {
        FeatureConfigurator.New(FeatureName, Guid)
            .AddPrerequisiteFeature(feature: GrayMaidensTrainingFeature.Guid, checkInProgression: true)
            .AddSavingThrowBonusAgainstDescriptor(value: 2, spellDescriptor: SpellDescriptor.Emotion)
            .AddDamageResistancePhysical(value: 3, form: PhysicalDamageForm.Slashing)
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .Configure();
    }
}
