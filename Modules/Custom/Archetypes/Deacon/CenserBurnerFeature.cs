using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.Components.Replacements;
using BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using BlueprintCore.Utils;
using BlueprintCore.Utils.Assets;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.ActivatableAbilities;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Commands.Base;
using Kingmaker.Utility;
using LostChapters.Components;
using LostChapters.Modules.Custom.Archetypes.Deacon.Components;
using LostChapters.Tools;
using UnityEngine;

namespace LostChapters.Modules.Custom.Archetypes.Deacon;

internal class CenserBurnerFeature
{
    public static readonly string Guid = "{1219026c-1406-4971-a1b7-7ca87da45049}";

    private static readonly string BaseName = "CenserBurner";

    private static readonly string FeatureName = $"{BaseName}Feature";
    private static readonly string DisplayName = $"{FeatureName}.Name";
    private static readonly string Description = $"{FeatureName}.Description";

    private static readonly string Icon = $"{CustomModule.IconPath}/{DeaconArchetype.BaseName}/{BaseName}.png".ToLower();

    public static void Configure()
    {
        Fact.Configure();
        Resource.Configure();
        ActivatableAbility.Configure();

        FeatureConfigurator.New(FeatureName, Guid)
            .AddFacts([ActivatableAbility.Guid])
            .AddAbilityResources(resource: Resource.Guid, restoreAmount: true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .SetIcon(Icon)
            .Configure();
    }

    internal class Fact
    {
        public static readonly string Guid = "{7713f55c-878d-4265-8ed1-c08f106c59fb}";

        private static readonly string FactName = $"{BaseName}Fact";

        public static void Configure()
        {
            var feature = FeatureConfigurator.New(FactName, Guid)
                .SetHideInCharacterSheetAndLevelUp(true)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(Icon)
                .Configure();

            TooltipConfigurator.CreateFeatureTooltip(key: $"LC_{BaseName}", feature: feature);
        }
    }

    internal class ActivatableAbility
    {
        public static readonly string Guid = "{7cf8d9d0-97d4-44e9-ba01-8ea2bcdee443}";

        private static readonly string AbilityName = $"{BaseName}Ability";

        internal static void Configure()
        {
            AreaBuff.Configure();

            ActivatableAbilityConfigurator.New(AbilityName, Guid)
                .SetBuff(AreaBuff.Guid)
                .AddComponent<DeaconIncenseDC>()
                .AddActivatableAbilityResourceLogic(
                    spendType: ActivatableAbilityResourceLogic.ResourceSpendType.NewRound, 
                    requiredResource: Resource.Guid)
                .SetActivationType(AbilityActivationType.WithUnitCommand)
                .SetActivateWithUnitCommand(UnitCommand.CommandType.Standard)
                .SetActivateOnUnitAction(AbilityActivateOnUnitActionType.Attack)
                .SetDeactivateIfCombatEnded(true)
                .SetDeactivateIfOwnerUnconscious(true)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(Icon)
                .Configure();
        }
    }

    internal class Resource
    {
        public static readonly string Guid = "{f1fc12f2-acac-4d0f-887b-c45450740696}";

        private static readonly string ResourceName = $"{FeatureName}Resource";

        internal static void Configure()
        {
            var builder = ResourceAmountBuilder.New(baseValue: 1)
                .IncreaseByLevel([CharacterClassRefs.WarpriestClass.ToString()], 2)
                .IncreaseByStat(StatType.Wisdom)
                .Build();

            AbilityResourceConfigurator.New(ResourceName, Guid)
                .SetMaxAmount(builder)
                .Configure();
        }
    }

    internal class AreaBuff
    {
        public static readonly string Guid = "{1005297c-7933-4c19-b004-3ffbc4bd9ddd}";

        private static readonly string BuffName = $"{BaseName}AreaBuff";

        internal static void Configure()
        {
            AbilityArea.Configure();

            var sourceFx = "54b14a687d7af52418f23485ca51d690";
            var newFx = "{9c6befdd-56f2-4466-95f2-1143862a74a4}";
            
            AssetTool.RegisterDynamicPrefabLink(assetId: newFx, source: sourceFx, ModifyFx);

            static void ModifyFx(GameObject gameObject)
            {
                var transform = gameObject.transform;

                Toolbox.ChangeStartColor(transform.Find("Ground (1)/Border").gameObject, new Color(0.85f, 0.7f, 0.85f));
                Toolbox.ChangeStartColor(transform.Find("Ground (1)/BorderWaves").gameObject, new Color(0.85f, 0.7f, 0.85f));
                Toolbox.ChangeStartColor(transform.Find("Ground (1)/StartWave").gameObject, new Color(0.92f, 0.71f, 0.92f, 0.73f));
                Toolbox.ChangeStartColor(transform.Find("Ground (1)/StartWave/EnergyWave_Start").gameObject, new Color(0.92f, 0.71f, 0.92f));
                Toolbox.ChangeStartColor(transform.Find("Ground (1)/StartWave/Waves").gameObject, new Color(0.937f, 0.678f, 0.937f));
                Toolbox.ChangeStartColor(transform.Find("Ground (1)/StartWave/BigWave_mid").gameObject, new Color(0.94f, 0.678f, 0.94f));
                Toolbox.ChangeStartColor(transform.Find("Ground (1)/StartWave/BigWave_trail").gameObject, new Color(0.92f, 0.71f, 0.92f));
                Toolbox.ChangeStartColor(transform.Find("Ground (1)/StartWave/Bottom_dark").gameObject, new Color(0.2f, 0.024f, 0.2f, 0.549f));
                Toolbox.ChangeStartColor(transform.Find("Ground (1)/StartWave/Bottom_wave").gameObject, new Color(0.92f, 0.71f, 0.92f));
                Toolbox.ChangeStartColor(transform.Find("Ground (1)/Border_particleEnergy").gameObject, new Color(0.639f, 0.541f, 0.639f));
                Toolbox.ChangeStartColor(transform.Find("Ground (1)/sparks (2)").gameObject, new Color(0.847f, 0.529f, 0.847f));
                Toolbox.ChangeAnimatedLightBaseColor(transform.Find("Point light (3)").gameObject, new Color(0.973f, 0.706f, 0.973f, 0f), true);
            }

            BuffConfigurator.New(BuffName, Guid)
                .AddAreaEffect(areaEffect: AbilityArea.Guid)
                .SetFxOnStart(newFx)
                .SetFlags(BlueprintBuff.Flags.HiddenInUi, BlueprintBuff.Flags.StayOnDeath)
                .SetIsClassFeature(true)
                .Configure();
        }
    }

    internal class AbilityArea
    {
        public static readonly string Guid = "{4545f197-8d7d-4630-8e75-4dba423fca61}";

        private static readonly string AbilityAreaName = $"{BaseName}AbilityArea";

        internal static void Configure()
        {
            AllBuff.Configure();
            AllyBuff.Configure();

            AbilityAreaEffectConfigurator.New(AbilityAreaName, Guid)
                .AddAbilityAreaEffectBuff(AllBuff.Guid)
                .AddAbilityAreaEffectBuff(AllyBuff.Guid, condition: ConditionsBuilder.New().IsAlly())
                .SetShape(AreaEffectShape.Cylinder)
                .SetSize(30.Feet())
                .AddContextSetAbilityParams(dC: 0)
                .Configure();
        }
    }

    internal class AllBuff
    {
        public static readonly string Guid = "{798c5c37-ca5a-4165-a71f-33a73a8c8641}";

        private static readonly string BuffName = $"{BaseName}AllBuff";
        private static readonly string DisplayName = $"{BuffName}.Name";
        private static readonly string Description = $"{BuffName}.Description";

        internal static void Configure()
        {
            var supressBuff = new SuppressBuffsFixed()
            {
                ApplyToNewBuffs = true,
                m_Buffs = [
                    BlueprintTool.GetRef<BlueprintBuffReference>(BuffRefs.RageBuff.ToString()),
                    BlueprintTool.GetRef<BlueprintBuffReference>(BuffRefs.RageBuffNoFX.ToString()),
                    BlueprintTool.GetRef<BlueprintBuffReference>(BuffRefs.RageSpellBuff.ToString()),
                    BlueprintTool.GetRef<BlueprintBuffReference>(BuffRefs.DLC3_RageBuff.ToString()),
                    BlueprintTool.GetRef<BlueprintBuffReference>(BuffRefs.DLC3_RageBuff_0.ToString()),
                    BlueprintTool.GetRef<BlueprintBuffReference>(BuffRefs.DLC3_DevilsRageIslandBuff.ToString()),
                    BlueprintTool.GetRef<BlueprintBuffReference>(BuffRefs.DLC3_DevilsRageIslandOffensiveBuff.ToString()),
                    BlueprintTool.GetRef<BlueprintBuffReference>(BuffRefs.DLC3_BarbRagerBuff.ToString())]
            };

            var buff = BuffConfigurator.New(BuffName, Guid)
                .AddComponent<NegateBuffApply>(x => x.NegateBuffs = [
                    BlueprintTool.Get<BlueprintBuff>(BuffRefs.InspiredRageEffectBuff.ToString()),
                    BlueprintTool.Get<BlueprintBuff>(BuffRefs.InciteRageEffectBuff.ToString())])
                .AddFactContextActions(activated: ActionsBuilder.New()
                    .RemoveBuff(BuffRefs.StandartRageBuff.ToString())
                    .RemoveBuff(BuffRefs.InspiredRageEffectBuff.ToString())
                    .RemoveBuff(BuffRefs.InciteRageEffectBuff.ToString())
                    .RemoveBuff(BuffRefs.BloodragerStandartRageBuff.ToString())
                    .RemoveBuff(BuffRefs.BloodriderFeralMountRageBuffEffect.ToString())
                    .RemoveBuff(BuffRefs.StandartFocusedRageBuff.ToString())
                    .RemoveBuff(BuffRefs.RageshaperDevastatingFormBuff.ToString()))
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(Icon)
                .Configure();

            RageHelper.AddRestrictionFactToRageAbilities(buff);
        }
    }

    internal class AllyBuff
    {
        public static readonly string Guid = "{5a36fe50-9a1f-4131-acdc-87c93f5b16a2}";

        private static readonly string BuffName = $"{BaseName}AllyBuff";

        internal static void Configure()
        {
            BuffConfigurator.New(BuffName, Guid)
                .AddSavingThrowBonusAgainstDescriptor(
                    value: 2,
                    spellDescriptor: SpellDescriptor.Emotion | SpellDescriptor.Charm,
                    modifierDescriptor: ModifierDescriptor.Alchemical)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetFlags(BlueprintBuff.Flags.HiddenInUi)
                .Configure();
        }
    }
}