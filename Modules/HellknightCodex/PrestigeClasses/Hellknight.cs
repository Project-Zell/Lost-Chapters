using BlueprintCore.Blueprints.Configurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.Classes.Selection;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Blueprints.Items.Armors;
using LostChapters.Modules.GraySisterhood.Feats.HellknightCodex;
using LostChapters.Modules.GraySisterhood.Feats.Selection;

namespace LostChapters.Modules.GraySisterhood.PrestigeClasses
{
    public class Hellknight
    {
        private static readonly string HellknightProgression = "HellknightProgression";
        private static readonly string HellknightProgressionGuid = "18f452e5-e86a-4f60-9b3e-9556b7eb0ae7";

        public static void Configure()
        {
            var progress = ProgressionConfigurator.New(HellknightProgression, HellknightProgressionGuid)
                .SetClasses(CharacterClassRefs.HellknightClass.ToString())
                .AddToLevelEntry(01, HellknightOrderSelection.HellknightOrderVariantRef, HellknightDisciplineSelection.Guid, FeatureRefs.SmiteChaosFeature.ToString(), CreateHellknightCodex())
                .AddToLevelEntry(02, CreateHellknightArmor())
                .AddToLevelEntry(03, CreateNewForceOfWill())
                .AddToLevelEntry(04, HellknightArmorGuid, HellknightDisciplineSelection.Guid, FeatureRefs.SmiteChaosAdditionalUse.ToString())
                .AddToLevelEntry(05)
                .AddToLevelEntry(06, HellknightArmorGuid, NewForceOfWillGuid)
                .AddToLevelEntry(07, HellknightDisciplineSelection.Guid, FeatureRefs.SmiteChaosAdditionalUse.ToString())
                .AddToLevelEntry(08, HellknightArmorGuid)
                .AddToLevelEntry(09, NewForceOfWillGuid)
                .AddToLevelEntry(10, CreateForgedInHell(), HellknightDisciplineSelection.Guid, FeatureRefs.SmiteChaosAdditionalUse.ToString())
                .SetUIGroups(UIGroupBuilder.New()
                    .AddGroup(new Blueprint<BlueprintFeatureBaseReference>[] { HellknightArmorGuid, ForgedInHellGuid })
                    .AddGroup(new Blueprint<BlueprintFeatureBaseReference>[] { HellknightDisciplineSelection.Guid })
                    .AddGroup(new Blueprint<BlueprintFeatureBaseReference>[] { NewForceOfWillGuid }))
                .SetUIDeterminatorsGroup(new Blueprint<BlueprintFeatureBaseReference>[] { HellknightOrderSelection.HellknightOrderVariantRef, FeatureRefs.SmiteChaosFeature.ToString() })
                .SetIsClassFeature(true)
                .Configure();

            CharacterClassConfigurator.For(CharacterClassRefs.HellknightClass)
                .SetProgression(progress)
                .Configure();
        }



        private static readonly string HellknightArmor = "Hellknight.HellknightArmor";
        private static readonly string HellknightArmorGuid = "{d7a59760-e5f8-4b93-ab0e-4001bcaabc49}";

        private static readonly string HellknightArmorDisplayName = "Hellknight.HellknightArmor.BuffName";
        private static readonly string HellknightArmorDescription = "Hellknight.HellknightArmor.Description";

        private static BlueprintFeature CreateHellknightArmor()
        {
            var icon = FeatureRefs.ArmoredHulkIndomitableStance.Reference.Get().Icon;

            return FeatureConfigurator.New(HellknightArmor, HellknightArmorGuid)
                .AddArmorCheckPenaltyIncrease(bonesPerRank: 1, category: ArmorProficiencyGroup.Heavy, checkCategory: true)
                .AddMaxDexBonusIncrease(bonesPerRank: 1, category: ArmorProficiencyGroup.Heavy, checkCategory: true)
                .AddDamageResistanceEnergy(type: Kingmaker.Enums.Damage.DamageEnergyType.Fire, value: 10)
                .SetRanks(4)
                .SetDescription(HellknightArmorDescription)
                .SetDisplayName(HellknightArmorDisplayName)
                .SetIcon(icon)
                .Configure();
        }

        private static readonly string ForgedInHell = "Hellknight.ForgedInHell";
        private static readonly string ForgedInHellGuid = "2f26d05a-d70c-4a95-9a63-e75026ed8d06";

        private static readonly string ForgedInHellDisplayName = "Hellknight.ForgedInHell.BuffName";
        private static readonly string ForgedInHellDescription = "Hellknight.ForgedInHell.Description";

        private static BlueprintFeature CreateForgedInHell()
        {
            var icon = AbilityRefs.ConsumeFear.Reference.Get().Icon;

            return FeatureConfigurator.New(ForgedInHell, ForgedInHellGuid)
                .SetIcon(icon)
                .SetDescription(ForgedInHellDescription)
                .SetDisplayName(ForgedInHellDisplayName)
                .Configure();
        }

        private static readonly string NewForceOfWill = "Hellknight.NewForceOfWill";
        private static readonly string NewForceOfWillGuid = "5b4a5941-4f30-4f92-82af-20bf726e6d94";

        private static readonly string NewForceOfWillDisplayName = "Hellknight.NewForceOfWill.BuffName";
        private static readonly string NewForceOfWillDescription = "Hellknight.NewForceOfWill.Description";

        private static BlueprintFeature CreateNewForceOfWill()
        {
            var icon = AbilityRefs.ProtectionFromChaos.Reference.Get().Icon;

            return FeatureConfigurator.New(NewForceOfWill, NewForceOfWillGuid)
                .SetRanks(3)
                .SetIcon(icon)
                .SetDescription(NewForceOfWillDescription)
                .SetDisplayName(NewForceOfWillDisplayName)
                .Configure();
        }

        private static readonly string HellknightCodex = "Hellknight.Codex";
        private static readonly string HellknightCodexGUID = "6a34865b-3164-44c7-85b1-e8432b2394a0";

        private static readonly string HellknightCodexName = "HellknightCodex.BuffName";
        private static readonly string HellknightCodexDescription = "HellknightCodex.Description";

        public static BlueprintFeatureSelection CreateHellknightCodex()
        {
            var icon = FeatureSelectionRefs.DiscoverySelection.Reference.Get().Icon;

            return FeatureSelectionConfigurator.New(HellknightCodex, HellknightCodexGUID)
                .AddToAllFeatures(FeatureSelectionRefs.OrderOfTheNailFavoriteEnemySelection.ToString(), InfiltratorCodex.CreateCodex(), CreateArmigerCodexProgression())
                .SetDisplayName(HellknightCodexName)
                .SetDescription(HellknightCodexDescription)
                .SetIcon(icon)
                .Configure();
        }

        #region Codex of the Lawbringer
        private static readonly string LawbringerCodex = "Hellknight.LawbringerCodex";
        private static readonly string LawbringerCodexGUID = "bafac28e-dba2-45af-a106-df80915488af";

        private static readonly string LawbringerCodexName = "LawbringerCodex.BuffName";
        private static readonly string LawbringerCodexDescription = "LawbringerCodex.Description";

        private static BlueprintProgression CreateLawbringerCodexProgression()
        {
            return ProgressionConfigurator.New(LawbringerCodex, LawbringerCodexGUID)
                .SetClasses(CharacterClassRefs.HellknightClass.ToString())
                .AddToLevelEntry(1, FeatureSelectionRefs.OrderOfTheNailFavoriteEnemySelection.ToString())
                .SetIsClassFeature(true)
                .SetDisplayName(LawbringerCodexName)
                .SetDescription(LawbringerCodexDescription)
                .Configure();
        }
        #endregion

        #region Armiger Codex
        private static readonly string ArmigerCodex = "Hellknight.Codex.Armger";
        private static readonly string ArmigerCodexGuid = "8b9c7c22-ea10-41b8-98c3-2c6d7c225acd";

        private static readonly string ArmigerCodexDisplayName = "Hellknight.Codex.Armiger.BuffName";
        private static readonly string ArmigerCodexDescription = "Hellknight.Codex.Armiger.Description";

        private static BlueprintProgression CreateArmigerCodexProgression()
        {
            return ProgressionConfigurator.New(ArmigerCodex, ArmigerCodexGuid)
                .SetClasses(CharacterClassRefs.HellknightClass.ToString())
                .AddToLevelEntry(2, FeatureSelectionRefs.RangerStyleMenacingSelection10.ToString())
                .AddToLevelEntry(6, FeatureSelectionRefs.RangerStyleMenacingSelection10.ToString())
                .AddToLevelEntry(10, FeatureSelectionRefs.RangerStyleMenacingSelection10.ToString())
                .SetUIGroups(UIGroupBuilder.New()
                    .AddGroup(new Blueprint<BlueprintFeatureBaseReference>[] { FeatureSelectionRefs.RangerStyleMenacingSelection10.ToString() }))
                .SetIsClassFeature(true)
                .SetDisplayName(ArmigerCodexDisplayName)
                .SetDescription(ArmigerCodexDescription)
                .Configure();
        }
        #endregion

    }
}
