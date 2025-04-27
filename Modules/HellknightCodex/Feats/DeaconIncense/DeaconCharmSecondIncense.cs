using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using LostChapters.Modules.GraySisterhood.Archetypes;
using LostChapters.Modules.GraySisterhood.Archetypes.ClassFeatures;
using LostChapters.Modules.GraySisterhood.Feats.Selection;

namespace LostChapters.Modules.GraySisterhood.Feats.DeaconIncense
{
    internal class DeaconCharmSecondIncense
    {
        public static readonly string Guid = "dfa9a7a4-5fa7-41db-b851-9dcea4cbda31";

        private const string IncenseName = "CharmSecondIncense";
        private const string DisplayName = "CharmSecondIncense.BuffName";
        private const string Description = "CharmSecondIncense.LocalizedDescription";

        public static void Configure()
        {
            AbilityAreaEffectConfigurator.For(CapellanIncenseClassFeature.AreaRef)
                .AddAbilityAreaEffectBuff(
                    buff: DeaconCharmSecondIncenseNormalBuff.GetReference(),
                    condition: ConditionsBuilder.New().IsAlly().CasterHasFact(Guid).CasterHasFact(fact: Deacon.FeatGuid, negate: true))
                .AddAbilityAreaEffectBuff(
                    buff: DeaconCharmSecondIncenseStrongBuff.GetReference(),
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

    internal class DeaconCharmSecondIncenseNormalBuff
    {
        public static readonly string Guid = "c7bf5003-e10e-43c9-8795-66f1379e1d09";

        private const string BuffName = "CharmSecondIncense.NormalBuff";
        private const string DisplayName = "CharmSecondIncense.NormalBuff.BuffName";
        private const string Description = "CharmSecondIncense.NormalBuff.LocalizedDescription";

#nullable enable
        private static BlueprintBuff? Reference;
#nullable disable

        public static BlueprintBuff GetReference() => Reference ??= CreateBuff();

        private static BlueprintBuff CreateBuff()
        {
            return BuffConfigurator.New(BuffName, Guid)
                .AddStatBonus(stat: StatType.Charisma, value: 2, descriptor: ModifierDescriptor.Alchemical)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.HauntingMists.Reference.Get().Icon)
                .Configure();
        }
    }

    internal class DeaconCharmSecondIncenseStrongBuff
    {
        public static readonly string Guid = "8f8c7138-4ca0-40d9-b6f0-584ef114b652";

        private const string BuffName = "CharmSecondIncense.StrongBuff";
        private const string DisplayName = "CharmSecondIncense.StrongBuff.BuffName";
        private const string Description = "CharmSecondIncense.StrongBuff.LocalizedDescription";

#nullable enable
        private static BlueprintBuff? Reference;
#nullable disable

        public static BlueprintBuff GetReference() => Reference ??= CreateBuff();

        private static BlueprintBuff CreateBuff()
        {
            return BuffConfigurator.New(BuffName, Guid)
                .AddStatBonus(stat: StatType.Charisma, value: 4, descriptor: ModifierDescriptor.Alchemical)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.HauntingMists.Reference.Get().Icon)
                .Configure();
        }
    }
}
