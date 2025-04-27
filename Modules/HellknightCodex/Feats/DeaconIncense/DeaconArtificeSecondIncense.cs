using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using LostChapters.Modules.GraySisterhood.Archetypes;
using LostChapters.Modules.GraySisterhood.Archetypes.ClassFeatures;
using LostChapters.Modules.GraySisterhood.Feats.Selection;

namespace LostChapters.Modules.GraySisterhood.Feats.DeaconIncense
{
    internal class DeaconArtificeSecondIncense
    {
        public static readonly string Guid = "5c8b123a-ad7a-4771-9e0d-ac7c6d3f418a";

        private const string IncenseName = "ArtificeSecondIncense";
        private const string DisplayName = "ArtificeSecondIncense.BuffName";
        private const string Description = "ArtificeSecondIncense.LocalizedDescription";

        public static void Configure()
        {
            AbilityAreaEffectConfigurator.For(CapellanIncenseClassFeature.AreaRef)
                .AddAbilityAreaEffectBuff(
                    buff: DeaconArtificeSecondIncenseNormalBuff.GetReference(),
                    condition: ConditionsBuilder.New().IsAlly().CasterHasFact(Guid).CasterHasFact(fact: Deacon.FeatGuid, negate: true))
                .AddAbilityAreaEffectBuff(
                    buff: DeaconArtificeSecondIncenseStrongBuff.GetReference(),
                    condition: ConditionsBuilder.New().IsAlly().CasterHasFact(Guid).CasterHasFact(fact: Deacon.FeatGuid))
                .Configure();

            FeatureConfigurator.New(IncenseName, Guid)
                .AddToFeatureSelection(CapellanIncenseSelector.Guid)
                .SetIcon(AbilityRefs.HauntingMists.Reference.Get().Icon)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }

    internal class DeaconArtificeSecondIncenseNormalBuff
    {
        public static readonly string Guid = "e416122e-c28f-4e08-84ff-823f1fa31547";

        private const string BuffName = "ArtificeSecondIncense.NormalBuff";
        private const string DisplayName = "ArtificeSecondIncense.NormalBuff.BuffName";
        private const string Description = "ArtificeSecondIncense.NormalBuff.LocalizedDescription";

#nullable enable
        private static BlueprintBuff? Reference;
#nullable disable

        public static BlueprintBuff GetReference() => Reference ??= CreateBuff();

        private static BlueprintBuff CreateBuff()
        {
            return BuffConfigurator.New(BuffName, Guid)
                .AddSavingThrowBonusAgainstDescriptor(bonus: 2, spellDescriptor: SpellDescriptor.Bleed)
                .AddSavingThrowBonusAgainstDescriptor(bonus: 2, spellDescriptor: SpellDescriptor.Sleep)
                .AddSavingThrowBonusAgainstDescriptor(bonus: 2, spellDescriptor: SpellDescriptor.Paralysis)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.HauntingMists.Reference.Get().Icon)
                .Configure();
        }
    }

    internal class DeaconArtificeSecondIncenseStrongBuff
    {
        public static readonly string Guid = "81b783c7-6fec-42b1-becd-a587795e9936";

        private const string BuffName = "ArtificeSecondIncense.StrongBuff";
        private const string DisplayName = "ArtificeSecondIncense.StrongBuff.BuffName";
        private const string Description = "ArtificeSecondIncense.StrongBuff.LocalizedDescription";

#nullable enable
        private static BlueprintBuff? Reference;
#nullable disable

        public static BlueprintBuff GetReference() => Reference ??= CreateBuff();

        private static BlueprintBuff CreateBuff()
        {
            return BuffConfigurator.New(BuffName, Guid)
                .AddSavingThrowBonusAgainstDescriptor(bonus: 4, spellDescriptor: SpellDescriptor.Bleed)
                .AddSavingThrowBonusAgainstDescriptor(bonus: 4, spellDescriptor: SpellDescriptor.Sleep)
                .AddSavingThrowBonusAgainstDescriptor(bonus: 4, spellDescriptor: SpellDescriptor.Paralysis)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.HauntingMists.Reference.Get().Icon)
                .Configure();
        }
    }
}
