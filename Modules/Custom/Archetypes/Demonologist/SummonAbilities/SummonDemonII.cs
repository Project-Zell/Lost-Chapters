using LostChapters.Modules.Custom.Archetypes.Demonologist.SummonUnits;
using LostChapters.Modules.Custom.Archetypes.Demonologist.Tools;

namespace LostChapters.Modules.Custom.Archetypes.Demonologist.SummonAbilities;

internal class SummonDemonII
{
    public static readonly string Guid = "{075bf4c0-4e2e-40f6-a142-706afd61c3de}";

    private static readonly string BaseName = "SummonDemonII";

    private static readonly string Icon = $"{CustomModule.IconPath}/summondemon1.png";

    internal static void Configure()
    {
        DretchSummonUnit.Configure();
        BaseAbility.Configure();
    }

    internal class BaseAbility
    {
        public static readonly string Guid = "{e5b7c8c5-acb3-4731-9c94-622371a1f1d4}";

        private static readonly string AbilityName = $"{BaseName}.BaseAbility";
        private static readonly string DisplayName = $"{AbilityName}.Name";
        private static readonly string Description = $"{AbilityName}.Description";

        internal static void Configure()
        {
            Single.Configure();
            OneToThree.Configure();

            DemonologistSummonAbilityHelper.CreateBaseAbility(
                guid: Guid,
                name: AbilityName,
                displayName: DisplayName,
                description: Description,
                icon: Icon,
                abilities: [Single.Guid, OneToThree.Guid]);
        }
    }

    internal class Single
    {
        public static readonly string Guid = "{d2a944d8-1ddb-4779-bf9f-8a365d87b7f7}";

        private static readonly string AbilityName = $"{BaseName}.MajorAbility";
        private static readonly string DisplayName = $"{AbilityName}.Name";
        private static readonly string Description = $"{AbilityName}.Description";

        internal static void Configure()
        {
            DemonologistSummonAbilityHelper.CreateSummonAbility(
                guid: Guid,
                name: AbilityName,
                displayName: DisplayName,
                description: Description,
                icon: Icon,
                summonUnitID: DretchSummonUnit.Guid,
                countType: DemonologistSummonAbilityHelper.SummonCountType.single);
        }
    }

    internal class OneToThree
    {
        public static readonly string Guid = "{4bbaddb6-9a26-40a2-a93e-6ae2cc11a34b}";

        private static readonly string AbilityName = $"{BaseName}.MinorAbility";
        private static readonly string DisplayName = $"{AbilityName}.Name";
        private static readonly string Description = $"{AbilityName}.Description";

        private static readonly string Icon = $"{CustomModule.IconPath}/summondemon1.png";

        internal static void Configure()
        {
            DemonologistSummonAbilityHelper.CreateSummonAbility(
                guid: Guid,
                name: AbilityName,
                displayName: DisplayName,
                description: Description,
                icon: Icon,
                summonUnitID: QuasitSummonUnit.Guid,
                countType: DemonologistSummonAbilityHelper.SummonCountType.d3);
        }
    }
}
