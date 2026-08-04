using LostChapters.Modules.Custom.Archetypes.Demonologist.SummonUnits;
using LostChapters.Modules.Custom.Archetypes.Demonologist.Tools;

namespace LostChapters.Modules.Custom.Archetypes.Demonologist.SummonAbilities;

internal class SummonDemonIV
{
    public static readonly string Guid = "{c5a722e8-70be-43cf-a2aa-ef412b6ff6ff}";

    private static readonly string BaseName = "SummonDemonIV";

    private static readonly string Icon = $"{CustomModule.IconPath}/summondemon4.png";

    internal static void Configure()
    {
        BabauSummonUnit.Configure();
        BaseAbility.Configure();
    }

    internal class BaseAbility
    {
        public static readonly string Guid = "{688378a2-5a9a-43c5-9410-44222b2cedef}";

        private static readonly string AbilityName = $"{BaseName}.Base";
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
        public static readonly string Guid = "{d157b9a1-0967-4cf0-ad36-b13c19992d47}";

        private static readonly string AbilityName = $"{BaseName}.Single";
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
                summonUnitID: BabauSummonUnit.Guid,
                countType: DemonologistSummonAbilityHelper.SummonCountType.Single);
        }
    }

    internal class OneToThree
    {
        public static readonly string Guid = "{61307930-587c-42ff-8402-b6fc9b6a5c29}";

        private static readonly string AbilityName = $"{BaseName}OneToThree";
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
                summonUnitID: SchirSummonUnit.Guid,
                countType: DemonologistSummonAbilityHelper.SummonCountType.d3);
        }
    }

    internal class OneToFourPlusOne
    {
        public static readonly string Guid = "{3cb6c5e8-2443-4d20-80be-cc35c33ba8c1}";

        private static readonly string AbilityName = $"{BaseName}OneToFourPlusOne";
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
                summonUnitID: DretchSummonUnit.Guid,
                countType: DemonologistSummonAbilityHelper.SummonCountType.d4plus1);
        }
    }
}
