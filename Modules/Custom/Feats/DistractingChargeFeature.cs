using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using Kingmaker.Blueprints.Classes;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using LostChapters.Modules.GraySisterhood.Components;
using LostChapters.Tools;
using Kingmaker.Blueprints.Classes.Selection;
using LostChapters.Modules.Custom.Components;
using LostChapters.Modules.GraySisterhood;

namespace LostChapters.Modules.Custom.Feats;

internal class DistractingChargeFeature
{
    public static readonly string Guid = "{a351b475-a964-4fdc-ad11-0b676288330e}";

    public static readonly string CavalierBuffGuid = "{2d1e0ddf-7eea-403b-b161-46a92e70b8fe}";
    public static readonly string VanguardBuffGuid = "{68e7c557-c44e-495d-8f5e-61ff87e3bd01}";
    public static readonly string VanguardAbilityGuid = "{d27afe71-10a6-48a6-b539-093651dbc589}";
    public static readonly string PackRagerBuffGuid = "{20808a0a-137b-4ffb-b2ec-ab239e29c5a5}";
    public static readonly string PackRagerAreaGuid = "{4ecc8e35-5da6-4e84-851f-70983cd79e59}";
    public static readonly string PackRagerAreaBuffGuid = "{ff482b3c-b831-4655-b54d-68a0a7670eb9}";
    public static readonly string PackRagerToggleBuffGuid = "{9d0db827-50c8-4834-8137-0032b10710dc}";
    public static readonly string PackRagerToggleGuid = "{e41f771c-20f0-4756-9762-84706eb49f0c}";
    public static readonly string ForesterAbilityGuid = "{3f5b9905-e7c0-4df5-b028-65da66861f64}";

    private static readonly string FeatureName = "DistractingCharge";
    private static readonly string DisplayName = "DistractingCharge.Name";
    private static readonly string Description = "DistractingCharge.Description";

    private static readonly string Icon = $"{GraySisterhoodModule.IconPath}/distractingcharge.png";

    internal static void Configure()
    {
        Buff.Configure();
        var applyBuffPermanent = ActionsBuilder.New().Conditional(ConditionsBuilder.New().HasBuffFromCaster(buff: Buff.Guid),
            ifFalse: ActionsBuilder.New().ApplyBuffPermanent(buff: Buff.Guid, isFromSpell: false, isNotDispelable: true, asChild: true));

        var feature = FeatureConfigurator.New(FeatureName, Guid, FeatureGroup.Feat, FeatureGroup.CombatFeat, FeatureGroup.TeamworkFeat)
            .AddPrerequisiteStatValue(stat: StatType.Intelligence, value: 3)
            .AddInitiatorAttackWithWeaponTrigger(onlyOnFirstHit: true, onCharge: true, onlyHit: true, action: applyBuffPermanent)
            .AddAsTeamworkFeat(
                cavalierBuffGuid: CavalierBuffGuid,
                vanguardBuffGuid: VanguardBuffGuid,
                vanguardAbilityGuid: VanguardAbilityGuid,
                packRagerBuffGuid: PackRagerBuffGuid,
                packRagerAreaGuid: PackRagerAreaGuid,
                packRagerAreaBuffGuid: PackRagerAreaBuffGuid,
                packRagerToggleBuffGuid: PackRagerToggleBuffGuid,
                packRagerToggleGuid: PackRagerToggleGuid)
            .AddToFeatureSelection(FeatureSelectionRefs.DevilbanePriestTeamworkFeatSelection.ToString())
            .AddFacts([CavalierBuffGuid])
            .AddFeatureTagsComponent(FeatureTag.Teamwork | FeatureTag.Melee | FeatureTag.Attack)
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            //.SetIcon(Icon)
            .Configure();

        feature.AddAsDLCTeamworkFeat(foresterAbilityGuid: ForesterAbilityGuid, vanguardBuffGuid: VanguardBuffGuid);
    }

    internal class Buff
    {
        public static readonly string Guid = "{3d74051e-753e-403e-b197-7b99ab747f44}";

        private static readonly string BuffName = "DistractingChargeBuff";

        internal static void Configure()
        {
            BuffConfigurator.New(BuffName, Guid)
                .AddComponent<RemoveSelfOnCasterNewTurn>()
                .AddComponent<DistractingCharge>()
                .AddToFlags(BlueprintBuff.Flags.HiddenInUi)
                .SetStacking(StackingType.Stack)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }
}
