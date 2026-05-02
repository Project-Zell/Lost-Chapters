using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;

namespace LostChapters.Modules.Custom.Archetypes.Demonologist;

internal class CallOfTheAbyssFeature
{
    public static readonly string Guid = "{bfabd869-e103-479c-8944-16055c16c0ae}";

    private static readonly string FeatureName = "CallOfTheAbyssFeature";
    private static readonly string DisplayName = $"{FeatureName}.Name";
    private static readonly string Description = $"{FeatureName}.Description";

    //private static readonly Sprite Icon = $"{_Module.IconPath}/ .png";

    internal static void Configure()
    {
        Ability.Configure();
        Buff.Configure();
        DemonSummonRageBuff.Configure();

        FeatureConfigurator.New(FeatureName, Guid)
            .AddFacts([Ability.Guid])
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            //.AddFeatureTagsComponent()
            //.SetIcon(Icon)
            .Configure();
    }

    internal class Ability
    {
        public static readonly string Guid = "{bd1ee7dc-8998-448b-8057-20d101a08333}";

        private static readonly string AbilityName = $"{FeatureName}.Ability";
        private static readonly string DisplayName = $"{AbilityName}.Name";
        private static readonly string Description = $"{AbilityName}.Description";

        internal static void Configure()
        {
            var action = ActionsBuilder.New().ApplyBuffPermanent(Buff.Guid);

            AbilityConfigurator.New(AbilityName, Guid)
                .AddAbilityEffectRunAction(action)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }

    internal class Buff
    {
        public static readonly string Guid = "{642e95ad-e185-490a-a4df-91c6a9f8eedc}";

        private static readonly string BuffName = $"{FeatureName}.Buff";
        private static readonly string DisplayName = $"{BuffName}.Name";
        private static readonly string Description = $"{BuffName}.Description";

        internal static void Configure()
        {
            BuffConfigurator.New(BuffName, Guid)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }
}
