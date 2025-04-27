using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.BasicEx;
using BlueprintCore.Utils;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.Utility;

namespace LostChapters.Tools
{
    internal static class TeamworkFeatHelper
    {
        internal static void AddAsDLCTeamworkFeat(this BlueprintFeature blueprint, string foresterAbilityGuid, string vanguardBuffGuid)
        {
            AbilityConfigurator abilityConfigurator = AbilityConfigurator.New("ForesterTactician" + blueprint.name + "Ability", foresterAbilityGuid).SetDisplayName(blueprint.m_DisplayName).SetDescription(blueprint.m_Description)
                .SetIcon(blueprint.Icon)
                .SetRange(AbilityRange.Personal)
                .SetType(AbilityType.Extraordinary)
                .SetParent(AbilityRefs.ForesterTacticianBaseAbility.ToString())
                .AddAbilityEffectRunAction(ActionsBuilder.New().Conditional(ConditionsBuilder.New().HasFact(blueprint, negate: true), ActionsBuilder.New().ApplyBuff(vanguardBuffGuid, ContextDuration.Variable(ContextValues.Rank()))))
                .AddContextRankConfig(ContextRankConfigs.ClassLevel(new string[1] { CharacterClassRefs.HunterClass.ToString() }).WithDiv2Progression(3));
            TargetType? targetType = TargetType.Ally;
            Feet? radius = new Feet(30f);
            AbilityConfigurator abilityConfigurator2 = abilityConfigurator.AddAbilityTargetsAround(null, null, null, ComponentMerge.Fail, radius, null, targetType);
            Blueprint<BlueprintUnitFactReference> unitFact = blueprint;
            AbilityConfigurator abilityConfigurator3 = abilityConfigurator2.AddAbilityShowIfCasterHasFact(null, ComponentMerge.Fail, null, unitFact);
            bool? isSpendResource = true;
            Blueprint<BlueprintAbilityResourceReference> requiredResource = AbilityResourceRefs.ForesterTacticianResource.ToString();
            BlueprintAbility foresterAbility = abilityConfigurator3.AddAbilityResourceLogic(null, null, isSpendResource, null, ComponentMerge.Fail, requiredResource).Configure();
            AbilityConfigurator.For(AbilityRefs.ForesterTacticianBaseAbility).EditComponent(delegate (AbilityVariants c)
            {
                c.m_Variants = CommonTool.Append(c.m_Variants, foresterAbility.ToReference<BlueprintAbilityReference>());
            }).Configure();
        }
    }
}
