using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.Configurators.Root;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Commands.Base;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.Visual.Animation.Kingmaker.Actions;
using UnityEngine;

namespace LostChapters.Modules.Custom.Archetypes.FalseKnight.FallenOrder;

internal class UnyieldingDevotionFeature
{
    public static readonly string Guid = "{87693bd2-0891-4f44-a298-e78bb29b4231}";

    private static readonly string BaseName = "UnyieldingDevotion";

    private static readonly string AbilityName = $"{BaseName}Feature";
    private static readonly string DisplayName = $"{AbilityName}.Name";
    private static readonly string Description = $"{AbilityName}.Description";

    //private static readonly Sprite Icon = $"{_Module.IconPath}/ .png";

    internal static void Configure()
    {
        FallenKnightUnitSpear.Configure();
        FallenKnightUnitShortSword.Configure();
        FallenKnightUnitBannerBearer.Configure();

        //Wind Master helmet

        //Summon Spirit Guardian/Paladin
        //Black Knight calls to his fallen order brothers spirits. One time per day, he can summon 3 ghost knights for 1 minute.
        CampaignConfigurator.For(CampaignRefs.MainCampaign.ToString())
            .AddToPregens(UnitRefs.StartGamePregenCavalierUnit.ToString())
            .Configure();

        var count = new ContextDiceValue { DiceCountValue = 0, BonusValue = 1 };
        var duration = ContextDuration.Fixed(value: 1, rate: DurationRate.Minutes);

        var spawnAction = ActionsBuilder.New()
            .SpawnMonster(monster: FallenKnightUnitSpear.Guid, countValue: count, durationValue: duration, offset: new Vector3(0.75f, 0, -0.75f))
            .SpawnMonster(monster: FallenKnightUnitShortSword.Guid, countValue: count, durationValue: duration, offset: new Vector3(-0.75f, 0, -0.75f))
            .SpawnMonster(monster: FallenKnightUnitBannerBearer.Guid, countValue: count, durationValue: duration);

        AbilityConfigurator.New(AbilityName, Guid)
            .AddBuffEnchantAnyWeapon(WeaponEnchantmentRefs.Enhancement3.ToString())
            .AddAbilityEffectRunAction(spawnAction)
            .SetType(AbilityType.Spell)
            .SetRange(AbilityRange.Close)
            .AddSpellComponent(SpellSchool.Conjuration)
            .AddSpellDescriptorComponent(SpellDescriptor.Summoning)
            .SetActionType(UnitCommand.CommandType.Standard)
            .SetAnimation(UnitAnimationActionCastSpell.CastAnimationStyle.Point)
            .SetCanTargetSelf(true)
            .SetCanTargetPoint(true)
            .SetIsFullRoundAction(true)
            .SetAvailableMetamagic([Metamagic.Extend, Metamagic.Quicken, Metamagic.Heighten, Metamagic.Reach, Metamagic.CompletelyNormal])
            .SetLocalizedDuration("6250ccf0-1ed0-460f-8ce7-094c2da7e198")
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .Configure();
    }
}