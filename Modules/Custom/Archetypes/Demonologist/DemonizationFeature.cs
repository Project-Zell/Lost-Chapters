using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Commands.Base;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Properties;
using Kingmaker.Visual.Animation.Kingmaker.Actions;
using LostChapters.Components;
using LostChapters.Tools;

namespace LostChapters.Modules.Custom.Archetypes.Demonologist;

internal class DemonizationFeature
{
    public static readonly string Guid = "{f44ad496-3cc6-4dac-ad1e-efdd4c3c965e}";

    private static readonly string BaseName = "Demonization";

    private static readonly string FeatureName = $"{BaseName}Feature";
    private static readonly string DisplayName = $"{FeatureName}.Name";
    private static readonly string Description = $"{FeatureName}.Description";

    internal static readonly string Icon = $"{CustomModule.IconPath}/{DemonologistArchetype.BaseName}/{BaseName}.png".ToLower();

    internal static void Configure()
    {
        Buff.Configure();
        Ability.Configure();

        FeatureConfigurator.New(FeatureName, Guid)
            .AddFacts([Ability.Guid])
            .SetIsClassFeature(true)
            .SetHideInCharacterSheetAndLevelUp(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .SetIcon(Icon)
            .Configure();
    }

    internal class Ability
    {
        public static readonly string Guid = "{40a9751c-5b76-4422-8230-42d8ec92f383}";

        private static readonly string AbilityName = $"{BaseName}Ability";
        private static readonly string AbilityText = $"{AbilityName}.UIText";

        internal static void Configure()
        {
            var value = ContextValues.Property(UnitProperty.Level, toCaster: false);
            var duration = ContextDuration.Variable(value, DurationRate.Rounds);

            var action = ActionsBuilder.New()
                .RemoveBuff(HellsWhisperFeature.Buff.Guid)
                .Kill(UnitState.DismemberType.InPower)
                .ApplyBuff(buff: Buff.Guid, durationValue: duration, toCaster: true);

            var resource = AbilityResourceRefs.ArcanistArcaneReservoirResource.ToString();

            AbilityConfigurator.New(AbilityName, Guid)
                .AddAbilityResourceLogic(requiredResource: resource, isSpendResource: true, amount: 1)
                .AddAbilityEffectRunAction(action)
                .AddComponent<AbilityTargetIsSummonedUnit>(component =>
                {
                    component.CasterIsUnitSummoner = true;
                    component.CheckedFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(HellsWhisperFeature.Buff.Guid);
                    component.MessageOverride = AbilityText;
                })
                .SetActionType(UnitCommand.CommandType.Swift)
                .SetShouldTurnToTarget(true)
                .AllowTargeting(point: false, enemies: false, friends: true, self: false)
                .SetAnimation(UnitAnimationActionCastSpell.CastAnimationStyle.Omni)
                .SetRange(AbilityRange.Long)
                .SetType(AbilityType.Supernatural)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(Icon)
                .Configure();
        }
    }

    internal class Buff
    {
        public static readonly string Guid = "{c4392ec8-b3f2-4588-b81e-29c9b6115ae6}";

        private static readonly string BuffName = $"{BaseName}Buff";
        private static readonly string Description = $"{BuffName}.Description";

        internal static void Configure()
        {
            RageHelper.AddArchetypeToRagePowerCalculation(CharacterClassRefs.ArcanistClass.ToString(), DemonologistArchetype.Guid);

            var rageFx = "53c86872d2be80b48afc218af1b204d7";

            RageHelper.ConfigureRageBuffsFor(Guid);
            RageHelper.ConfigureRageStancesFor(Guid);

            var actionsOnActivate = RageHelper.NewActivateRagePowersActionBuilder();
            var actionsOnDeactivate = RageHelper.NewDeactivateRagePowersActionBuilder();

            BuffConfigurator.New(BuffName, Guid)
                .AddFactContextActions(activated: actionsOnActivate, deactivated: actionsOnDeactivate)
                .AddFacts([FeatureRefs.SubtypeDemon.ToString()])
                .AddAdditionalLimb(weapon: ItemWeaponRefs.Gore2d6.ToString())
                .SetFxOnStart(rageFx)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(Icon)
                .Configure();
        }
    }
}