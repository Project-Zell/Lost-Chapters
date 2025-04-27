using Kingmaker.Armies.TacticalCombat.Data;
using Kingmaker.Controllers.Units;
using Kingmaker.PubSubSystem;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.ActivatableAbilities;
using Kingmaker.UnitLogic.Mechanics.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostChapters.Modules.GraySisterhood.Components
{
    internal class LingeringAroma : UnitFactComponentDelegate, IActivatableAbilityWillStopHandler, ITickEachRound
    {
        public void HandleActivatableAbilityWillStop(ActivatableAbility ability)
        {
            ability.Stop();

            throw new NotImplementedException();
        }

        public void OnNewRound()
        {
            throw new NotImplementedException();
        }
    }
}
