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
    internal class CapellanWeatherMajorIncense
    {
        public static readonly string Guid = "9fe7f64b-f935-4600-8c27-51eddeec048f";

        private const string IncenseName = "WeatherMajorIncense";
        private const string DisplayName = "WeatherMajorIncense.BuffName";
        private const string Description = "WeatherMajorIncense.LocalizedDescription";

        public static void Configure()
        {
            AbilityAreaEffectConfigurator.For(CapellanIncenseClassFeature.AreaRef)
                .AddAbilityAreaEffectBuff(
                    buff: CapellanWeatherMajorIncenseBuff.GetReference(),
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

    internal class CapellanWeatherMajorIncenseBuff
    {
        public static readonly string Guid = "a78bf64d-471f-4bb0-bf0e-6f79972e16f7";

        private const string BuffName = "WeatherMajorIncense.BuffName";
        private const string DisplayName = "WeatherMajorIncense.BuffName.BuffName";
        private const string Description = "WeatherMajorIncense.BuffName.LocalizedDescription";

#nullable enable
        private static BlueprintBuff? Reference;
#nullable disable

        public static BlueprintBuff GetReference() => Reference ??= CreateBuff();

        private static BlueprintBuff CreateBuff()
        {
            return BuffConfigurator.New(BuffName, Guid)
                .AddDamageResistanceEnergy(
                    type: DamageEnergyType.Sonic,
                    value: ContextValues.Rank())
                .AddContextRankConfig(ContextRankConfigs.ClassLevel([CharacterClassRefs.WarpriestClass.ToString()]).WithBonusValueProgression(10))
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.HauntingMists.Reference.Get().Icon)
                .Configure();
        }
    }
}
