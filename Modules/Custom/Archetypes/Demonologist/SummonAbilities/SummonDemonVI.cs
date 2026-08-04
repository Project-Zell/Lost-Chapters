using LostChapters.Modules.Custom.Archetypes.Demonologist.SummonUnits;
using LostChapters.Modules.Custom.Archetypes.Demonologist.Tools;

namespace LostChapters.Modules.Custom.Archetypes.Demonologist.SummonAbilities;

internal class SummonDemonVI
{
    public static readonly string Guid = "{606847f0-1717-4428-a290-4d8b18d69144}";

    private static readonly string BaseName = "SummonDemonVI";

    private static readonly string Icon = $"{CustomModule.IconPath}/summondemon6.png";

    internal static void Configure()
    {
        VrockSummonUnit.Configure();
        BaseAbility.Configure();
    }

    internal class BaseAbility
    {
        public static readonly string Guid = "{4b78a5b9-8d19-482e-9090-aa9c19ad620e}";

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
        public static readonly string Guid = "{5d39124b-63ca-4530-a483-47d5af0f8d36}";

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
                summonUnitID: VrockSummonUnit.Guid,
                countType: DemonologistSummonAbilityHelper.SummonCountType.Single);
        }
    }

    internal class OneToThree
    {
        public static readonly string Guid = "{604fc9fa-207d-4084-aa97-24a2b22fcde1}";

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
                summonUnitID: NabasuSummonUnit.Guid,
                countType: DemonologistSummonAbilityHelper.SummonCountType.d3);
        }
    }

    internal class OneToFourPlusOne
    {
        public static readonly string Guid = "{9e92f36f-2a62-42a2-bcec-1e4de3905676}";

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
                summonUnitID: BabauSummonUnit.Guid,
                countType: DemonologistSummonAbilityHelper.SummonCountType.d4plus1);
        }
    }
}
