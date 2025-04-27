using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using LostChapters.Modules.Custom.Components;
using LostChapters.Modules.GraySisterhood;

namespace LostChapters.Modules.Custom.Archetypes.HoodedWanderer;

internal class UnseenPathFeature
{
    public static readonly string Guid = "{07bc21a6-214a-488f-ab46-38c2810dc086}";

    private static readonly string FeatureName = "UnseenPath";
    private static readonly string DisplayName = "UnseenPath.Name";
    private static readonly string Description = "UnseenPath.Description";

    private static readonly string Icon = $"{GraySisterhoodModule.IconPath}/unseenpath.png";

    internal static void Configure()
    {
        Buff.Configure();

        FeatureConfigurator.New(FeatureName, Guid)
            .AddComponent<UnseenPath>()
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .SetIcon(Icon)
            .Configure();
    }

    internal class Buff
    {
        public static readonly string Guid = "{eb0a9605-a1bb-4f3b-8834-442c1622d03c}";

        private static readonly string BuffName = "UnseenPath.Buff";

        internal static void Configure()
        {
            BuffConfigurator.New(BuffName, Guid)
                .AddConcealment(
                    descriptor: ConcealmentDescriptor.Blur,
                    concealment: Concealment.Partial,
                    rangeType: WeaponRangeType.Melee)
                .AddCombatStateTrigger(combatEndActions: ActionsBuilder.New().RemoveSelf())
                .SetFlags(BlueprintBuff.Flags.HiddenInUi | BlueprintBuff.Flags.StayOnDeath | BlueprintBuff.Flags.RemoveOnRest)
                .Configure();
        }
    }
}
