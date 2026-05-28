using BlueprintCore.Utils;
using Kingmaker;
using Kingmaker.Blueprints.Facts;
using Kingmaker.Controllers.Rest;
using Kingmaker.ElementsSystem;
using Kingmaker.PubSubSystem;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Buffs.Components;
using LostChapters.Modules.Custom.PrestigeClasses.PlagueKnight;

namespace LostChapters.Components;

internal class RunActionOnNewDayAfterRest : UnitBuffComponentDelegate, IRestFinishedHandler, ISubscriber, IGlobalSubscriber
{
    public ActionList Actions;

    public void HandleRestFinished(RestStatus status)
    {
        var currentHour = Game.Instance.TimeController.GameTime.Hours;
        if (currentHour - status.SleepTime.TotalHours < 0)
        {
            RunActions();
        }
    }

    private void RunActions()
    {
        using (Context.GetDataScope(Owner))
        {
            Actions.Run();
        }
    }
}