using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Root.Strings.GameLog;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.Enums;
using Kingmaker.Localization;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UI.Models.Log.CombatLog_ThreadSystem;
using Kingmaker.UI.Models.Log.CombatLog_ThreadSystem.LogThreads.Combat;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.Utility;
using LostChapters.Enchantment;
using LostChapters.Modules.GraySisterhood.Backgrounds;
using LostChapters.Modules.GraySisterhood.Feats;
using LostChapters.Modules.GraySisterhood.Items.Other;
using LostChapters.Tools;
using System.Linq;
using UnityEngine;

namespace LostChapters.Modules.GraySisterhood.Components;

internal class Bodyguard : UnitFactComponentDelegate<ACBonusAgainstAttacks.RuntimeData>, ITargetRulebookHandler<RuleCalculateAC>, ITargetRulebookSubscriber, ITargetRulebookHandler<RuleAttackWithWeapon>, IRulebookHandler<RuleCalculateAC>, ISubscriber, IRulebookHandler<RuleAttackWithWeapon>
{
    private static readonly string CombatLogMessage = "Bodyguard.GameLogMessage";

    public void OnEventAboutToTrigger(RuleAttackWithWeapon evt)
    {
        var maybeCaster = Context.MaybeCaster;

        var cooldownBuff = BlueprintTool.Get<BlueprintBuff>(BodyguardFeature.CooldownBuff.Guid);
        var swiftAidArmorBuff = BlueprintTool.Get<BlueprintBuff>(SwiftAid.ArmorClassBuff.Guid);
        var aidAnotherArmorBuff = BlueprintTool.Get<BlueprintBuff>(AidAnotherFeature.ArmorClassBuff.Guid);

        if (evt.Target == maybeCaster || Toolbox.IsTargetHasBuffFromCaster(evt.Target.Buffs, [cooldownBuff, swiftAidArmorBuff, aidAnotherArmorBuff], maybeCaster))
            return;

        var hasAttackOfOpportunity = maybeCaster.CombatState.AttackOfOpportunityCount >= 1;

        if (Toolbox.IsTargetInMeleeRangeOfCaster(maybeCaster, evt.Target) is false || Toolbox.IsEventTargetInMeleeRange(evt) is false ||
            hasAttackOfOpportunity is false || Toolbox.IsTargetHasBuffFromCaster(evt.Target.Buffs, BlueprintTool.Get<BlueprintBuff>(AidAnotherFeature.ArmorClassBuff.Guid), maybeCaster))
            return;

        var rankBonus = 0;
        var rankFeature = BlueprintTool.Get<BlueprintFeature>(AidAnotherFeature.ArmorClassRank.Guid);

        if (maybeCaster.HasFact(rankFeature))
            rankBonus = maybeCaster.Descriptor.Progression.Features.GetRank(rankFeature);

        if (rankBonus > 5)
            rankBonus = 5;

        var featBonus = 0;
        if (maybeCaster.HasFact(BlueprintTool.Get<BlueprintFeature>(HelpfulFeature.Guid)))
        {
            var isTiny = maybeCaster.HasFact(RaceRefs.HalflingRace.Reference) ||
                         maybeCaster.HasFact(RaceRefs.GnomeRace.Reference);

            featBonus = isTiny ? 2 : 1;
        }

        if (maybeCaster.HasFact(BlueprintTool.Get<BlueprintFeature>(BattlefieldDiscipleBackground.Guid)))
            featBonus += 1;

        var equipmentBonus = 0;
        if (maybeCaster.HasFact(BenevolentArmorEnchantment.FeatReference))
        {
            equipmentBonus = Toolbox.IsArmorHasEnchantment(maybeCaster.Body.Armor.MaybeArmor.Blueprint,
                    BenevolentArmorEnchantment.Enchantment) ? Toolbox.GetItemEnhancementBonus(maybeCaster.Body.Armor) : 0;
        }

        if (maybeCaster.HasFact(RingOfAltruismItem.Reference))
            equipmentBonus += 1;

        Data.ACModifier = 2 + rankBonus + featBonus + equipmentBonus;
        Data.Initiator = evt.Initiator;

        maybeCaster.CombatState.AttackOfOpportunityCount--;

        evt.Target.AddBuff(blueprint: cooldownBuff, caster: Context.MaybeCaster);

        ShowBodyguardMessage(maybeCaster, evt.Target);
    }

    public void OnEventDidTrigger(RuleAttackWithWeapon evt)
    {
        Data.Clear();

        var maybeCaster = Context.MaybeCaster;
        var target = evt.Target;

        var harryingPartners = BlueprintTool.Get<BlueprintFeature>(HarryingPartnersFeature.Guid);

        var hasHarryingPartners = target.HasFact(harryingPartners) && maybeCaster.HasFact(harryingPartners);
        var buff = BlueprintTool.Get<BlueprintBuff>(AidAnotherFeature.ArmorClassBuff.Guid);

        if (Toolbox.IsEventTargetInMeleeRange(evt) is false || Toolbox.IsTargetInMeleeRangeOfCaster(maybeCaster, target) is false ||
            Toolbox.IsTargetHasBuffFromCaster(target.Buffs, buff, maybeCaster) || evt.Target == Context.MaybeCaster || hasHarryingPartners is false)
            return;
        
        evt.Target.AddBuff(blueprint: buff, caster: maybeCaster);
    }

    public void OnEventAboutToTrigger(RuleCalculateAC evt)
    {
        if (Data.Initiator != null && Data.Initiator == evt.Initiator && (evt.Target == Context.MaybeCaster) is false)
        {
            evt.AddTemporaryModifier(evt.Target.Stats.AC.AddModifier(Data.ACModifier, Fact, ModifierDescriptor.UntypedStackable));
        }
    }

    public void OnEventDidTrigger(RuleCalculateAC evt) { }

    private void ShowBodyguardMessage(UnitEntityData caster, UnitEntityData target)
    {
        var targetColor = ColorUtility.ToHtmlStringRGB(target.Blueprint.Color);
        var casterColor = ColorUtility.ToHtmlStringRGB(caster.Blueprint.Color);

        var targetName = $"<color=#{targetColor}><b>{target.CharacterName}</b></color>";
        var casterName = $"<color=#{casterColor}><b>{caster.CharacterName}</b></color>";

        var localizedText = LocalizationManager.CurrentPack.GetText(CombatLogMessage);
        var message = new CombatLogMessage($"{targetName} {localizedText} {casterName}.", GameLogStrings.Instance.DefaultColor, PrefixIcon.RightArrow, null, false);

        var messageLog = LogThreadService.Instance.m_Logs[LogChannelType.InGameCombat].First(x => x is AttackLogThread);
        messageLog.AddMessage(message);
    }
}
