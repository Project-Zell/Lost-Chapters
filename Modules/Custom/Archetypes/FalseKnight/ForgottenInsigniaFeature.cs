using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.Utility;
using LostChapters.Modules.Custom.Components;
using LostChapters.Modules.HellknightsCodex;

namespace LostChapters.Modules.Custom.Archetypes.BlackKnight;

internal class ForgottenInsigniaFeature
{
    public static readonly string Guid = "{4ffc69ce-b22a-4527-9269-24d3f2ac15f6}";

    private static readonly string FeatureName = "ForgottenInsigniaFeature";
    private static readonly string DisplayName = $"{FeatureName}.Name";
    private static readonly string Description = $"{FeatureName}.Description";

    private static readonly string Icon = $"{HellknightCodexModule.IconsPath}/forgottenrelic.png";

    internal static void Configure()
    {
        ForgottenInsigniaBuff.Configure();
        ForgottenInsigniaArea.Configure();
        ForgottenInsigniaAreaBuff.Configure();

        FeatureConfigurator.New(FeatureName, Guid)
            .AddAuraFeatureComponent(ForgottenInsigniaAreaBuff.Guid)
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .SetIcon(Icon)
            .Configure();
    }

    internal class ForgottenInsigniaAreaBuff
    {
        public static readonly string Guid = "{951daaf7-218b-411f-9614-d3b34bb56745}";

        private static readonly string BuffName = $"{FeatureName}.AreaBuff";

        internal static void Configure()
        {
            BuffConfigurator.New(BuffName, Guid)
                .AddAreaEffect(ForgottenInsigniaArea.Guid)
                .SetFlags(BlueprintBuff.Flags.HiddenInUi | BlueprintBuff.Flags.StayOnDeath)
                .Configure();
        }
    }

    internal class ForgottenInsigniaBuff
    {
        public static readonly string Guid = "{f608a310-5474-44d7-acd0-dd67a2daeacc}";

        private static readonly string BuffName = $"{FeatureName}.Buff";

        internal static void Configure()
        {
            BuffConfigurator.New(BuffName, Guid)
                .AddComponent<ForgottenInsignia>()
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(Icon)
                .Configure();
        }
    }

    internal class ForgottenInsigniaArea
    {
        public static readonly string Guid = "{32797c23-52bc-46a4-b498-8ecfd492f5e7}";

        private static readonly string AreaName = $"{FeatureName}.Area";

        internal static void Configure()
        {
            AbilityAreaEffectConfigurator.New(AreaName, Guid)
                .AddAbilityAreaEffectRunAction(
                    unitEnter: ActionsBuilder.New().Conditional(conditions: ConditionsBuilder.New().IsAlly(),
                        ifFalse: ActionsBuilder.New().ApplyBuffPermanent(buff: ForgottenInsigniaBuff.Guid, asChild: true)),
                    unitExit: ActionsBuilder.New().Conditional(conditions: ConditionsBuilder.New().IsAlly(),
                        ifFalse: ActionsBuilder.New().RemoveBuff(buff: ForgottenInsigniaBuff.Guid)))
                .SetTargetType(BlueprintAbilityAreaEffect.TargetType.Any)
                .SetShape(AreaEffectShape.Cylinder)
                .SetSize(30.Feet())
                .Configure();
        }
    }
}
