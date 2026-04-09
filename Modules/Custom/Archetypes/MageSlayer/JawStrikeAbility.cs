using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils.Types;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.Visual.Animation.Kingmaker.Actions;
using LostChapters._wip;
using LostChapters.Modules.Custom.Components;

namespace LostChapters.Modules.Custom.Archetypes.MageSlayer;

internal class JawStrikeAbility
{
    public static readonly string Guid = "{2324832b-e472-4a87-82c0-13246e44d1eb}";

    private static readonly string AbilityName = "JawStrikeAbility";
    private static readonly string DisplayName = $"{AbilityName}.Name";
    private static readonly string Description = $"{AbilityName}.Description";

    //private static readonly Sprite Icon = $"{_Module.IconPath}/ .png";
    
    internal static void Configure()
    {
        var action = ActionsBuilder.New().ApplyBuff(BuffRefs.BlessBuff.ToString(), ContextDuration.Fixed(1));
        var jawStrike = ActionsBuilder.New().Add(new JawStrikeCustomAction(action));

        AbilityConfigurator.New(AbilityName, Guid)
            .AddAbilityEffectRunAction(jawStrike)
            .SetUseCurrentWeaponAsReasonItem(false)
            .AllowTargeting(point: false, enemies: true, friends: true, self: false)
            .SetAnimation(UnitAnimationActionCastSpell.CastAnimationStyle.Immediate)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            //.SetIcon(Icon)
            .Configure();
    }
}
