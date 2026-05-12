using BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils.Assets;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.ActivatableAbilities;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.Utility;
using LostChapters.Modules.HellknightCodex.Components;
using LostChapters.Tools;
using UnityEngine;

namespace LostChapters.Modules.HellknightsCodex.Archetypes.Deacon;

internal class DeaconIncenseFeature
{
    public static readonly string Guid = "{1219026c-1406-4971-a1b7-7ca87da45049}";

    private static readonly string FeatureName = "DeaconIncense";
    private static readonly string DisplayName = $"{FeatureName}.Name";
    private static readonly string Description = $"{FeatureName}.Description";

    public static void Configure()
    {
        ActivatableAbility.Configure();

        //ContextActionRemoveBuff StandartRage/Rage Spell
        FeatureConfigurator.New(FeatureName, Guid)
            .AddFacts([ActivatableAbility.Guid])
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .Configure();
    }

    internal class ActivatableAbility
    {
        public static readonly string Guid = "{7cf8d9d0-97d4-44e9-ba01-8ea2bcdee443}";

        private static readonly string AbilityName = "DeaconIncense.Ability";
        private static readonly string DisplayName = $"{AbilityName}.Name";
        private static readonly string Description = $"{AbilityName}.Description";

        internal static void Configure()
        {
            Buff.Configure();

            ActivatableAbilityConfigurator.New(AbilityName, Guid)
                .SetBuff(Buff.Guid)
                .AddComponent<DeaconIncenseDC>()
                .SetActivationType(AbilityActivationType.WithUnitCommand)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }

    internal class Resource
    {
        public static readonly string Guid = "{f1fc12f2-acac-4d0f-887b-c45450740696}";

        private static readonly string ResourceName = $"{FeatureName}.Resource";

        internal static void Configure()
        {
            AbilityResourceConfigurator.New(ResourceName, Guid)
                .Configure();
        }
    }

    internal class Buff
    {
        public static readonly string Guid = "{1005297c-7933-4c19-b004-3ffbc4bd9ddd}";

        private static readonly string BuffName = "DeaconIncense.Buff";
        private static readonly string DisplayName = $"{BuffName}.Name";
        private static readonly string Description = $"{BuffName}.Description";


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

        private static readonly string AbilityAreaName = "DeaconIncense.AbilityArea";

        internal static void Configure()
        {
            EffectBuff.Configure();

            AbilityAreaEffectConfigurator.New(AbilityAreaName, Guid)
                .AddAbilityAreaEffectBuff(EffectBuff.Guid)
                .SetShape(AreaEffectShape.Cylinder)
                .SetSize(30.Feet())
                .AddContextSetAbilityParams(dC: 0)
                .Configure();
        }
    }

    internal class EffectBuff
    {
        public static readonly string Guid = "{5a36fe50-9a1f-4131-acdc-87c93f5b16a2}";

        private static readonly string BuffName = "DeaconIncense.EffectBuff";
        private static readonly string DisplayName = $"{BuffName}.Name";
        private static readonly string Description = $"{BuffName}.Description";

        internal static void Configure()
        {
            BuffConfigurator.New(BuffName, Guid)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.HauntingMists.Reference.Get().Icon)
                .Configure();
        }
    }
}
