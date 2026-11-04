using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.Utility;
using LostChapters.Modules.Custom.Archetypes.FalseKnight.Components;

namespace LostChapters.Modules.Custom.Archetypes.FalseKnight;

internal class ForgottenInsigniaFeature
{
    public static readonly string Guid = "{4ffc69ce-b22a-4527-9269-24d3f2ac15f6}";

    private static readonly string BaseName = "ForgottenInsignia";

    private static readonly string FeatureName = $"{BaseName}Feature";
    private static readonly string DisplayName = $"{FeatureName}.Name";
    private static readonly string Description = $"{FeatureName}.Description";

    //private static readonly string Icon = $"{CustomModule.IconPath}/{FalseKnightArchetype.BaseName}/{BaseName}.png".ToLower();

    internal static void Configure()
    {
        AreaBuff.Configure();

        FeatureConfigurator.New(FeatureName, Guid)
            .AddAuraFeatureComponent(AreaBuff.Guid)
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            //.SetIcon(Icon)
            .Configure();
    }

    internal class AreaBuff
    {
        public static readonly string Guid = "{951daaf7-218b-411f-9614-d3b34bb56745}";

        private static readonly string BuffName = $"{FeatureName}AreaBuff";

        internal static void Configure()
        {
            AreaEffect.Configure();

            BuffConfigurator.New(BuffName, Guid)
                .AddAreaEffect(AreaEffect.Guid)
                .SetFlags(BlueprintBuff.Flags.HiddenInUi | BlueprintBuff.Flags.StayOnDeath)
                .Configure();
        }
    }

    internal class AreaEffect
    {
        public static readonly string Guid = "{32797c23-52bc-46a4-b498-8ecfd492f5e7}";

        private static readonly string AreaName = $"{FeatureName}Area";

        internal static void Configure()
        {
            EffectBuff.Configure();

            var enterConditional = ActionsBuilder.New()
                .Conditional(conditions: ConditionsBuilder.New().IsEnemy(),
                        ifTrue: ActionsBuilder.New().ApplyBuffPermanent(buff: EffectBuff.Guid, asChild: true)
                .Conditional(conditions: ConditionsBuilder.New().IsEnemy().CasterHasFact(ForbiddenInsigniaFeature.Guid),
                        ifTrue: ActionsBuilder.New().ApplyBuffPermanent(buff: ForbiddenInsigniaFeature.Buff.Guid, asChild: true)));

            var exitConditionas = ActionsBuilder.New()
                .Conditional(conditions: ConditionsBuilder.New().IsEnemy(),
                        ifTrue: ActionsBuilder.New().RemoveBuff(buff: EffectBuff.Guid)
                .Conditional(conditions: ConditionsBuilder.New().IsEnemy().CasterHasFact(ForbiddenInsigniaFeature.Guid),
                        ifTrue: ActionsBuilder.New().RemoveBuff(buff: ForbiddenInsigniaFeature.Buff.Guid)));

            AbilityAreaEffectConfigurator.New(AreaName, Guid)
                .AddAbilityAreaEffectRunAction(unitEnter: enterConditional, unitExit: exitConditionas)
                .SetTargetType(BlueprintAbilityAreaEffect.TargetType.Any)
                .SetShape(AreaEffectShape.Cylinder)
                .SetSize(30.Feet())
                .Configure();
        }
    }

    internal class EffectBuff
    {
        public static readonly string Guid = "{f608a310-5474-44d7-acd0-dd67a2daeacc}";

        private static readonly string BuffName = $"{FeatureName}EffectBuff";

        internal static void Configure()
        {
            BuffConfigurator.New(BuffName, Guid)
                .AddComponent<FalseKnightInsignia>()
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                //.SetIcon(Icon)
                .Configure();
        }
    }
}