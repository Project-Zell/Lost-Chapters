using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Utils.Assets;
using Kingmaker.ResourceLinks;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.Visual.Particles;
using LostChapters._tools;
using UnityEngine;

namespace LostChapters.Modules.Custom.Archetypes.Demonologist;

internal class SummonDemonVisual
{
    public static readonly string Guid = "{9d785ceb-098a-4cbd-aa97-23245f12de45}";
    public static readonly string DismemberGuid = "{68bea533-5a31-4a1b-9b84-378d56ab5b38}";

    private static readonly string BuffName = "SummonDemonVisual";

    internal static void Configure()
    {
        var disaperFx = "ab292bc1fd040844b8165bfb6a3648e5";
        AssetTool.RegisterDynamicPrefabLink(assetId: DismemberGuid, source: disaperFx, AddObserver);

        //"dc21c754292adb647a3bb7136e894092"
        //"b2a220e7f10ae1446a7461912a11de3e"
        BuffConfigurator.New(BuffName, Guid)
            .SetFxOnStart("b2a220e7f10ae1446a7461912a11de3e")
            //.SetFxOnStart("ab292bc1fd040844b8165bfb6a3648e5")
            .SetFlags(BlueprintBuff.Flags.HiddenInUi)
            .AddDeathActions()
            .Configure();

        var ragePrefab = "53c86872d2be80b48afc218af1b204d7";
        var newRageID = "{15607204-0d6b-458b-9920-d35877ce4778}";
        AssetTool.RegisterDynamicPrefabLink(assetId: newRageID, source: ragePrefab, ModifyDismember);

         static void ModifyDismember(GameObject go)
         {
            go.AddComponent<FxDestroyOnStop>();
         }

        BuffConfigurator.New("SummonDemonRageSetupArcanist", "{285da3ef-de53-4e8a-8727-a5c679810ea1}")
            .SetFxOnStart(newRageID)
            .SetFlags(BlueprintBuff.Flags.HiddenInUi)
            .AddDeathActions()
            .Configure();
    }

    internal static void AddObserver(GameObject gameObject)
    {
        var spy = gameObject.AddComponent<OwlcatSpy>();
        spy.GetMaterialProperies();
        spy.GetDismemberUnitFXDelay();
        spy.GetAllComponents();
        spy.GetAllParticleControllers();
    }

    internal static void Mod(GameObject gameObject)
    {
        gameObject.AddComponent<DismemberUnitFX>(x =>
        {
            x.Delay = 1.5f;
            x.m_DismemberBloodPuddle = gameObject;
        }
        );
    }
}
