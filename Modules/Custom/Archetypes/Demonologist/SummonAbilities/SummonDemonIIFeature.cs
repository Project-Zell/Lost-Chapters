using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using LostChapters.Modules.Custom.Archetypes.Demonologist.SummonUnits;

namespace LostChapters.Modules.Custom.Archetypes.Demonologist.SummonAbilities;

internal class SummonDemonIIFeature
{
    public static readonly string Guid = "{075bf4c0-4e2e-40f6-a142-706afd61c3de}";

    private static readonly string FeatureName = "SummonDemonIIFeature";
    private static readonly string DisplayName = $"{FeatureName}.Name";
    private static readonly string Description = $"{FeatureName}.Description";

    private static readonly string Icon = $"{CustomModule.IconPath}/summondemon1.png";

    internal static void Configure()
    {
        DretchSummonUnit.Configure();

        BaseAbility.Configure();

        FeatureConfigurator.New(FeatureName, Guid)
            .AddFacts([BaseAbility.Guid])
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .SetIcon(Icon)
            .Configure();
    }

    internal class BaseAbility
    {
        public static readonly string Guid = "{e5b7c8c5-acb3-4731-9c94-622371a1f1d4}";

        private static readonly string AbilityName = $"{FeatureName}.BaseAbility";

        internal static void Configure()
        {
            SummonDemonIISingle.Configure();
            SummonDemonIId3.Configure();

            SummonAbilityHelper.CreateBaseAbility(
                guid: Guid,
                name: AbilityName,
                displayName: DisplayName,
                description: Description,
                icon: Icon,
                abilities: [SummonDemonIISingle.Guid, SummonDemonIId3.Guid]);
        }
    }

    internal class SummonDemonIISingle
    {
        public static readonly string Guid = "{d2a944d8-1ddb-4779-bf9f-8a365d87b7f7}";

        private static readonly string AbilityName = $"{FeatureName}.MajorAbility";
        private static readonly string DisplayName = $"{AbilityName}.Name";
        private static readonly string Description = $"{AbilityName}.Description";

        internal static void Configure()
        {
            SummonAbilityHelper.CreateSummonAbility(
                guid: Guid,
                name: AbilityName,
                displayName: DisplayName,
                description: Description,
                icon: Icon,
                summonUnitID: DretchSummonUnit.Guid,
                countType: SummonAbilityHelper.SummonCountType.single);
        }
    }

    internal class SummonDemonIId3
    {
        public static readonly string Guid = "{4bbaddb6-9a26-40a2-a93e-6ae2cc11a34b}";

        private static readonly string AbilityName = $"{FeatureName}.MinorAbility";
        private static readonly string DisplayName = $"{AbilityName}.Name";
        private static readonly string Description = $"{AbilityName}.Description";

        private static readonly string Icon = $"{CustomModule.IconPath}/summondemon1.png";

        internal static void Configure()
        {
            SummonAbilityHelper.CreateSummonAbility(
                guid: Guid,
                name: AbilityName,
                displayName: DisplayName,
                description: Description,
                icon: Icon,
                summonUnitID: QuasitSummonUnit.Guid,
                countType: SummonAbilityHelper.SummonCountType.d3);
        }
    }
}
