using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using BlueprintCore.Utils.Types;
using Kingmaker.Enums.Damage;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using LostChapters.Modules.GraySisterhood.Archetypes;
using LostChapters.Modules.GraySisterhood.Archetypes.ClassFeatures;
using LostChapters.Modules.GraySisterhood.Feats.Selection;

namespace LostChapters.Modules.GraySisterhood.Feats.DeaconIncense
{
    internal class DeaconAirSecondIncense
    {
        public static readonly string Guid = "9e1eed63-c506-4993-a6db-2b3256a7249f";

        private const string IncenseName = "AirSecondIncense";
        private const string DisplayName = "AirSecondIncense.BuffName";
        private const string Description = "AirSecondIncense.LocalizedDescription";

        public static void Configure()
        {
            AbilityAreaEffectConfigurator.For(CapellanIncenseClassFeature.AreaRef)
                .AddAbilityAreaEffectBuff(
                    buff: DeaconAirSecondIncenseNormalBuff.GetReference(),
                    condition: ConditionsBuilder.New().IsAlly().CasterHasFact(Guid).CasterHasFact(fact: Deacon.FeatGuid, negate: true))
                .AddAbilityAreaEffectBuff(
                    buff: DeaconAirSecondIncenseStrongBuff.GetReference(),
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


    internal class DeaconAirSecondIncenseNormalBuff
    {
        public static readonly string Guid = "5e404847-7151-4322-bf23-2fa9b2050793";

        private const string BuffName = "AirSecondIncense.NormalBuff";
        private const string DisplayName = "AirSecondIncense.NormalBuff.BuffName";
        private const string Description = "AirSecondIncense.NormalBuff.LocalizedDescription";

#nullable enable
        private static BlueprintBuff? Reference;
#nullable disable

        public static BlueprintBuff GetReference() => Reference ??= CreateBuff();

        private static BlueprintBuff CreateBuff()
        {
            return BuffConfigurator.New(BuffName, Guid)
                .AddDamageResistanceEnergy(
                    type: DamageEnergyType.Electricity,
                    value: ContextValues.Constant(10))
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.HauntingMists.Reference.Get().Icon)
                .Configure();
        }
    }

    internal class DeaconAirSecondIncenseStrongBuff
    {
        public static readonly string Guid = "da0bdb07-72b4-4f82-a20e-2df0e0c0aa89";

        private const string BuffName = "AirSecondIncense.StrongBuff";
        private const string DisplayName = "AirSecondIncense.StrongBuff.BuffName";
        private const string Description = "AirSecondIncense.StrongBuff.LocalizedDescription";

#nullable enable
        private static BlueprintBuff? Reference;
#nullable disable

        public static BlueprintBuff GetReference() => Reference ??= CreateBuff();

        private static BlueprintBuff CreateBuff()
        {
            return BuffConfigurator.New(BuffName, Guid)
                .AddDamageResistanceEnergy(
                    type: DamageEnergyType.Electricity,
                    value: ContextValues.Rank())
                .AddContextRankConfig(ContextRankConfigs.ClassLevel([CharacterClassRefs.WarpriestClass.ToString()]).WithBonusValueProgression(10))
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.HauntingMists.Reference.Get().Icon)
                .Configure();
        }
    }
}
