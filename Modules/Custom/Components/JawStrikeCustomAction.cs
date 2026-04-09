using BlueprintCore.Actions.Builder;
using Kingmaker;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.UnitLogic.Mechanics.Actions;

namespace LostChapters.Modules.Custom.Components;

internal class JawStrikeCustomAction : ContextAction
{
    private readonly ActionsBuilder ActionsBuilder;
    
    public JawStrikeCustomAction(ActionsBuilder action)
    {
        ActionsBuilder = action;
    }

    public override string GetCaption()
    {
        throw new System.NotImplementedException();
    }

    public override void RunAction()
    {
        UnitEntityData maybeCaster = Context.MaybeCaster;
        if (maybeCaster == null)
        {
            PFLog.Default.Error("Caster is missing");
            return;
        }

        UnitEntityData target = Target?.Unit;
        
        UnarmedAttackWithActionOnHit cmd = new(target, ActionsBuilder)
        {
            IsExtraAttack = true,
            Context = Context,
            OnlyHit = true,
            OnlySneakAttack = true,
        };
        maybeCaster.Commands.AddToQueue(cmd);
    }
}
