using LostChapters.Modules.Custom.Archetypes.Demonologist.SummonUnits;
using LostChapters.Modules.Custom.Archetypes.Demonologist.Tools;

namespace LostChapters.Modules.Custom.Archetypes.Demonologist.SummonAbilities;

internal class SummonDemonVII
{
    public static readonly string Guid = "{397b9893-6546-41ac-a6cf-64f948237850}";

    private static readonly string BaseName = "SummonDemonVII";

    internal static readonly string Icon = $"{CustomModule.IconPath}/{DemonologistArchetype.BaseName}/{BaseName}.png".ToLower();

    internal static void Configure()
    {
        KalavakusSummonUnit.Configure();
        BaseAbility.Configure();
    }

    internal class BaseAbility
    {
        public static readonly string Guid = "{d097c177-a47d-4ddd-bf60-81e8abfbf0ac}";

        private static readonly string AbilityName = $"{BaseName}Base";
        private static readonly string DisplayName = $"{AbilityName}.Name";
        private static readonly string Description = $"{AbilityName}.Description";

        internal static void Configure()
        {
            Single.Configure();
            OneToThree.Configure();
            OneToFourPlusOne.Configure();

            DemonologistSummonAbilityHelper.CreateBaseAbility(
                guid: Guid,
                name: AbilityName,
                displayName: DisplayName,
                description: Description,
                icon: Icon,
                abilities: [Single.Guid, OneToThree.Guid, OneToFourPlusOne.Guid]);
        }
    }

    internal class Single
    {
        public static readonly string Guid = "{79dcb440-a254-4890-beb1-948ff4e32f26}";

        private static readonly string AbilityName = $"{BaseName}Single";
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
                summonUnitID: KalavakusSummonUnit.Guid,
                countType: DemonologistSummonAbilityHelper.SummonCountType.Single, 
                fxSize: KalavakusSummonUnit.FxSize);
        }
    }

    internal class OneToThree
    {
        public static readonly string Guid = "{a27530b6-7e29-4046-85ce-db67cd12ca15}";

        private static readonly string AbilityName = $"{BaseName}OneToThree";
        private static readonly string DisplayName = $"{AbilityName}.Name";
        private static readonly string Description = $"{AbilityName}.Description";

        internal static void Configure()
        {
            DemonologistSummonAbilityHelper.CreateSummonAbility(
                guid: Guid,
                name: AbilityName,
                displayName: DisplayName,
                description: Description,
                icon: SummonDemonVI.Icon,
                summonUnitID: VrockSummonUnit.Guid,
                countType: DemonologistSummonAbilityHelper.SummonCountType.d3, 
                fxSize: VrockSummonUnit.FxSize);
        }
    }

    internal class OneToFourPlusOne
    {
        public static readonly string Guid = "{213b1036-a89d-4da1-b192-d34ff40df93a}";

        private static readonly string AbilityName = $"{BaseName}OneToFourPlusOne";
        private static readonly string DisplayName = $"{AbilityName}.Name";
        private static readonly string Description = $"{AbilityName}.Description";

        internal static void Configure()
        {
            DemonologistSummonAbilityHelper.CreateSummonAbility(
                guid: Guid,
                name: AbilityName,
                displayName: DisplayName,
                description: Description,
                icon: SummonDemonV.Icon,
                summonUnitID: NabasuSummonUnit.Guid,
                countType: DemonologistSummonAbilityHelper.SummonCountType.d4plus1, 
                fxSize: NabasuSummonUnit.FxSize);
        }
    }
}
