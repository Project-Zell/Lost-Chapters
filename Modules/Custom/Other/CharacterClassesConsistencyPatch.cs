using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;

namespace LostChapters.Modules.Custom.Other;

/// <summary>
/// Move all class proficiencies, cantrips and animal companion selection from level 1 to UI determination groups. For easier navigation and consisntency.
/// </summary>
internal class CharacterClassesConsistencyPatch
{
    internal static void Configure()
    {
        AddToUIDeterminatorsGroup(ProgressionRefs.ArcanistProgression.ToString(), [
            FeatureRefs.ArcanistProficiencies.ToString(), 
            FeatureRefs.ArcanistCantripsFeature.ToString()]);
        
        AddToUIDeterminatorsGroup(ProgressionRefs.BarbarianProgression.ToString(), FeatureRefs.InstinctualWarriorProficiencies.ToString());
        
        AddToUIDeterminatorsGroup(ProgressionRefs.BloodragerProgression.ToString(), [
            FeatureRefs.BloodragerProficiencies.ToString(), 
            FeatureRefs.SteelbloodArmorProficiency.ToString()]);
        
        AddToUIDeterminatorsGroup(ProgressionRefs.CavalierProgression.ToString(), [
            FeatureRefs.CavalierProficiencies.ToString(), 
            FeatureRefs.BeastRiderProficiencies.ToString(), 
            FeatureSelectionRefs.CavalierMountSelection.ToString(), 
            FeatureSelectionRefs.GhostRiderGhostMountSelection.ToString(), 
            FeatureSelectionRefs.OrderOfThePawMountSelection.ToString(), 
            FeatureSelectionRefs.BeastRiderMountSelection.ToString()]);

        AddToUIDeterminatorsGroup(ProgressionRefs.ClericProgression.ToString(), [
            FeatureRefs.AngelfireApostleProficiencies.ToString(),
            FeatureRefs.DevilbanePriestHeavyArmorProficiency.ToString(),
            FeatureRefs.EcclesitheurgeProficiencies.ToString()]);

        AddToUIDeterminatorsGroup(ProgressionRefs.DruidProgression.ToString(), FeatureSelectionRefs.AnimalCompanionSelectionPrimalDruid.ToString());
        
        AddToUIDeterminatorsGroup(ProgressionRefs.HunterProgression.ToString(), [
            FeatureRefs.HunterProficiencies.ToString(),
            FeatureSelectionRefs.AnimalCompanionSelectionDivineHound.ToString()]);

        AddToUIGroups(ProgressionRefs.HunterProgression.ToString(), [FeatureRefs.JudgmentFeature.ToString(), FeatureRefs.JudgmentAdditionalUse.ToString()]);

        AddToUIGroups(ProgressionRefs.InquisitorProgression.ToString(), [
            FeatureSelectionRefs.SlayerTalentSelection6.ToString(), 
            FeatureSelectionRefs.SlayerTalentSelection10.ToString()]);

        AddToUIDeterminatorsGroup(ProgressionRefs.MagusProgression.ToString(), [
            FeatureRefs.ArmoredBattlemageMediumArmor.ToString(),
            FeatureSelectionRefs.ArcaneRiderMountSelection.ToString()]);

        AddToUIGroups(ProgressionRefs.MagusProgression.ToString(), [FeatureRefs.ArmoredBattlemageMediumArmor.ToString(), FeatureRefs.ArmoredBattlemageArcaneHeavyArmor.ToString(), FeatureRefs.ArmoredBattlemageArmorTraining.ToString()]);

        AddToUIDeterminatorsGroup(ProgressionRefs.MonkProgression.ToString(), [
            FeatureRefs.SoheiProficiencies.ToString(),
            FeatureRefs.ZenArcherProficiency.ToString(),
            FeatureSelectionRefs.SoheiMonasticMountHorseSelection.ToString()]);

        AddToUIGroups(ProgressionRefs.MonkProgression.ToString(), [
            FeatureSelectionRefs.SoheiMountedCombatFeatSelection.ToString(),
            FeatureSelectionRefs.SoheiMountedCombatFeatSelection6.ToString(),
            FeatureSelectionRefs.SoheiMountedCombatFeatSelection10.ToString()]);

        AddToUIDeterminatorsGroup(ProgressionRefs.OracleProgression.ToString(), [FeatureRefs.OracleProficiency.ToString()]);
        
        AddToUIDeterminatorsGroup(ProgressionRefs.RangerProgression.ToString(), [FeatureSelectionRefs.NomadMountSelection.ToString()]);
        
        AddToUIDeterminatorsGroup(ProgressionRefs.ShamanProgression.ToString(), [FeatureSelectionRefs.AnimalCompanionSelectionWildlandShaman.ToString()]);
        
        AddToUIDeterminatorsGroup(ProgressionRefs.SkaldProgression.ToString(), [FeatureRefs.SkaldProficiencies.ToString()]);

        AddToUIDeterminatorsGroup(ProgressionRefs.SlayerProgression.ToString(), [FeatureRefs.StygianSlayerProficiencies.ToString()]);
        
        AddToUIDeterminatorsGroup(ProgressionRefs.WarpriestProgression.ToString(), [
            FeatureRefs.WarpriestProficiencies.ToString(),
            FeatureRefs.CultLeaderWeaponProficiencies.ToString(),
            FeatureRefs.MantisZealotProficiencies.ToString(),
        ]);

        AddToUIDeterminatorsGroup(ProgressionRefs.WitchProgression.ToString(), [FeatureRefs.SimpleWeaponProficiency.ToString()]);
        
        AddToUIDeterminatorsGroup(ProgressionRefs.AssassinProgression.ToString(), [FeatureRefs.AssassinProficiencies.ToString()]);
        
        AddToUIDeterminatorsGroup(ProgressionRefs.StalwartDefenderProgression.ToString(), [FeatureRefs.StalwartDefenderProficiencies.ToString()]);

    }

    private static void AddToUIDeterminatorsGroup(Blueprint<BlueprintReference<BlueprintProgression>> characterClass, params Blueprint<BlueprintFeatureBaseReference>[] uIDeterminatorsGroup)
    {
        ProgressionConfigurator.For(characterClass)
            .AddToUIDeterminatorsGroup(uIDeterminatorsGroup)
            .Configure();
    }

    private static void AddToUIGroups(Blueprint<BlueprintReference<BlueprintProgression>> characterClass, params Blueprint<BlueprintFeatureBaseReference>[] features)
    {
        ProgressionConfigurator.For(characterClass)
            .AddToUIGroups(features)
            .Configure();
    }
}
