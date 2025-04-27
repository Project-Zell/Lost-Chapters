using Kingmaker.PubSubSystem;
using Kingmaker.UI.MVVM._PCView.ServiceWindows.Inventory;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Parts;
using Kingmaker.View;
using System.Linq;

namespace LostChapters.Modules.GraySisterhood.Components
{
    internal class ResetSpawnFxOnStartOnLocationChange : UnitFactComponentDelegate, ISubscriber, ITeleportHandler, IGlobalSubscriber
    {
        public void HandlePartyTeleport(AreaEnterPoint enterPoint)
        {
            var fxObjects = Owner.View.gameObject.GetComponents<SpawnFxOnStart>().ToList();
            fxObjects.ForEach(obj => { obj.ResetFx(); });
        }
    }
}
