using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Craft;
using Kingmaker.RuleSystem;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Commands.Base;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.Visual.Animation.Kingmaker.Actions;

namespace LostChapters.Modules.GraySisterhood.Spells;

internal class ShieldOfFortificationGreater
{
    public static readonly string Guid = "{f9c641e5-ab3b-4c53-a419-89e4cfbf1c47}";

    private static readonly string AbilityName = "ShieldOfFortificationGreater";
    private static readonly string DisplayName = "ShieldOfFortificationGreater.Name";
    private static readonly string Description = "ShieldOfFortificationGreater.Description";

    internal static void Configure()
    {
        var duration = ContextDuration.VariableDice(diceType: DiceType.Zero, diceCount: 0, bonus: ContextValues.Rank(), rate: DurationRate.Minutes, isExtendable: true);
        var action = ActionsBuilder.New().ApplyBuff(buff: Buff.Guid, durationValue: duration, isFromSpell: true);

        AbilityConfigurator.New(AbilityName, Guid)
            .AddSpellComponent(SpellSchool.Conjuration)
            .AddAbilityEffectRunAction(action)
            .AddToSpellList(level: 3, spellList: SpellListRefs.InquisitorSpellList.ToString())
            .AddToSpellList(level: 3, spellList: SpellListRefs.PaladinSpellList.ToString())
            .AddToSpellList(level: 4, spellList: SpellListRefs.ClericSpellList.ToString())
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
        public static readonly string Guid = "{5d0b7f4d-b9f7-4a83-ab1d-3b40302b8183}";

        private static readonly string BuffName    = "ShieldOfFortificationGreater.ArmorClassBuff";
        private static readonly string DisplayName = "ShieldOfFortificationGreater.Name";
        private static readonly string Description = "ShieldOfFortificationGreater.Description";

        internal static void Configure()
        {
            BuffConfigurator.New(BuffName, Guid)
                .AddFortification(bonus: 50)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }
}
