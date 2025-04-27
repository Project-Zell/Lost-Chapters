using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using BlueprintCore.Utils.Types;
using LostChapters.Modules.GraySisterhood.Feats.Selection;
using LostChapters.Modules.GraySisterhood.Archetypes;
using LostChapters.Modules.GraySisterhood.Archetypes.ClassFeatures;

namespace LostChapters.Modules.GraySisterhood.Feats.DeaconIncense
{
    internal class DeaconCommunitySecondIncense
    {
        public static readonly string Guid = "eec421d5-bcb7-4f96-ba19-0a1b6c9374fd";

        private const string IncenseName = "CommunitySecondIncense";
        private const string DisplayName = "CommunitySecondIncense.BuffName";
        private const string Description = "CommunitySecondIncense.LocalizedDescription";
        public static void Configure()
        {
            AbilityAreaEffectConfigurator.For(CapellanIncenseClassFeature.AreaRef)
                .AddAbilityAreaEffectBuff(
                    buff: DeaconCommunitySecondIncenseBuff.GetReference(),
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

    internal class DeaconCommunitySecondIncenseBuff
    {
        public static readonly string Guid = "92325b51-faec-400b-8663-d919f6b8a6c8";

        private const string BuffName = "CommunitySecondIncense.NormalBuff";
        private const string DisplayName = "CommunitySecondIncense.NormalBuff.BuffName";
        private const string Description = "CommunitySecondIncense.NormalBuff.LocalizedDescription";

#nullable enable
        private static BlueprintBuff? Reference;
#nullable disable

        public static BlueprintBuff GetReference() => Reference ??= CreateBuff();

        private static BlueprintBuff CreateBuff()
        {
            return BuffConfigurator.New(BuffName, Guid)
                .AddSetAttackerMissChance(
                    type: SetAttackerMissChance.Type.Ranged,
                    conditions: ConditionsBuilder.New().CasterHasFact(fact: Deacon.FeatGuid, negate: true),
                    value: 20)
                .AddSetAttackerMissChance(
                    type: SetAttackerMissChance.Type.Ranged,
                    conditions: ConditionsBuilder.New().CasterHasFact(fact: Deacon.FeatGuid),
                    value: ContextValues.Rank())
                .AddContextRankConfig(ContextRankConfigs.ClassLevel(classes: [CharacterClassRefs.WarpriestClass.ToString()]).WithBonusValueProgression(20))
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.HauntingMists.Reference.Get().Icon)
                .Configure();
        }
    }
}