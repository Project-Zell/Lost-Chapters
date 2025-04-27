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

namespace LostChapters.Modules.GraySisterhood.Feats;

internal class AidAnotherFeature
{
    public static readonly string Guid = "{80225498-3cb2-4615-8660-ac6810ed50d1}";

    private static readonly string FeatureName = "AidAnother";
    private static readonly string DisplayName = "AidAnother.Name";
    private static readonly string Description = "AidAnother.Description";

    private static readonly string FX_AssedID = "358e9c4bd0b52f443b72ad2332e038a4";

    public static void Configure()
    {
        BaseAbility.Configure();
        ArmorClassAbility.Configure();
        AttackAbility.Configure();
        SaveAbility.Configure();
        SkillCheckAbility.Configure();

        var baseFeature = FeatureConfigurator.New(FeatureName, Guid)
            .AddFacts([BaseAbility.Guid])
            .AddHideFeatureInInspect()
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .Configure();
    }

    internal class BaseAbility
    {
        public static readonly string Guid = "{0eed4286-b177-47ef-9de5-e34f2ccda5a4}";

        private static readonly string AbilityName = "AidAnother.BaseAbility";

        internal static void Configure()
        {
            AbilityConfigurator.New(AbilityName, Guid)
                .AddAbilityVariants([AttackAbility.Guid, ArmorClassAbility.Guid, SaveAbility.Guid, SkillCheckAbility.Guid])
                .AllowTargeting(point: false, enemies: false, friends: true, self: false)
                .AddHideDCFromTooltip()
                .AddHideFeatureInInspect()
                .SetType(AbilityType.Special)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }

    #region Attack
    internal class AttackAbility
    {
        public static readonly string Guid = "{78430268-a44e-448f-a776-cffcf6e458be}";

        private static readonly string AbilityName = "AidAnother.AttackAbility";
        private static readonly string DisplayName = "AidAnother.AttackAbility.Name";
        private static readonly string Description = "AidAnother.AttackAbility.Description";

        internal static void Configure()
        {
            AttackBuff.Configure();
            AttackRank.Configure();

            var action = ActionsBuilder.New().Conditional(ConditionsBuilder.New().IsInCombat(),
                ifTrue: ActionsBuilder.New().ApplyBuffPermanent(buff: AttackBuff.Guid),
                ifFalse: ActionsBuilder.New().ApplyBuff(buff: AttackBuff.Guid, durationValue: ContextDuration.FixedDice(DiceType.Zero, bonus: 1), isFromSpell: false, isNotDispelable: false));

            AbilityConfigurator.New(AbilityName, Guid)
                .AddAbilityEffectRunAction(action)
                .AllowTargeting(point: false, enemies: false, friends: true, self: false)
                .SetActionType(UnitCommand.CommandType.Standard)
                .SetAnimation(UnitAnimationActionCastSpell.CastAnimationStyle.Touch)
                .AddAbilitySpawnFx(AbilitySpawnFxAnchor.SelectedTarget, prefabLink: FX_AssedID)
                .AddHideDCFromTooltip()
                .SetType(AbilityType.Special)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }

    internal class AttackBuff
    {
        public static readonly string Guid = "{ec9aa6b0-89ee-4f5d-b44f-f52c0034415f}";

        private static readonly string BuffName = "AidAnother.AttackBuff";
        private static readonly string DisplayName = "AidAnother.AttackBuff.Name";
        private static readonly string Description = "AidAnother.AttackBuff.Description";

        internal static void Configure()
        {
            BuffConfigurator.New(BuffName, Guid)
                .AddComponent<AidAnotherAttack>()
                .SetStacking(StackingType.Stack)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }

    public class AttackRank
    {
        public static readonly string Guid = "{1719af67-80f1-4c99-b68b-44bf4d2b9c49}";

        private static readonly string FeatureName = "AidAnother.AttackRank";

        internal static void Configure()
        {
            FeatureConfigurator.New(FeatureName, Guid)
                .SetRanks(5)
                .SetHideInUI(true)
                .SetIsClassFeature(true)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }
    #endregion

    #region Armor Class
    internal class ArmorClassAbility
    {
        public static readonly string Guid = "{0c40e542-9bcf-43c7-ad00-440e24661744}";

        private static readonly string AbilityName = "AidAnother.ArmorClassAbility";
        private static readonly string DisplayName = "AidAnother.ArmorClassAbility.Name";
        private static readonly string Description = "AidAnother.ArmorClassAbility.Description";

        internal static void Configure()
        {
            ArmorClassBuff.Configure();
            ArmorClassRank.Configure();

            var action = ActionsBuilder.New().Conditional(ConditionsBuilder.New().IsInCombat(),
                ifTrue: ActionsBuilder.New().ApplyBuffPermanent(buff: ArmorClassBuff.Guid),
                ifFalse: ActionsBuilder.New().ApplyBuff(buff: ArmorClassBuff.Guid, durationValue: ContextDuration.FixedDice(DiceType.Zero, bonus: 1), isFromSpell: false, isNotDispelable: false));

            AbilityConfigurator.New(AbilityName, Guid)
                .AddAbilityEffectRunAction(action)
                .AllowTargeting(point: false, enemies: false, friends: true, self: false)
                .SetActionType(UnitCommand.CommandType.Standard)
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
        public static readonly string Guid = "{d4ec56f2-58e9-42d3-a32b-81c439f3a6e5}";

        private static readonly string BuffName = "AidAnotherArmorClassBuff";
        private static readonly string DisplayName = "AidAnotherArmorClassBuff.Name";
        private static readonly string Description = "AidAnotherArmorClassBuff.Description";

        internal static void Configure()
        {
            BuffConfigurator.New(BuffName, Guid)
                .AddComponent<AidAnotherArmorClass>()
                .SetStacking(StackingType.Stack)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }

    public class ArmorClassRank
    {
        public static readonly string Guid = "{29be85a9-12cd-4d54-8d28-2d76b3698533}";

        private static readonly string FeatureName = "AidAnother.ArmorClassRank";

        public static void Configure()
        {
            FeatureConfigurator.New(FeatureName, Guid)
                .SetRanks(5)
                .SetHideInUI(true)
                .SetIsClassFeature(true)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }
    #endregion

    #region Save Action
    internal class SaveAbility
    {
        public static readonly string Guid = "{2953448c-7dd0-499f-8dff-4a5642f17ac0}";

        private static readonly string AbilityName = "AidAnother.SaveAbility";
        private static readonly string DisplayName = "AidAnother.SaveAbility.Name";
        private static readonly string Description = "AidAnother.SaveAbility.Description";

        public static void Configure()
        {
            SaveBuff.Configure();
            SaveRank.Configure();

            var action = ActionsBuilder.New().Conditional(ConditionsBuilder.New().IsInCombat(),
                ifTrue: ActionsBuilder.New().ApplyBuffPermanent(buff: SaveBuff.Guid),
                ifFalse: ActionsBuilder.New().ApplyBuff(buff: SaveBuff.Guid, durationValue: ContextDuration.FixedDice(DiceType.Zero, bonus: 1), isFromSpell: false, isNotDispelable: false));

            AbilityConfigurator.New(AbilityName, Guid)
                .AddAbilityEffectRunAction(action)
                .AllowTargeting(point: false, enemies: false, friends: true, self: false)
                .SetActionType(UnitCommand.CommandType.Standard)
                .SetAnimation(UnitAnimationActionCastSpell.CastAnimationStyle.Touch)
                .AddAbilitySpawnFx(AbilitySpawnFxAnchor.SelectedTarget, prefabLink: FX_AssedID)
                .AddHideDCFromTooltip()
                .SetType(AbilityType.Special)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }

    internal class SaveBuff
    {
        public static readonly string Guid = "{0de91af6-58e9-461e-b0a6-11ab14ade881}";

        private static readonly string BuffName = "AidAnother.SaveBuff";
        private static readonly string DisplayName = "AidAnother.SaveBuff.Name";
        private static readonly string Description = "AidAnother.SaveBuff.Description";

        internal static void Configure()
        {
            BuffConfigurator.New(BuffName, Guid)
                .AddComponent<AidAnotherSave>()
                .SetStacking(StackingType.Stack)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }

    public class SaveRank
    {
        public static readonly string Guid = "{01fb5f7c-c192-4227-95c9-15abc83cc594}";

        private static readonly string FeatureName = "AidAnother.SaveRank";

        public static void Configure()
        {
            FeatureConfigurator.New(FeatureName, Guid)
                .SetRanks(5)
                .SetHideInUI(true)
                .SetIsClassFeature(true)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }
    #endregion

    #region Skill Check
    internal class SkillCheckAbility
    {
        public static readonly string Guid = "{7e1ed9c9-8e0d-48ba-bf6a-dcb0b8e62cb3}";

        private static readonly string AbilityName = "AidAnother.SkillCheckAbility";
        private static readonly string DisplayName = "AidAnother.SkillCheckAbility.Name";
        private static readonly string Description = "AidAnother.SkillCheckAbility.Description";

        internal static void Configure()
        {
            SkillCheckBuff.Configure();
            SkillCheckRank.Configure();

            var action = ActionsBuilder.New().Conditional(ConditionsBuilder.New().IsInCombat(),
                ifTrue: ActionsBuilder.New().ApplyBuffPermanent(buff: SkillCheckBuff.Guid),
                ifFalse: ActionsBuilder.New().ApplyBuff(buff: SkillCheckBuff.Guid, durationValue: ContextDuration.FixedDice(DiceType.Zero, bonus: 1), isFromSpell: false, isNotDispelable: false));

            AbilityConfigurator.New(AbilityName, Guid)
                .AddAbilityEffectRunAction(action)
                .AllowTargeting(point: false, enemies: false, friends: true, self: false)
                .SetActionType(UnitCommand.CommandType.Standard)
                .SetAnimation(UnitAnimationActionCastSpell.CastAnimationStyle.Touch)
                .AddAbilitySpawnFx(AbilitySpawnFxAnchor.SelectedTarget, prefabLink: FX_AssedID)
                .AddHideDCFromTooltip()
                .SetType(AbilityType.Special)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }

    internal class SkillCheckBuff
    {
        public static readonly string Guid = "{11f23a05-e473-4ce8-95ff-7bd11de8dead}";

        private static readonly string BuffName = "AidAnother.SkillCheckBuff";
        private static readonly string DisplayName = "AidAnother.SkillCheckBuff.Name";
        private static readonly string Description = "AidAnother.SkillCheckBuff.Description";

        internal static void Configure()
        {
            BuffConfigurator.New(BuffName, Guid)
                .AddComponent<AidAnotherSkillCheck>()
                .SetStacking(StackingType.Stack)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }

    public class SkillCheckRank
    {
        public static readonly string Guid = "{4d883179-642d-4f20-8e13-04735aa77796}";

        private static readonly string FeatureName = "AidAnother.SkillCheckRank";

        public static void Configure()
        {
            FeatureConfigurator.New(FeatureName, Guid)
                .SetRanks(5)
                .SetHideInUI(true)
                .SetIsClassFeature(true)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }
    #endregion
}