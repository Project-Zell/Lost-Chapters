using BlueprintCore.Actions.Builder;
using BlueprintCore.Utils;
using JetBrains.Annotations;
using Kingmaker.ElementsSystem;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.Items;
using Kingmaker.RuleSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UnitLogic.Commands;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.View.Animation;

namespace LostChapters.Modules.Custom.Components;

internal class UnarmedAttackWithActionOnHit : UnitCustomFreeAttackBase
{
    public MechanicsContext Context;
    public ActionList Action;
    public bool OnlyHit;
    public bool OnlySneakAttack;
    public override AttackMode Mode => AttackMode.Attack;
    private WeaponAnimationStyle Style;

    public UnarmedAttackWithActionOnHit([NotNull] UnitEntityData target, ActionsBuilder action = null) : base(target)
    {
        Action = action?.Build() ?? Action;
        Action ??= Constants.Empty.Actions;
    }

    public override void OnRun()
    {
        //ToDo Check with dual wield and shield and one handed and Size increase
        var equipmentSet = Executor.Body.CurrentHandsEquipmentSet;
        Style = equipmentSet.PrimaryHand.MaybeWeapon.GetAnimationStyle(false);
        equipmentSet.PrimaryHand.MaybeWeapon.WeaponVisualParameters.m_WeaponAnimationStyle = WeaponAnimationStyle.Fist;
        Executor.View.ForcePeacefulLook(true);

        base.OnRun();
    }

    public override void OnEnded(bool raiseEvent = true)
    {
        base.OnEnded(raiseEvent);

        Executor.View.ForcePeacefulLook(false);
        Executor.Body.CurrentHandsEquipmentSet.PrimaryHand.MaybeWeapon.WeaponVisualParameters.m_WeaponAnimationStyle = Style;
    }

    public override ResultType OnAction()
    {
        if (Target.Descriptor.State.IsDead)
        {
            return ResultType.Success;
        }

        ItemEntityWeapon weapon = Executor.Body.EmptyHandWeapon;
        RunAttackRuleAndEffect(Executor, Target, weapon);

        return ResultType.Success;
    }

    public void RunAttackRuleAndEffect(UnitEntityData caster, UnitEntityData target, ItemEntityWeapon weapon)
    {
        RuleAttackWithWeapon evt = new(caster, target, weapon, 0);
        if (IsExtraAttack.HasValue)
        {
            evt.ExtraAttack = IsExtraAttack.Value;
        }

        Rulebook.Trigger(evt);

        var roll = evt.AttackRoll;

        if (CheckConditions(roll))
        {
            using (Context.GetDataScope(target))
            {
                Action.Run();
            }
        }
    }

    public bool CheckConditions(RuleAttackRoll roll)
    {
        if (OnlyHit && roll.IsHit is false)
        {
            return false;
        }

        if (OnlySneakAttack && (roll.IsSneakAttack is false || roll.FortificationNegatesSneakAttack))
        {
            return false;
        }

        return true;
    }

    public override bool IsSuitableWeapon(ItemEntityWeapon weapon) => true;
}
