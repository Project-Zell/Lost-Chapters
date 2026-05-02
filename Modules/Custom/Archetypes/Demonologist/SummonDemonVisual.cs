using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using BlueprintCore.Utils.Assets;
using BlueprintCore.Utils.Types;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.View;
using Kingmaker.Visual.MaterialEffects.ColorTint;
using Kingmaker.Visual.MaterialEffects.Dissolve;
using Kingmaker.Visual.MaterialEffects.RimLighting;
using Kingmaker.Visual.Particles;
using LostChapters._tools;
using LostChapters.Modules.HellknightsCodex.PrestigeClasses.Hellknight.Discipline;
using LostChapters.Tools;
using Owlcat.Runtime.Visual.RenderPipeline;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI.Extensions;

namespace LostChapters.Modules.Custom.Archetypes.Demonologist;

internal class SummonDemonVisual
{
    internal enum FxSize { Small, Medium, Big }

    private static readonly string BaseName = "SummonDemonVisual";
    private static readonly string AppearFx = "dc36f0c47ccd0fc449fe71d981fc3eb4";
    private static readonly string DisappearFx = "651a1b69350824440be0438bdede4d31";

    internal static void ConfigureAppear()
    {
        SummonedDemonFx.Configure();

        SmallAppearBuff.Configure();
        MediumAppearBuff.Configure();
        BigAppearBuff.Configure();
    }

    internal static void ConfigureDismemberFx()
    {
        SmallDismemberFx.Configure();
        MediumDismemberFx.Configure();
        BigDismemberFx.Configure();
    }

    internal static void ConfigureUnit(string unitName, string newPrefabID, string sourcePrefabID, FxSize fxSize, float unitScaleMod = 1f)
    {
        AssetTool.RegisterDynamicPrefabLink(assetId: newPrefabID, source: sourcePrefabID, ModifyUnit);

        void ModifyUnit(GameObject unit)
        {
            unit.name = $"[{Main.ModName}] {unitName}";
            unit.transform.localScale = Vector3.one * unitScaleMod;

            switch (fxSize)
            {
                case FxSize.Medium: 
                    MediumDismemberFx.RegisterUnit(unit);
                    break;
                case FxSize.Big:
                    BigDismemberFx.RegisterUnit(unit);
                    break;
                default: 
                    SmallDismemberFx.RegisterUnit(unit); 
                    break;
            }
        }
    }

    internal static void ModifyFx(GameObject gameObject, Vector3 areaSize)
    {
        gameObject.name = $"[{Main.ModName}] Demon Appear Fx";

        foreach (var child in gameObject.GetComponentsInChildren<Transform>())
        {
            if (child.gameObject.name.Contains("Runes"))
            {
                child.localScale = areaSize * 1.5f;
            }
            else
            {
                child.localScale = areaSize;
            }
        }

        var transform = gameObject.transform;

        Toolbox.ChangeMaterialColor(transform.Find("Ground_DontRotate/Darkness/redBottom").gameObject, color: new(1f, 0.4f, 0.1f, 1f));
        Toolbox.ChangeMaterialColor(transform.Find("Ground_DontRotate/Darkness/BigBottomDark").gameObject, color: new(1f, 0.15f, 0.15f, 1f));
        Toolbox.ChangeMaterialColor(transform.Find("Ground_DontRotate/Darkness/BigDist").gameObject, color: new(1f, 0.412f, 0.378f, 1f));
        Toolbox.ChangeMaterialColor(transform.Find("Ground_DontRotate/Darkness/BigDist (1)").gameObject, color: new(1f, 0.412f, 0.378f, 1f));

        Toolbox.ChangeStartColor(transform.Find("Ground_DontRotate/Darkness/Smoke_Trails").gameObject, color: Color.black);
        Toolbox.ChangeStartColor(transform.Find("Ground_DontRotate/Darkness/BigWaves").gameObject, color: new (1f, 0.414f, 0.407f, 0.643f));
        Toolbox.ChangeStartColor(transform.Find("Ground_DontRotate/Darkness/Lightning").gameObject, color: new (0.8f, 0.363f, 0.169f, 1f));
        Toolbox.ChangeStartColor(transform.Find("Ground_DontRotate/Darkness/Sparks (1)").gameObject, color: new (0.8f, 0.363f, 0.169f, 1f));
        Toolbox.ChangeStartColor(transform.Find("Buff_Spawn/GameObject (1)/Lightning (1)").gameObject, color: new (0.8f, 0.363f, 0.169f, 1f));
        Toolbox.ChangeStartColor(transform.Find("Buff_Spawn/SmokeBodySnap").gameObject, color: new (0.8f, 0.363f, 0.169f, 1f));
        Toolbox.ChangeStartColor(transform.Find("Buff_Spawn/GameObject (1)/CenterFlash (1)").gameObject, color: new (0.8f, 0.363f, 0.169f, 1f));
        Toolbox.ChangeStartColor(transform.Find("Buff_Spawn/BackElec").gameObject, color: new (0.8f, 0.363f, 0.169f, 1f));

        Object.DestroyImmediate(transform.Find("CameraShake (1)").gameObject);
        Object.DestroyImmediate(transform.Find("Ground_DontRotate/Darkness/Lightning/ElectroKatyshki/FireTiny").gameObject);
        Object.DestroyImmediate(transform.Find("Light/Point Light").gameObject);
        Object.DestroyImmediate(transform.Find("Ground_DontRotate/Darkness/BackElec (1)").gameObject);
        Object.DestroyImmediate(transform.Find("Ground_DontRotate/Darkness/Electricity_splash_aftertest").gameObject);
        Object.DestroyImmediate(transform.Find("Ground_DontRotate/Decal").gameObject);
    }

    static void ModifyDismember(GameObject gameObject, HashSet<GameObject> unitsToConfigure)
    {
        var dismemberFx = gameObject.AddComponent<DismemberUnitFX>(fx => fx.Delay = 1f);

        foreach (var unit in unitsToConfigure)
            dismemberFx.Init(unit.GetComponentInChildren<UnitEntityView>());
    }

    internal class SummonedDemonFx
    {
        public static readonly string Guid = "{ae0f3f1c-995a-4228-99fe-4071467b2dcd}";
        public static readonly string FxID = "{5e1e4fc2-2065-479b-93ed-84036014b685}";

        private static readonly string BuffName = $"{BaseName}.DemonSummonBuff";

        internal static void Configure()
        {
            var baseFx = "5b761777f0523b5409cbc7ef0ffee696";

            AssetTool.RegisterDynamicPrefabLink(assetId: FxID, source: baseFx, Modify);

            static void Modify(GameObject gameObject)
            {
                var rim = gameObject.GetComponentInChildren<RimLightingAnimationSetup>();
                Color rimColor = new(0.54f, 0.13f, 0.13f, 0.1f);
                GradientColorKey[] rimColorKeys = [new(rimColor, 0f), new(rimColor, 1f)];
                GradientAlphaKey[] rimAlphaKeys = [new(1f, 0f), new(1f, 1f)];
                rim.Settings.ColorOverLifetime.SetKeys(rimColorKeys, rimAlphaKeys);

                var tint = gameObject.GetComponentInChildren<ColorTintAnimationSetup>();
                Color tintColor = new (0.122f, 0.02f, 0.02f, 1f);
                GradientColorKey[] tintColorKeys = [new(tintColor, 0f), new(tintColor, 1f)];
                GradientAlphaKey[] tintAlphaKeys = [new(0.3137255f, 0f), new(0.3137255f, 1f)];
                tint.Settings.ColorOverLifetime.SetKeys(tintColorKeys, tintAlphaKeys);

                var dissolve = gameObject.GetComponentInChildren<DissolveSetup>();
                dissolve.Settings.ColorOverLifetime.SetKeys(rimColorKeys, rimAlphaKeys);

                var particleSystem = gameObject.GetComponentInChildren<ParticleSystem>();
                var main = particleSystem.main;
                main.startColor = new Color(0.54f, 0.13f, 0.13f, 0.1f);
                main.startDelay = 0f;
            }

            BuffConfigurator.New(BuffName, Guid)
                .SetFxOnStart("{5e1e4fc2-2065-479b-93ed-84036014b685}")
                .SetFlags(BlueprintBuff.Flags.HiddenInUi)
                .Configure();
        }
    }

    internal class SmallAppearBuff
    {
        public static readonly string Guid = "{2dbfb607-48f8-4ad8-b9cd-7a75634fea8a}";
        public static readonly string FxID = "{5a066e79-a1d5-4da5-a9b7-9563ccfa5781}";

        private static readonly string BuffName = $"{BaseName}.SmallAppearBuff";

        internal static void Configure()
        {
            AssetTool.RegisterDynamicPrefabLink(assetId: FxID, source: AppearFx, Modify);

            static void Modify(GameObject gameObject) => ModifyFx(gameObject, new Vector3(0.3f, 0.3f, 0.3f));

            BuffConfigurator.New(BuffName, Guid)
                .SetFxOnStart(FxID)
                .SetFlags(BlueprintBuff.Flags.HiddenInUi)
                .Configure();
        }
    }

    internal class MediumAppearBuff
    {
        public static readonly string Guid = "{71d77454-cafd-439b-a021-6b5f97a324f5}";
        public static readonly string FxID = "{15d9de15-b413-49a3-b8ef-9af19ef252ed}";

        private static readonly string BuffName = $"{BaseName}.MediumAppearBuff";

        internal static void Configure()
        {
            AssetTool.RegisterDynamicPrefabLink(assetId: FxID, source: AppearFx, Modify);

            static void Modify(GameObject gameObject) => ModifyFx(gameObject, new Vector3(0.5f, 0.5f, 0.5f));

            BuffConfigurator.New(BuffName, Guid)
                .SetFxOnStart(FxID)
                .SetFlags(BlueprintBuff.Flags.HiddenInUi)
                .Configure();
        }
    }

    internal class BigAppearBuff
    {
        public static readonly string Guid = "{4e6d57b7-e3f3-4936-a3ae-28acbb93d5bb}";
        public static readonly string FxID = "{e9ce270e-b079-43cc-b313-68cdc484797e}";

        private static readonly string BuffName = $"{BaseName}.BigAppearBuff";

        internal static void Configure()
        {
            AssetTool.RegisterDynamicPrefabLink(assetId: FxID, source: AppearFx, Modify);

            static void Modify(GameObject gameObject) => ModifyFx(gameObject, new Vector3(0.7f, 0.7f, 0.7f));

            BuffConfigurator.New(BuffName, Guid)
                .SetFxOnStart(FxID)
                .SetFlags(BlueprintBuff.Flags.HiddenInUi)
                .Configure();
        }
    }

    internal class SmallDismemberFx
    {
        public readonly static string Guid = "{eaa9c101-7b09-4b90-8bb4-16e202041980}";

        private static readonly HashSet<GameObject> UnitsToConfigure = [];

        internal static void Configure()
        {
            AssetTool.RegisterDynamicPrefabLink(assetId: Guid, source: DisappearFx, Modify);

            static void Modify(GameObject gameObject)
            {
                ModifyFx(gameObject, new Vector3(0.3f, 0.3f, 0.3f));
                ModifyDismember(gameObject, UnitsToConfigure);
                UnitsToConfigure.Clear();
            }
        }
        internal static void RegisterUnit(GameObject unit) => UnitsToConfigure.Add(unit);
    }

    internal class MediumDismemberFx
    {
        public readonly static string Guid = "{faefd0aa-7545-4c21-9d73-8972cfe1a631}";

        private static readonly HashSet<GameObject> UnitsToConfigure = [];

        internal static void Configure()
        {
            AssetTool.RegisterDynamicPrefabLink(assetId: Guid, source: DisappearFx, Modify);

            static void Modify(GameObject gameObject)
            {
                ModifyFx(gameObject, new Vector3(0.5f, 0.5f, 0.5f));
                ModifyDismember(gameObject, UnitsToConfigure);
                UnitsToConfigure.Clear();
            }
        }
        internal static void RegisterUnit(GameObject unit) => UnitsToConfigure.Add(unit);
    }

    internal class BigDismemberFx
    {
        public readonly static string Guid = "{8829c7ba-9270-4768-a17a-0cdf828858be}";

        private static readonly HashSet<GameObject> UnitsToConfigure = [];

        internal static void Configure()
        {
            AssetTool.RegisterDynamicPrefabLink(assetId: Guid, source: DisappearFx, Modify);

            static void Modify(GameObject gameObject)
            {
                ModifyFx(gameObject, new Vector3(0.7f, 0.7f, 0.7f));
                ModifyDismember(gameObject, UnitsToConfigure);
                UnitsToConfigure.Clear();
            }
        }
        internal static void RegisterUnit(GameObject unit) => UnitsToConfigure.Add(unit);
    }
}
