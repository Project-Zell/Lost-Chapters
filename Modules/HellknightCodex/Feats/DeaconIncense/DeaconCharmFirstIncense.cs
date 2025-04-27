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
    internal class DeaconCharmFirstIncense
    {
        public static readonly string Guid = "c2cc863c-942d-4d8b-8a07-3001786b3fd1";

        private const string IncenseName = "CharmFirstIncense";
        private const string DisplayName = "CharmFirstIncense.BuffName";
        private const string Description = "CharmFirstIncense.LocalizedDescription";
        public static void Configure()
        {
            AbilityAreaEffectConfigurator.For(CapellanIncenseClassFeature.AreaRef)
                .AddAbilityAreaEffectBuff(
                    buff: DeaconCharmFirstIncenseNormalBuff.GetReference(),
                    condition: ConditionsBuilder.New().IsEnemy().CasterHasFact(Guid).CasterHasFact(fact: Deacon.FeatGuid, negate: true))
                .AddAbilityAreaEffectBuff(
                    buff: DeaconCharmFirstIncenseStrongBuff.GetReference(),
                    condition: ConditionsBuilder.New().IsEnemy().CasterHasFact(Guid).CasterHasFact(fact: Deacon.FeatGuid))
                .Configure();

            FeatureConfigurator.New(IncenseName, Guid)
                .AddToFeatureSelection(CapellanIncenseSelector.Guid)
                .SetIcon(AbilityRefs.HauntingMists.Reference.Get().Icon)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }

    internal class DeaconCharmFirstIncenseNormalBuff
    {
        public static readonly string Guid = "be0ece6b-04bb-4b9f-b148-90cea9b5775b";

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
                .AddSavingThrowBonusAgainstDescriptor(bonus: -2, spellDescriptor: SpellDescriptor.MindAffecting)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.HauntingMists.Reference.Get().Icon)
                .Configure();
        }
    }

    internal class DeaconCharmFirstIncenseStrongBuff
    {
        public static readonly string Guid = "087e0ddc-07cc-4626-9f97-52e7d5020fa4";

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
                .AddSavingThrowBonusAgainstDescriptor(bonus: -4, spellDescriptor: SpellDescriptor.MindAffecting)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.HauntingMists.Reference.Get().Icon)
                .Configure();
        }
    }
}
