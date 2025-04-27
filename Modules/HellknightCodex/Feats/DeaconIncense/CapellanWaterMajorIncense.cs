using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using BlueprintCore.Utils.Types;
using Kingmaker.Enums.Damage;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using LostChapters.Modules.GraySisterhood.Archetypes.ClassFeatures;
using LostChapters.Modules.GraySisterhood.Feats.Selection;

namespace LostChapters.Modules.GraySisterhood.Feats.DeaconIncense
{
    internal class CapellanWaterMajorIncense
    {
        public static readonly string Guid = "23b006c3-1bd7-4cf6-b134-8d224e8903f2";

        private const string IncenseName = "WaterMajorIncense";
        private const string DisplayName = "WaterMajorIncense.BuffName";
        private const string Description = "WaterMajorIncense.LocalizedDescription";

        public static void Configure()
        {
            AbilityAreaEffectConfigurator.For(CapellanIncenseClassFeature.AreaRef)
                .AddAbilityAreaEffectBuff(
                    buff: CapellanWaterMajorIncenseBuff.GetReference(),
                    condition: ConditionsBuilder.New().IsAlly().CasterHasFact(Guid))
                .Configure();

            FeatureConfigurator.New(IncenseName, Guid)
                .AddToFeatureSelection(CapellanIncenseSelector.Guid)
                .SetIcon(AbilityRefs.HauntingMists.Reference.Get().Icon)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }

    internal class CapellanWaterMajorIncenseBuff
    {
        public static readonly string Guid = "d5c1317f-5de2-4cb4-9a2c-40acfda2efa1";

        private const string BuffName = "WaterMajorIncense.BuffName";
        private const string DisplayName = "WaterMajorIncense.BuffName.BuffName";
        private const string Description = "WaterMajorIncense.BuffName.LocalizedDescription";

#nullable enable
        private static BlueprintBuff? Reference;
#nullable disable

        public static BlueprintBuff GetReference() => Reference ??= CreateBuff();

        private static BlueprintBuff CreateBuff()
        {
            return BuffConfigurator.New(BuffName, Guid)
                .AddDamageResistanceEnergy(
                    type: DamageEnergyType.Cold,
                    value: ContextValues.Rank())
                .AddContextRankConfig(ContextRankConfigs.ClassLevel([CharacterClassRefs.WarpriestClass.ToString()]).WithBonusValueProgression(10))
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.HauntingMists.Reference.Get().Icon)
                .Configure();
        }
    }
}
