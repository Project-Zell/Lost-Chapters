using LostChapters.Modules.Custom.Archetypes.Demonologist.SummonUnits;
using LostChapters.Modules.Custom.Archetypes.Demonologist.Tools;

namespace LostChapters.Modules.Custom.Archetypes.Demonologist.SummonAbilities;

internal class SummonDemonI
{
    public static readonly string Guid = "{e2e431bf-3f2a-493e-96cd-524cc6e60d68}";

    private static readonly string BaseName = "SummonDemonI";

    private static readonly string Icon = $"{CustomModule.IconPath}/summondemon1.png";

    internal static void Configure()
    {
        QuasitSummonUnit.Configure();
        Single.Configure();
    }

    internal class Single
    {
        public static readonly string Guid = "{f5ed109f-3b24-4718-8c1e-02e4561067d1}";

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
                summonUnitID: QuasitSummonUnit.Guid,
                countType: DemonologistSummonAbilityHelper.SummonCountType.single);
        }
    }
}
