using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.Configurators.UnitLogic.Properties;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.UnitLogic.Mechanics.Properties;
using Kingmaker.Utility;
using LostChapters.Components;
using System;
using System.Linq;

namespace LostChapters.Tools;

internal class RageHelper
{
    internal static void ConfigureRageProperty()
    {
        UnitPropertyConfigurator.For(UnitPropertyRefs.RageLevelProperty.ToString())
            .RemoveComponents(x => x is SummClassLevelGetter)
            .AddComponent<SummClassLevelGatedGetter>(z =>
            {
                z.Classes = [
                    BlueprintTool.GetRef<BlueprintCharacterClassReference>(CharacterClassRefs.BarbarianClass.ToString()),
                    BlueprintTool.GetRef<BlueprintCharacterClassReference>(CharacterClassRefs.SkaldClass.ToString()),
                    BlueprintTool.GetRef<BlueprintCharacterClassReference>(CharacterClassRefs.BloodragerClass.ToString())];
                z.Archetypes = [
                    BlueprintTool.GetRef<BlueprintArchetypeReference>(ArchetypeRefs.PrimalistArchetype.ToString())];
                z.GatedFacts = [];
                z.Settings = new PropertySettings()
                {
                    m_StepLevel = 4
                };
            })
            .Configure();
    }

    internal static ActionsBuilder NewActivateRagePowersActionBuilder()
    {
        var recklessStanceCondition = ConditionsBuilder.New().HasFact(BuffRefs.RecklessStanceSwitchBuff.ToString());
        var recklessStanceAction = ActionsBuilder.New().ApplyBuffPermanent(buff: BuffRefs.RecklessStanceEffectBuff.ToString(), asChild: true);

        var inspireFerocityCondition = ConditionsBuilder.New().HasFact(BuffRefs.RecklessStanceSwitchBuff.ToString()).HasFact(BuffRefs.InspireFerocityBaseBuff.ToString());
        var inspireFerocityAction = ActionsBuilder.New().ApplyBuffPermanent(buff: BuffRefs.InspireFerocityRageBuff.ToString(), asChild: true);

        var animalFuryCondition = ConditionsBuilder.New().HasFact(FeatureRefs.AnimalFuryFeature.ToString());
        var animalFuryAction = ActionsBuilder.New().ApplyBuffPermanent(buff: BuffRefs.AnimalFuryRageBuff.ToString(), asChild: true);

        var swiftFootCondition = ConditionsBuilder.New().HasFact(FeatureRefs.SwiftFootFeature.ToString());
        var swiftFootAction = ActionsBuilder.New().ApplyBuffPermanent(buff: BuffRefs.SwiftFootRageBuff.ToString(), asChild: true);

        var internalFortitudeCondition = ConditionsBuilder.New().HasFact(FeatureRefs.InternalFortitudeFeature.ToString());
        var internalFortitudeAction = ActionsBuilder.New().ApplyBuffPermanent(buff: BuffRefs.InternalFortitudeRageBuff.ToString(), asChild: true);

        var lethalStanceCondition = ConditionsBuilder.New().HasFact(BuffRefs.LethalStanceSwitchBuff.ToString());
        var lethalStanceAction = ActionsBuilder.New().ApplyBuffPermanent(buff: BuffRefs.LethalStanceEffectBuff.ToString(), asChild: true);

        var beastTotemLesserCondition = ConditionsBuilder.New().HasFact(FeatureRefs.BeastTotemLesserFeature.ToString());
        var beastTotemLesserAction = ActionsBuilder.New().ApplyBuffPermanent(buff: BuffRefs.BeastTotemLesserRageBuff.ToString(), asChild: true);

        var beastTotemCondition = ConditionsBuilder.New().HasFact(FeatureRefs.BeastTotemFeature.ToString());
        var beastTotemAction = ActionsBuilder.New().ApplyBuffPermanent(buff: BuffRefs.BeastTotemRageBuff.ToString(), asChild: true);

        var beastTotemGreaterCondition = ConditionsBuilder.New().HasFact(FeatureRefs.BeastTotemGreaterFeature.ToString());
        var beastTotemGreaterAction = ActionsBuilder.New().ApplyBuffPermanent(buff: BuffRefs.BeastTotemGreaterRageBuff.ToString(), asChild: true);

        var fearlessRageCondition = ConditionsBuilder.New().HasFact(FeatureRefs.FearlessRageFeature.ToString());
        var featlessRageAction = ActionsBuilder.New().ApplyBuffPermanent(buff: BuffRefs.FearlessRageRageBuff.ToString(), asChild: true);

        var guardedStanceCondition = ConditionsBuilder.New().HasFact(BuffRefs.GuardedStanceSwitchBuff.ToString());
        var guardedStanceAction = ActionsBuilder.New().ApplyBuffPermanent(buff: BuffRefs.GuardedStanceEffectBuff.ToString(), asChild: true);

        var scentCondition = ConditionsBuilder.New().HasFact(FeatureRefs.ScentFeature.ToString());
        var scentAction = ActionsBuilder.New().ApplyBuffPermanent(buff: BuffRefs.ScentRageBuff.ToString(), asChild: true);

        var fiendTotemLesserCondition = ConditionsBuilder.New().HasFact(FeatureRefs.FiendTotemLesserFeature.ToString());
        var fiendTotemLesserAction = ActionsBuilder.New().ApplyBuffPermanent(buff: BuffRefs.FiendTotemLesserRageBuff.ToString(), asChild: true);

        var fiendTotemCondition = ConditionsBuilder.New().HasFact(FeatureRefs.FiendTotemFeature.ToString());
        var fiendTotemAction = ActionsBuilder.New().ApplyBuffPermanent(buff: BuffRefs.FiendTotemRageBuff.ToString(), asChild: true);

        var fiendTotemGreaterCondition = ConditionsBuilder.New().HasFact(FeatureRefs.FiendTotemGreaterFeature.ToString());
        var fiendTotemGreaterAction = ActionsBuilder.New().ApplyBuffPermanent(buff: BuffRefs.FiendTotemGreaterRageBuff.ToString(), asChild: true);

        var clearMindCondition = ConditionsBuilder.New().HasFact(FeatureRefs.ClearMindFeature.ToString());
        var clearMindAction = ActionsBuilder.New().ApplyBuffPermanent(buff: BuffRefs.ClearMindBuff.ToString(), asChild: true);

        var comeAndGetMeCondition = ConditionsBuilder.New().HasFact(BuffRefs.ComeAndGetMeSwitchBuff.ToString());
        var comeAndGetMeAction = ActionsBuilder.New().ApplyBuffPermanent(buff: BuffRefs.ComeAndGetMeEffectBuff.ToString(), asChild: true);

        var action = ActionsBuilder.New()
            .Conditional(conditions: recklessStanceCondition, ifTrue: recklessStanceAction)
            .Conditional(conditions: inspireFerocityCondition, ifTrue: inspireFerocityAction)
            .Conditional(conditions: animalFuryCondition, ifTrue: animalFuryAction)
            .Conditional(conditions: swiftFootCondition, ifTrue: swiftFootAction)
            .Conditional(conditions: internalFortitudeCondition, ifTrue: internalFortitudeAction)
            .Conditional(conditions: lethalStanceCondition, ifTrue: lethalStanceAction)
            .Conditional(conditions: beastTotemLesserCondition, ifTrue: beastTotemLesserAction)
            .Conditional(conditions: beastTotemCondition, ifTrue: beastTotemAction)
            .Conditional(conditions: beastTotemGreaterCondition, ifTrue: beastTotemGreaterAction)
            .Conditional(conditions: fearlessRageCondition, ifTrue: featlessRageAction)
            .Conditional(conditions: guardedStanceCondition, ifTrue: guardedStanceAction)
            .Conditional(conditions: scentCondition, ifTrue: scentAction)
            .Conditional(conditions: fiendTotemLesserCondition, ifTrue: fiendTotemLesserAction)
            .Conditional(conditions: fiendTotemCondition, ifTrue: fiendTotemAction)
            .Conditional(conditions: fiendTotemGreaterCondition, ifTrue: fiendTotemGreaterAction)
            .Conditional(conditions: clearMindCondition, ifTrue: clearMindAction)
            .Conditional(conditions: comeAndGetMeCondition, ifTrue: comeAndGetMeAction);

        return action;
    }

    internal static ActionsBuilder NewDeactivateRagePowersActionBuilder()
    {
        return ActionsBuilder.New()
            .RemoveBuff(buff: BuffRefs.RecklessStanceEffectBuff.ToString())
            .RemoveBuff(buff: BuffRefs.InspireFerocityRageBuff.ToString())
            .RemoveBuff(buff: BuffRefs.LethalStanceEffectBuff.ToString())
            .RemoveBuff(buff: BuffRefs.GuardedStanceEffectBuff.ToString())
            .RemoveBuff(buff: BuffRefs.ScentRageBuff.ToString())
            .RemoveBuff(buff: BuffRefs.FiendTotemLesserRageBuff.ToString())
            .RemoveBuff(buff: BuffRefs.FiendTotemLesserRageBuff.ToString())
            .RemoveBuff(buff: BuffRefs.FiendTotemGreaterRageBuff.ToString())
            .RemoveBuff(buff: BuffRefs.ClearMindBuff.ToString())
            .RemoveBuff(buff: BuffRefs.ComeAndGetMeEffectBuff.ToString());
    }

    internal static void ConfigureRageStancesFor(string buffGuid)
    {
        BuffConfigurator.For(BuffRefs.RecklessStanceSwitchBuff.ToString())
            .AddFactContextActions(
                    activated: ActionsBuilder.New().Conditional(ConditionsBuilder.New().HasFact(buffGuid),
                        ifTrue: ActionsBuilder.New().ApplyBuffPermanent(buff: BuffRefs.RecklessStanceEffectBuff.ToString(), asChild: true)),
                    deactivated: ActionsBuilder.New().RemoveBuff(BuffRefs.RecklessStanceEffectBuff.ToString()))
            .Configure();

        BuffConfigurator.For(BuffRefs.LethalStanceSwitchBuff.ToString())
            .AddFactContextActions(
                activated: ActionsBuilder.New().Conditional(ConditionsBuilder.New().HasFact(buffGuid),
                    ifTrue: ActionsBuilder.New().ApplyBuffPermanent(buff: BuffRefs.LethalStanceEffectBuff.ToString(), asChild: true)),
                deactivated: ActionsBuilder.New().RemoveBuff(BuffRefs.LethalStanceEffectBuff.ToString()))
            .Configure();

        BuffConfigurator.For(BuffRefs.GuardedStanceSwitchBuff.ToString())
            .AddFactContextActions(
                activated: ActionsBuilder.New().Conditional(ConditionsBuilder.New().HasFact(buffGuid),
                    ifTrue: ActionsBuilder.New().ApplyBuffPermanent(buff: BuffRefs.GuardedStanceEffectBuff.ToString(), asChild: true)),
                deactivated: ActionsBuilder.New().RemoveBuff(BuffRefs.GuardedStanceEffectBuff.ToString()))
            .Configure();

        BuffConfigurator.For(BuffRefs.ComeAndGetMeSwitchBuff.ToString())
            .AddFactContextActions(
                activated: ActionsBuilder.New().Conditional(ConditionsBuilder.New().HasFact(buffGuid),
                    ifTrue: ActionsBuilder.New().ApplyBuffPermanent(buff: BuffRefs.ComeAndGetMeEffectBuff.ToString(), asChild: true)),
                deactivated: ActionsBuilder.New().RemoveBuff(BuffRefs.ComeAndGetMeEffectBuff.ToString()))
            .Configure();
        
        BuffConfigurator.For(BuffRefs.PowerfulStanceSwitchBuff.ToString())
            .AddFactContextActions(
                activated: ActionsBuilder.New().Conditional(ConditionsBuilder.New().HasFact(buffGuid),
                    ifTrue: ActionsBuilder.New().ApplyBuffPermanent(buff: BuffRefs.PowerfulStanceEffectBuff.ToString(), asChild: true)),
                deactivated: ActionsBuilder.New().RemoveBuff(BuffRefs.PowerfulStanceEffectBuff.ToString()))
            .Configure();
    }

    internal static void ConfigureRageBuffsFor(string buffGuid)
    {
        FeatureConfigurator.For(FeatureRefs.CelestialTotemFeature)
            .AddBuffExtraEffects(checkedBuff: buffGuid, extraEffectBuff: BuffRefs.CelestialTotemAreaBuff.ToString())
            .Configure();

        FeatureConfigurator.For(FeatureRefs.CelestialTotemGreaterFeature)
            .AddBuffExtraEffects(checkedBuff: buffGuid, extraEffectBuff: BuffRefs.CelestialTotemGreaterBuff.ToString())
            .Configure();

        FeatureConfigurator.For(FeatureRefs.CelestialTotemLesserFeature)
            .AddBuffExtraEffects(checkedBuff: buffGuid, extraEffectBuff: BuffRefs.CelestialTotemLesserBuff.ToString())
            .Configure();

        FeatureConfigurator.For(FeatureRefs.DaemonTotemFeature)
            .AddBuffExtraEffects(checkedBuff: buffGuid, extraEffectBuff: BuffRefs.DaemonTotemBuff.ToString())
            .Configure();

        FeatureConfigurator.For(FeatureRefs.DaemonTotemGreaterFeature)
            .AddBuffExtraEffects(checkedBuff: buffGuid, extraEffectBuff: BuffRefs.DaemonTotemGreaterBuff.ToString())
            .Configure();

        FeatureConfigurator.For(FeatureRefs.DaemonTotemLesserFeature)
            .AddBuffExtraEffects(checkedBuff: buffGuid, extraEffectBuff: BuffRefs.DaemonTotemLesserBaseBuff.ToString())
            .Configure();
    }

    public static void AddArchetypeToRagePowerCalculation(string classGuid, string archetypeGuid)
    {
        var rageProperty = BlueprintTool.Get<BlueprintUnitProperty>(UnitPropertyRefs.RageLevelProperty.ToString());
        var component = rageProperty.Components.OfType<SummClassLevelGatedGetter>().FirstOrDefault();
        
        var classReference = BlueprintTool.GetRef<BlueprintCharacterClassReference>(classGuid);
        if(component.Classes.Contains(classReference) is false)
            component.Classes = [.. component.Classes,  classReference];

        var archetypeReference = BlueprintTool.GetRef<BlueprintArchetypeReference>(archetypeGuid);
        if (component.Archetypes.Contains(archetypeReference) is false)
            component.Archetypes = [.. component.Archetypes, archetypeReference];
    }

    public static void AddFactGateToRageLevelProperty(string factGuid)
    {
        var rageProperty = BlueprintTool.Get<BlueprintUnitProperty>(UnitPropertyRefs.RageLevelProperty.ToString());
        var component = rageProperty.Components.OfType<SummClassLevelGatedGetter>().FirstOrDefault();

        var factReference = BlueprintTool.GetRef<BlueprintUnitFactReference>(factGuid);

        component.GatedFacts ??= [];

        if (component.GatedFacts.Contains(factReference) is false)
            component.GatedFacts = [.. component.GatedFacts, factReference];
    }

    internal static void AddArchetypeToRagePowerPrerequisites(string characterClass, string archetype)
    {
        FeatureConfigurator.For(FeatureRefs.BeastTotemFeature.ToString())
            .AddPrerequisiteArchetypeLevel(level: 06, characterClass: characterClass, archetype: archetype, group: Prerequisite.GroupType.Any)
            .Configure();

        FeatureConfigurator.For(FeatureRefs.BeastTotemGreaterFeature.ToString())
            .AddPrerequisiteArchetypeLevel(level: 10, characterClass: characterClass, archetype: archetype, group: Prerequisite.GroupType.Any)
            .Configure();

        FeatureConfigurator.For(FeatureRefs.CelestialTotemFeature.ToString())
            .AddPrerequisiteArchetypeLevel(level: 06, characterClass: characterClass, archetype: archetype, group: Prerequisite.GroupType.Any)
            .Configure();

        FeatureConfigurator.For(FeatureRefs.CelestialTotemGreaterFeature.ToString())
            .AddPrerequisiteArchetypeLevel(level: 10, characterClass: characterClass, archetype: archetype, group: Prerequisite.GroupType.Any)
            .Configure();

        FeatureConfigurator.For(FeatureRefs.ClearMindFeature.ToString())
            .AddPrerequisiteArchetypeLevel(level: 08, characterClass: characterClass, archetype: archetype, group: Prerequisite.GroupType.Any)
            .Configure();

        FeatureConfigurator.For(FeatureRefs.ComeAndGetMeFeature.ToString())
            .AddPrerequisiteArchetypeLevel(level: 12, characterClass: characterClass, archetype: archetype, group: Prerequisite.GroupType.Any)
            .Configure();

        FeatureConfigurator.For(FeatureRefs.CripplingBlowsFeature.ToString())
            .AddPrerequisiteArchetypeLevel(level: 08, characterClass: characterClass, archetype: archetype, group: Prerequisite.GroupType.Any)
            .Configure();

        FeatureConfigurator.For(FeatureRefs.DaemonTotemFeature.ToString())
            .AddPrerequisiteArchetypeLevel(level: 06, characterClass: characterClass, archetype: archetype, group: Prerequisite.GroupType.Any)
            .Configure();

        FeatureConfigurator.For(FeatureRefs.DaemonTotemGreaterFeature.ToString())
            .AddPrerequisiteArchetypeLevel(level: 10, characterClass: characterClass, archetype: archetype, group: Prerequisite.GroupType.Any)
            .Configure();

        FeatureConfigurator.For(FeatureRefs.DeadlyAccuracyFeature.ToString())
            .AddPrerequisiteArchetypeLevel(level: 4, characterClass: characterClass, archetype: archetype, group: Prerequisite.GroupType.Any)
            .Configure();

        FeatureConfigurator.For(FeatureRefs.FearlessRageFeature.ToString())
            .AddPrerequisiteArchetypeLevel(level: 12, characterClass: characterClass, archetype: archetype, group: Prerequisite.GroupType.Any)
            .Configure();

        FeatureConfigurator.For(FeatureRefs.FiendTotemFeature.ToString())
            .AddPrerequisiteArchetypeLevel(level: 06, characterClass: characterClass, archetype: archetype, group: Prerequisite.GroupType.Any)
            .Configure();

        FeatureConfigurator.For(FeatureRefs.FiendTotemGreaterFeature.ToString())
            .AddPrerequisiteArchetypeLevel(level: 10, characterClass: characterClass, archetype: archetype, group: Prerequisite.GroupType.Any)
            .Configure();

        FeatureConfigurator.For(FeatureRefs.IncreasedDamageReductionFeature.ToString())
            .AddPrerequisiteArchetypeLevel(level: 08, characterClass: characterClass, archetype: archetype, group: Prerequisite.GroupType.Any)
            .Configure();

        FeatureConfigurator.For(FeatureRefs.InternalFortitudeFeature.ToString())
            .AddPrerequisiteArchetypeLevel(level: 08, characterClass: characterClass, archetype: archetype, group: Prerequisite.GroupType.Any)
            .Configure();

        FeatureConfigurator.For(FeatureRefs.LethalAccuracyFeature.ToString())
            .AddPrerequisiteArchetypeLevel(level: 16, characterClass: characterClass, archetype: archetype, group: Prerequisite.GroupType.Any)
            .Configure();

        FeatureConfigurator.For(FeatureRefs.ProtectVitalsFeature.ToString())
            .AddPrerequisiteArchetypeLevel(level: 08, characterClass: characterClass, archetype: archetype, group: Prerequisite.GroupType.Any)
            .Configure();

        FeatureConfigurator.For(FeatureRefs.ReflexiveDodgeFeature.ToString())
            .AddPrerequisiteArchetypeLevel(level: 06, characterClass: characterClass, archetype: archetype, group: Prerequisite.GroupType.Any)
            .Configure();

        FeatureConfigurator.For(FeatureRefs.RenewedVigorFeature.ToString())
            .AddPrerequisiteArchetypeLevel(level: 04, characterClass: characterClass, archetype: archetype, group: Prerequisite.GroupType.Any)
            .Configure();

        FeatureConfigurator.For(FeatureRefs.RollingDodgeFeature.ToString())
            .AddPrerequisiteArchetypeLevel(level: 06, characterClass: characterClass, archetype: archetype, group: Prerequisite.GroupType.Any)
            .Configure();

        FeatureConfigurator.For(FeatureRefs.WreckingBlowsFeature.ToString())
            .AddPrerequisiteArchetypeLevel(level: 12, characterClass: characterClass, archetype: archetype, group: Prerequisite.GroupType.Any)
            .Configure();

    }
}
