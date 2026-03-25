using BlueprintCore.Blueprints.Configurators.Root.Fx;
using BlueprintCore.Utils;
using Kingmaker.Blueprints.Root.Fx;
using Kingmaker.Dungeon.Actions;
using Kingmaker.PubSubSystem;
using Kingmaker.UnitLogic;
using Kingmaker.View;
using Kingmaker.Visual;
using System.Linq;

namespace LostChapters.Modules.HellknightCodex.Components;
internal class ResetSpawnFxOnStartOnLocationChange : UnitFactComponentDelegate, ISubscriber, ITeleportHandler, IGlobalSubscriber
{

    private static readonly LogWrapper Logger = LogWrapper.Get("Hellhound");
    public void HandlePartyTeleport(AreaEnterPoint enterPoint)
    {
        var fxObjects = Owner.View.gameObject.GetComponents<SpawnFxOnStart>().ToList();
        fxObjects.ForEach(obj => { obj.ResetFx(); });

        foreach(var obj in fxObjects)
        {
            Logger.Info(obj.name);
            
        }

        var ebalo = Owner.View.gameObject.GetComponents<SpawnFxOnStart>().ToList();

        Owner.View.gameObject.AddComponent<FxIsAlwaysVisible>();
    }
}
