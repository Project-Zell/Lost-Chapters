using BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using Kingmaker.Blueprints.Classes;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.ActivatableAbilities;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.Utility;
using LostChapters.Modules.GraySisterhood.Components;

namespace LostChapters.Modules.GraySisterhood.Archetypes.ClassFeatures
{
    internal class CapellanIncenseClassFeature
    {
        public static BlueprintAbilityAreaEffect AreaRef;

        private static readonly string FeatName = "DeaconIncense";
        public static readonly string FeatGuid = "e4c4ed54-6aff-4819-902f-29223b430389";
        private static readonly string DisplayName = "Censer.BuffName";
        private static readonly string Description = "Censer.LocalizedDescription";

        private static readonly string Ability = "Fog";
        private static readonly string AbilityGuid = "f2049812-41d2-4cb5-aeb9-c392ca6abf33";
        private static readonly string AbilityDisplayName = "Fog.BuffName";
        private static readonly string AbilityDescription = "Fog.LocalizedDescription";

        private static readonly string AbilityResource = "FogBrain";
        private static readonly string AbilityResourceGuid = "90fba939-158b-47da-90c4-1026418a0f2d";

        private static readonly string Buff = "FogBuff";
        private static readonly string BuffGuid = "82c660b2-57a6-4b92-aa9e-48e5a571f879";
        private static readonly string BuffDisplayName = "DeaconIncense.EffectBuff.BuffName";
        private static readonly string BuffDescription = "DeaconIncense.EffectBuff.LocalizedDescription";

        private static readonly string BuffArea = "FogBuffArea";
        private static readonly string BuffAreaGuid = "c3f19238-3697-4d49-895d-9d9e7c15e418";
        private static readonly string AbilityBuff = "Fog.Fofog";
        private static readonly string AbilityBuffGuid = "2c3d56e4-76ca-4021-b49b-5d33ecee6fc6";

        private static readonly string AreaEffect = "FogAreaBabla";
        private static readonly string AreaEffectGuid = "7890c488-cde4-4207-8778-b91d854cfc7b";

        public static BlueprintFeature CreateCapellanIncense()
        {
            var effectBuff = BuffConfigurator.New(Buff, BuffGuid)
                .SetDisplayName(BuffDisplayName)
                .SetDescription(BuffDescription)
                .SetIcon(AbilityRefs.HauntingMists.Reference.Get().Icon)
                .Configure();

            //ContextActionRemoveBuff StandartRage/Rage Spell

            var abilityAreaEffect = AbilityAreaEffectConfigurator.New(AreaEffect, AreaEffectGuid)
                .AddAbilityAreaEffectBuff(effectBuff)
                .SetShape(AreaEffectShape.Cylinder)
                .SetSize(30.Feet())
                .AddContextSetAbilityParams(dC: 0)
                .Configure();

            AreaRef = abilityAreaEffect;

            var abilityBuff = BuffConfigurator.New(AbilityBuff, AbilityBuffGuid)
                .AddAreaEffect(areaEffect: abilityAreaEffect)
                .SetFxOnStart("54b14a687d7af52418f23485ca51d690")
                .SetFlags(BlueprintBuff.Flags.HiddenInUi, BlueprintBuff.Flags.StayOnDeath)
                .SetIsClassFeature(true)
                .Configure();

            var activatableAbility = ActivatableAbilityConfigurator.New(Ability, AbilityGuid)
                .SetBuff(abilityBuff)
                .AddComponent<DeaconIncenseDC>()
                .SetActivationType(AbilityActivationType.WithUnitCommand)
                .SetDisplayName(AbilityDisplayName)
                .SetDescription(AbilityDescription)
                .Configure();

            return FeatureConfigurator.New(FeatName, FeatGuid)
                .AddFacts([activatableAbility])
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }
}
