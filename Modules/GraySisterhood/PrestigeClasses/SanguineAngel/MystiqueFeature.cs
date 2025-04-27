using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components.Base;
using Kingmaker.UnitLogic.Abilities.Components.TargetCheckers;
using LostChapters.Components;

namespace LostChapters.Modules.GraySisterhood.PrestigeClasses.SanguineAngel;

internal class MystiqueFeature
{
    public static readonly string Guid = "{f7c3ec23-a6c7-4298-b470-a5a213952152}";

    private static readonly string FeatureName = "Mystique";
    private static readonly string DisplayName = "Mystique.Name";
    private static readonly string Description = "Mystique.Description";

    internal static void Configure()
    {
        Ability.Configure();

        FeatureConfigurator.New(FeatureName, Guid)
            .AddFacts([Ability.Guid])
            .AddComponent<ChangeDCToClassLevelPlusStatBonus>(component =>
                {
                    component.Spell = BlueprintTool.Get<BlueprintAbility>(Ability.Guid);
                    component.ClassGuid = Ability.Guid;
                    component.Stat = StatType.Charisma;
                    component.BaseDC = 10;
                })
            .AddStatBonus(stat: StatType.CheckDiplomacy, value: 4)
            .AddStatBonus(stat: StatType.CheckIntimidate, value: 4)
            .AddAbilityResources(resource: Ability.ResourceGuid, restoreAmount: true)
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .Configure();
    }

    internal class Ability
    {
        public static readonly string Guid = "{7549bef1-f234-429e-b44a-742443594556}";
        public static readonly string ResourceGuid = "{2ac462a7-a210-4ac6-b777-77d830b41745}";

        private static readonly string AbilityName = "Mystique.Ability";
        private static readonly string ResourceName = "Mystique.Resource";

        internal static void Configure()
        {
            var resource = AbilityResourceConfigurator.New(ResourceName, ResourceGuid)
                .SetMaxAmount(builder: ResourceAmountBuilder.New(1))
                .Configure();

            var rankConfig = ContextRankConfigs.CharacterLevel();
            var duration = ContextDuration.Variable(ContextValues.Rank());

            var action = ActionsBuilder.New().ConditionalSaved(failed: ActionsBuilder.New().ApplyBuff(
                buff: BuffRefs.DominatePersonBuff.ToString(), durationValue: duration).Build());

            AbilityConfigurator.New(AbilityName, Guid)
                .AddAbilityEffectRunAction(actions: action, savingThrowType: SavingThrowType.Will)
                .AddContextRankConfig(rankConfig)
                .CopyFrom(AbilityRefs.DominatePerson.ToString(),
                    typeof(SpellComponent),
                    typeof(AbilitySpawnFx),
                    typeof(SpellDescriptorComponent),
                    typeof(AbilityTargetHasNoFactUnless),
                    typeof(AbilityTargetHasFact))
                .AddAbilityResourceLogic(requiredResource: resource, isSpendResource: true, amount: 1)
                .SetType(AbilityType.SpellLike)
                .Configure();
        }
    }
}
