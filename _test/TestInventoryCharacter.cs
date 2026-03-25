using BlueprintCore.Utils;
using Kingmaker.UI.MVVM._PCView.ServiceWindows.Inventory;
using Kingmaker.UI.ServiceWindow;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Abilities.Components.Base;
using Kingmaker.Utility;
using Kingmaker.Visual;
using Kingmaker.Visual.Particles;
using System.Drawing.Drawing2D;
using System.Linq;
using UnityEngine;

namespace LostChapters._test;

internal class TestInventoryCharacter : AbilityApplyEffect
{
    private static readonly LogWrapper Logger = LogWrapper.Get("Hellknight");
    public override void Apply(AbilityExecutionContext context, TargetWrapper target)
    {
        var particles = target.Unit.View.gameObject.GetComponentsInChildren<FxLocator>().ToList();
        foreach (var particle in particles)
        {
            particle.particleMap.m_SizeScale = 5000f;
        }
        var fxObjects = target.Unit.View.gameObject.GetComponent<SpawnFxOnStart>();
        fxObjects.ResetFx();

        //var Objects = target.Unit.View.gameObject.GetComponentsInChildren<MonoBehaviour>().ToList();
        //foreach (var obj in Objects)
        //{
        //    Logger.Info(obj.GetType().ToString());

        //}

        //var fxObjects = target.Unit.View.gameObject.GetComponents<SpawnFxOnStart>().ToList();
        //foreach (var fxObject in fxObjects)
        //{
        //    Logger.Info(fxObject.GetType().ToString());

        //    var e = fxObject.m_SpawnedFx.SpawnedObject.GetComponents<MonoBehaviour>();
        //    foreach (var s in e)
        //    {
        //        Logger.Info(s.GetType().ToString());
        //    }
        //}
    }
}
