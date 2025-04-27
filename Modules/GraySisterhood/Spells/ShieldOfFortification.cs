using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.References;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.UnitLogic.Commands.Base;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.Visual.Animation.Kingmaker.Actions;
using Kingmaker.Craft;
using BlueprintCore.Actions.Builder;
using Kingmaker.UnitLogic.Mechanics;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Utils.Types;
using Kingmaker.RuleSystem;
using BlueprintCore.Actions.Builder.ContextEx;
using Kingmaker.UnitLogic.Abilities;

namespace LostChapters.Modules.GraySisterhood.Spells;

internal class ShieldOfFortification
{
    public static readonly string Guid = "{d62792bb-2ea8-435f-95bd-0302a6c82dbb}";

    private static readonly string AbilityName = "ShieldOfFortification";
    private static readonly string DisplayName = "ShieldOfFortification.Name";
    private static readonly string Description = "ShieldOfFortification.Description";

    internal static void Configure()
    {
        var duration = ContextDuration.VariableDice(diceType: DiceType.Zero, diceCount: 0, bonus: ContextValues.Rank(), rate: DurationRate.Minutes, isExtendable: true);
        var action = ActionsBuilder.New().ApplyBuff(buff: Buff.Guid, durationValue: duration, isFromSpell: true);

        AbilityConfigurator.New(AbilityName, Guid)
            .AddSpellComponent(SpellSchool.Conjuration)
            .AddAbilityEffectRunAction(action)
            .AddToSpellList(level: 1, spellList: SpellListRefs.InquisitorSpellList.ToString())
            .AddToSpellList(level: 1, spellList: SpellListRefs.PaladinSpellList.ToString())
            .AddToSpellList(level: 2, spellList: SpellListRefs.ClericSpellList.ToString())
            .AddCraftInfoComponent(spellType: CraftSpellType.Buff)
            .SetType(AbilityType.Spell)
            .SetRange(AbilityRange.Touch)
            .AllowTargeting(point: false, enemies: false, friends: true, self: true)
            .SetShouldTurnToTarget(true)
            .SetAnimation(UnitAnimationActionCastSpell.CastAnimationStyle.Touch)
            .SetActionType(UnitCommand.CommandType.Standard)
            .SetAvailableMetamagic(Metamagic.Quicken | Metamagic.Extend | Metamagic.Heighten | Metamagic.Reach | Metamagic.CompletelyNormal)
            .SetLocalizedDuration(Duration.MinutePerLevel)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .Configure();
    }

    internal class Buff
    {
        public static readonly string Guid = "{334892e2-43b1-47d1-a982-9fcb321ea6e1}";

        private static readonly string BuffName    = "ShieldOfFortification.ArmorClassBuff";
        private static readonly string DisplayName = "ShieldOfFortification.Name";
        private static readonly string Description = "ShieldOfFortification.Description";

        internal static void Configure()
        {
            BuffConfigurator.New(BuffName, Guid)
                .AddFortification(bonus: 25)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }
}
