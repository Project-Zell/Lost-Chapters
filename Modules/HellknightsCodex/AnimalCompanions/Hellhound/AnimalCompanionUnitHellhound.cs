using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils.Assets;
using Kingmaker.Blueprints;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.Utility;
using LostChapters.Patches;
using UnityEngine;

namespace LostChapters.Modules.HellknightsCodex.AnimalCompanions.Hellhound;

internal class AnimalCompanionUnitHellhound
{
    public static readonly string Guid = "{31d359f1-f998-4af3-858a-9ce8b7a3baa5}";

    private const string UnitName = "AnimalCompanionUnitHellhound";

    public static void Configure()
    {
        Prefab.Configure();

        var unitBody = new BlueprintUnit.UnitBody
        {
            m_PrimaryHand             = ItemWeaponRefs.HellhouneBite.Reference.Get().ToReference<BlueprintItemEquipmentHandReference>(),
            m_PrimaryHandAlternative1 = ItemWeaponRefs.HellhouneBite.Reference.Get().ToReference<BlueprintItemEquipmentHandReference>(),
            m_PrimaryHandAlternative2 = ItemWeaponRefs.HellhouneBite.Reference.Get().ToReference<BlueprintItemEquipmentHandReference>(),
            m_PrimaryHandAlternative3 = ItemWeaponRefs.HellhouneBite.Reference.Get().ToReference<BlueprintItemEquipmentHandReference>(),
        };

        var unitVisual = UnitRefs.CR3_HellhoundStandard.Reference.Get().Visual;

        UnitConfigurator.New(UnitName, Guid)
            .AddAllowDyingCondition()
            .AddResurrectOnRest()
            .AddLockEquipmentSlot(slotType: LockEquipmentSlot.SlotType.MainHand, deactivate: false)
            .AddLockEquipmentSlot(slotType: LockEquipmentSlot.SlotType.OffHand, deactivate: false)
            .SetAlignment(Alignment.LawfulEvil)
            .SetPrefab(Prefab.PrefabID)
            .SetFaction(FactionRefs.Neutrals.ToString())
            .SetBrain("cf986dd7ba9d4ec46ad8a3a0406d02ae")
            .SetBody(unitBody)
            .SetVisual(unitVisual)
            .SetSkills(new BlueprintUnit.UnitSkills())
            .SetType(UnitTypeRefs.HellHound.ToString())
            .SetStrength(19)
            .SetDexterity(21)
            .SetConstitution(18)
            .SetIntelligence(6)
            .SetWisdom(10)
            .SetCharisma(6)
            .SetSpeed(40.Feet())
            .SetMaxHP(0)
            .SetStartingInventory([])
            .SetAdditionalTemplates([])
            .SetFactionOverrides(new FactionOverrides())
            .SetAddFacts([
                FeatureRefs.TripDefenseFourLegs.ToString(),
                FeatureRefs.SubtypeFire.ToString(),
                FeatureRefs.SubtypeEvil.ToString(),
                FeatureRefs.SubtypeLawful.ToString(),
                FeatureRefs.SubtypeExtraplanar.ToString(),
                FeatureRefs.HeadCastLocator.ToString(),
                FeatureRefs.AnimalCompanionSlotFeature.ToString()])
            .SetLocalizedName(UnitRefs.CR3_HellhoundStandard.Reference.Get().LocalizedName)
            .Configure();  
    }

    internal class Prefab
    {
        public static readonly string PrefabID = "{713f04ac-69d8-4426-a643-3774ac4a241f}";
        public static readonly string FxID = "{aa66bbde-a3bd-4a18-b805-beb897b88f9b}";

        internal static void Configure()
        {
            var sourcePrefabID = "4f0f6e792d298044f8ca30da4ec86e1f";
            AssetTool.RegisterDynamicPrefabLink(assetId: PrefabID, source: sourcePrefabID, ModifyGameObject);
        }
        private static void ModifyGameObject(GameObject unit)
        {
            unit.name = $"{Main.ModName} {UnitName}";
            var fx = unit.GetComponent<SpawnFxOnStart>();

            AssetTool.RegisterDynamicPrefabLink(assetId: FxID, source: fx.FxOnStart.AssetId, ModifyGameFX);
            fx.FxOnStart.AssetId = FxID;
        }

        private static void ModifyGameFX(GameObject unit)
        {
            unit.name = $"{Main.ModName} {UnitName} FX";
            unit.AddComponent<DollroomParticleSystemPatch>();
        }
    }
}
