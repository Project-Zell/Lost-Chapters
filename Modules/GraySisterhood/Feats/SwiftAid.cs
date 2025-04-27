using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.BasicEx;
using BlueprintCore.Utils.Types;
using Kingmaker.RuleSystem;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components.Base;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Commands.Base;
using Kingmaker.Visual.Animation.Kingmaker.Actions;
using LostChapters.Modules.GraySisterhood.Components;
using Kingmaker.EntitySystem.Stats;
using BlueprintCore.Blueprints.References;
using LostChapters.Modules.GraySisterhood.Revelations.Succor;

namespace LostChapters.Modules.GraySisterhood.Feats;

internal class SwiftAid
{
    public static readonly string Guid = "{b70354ff-506a-4078-9d79-ef832c8d60aa}";

    private static readonly string FeatureName = "SwiftAid";
    private static readonly string DisplayName = "SwiftAid.Name";
    private static readonly string Description = "SwiftAid.Description";

    private static readonly string FX_AssedID = "358e9c4bd0b52f443b72ad2332e038a4";

    private static readonly string Icon = $"{GraySisterhoodModule.IconPath}/swiftaid.png";

    public static void Configure()
    {
        BaseAbility.Configure();

        FeatureConfigurator.New(FeatureName, Guid, Kingmaker.Blueprints.Classes.FeatureGroup.Feat)
            .AddFacts([BaseAbility.Guid])
            .AddPrerequisiteStatValue(stat: StatType.Intelligence, value: 13)
            .AddPrerequisiteStatValue(stat: StatType.BaseAttackBonus, value: 6)
            .AddPrerequisiteFeaturesFromList(amount: 1, features: [FeatureRefs.CombatExpertiseFeature.ToString(), PerfectAid.Guid])
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .Configure();
    }

    internal class BaseAbility
    {
        public static readonly string Guid = "{65acc646-afe5-42f6-8d4a-d432f4de089a}";

        private static readonly string AbilityName = "SwiftAid.Ability";
        private static readonly string DisplayName = "SwiftAid.Ability.Name";
        private static readonly string Description = "SwiftAid.Ability.Description";

        internal static void Configure()
        {
            AttackAbility.Configure();
            ArmorClassAbility.Configure();

            AbilityConfigurator.New(AbilityName, Guid)
                .AllowTargeting(point: false, enemies: false, friends: true, self: false)
                .AddHideDCFromTooltip()
                .AddAbilityVariants([AttackAbility.Guid, ArmorClassAbility.Guid])
                .SetType(AbilityType.Special)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }

    #region Attack
    internal class AttackAbility
    {
        public static readonly string Guid = "{0cd69072-c1ee-4fba-acde-3fa12245c9e2}";

        private static readonly string AbilityName = "SwiftAid.AttackAbility";
        private static readonly string DisplayName = "SwiftAid.AttackAbility.Name";
        private static readonly string Description = "SwiftAid.AttackAbility.Description";

        internal static void Configure()
        {
            AttackBuff.Configure();

            var action = ActionsBuilder.New().Conditional(ConditionsBuilder.New().IsInCombat(),
                ifTrue: ActionsBuilder.New().ApplyBuffPermanent(buff: AttackBuff.Guid),
                ifFalse: ActionsBuilder.New().ApplyBuff(buff: AttackBuff.Guid, durationValue: ContextDuration.FixedDice(DiceType.Zero, bonus: 1), isFromSpell: false, isNotDispelable: false));

            AbilityConfigurator.New(AbilityName, Guid)
                .AddAbilityEffectRunAction(action)
                .AllowTargeting(point: false, enemies: false, friends: true, self: false)
                .AddHideDCFromTooltip()
                .SetType(AbilityType.Special)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetActionType(UnitCommand.CommandType.Swift)
                .SetAnimation(UnitAnimationActionCastSpell.CastAnimationStyle.Touch)
                .AddAbilitySpawnFx(AbilitySpawnFxAnchor.SelectedTarget, prefabLink: FX_AssedID)
                .Configure();
        }
    }

    internal class AttackBuff
    {
        public static readonly string Guid = "{8ca9e689-f3a9-43d1-8625-425770a91b91}";

        private static readonly string BuffName = "SwiftAid.AttackBuff";
        private static readonly string DisplayName = "SwiftAid.AttackBuff.Name";
        private static readonly string Description = "SwiftAid.AttackBuff.Description";

        internal static void Configure()
        {
            var buff = BuffConfigurator.New(BuffName, Guid)
                .AddComponent<AidAnotherAttack>(component => { component.BasicBonus = 1; })
                .SetStacking(StackingType.Stack)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }
    #endregion

    #region Armor Class
    internal class ArmorClassAbility
    {
        public static readonly string Guid = "{35d1ba0b-0914-41a1-8545-ad67262bd365}";

        private static readonly string AbilityName = "SwiftAid.ArmorClassAbility";
        private static readonly string DisplayName = "SwiftAid.ArmorClassAbility.Name";
        private static readonly string Description = "SwiftAid.ArmorClassAbility.Description";

        internal static void Configure()
        {
            ArmorClassBuff.Configure();

            var action = ActionsBuilder.New().Conditional(ConditionsBuilder.New().IsInCombat(),
                ifTrue: ActionsBuilder.New().ApplyBuffPermanent(buff: ArmorClassBuff.Guid),
                ifFalse: ActionsBuilder.New().ApplyBuff(buff: ArmorClassBuff.Guid, durationValue: ContextDuration.FixedDice(DiceType.Zero, bonus: 1), isFromSpell: false, isNotDispelable: false));

            AbilityConfigurator.New(AbilityName, Guid)
                .AddAbilityEffectRunAction(action)
                .AllowTargeting(point: false, enemies: false, friends: true, self: false)
                .SetActionType(UnitCommand.CommandType.Swift)
                .SetAnimation(UnitAnimationActionCastSpell.CastAnimationStyle.Touch)
                .AddAbilitySpawnFx(AbilitySpawnFxAnchor.SelectedTarget, prefabLink: FX_AssedID)
                .AddHideDCFromTooltip()
                .SetType(AbilityType.Special)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }

    internal class ArmorClassBuff
    {
        public static readonly string Guid = "{0d8fbd56-6915-4c83-8b9c-54a681e3a829}";

        private static readonly string BuffName = "SwiftAid.ArmorClassBuff";
        private static readonly string DisplayName = "SwiftAid.ArmorClassBuff.Name";
        private static readonly string Description = "SwiftAid.ArmorClassBuff.Description";

        internal static void Configure()
        {
            var buff = BuffConfigurator.New(BuffName, Guid)
                .AddComponent<AidAnotherArmorClass>(component => { component.BasicBonus = 1; })
                .SetStacking(StackingType.Stack)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }
    #endregion
}

