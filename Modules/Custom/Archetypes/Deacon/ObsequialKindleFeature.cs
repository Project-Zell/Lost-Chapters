using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.Components.Replacements;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using LostChapters.Components;

namespace LostChapters.Modules.Custom.Archetypes.Deacon;

internal class ObsequialKindleFeature
{
    public static readonly string Guid = "{60cdaec6-4be6-436a-962d-0e0ce27c49c2}";

    private static readonly string BaseName = "ObsequialKindle";

    private static readonly string FeatureName = $"{BaseName}Feature";
    private static readonly string DisplayName = $"{FeatureName}.Name";
    private static readonly string Description = $"{FeatureName}.Description";

    //private static readonly Sprite Icon = $"{_Module.IconPath}/ .png";

    internal static void Configure()
    {
        Buff.Configure();

        var damageTrigger = AddOutgoingDamageTriggerFixed.New(
            actions: ActionsBuilder.New().OnContextCaster(ActionsBuilder.New().ApplyBuffPermanent(buff: Buff.Guid, isNotDispelable: true)),
            applyToDamageFromThisFact: true);

        FeatureConfigurator.New(FeatureName, Guid, [FeatureGroup.Feat, FeatureGroup.CombatFeat])
            .AddComponent<PrerequisiteHasArchetype>(prerequisite =>
            {
                prerequisite.CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(CharacterClassRefs.WarpriestClass.ToString());
                prerequisite.Archetype = BlueprintTool.GetRef<BlueprintArchetypeReference>(DeaconArchetype.Guid);
            })
            .AddOutgoingDamageTriggerFixed(damageTrigger)
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .AddFeatureTagsComponent(FeatureTag.ClassSpecific)
            //.SetIcon(Icon)
            .Configure();
    }

    internal class Buff
    {
        public static readonly string Guid = "{7aa62b67-a50d-472b-9d15-7b2c72f919e4}";

        private static readonly string BuffName = $"{BaseName}Buff";
        private static readonly string Description = $"{BuffName}.Description";

        internal static void Configure()
        {
            BuffConfigurator.New(BuffName, Guid)
                .AddCombatStateTrigger(combatEndActions: 
                    ActionsBuilder.New().RestoreResource(resource: CenserBurnerFeature.Resource.Guid, value: 3).RemoveSelf())
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }
}
