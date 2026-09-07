using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Utils.Assets;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.Visual.MaterialEffects.ColorTint;
using Kingmaker.Visual.MaterialEffects.Dissolve;
using Kingmaker.Visual.MaterialEffects.RimLighting;
using Kingmaker.Visual.Particles;
using LostChapters._tools;
using LostChapters.Tools;
using UnityEngine;

namespace LostChapters.Modules.Custom.Archetypes.Demonologist.Tools;

internal class SummonDemonVisual
{
    internal enum FxSize { Small, Medium, Big, Giant }
    internal enum FxType { Appear, Disappear }

    private static readonly string BaseName = "SummonDemonVisual";
    private static readonly string AppearFx = "dc36f0c47ccd0fc449fe71d981fc3eb4";
    private static readonly string DisappearFx = "651a1b69350824440be0438bdede4d31";

    internal static void Configure()
    {
        SummonedDemonFx.Configure();

        SmallAppearBuff.Configure();
        MediumAppearBuff.Configure();
        BigAppearBuff.Configure();
        GiantAppearBuff.Configure();

        SmallDismemberFx.Configure();
        MediumDismemberFx.Configure();
        BigDismemberFx.Configure();
        GiantDismemberFx.Configure();
    }

    internal static void ConfigureDismemberFx(GameObject gameObject, Vector3 scale)
    {
        ModifyFx(gameObject, scale, FxType.Disappear);
        gameObject.AddComponent<DismemberUnitFX>(fx => fx.Delay = 1f);
    }

    internal static void ModifyFx(GameObject gameObject, Vector3 areaSize, FxType fxType)
    {
        gameObject.name = $"[{Main.ModName}] Demonologist - Summon {(fxType is FxType.Appear ? "Appear": "Disappear")} Fx";

        foreach (var child in gameObject.GetComponentsInChildren<Transform>())
        {
            child.localScale = child.gameObject.name.Contains("Runes") ? areaSize * 1.5f : areaSize;
        }

        var transform = gameObject.transform;

        OwlcatSpy.GetAllTranforms(gameObject);

        Color complimentColor = UnityHelper.HexColor("FF661A");
        Color highlightColir = UnityHelper.HexColor("FF2626");
        Color mainColor = UnityHelper.HexColor("FB570E");
        Color distColor = UnityHelper.HexColor("EF1C1C");
        Color waveColor = UnityHelper.HexColor("B20000", 0.65f);

        var darkness = "Ground_DontRotate/Darkness";

        Toolbox.ChangeMaterialColor(transform.Find($"{darkness}/redBottom").gameObject, color: complimentColor);
        Toolbox.ChangeMaterialColor(transform.Find($"{darkness}/BigBottomDark").gameObject, color: highlightColir);
        Toolbox.ChangeMaterialColor(transform.Find($"{darkness}/BigDist").gameObject, color: distColor);
        Toolbox.ChangeMaterialColor(transform.Find($"{darkness}/BigDist (1)").gameObject, color: distColor);

        Toolbox.ChangeStartColor(transform.Find($"{darkness}/Smoke_Trails").gameObject, color: Color.black);
        Toolbox.ChangeStartColor(transform.Find($"{darkness}/BigWaves").gameObject, color: waveColor);
        Toolbox.ChangeStartColor(transform.Find($"{darkness}/Lightning").gameObject, color: mainColor);
        Toolbox.ChangeStartColor(transform.Find($"{darkness}/Sparks (1)").gameObject, color: mainColor);
        Toolbox.ChangeStartColor(transform.Find($"{darkness}/OuterSmoke").gameObject, color: Color.black);

        var buffName = fxType is FxType.Appear ? "Buff_Spawn" : "Buff";
        var backElec = fxType is FxType.Appear ? "BackElec" : "BackElec (1)";

        Toolbox.ChangeStartColor(transform.Find($"{buffName}/GameObject (1)/Lightning (1)").gameObject, color: mainColor);
        Toolbox.ChangeStartColor(transform.Find($"{buffName}/SmokeBodySnap").gameObject, color: mainColor);
        Toolbox.ChangeStartColor(transform.Find($"{buffName}/GameObject (1)/CenterFlash (1)").gameObject, color: mainColor);
        Toolbox.ChangeStartColor(transform.Find($"{buffName}/{backElec}").gameObject, color: mainColor);

        Object.DestroyImmediate(transform.Find("CameraShake (1)").gameObject);
        Object.DestroyImmediate(transform.Find("Light/Point Light").gameObject);
        Object.DestroyImmediate(transform.Find("Ground_DontRotate/Decal").gameObject);
        Object.DestroyImmediate(transform.Find($"{darkness}/Lightning/ElectroKatyshki/FireTiny").gameObject);
        Object.DestroyImmediate(transform.Find($"{darkness}/BackElec (1)").gameObject);
        Object.DestroyImmediate(transform.Find($"{darkness}/Electricity_splash_aftertest").gameObject);
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
                Color rimColor = UnityHelper.HexColor("BF1919", 0.1f);
                GradientColorKey[] rimColorKeys = [new(rimColor, 0f), new(rimColor, 1f)];
                GradientAlphaKey[] rimAlphaKeys = [new(1f, 0f), new(1f, 1f)];
                rim.Settings.ColorOverLifetime.SetKeys(rimColorKeys, rimAlphaKeys);

                var tint = gameObject.GetComponentInChildren<ColorTintAnimationSetup>();
                Color tintColor = UnityHelper.HexColor("1F0505");
                GradientColorKey[] tintColorKeys = [new(tintColor, 0f), new(tintColor, 1f)];
                GradientAlphaKey[] tintAlphaKeys = [new(0.3137255f, 0f), new(0.3137255f, 1f)];
                tint.Settings.ColorOverLifetime.SetKeys(tintColorKeys, tintAlphaKeys);

                var dissolve = gameObject.GetComponentInChildren<DissolveSetup>();
                dissolve.Settings.ColorOverLifetime.SetKeys(rimColorKeys, rimAlphaKeys);

                var particleSystem = gameObject.GetComponentInChildren<ParticleSystem>();
                var main = particleSystem.main;
                main.startColor = rimColor;
                main.startDelay = 0f;
            }

            BuffConfigurator.New(BuffName, Guid)
                .SetFxOnStart(FxID)
                .SetFlags(BlueprintBuff.Flags.HiddenInUi | BlueprintBuff.Flags.StayOnDeath)
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

            static void Modify(GameObject gameObject) => ModifyFx(gameObject, new Vector3(0.225f, 0.225f, 0.225f), FxType.Appear);

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

            static void Modify(GameObject gameObject) => ModifyFx(gameObject, new Vector3(0.3f, 0.3f, 0.3f), FxType.Appear);

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

            static void Modify(GameObject gameObject) => ModifyFx(gameObject, new Vector3(0.45f, 0.45f, 0.45f), FxType.Appear);

            BuffConfigurator.New(BuffName, Guid)
                .SetFxOnStart(FxID)
                .SetFlags(BlueprintBuff.Flags.HiddenInUi)
                .Configure();
        }
    }

    internal class GiantAppearBuff
    {
        public static readonly string Guid = "{c15c3b78-8a47-495d-b1b3-a90ff27c5f2a}";
        public static readonly string FxID = "{b355212e-3db3-4c0c-9e67-820e549eabfe}";

        private static readonly string BuffName = $"{BaseName}GiantAppearBuff";

        internal static void Configure()
        {
            AssetTool.RegisterDynamicPrefabLink(assetId: FxID, source: AppearFx, Modify);

            static void Modify(GameObject gameObject) => ModifyFx(gameObject, new Vector3(0.6f, 0.6f, 0.6f), FxType.Appear);

            BuffConfigurator.New(BuffName, Guid)
                .SetFxOnStart(FxID)
                .SetFlags(BlueprintBuff.Flags.HiddenInUi)
                .Configure();
        }
    }

    internal class SmallDismemberFx
    {
        public readonly static string Guid = "{eaa9c101-7b09-4b90-8bb4-16e202041980}";

        internal static void Configure()
        {
            AssetTool.RegisterDynamicPrefabLink(assetId: Guid, source: DisappearFx, Modify);
            static void Modify(GameObject gameObject) => ConfigureDismemberFx(gameObject, new Vector3(0.2f, 0.2f, 0.2f));
        }
    }

    internal class MediumDismemberFx
    {
        public readonly static string Guid = "{faefd0aa-7545-4c21-9d73-8972cfe1a631}";

        internal static void Configure()
        {
            AssetTool.RegisterDynamicPrefabLink(assetId: Guid, source: DisappearFx, Modify);
            static void Modify(GameObject gameObject) => ConfigureDismemberFx(gameObject, new Vector3(0.3f, 0.3f, 0.3f));
        }
    }

    internal class BigDismemberFx
    {
        public readonly static string Guid = "{8829c7ba-9270-4768-a17a-0cdf828858be}";

        internal static void Configure()
        {
            AssetTool.RegisterDynamicPrefabLink(assetId: Guid, source: DisappearFx, Modify);
            static void Modify(GameObject gameObject) => ConfigureDismemberFx(gameObject, new Vector3(0.45f, 0.45f, 0.45f));
        }
    }

    internal class GiantDismemberFx
    {
        public readonly static string Guid = "{b4dd2c87-2ae3-4329-b805-bb0d55ee1869}";

        internal static void Configure()
        {
            AssetTool.RegisterDynamicPrefabLink(assetId: Guid, source: DisappearFx, Modify);
            static void Modify(GameObject gameObject) => ConfigureDismemberFx(gameObject, new Vector3(0.6f, 0.6f, 0.6f));
        }
    }
}
