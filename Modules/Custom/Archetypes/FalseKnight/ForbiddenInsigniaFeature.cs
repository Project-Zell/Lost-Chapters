using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.Buffs.Blueprints;

namespace LostChapters.Modules.Custom.Archetypes.FalseKnight;

internal class ForbiddenInsigniaFeature
{
    public static readonly string Guid = "{5355c8b7-56d7-461c-be2c-f7e0a62632e6}";

    private static readonly string BaseName = "ForbiddenInsignia";

    private static readonly string FeatureName = $"{BaseName}Feature";
    private static readonly string DisplayName = $"{FeatureName}.Name";
    private static readonly string Description = $"{FeatureName}.Description";

    //private static readonly string Icon = $"{CustomModule.IconPath}/{FalseKnightArchetype.BaseName}/{BaseName}.png".ToLower();

    internal static void Configure()
    {
        Buff.Configure();

        FeatureConfigurator.New(FeatureName, Guid)
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            //.SetIcon(Icon)
            .Configure();
    }

    internal class Buff
    {
        public static readonly string Guid = "{a9a884c0-c344-4ee9-87b5-08d4b37a8032}";

        private static readonly string BuffName = $"{FeatureName}Buff";

        internal static void Configure()
        {
            BuffConfigurator.New(BuffName, Guid)
                .AddWeaponParametersAttackBonus(attackBonus: -2, descriptor: ModifierDescriptor.Morale)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetFlags(BlueprintBuff.Flags.HiddenInUi)
                //.SetIcon(Icon)
                .Configure();
        }
    }
}