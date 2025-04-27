using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.BasicEx;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.ActivatableAbilities;
using Kingmaker.UnitLogic.Commands.Base;
using Kingmaker.UnitLogic.Mechanics;

namespace LostChapters.Modules.GraySisterhood.Feats
{
    internal class StandStillFeature
    {
        private static readonly string FeatName = "StandStill";
        private static readonly string FeatGuid = "61d7fe00-6475-459e-a404-bd9152edb6fb";
        private static readonly string DisplayName = "StandStill.BuffName";
        private static readonly string Description = "StandStill.LocalizedDescription";

        private static readonly string ToggleName = "StandStill.Toggle";
        private static readonly string ToggleGuid = "54382e4b-e3ba-49af-8c60-327e23b5af51";
        private static readonly string ToggleDisplayName = "StandStill.Toggle.BuffName";
        private static readonly string ToggleDescription = "StandStill.Toggle.LocalizedDescription";

        private static readonly string EnemyBuff = "StandStill.EnemyBuff";
        private static readonly string EnemyBuffGuid = "8c5a9b63-afac-4ec9-9b17-f2f0747a8afa";
        private static readonly string EnemyBuffDisplayName = "StandStill.EnemyBuff.BuffName";
        private static readonly string EnemyBuffDescription = "StandStill.EnemyBuff.LocalizedDescription";

        private static readonly string SelfBuffName = "StandStill.SelfBuff";
        private static readonly string SelfBuffGuid = "0ab2d299-f780-4618-9d87-8911dbc0901b";
        private static readonly string SelfBuffDisplayName = "StandStill.SelfBuff.BuffName";
        private static readonly string SelfBuffDescription = "StandStill.SelfBuff.LocalizedDescription";

        public static void Configure()
        {
            var icon = AbilityRefs.HoldPersonMass.Reference.Get().Icon;

            var onEnemyBuff = BuffConfigurator.New(EnemyBuff, EnemyBuffGuid)
                .AddCondition(UnitCondition.CantMove)
                .SetIcon(AbilityRefs.HoldPerson.Reference.Get().Icon)
                .SetDisplayName(EnemyBuffDisplayName)
                .SetDescription(EnemyBuffDescription)
                .Configure();

            var duration = ContextDuration.Fixed(1, DurationRate.Rounds);

            var actionBuilder = ActionsBuilder.New()
                .Conditional(ConditionsBuilder.New().IsInCombat(),
                    ifTrue: ActionsBuilder.New().ApplyBuff(onEnemyBuff, duration))
                .Build();

            var selfBuff = BuffConfigurator.New(SelfBuffName, SelfBuffGuid)
                .AddInitiatorAttackWithWeaponTrigger(action: actionBuilder, onAttackOfOpportunity: true, onlyHit: true, checkWeaponRangeType: true)
                .AddAttackOfOpportunityAttackBonus(-2)
                .SetDisplayName(SelfBuffDisplayName)
                .SetDescription(SelfBuffDescription)
                .Configure();

            var toggle = ActivatableAbilityConfigurator.New(ToggleName, ToggleGuid)
                .SetBuff(selfBuff)
                .SetActivateOnUnitAction(AbilityActivateOnUnitActionType.Attack)
                .SetActivationType(AbilityActivationType.Immediately)
                .SetActivateWithUnitCommand(UnitCommand.CommandType.Free)
                .SetDeactivateImmediately(true)
                .SetIsOnByDefault(true)
                .SetDisplayName(ToggleDisplayName)
                .SetDescription(ToggleDescription)
                .SetIcon(icon)
                .Configure();

            FeatureConfigurator.New(FeatName, FeatGuid, [FeatureGroup.Feat, FeatureGroup.CombatFeat])
                .AddFacts([toggle])
                .AddPrerequisiteFeature(FeatureRefs.CombatReflexes.ToString())
                .AddFeatureTagsComponent(FeatureTag.Attack | FeatureTag.Melee)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(icon)
                .Configure();
        }
    }
}
