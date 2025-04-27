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
    internal class DeaconCommunityFirstIncense
    {
        public static readonly string Guid = "f4712a02-78e5-4539-b1a9-8183c717fb48";

        private const string IncenseName = "CommunityFirstIncense";
        private const string DisplayName = "CommunityFirstIncense.BuffName";
        private const string Description = "CommunityFirstIncense.LocalizedDescription";
        public static void Configure()
        {
            AbilityAreaEffectConfigurator.For(CapellanIncenseClassFeature.AreaRef)
                .AddAbilityAreaEffectBuff(
                    buff: DeaconCommunityFirstIncenseNormalBuff.GetReference(),
                    condition: ConditionsBuilder.New().IsAlly().CasterHasFact(Guid).CasterHasFact(fact: Deacon.FeatGuid, negate: true))
                .AddAbilityAreaEffectBuff(
                    buff: DeaconCommunityFirstIncenseStrongBuff.GetReference(),
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

    internal class DeaconCommunityFirstIncenseNormalBuff
    {
        public static readonly string Guid = "a297e982-53e7-4b60-ace1-3f8e403f7d9c";

        private const string BuffName = "CharmFirstIncense.NormalBuff";
        private const string DisplayName = "CharmFirstIncense.NormalBuff.BuffName";
        private const string Description = "CharmFirstIncense.NormalBuff.LocalizedDescription";

#nullable enable
        private static BlueprintBuff? Reference;
#nullable disable

        public static BlueprintBuff GetReference() => Reference ??= CreateBuff();

        private static BlueprintBuff CreateBuff()
        {
            return BuffConfigurator.New(BuffName, Guid)
                .AddSavingThrowBonusAgainstDescriptor(bonus: 2, spellDescriptor: SpellDescriptor.Fear)
                .AddSavingThrowBonusAgainstDescriptor(bonus: 2, spellDescriptor: SpellDescriptor.Confusion)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.HauntingMists.Reference.Get().Icon)
                .Configure();
        }
    }

    internal class DeaconCommunityFirstIncenseStrongBuff
    {
        public static readonly string Guid = "b33980ce-0d0d-4317-a58a-83557001e1a2";

        private const string BuffName = "CharmFirstIncense.StrongBuff";
        private const string DisplayName = "CharmFirstIncense.StrongBuff.BuffName";
        private const string Description = "CharmFirstIncense.StrongBuff.LocalizedDescription";

#nullable enable
        private static BlueprintBuff? Reference;
#nullable disable

        public static BlueprintBuff GetReference() => Reference ??= CreateBuff();

        private static BlueprintBuff CreateBuff()
        {
            return BuffConfigurator.New(BuffName, Guid)
                .AddSavingThrowBonusAgainstDescriptor(bonus: 4, spellDescriptor: SpellDescriptor.Fear)
                .AddSavingThrowBonusAgainstDescriptor(bonus: 4, spellDescriptor: SpellDescriptor.Confusion)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.HauntingMists.Reference.Get().Icon)
                .Configure();
        }
    }
}