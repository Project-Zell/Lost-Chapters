using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using BlueprintCore.Utils.Types;
using Kingmaker.Enums.Damage;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using LostChapters.Modules.GraySisterhood.Archetypes.ClassFeatures;
using LostChapters.Modules.GraySisterhood.Feats.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostChapters.Modules.GraySisterhood.Feats.DeaconIncense
{
    internal class CapellanFireMajorIncense
    {
        public static readonly string Guid = "9193d24b-7b31-4d35-985e-1fa95990db97";

        private const string IncenseName = "FireMajorIncense";
        private const string DisplayName = "FireMajorIncense.BuffName";
        private const string Description = "FireMajorIncense.LocalizedDescription";

        public static void Configure()
        {
            AbilityAreaEffectConfigurator.For(CapellanIncenseClassFeature.AreaRef)
                .AddAbilityAreaEffectBuff(
                    buff: CapellanFireMajorIncenseBuff.GetReference(),
                    condition: ConditionsBuilder.New().IsAlly().CasterHasFact(Guid))
                .Configure();

            FeatureConfigurator.New(IncenseName, Guid)
                .AddToFeatureSelection(CapellanIncenseSelector.Guid)
                .SetIcon(AbilityRefs.HauntingMists.Reference.Get().Icon)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }

    internal class CapellanFireMajorIncenseBuff
    {
        public static readonly string Guid = "dcf08815-ea16-48ce-9474-7abede1d0b08";

        private const string BuffName = "FireMajorIncense.BuffName";
        private const string DisplayName = "FireMajorIncense.BuffName.BuffName";
        private const string Description = "FireMajorIncense.BuffName.LocalizedDescription";

#nullable enable
        private static BlueprintBuff? Reference;
#nullable disable

        public static BlueprintBuff GetReference() => Reference ??= CreateBuff();

        private static BlueprintBuff CreateBuff()
        {
            return BuffConfigurator.New(BuffName, Guid)
                .AddDamageResistanceEnergy(
                    type: DamageEnergyType.Fire,
                    value: ContextValues.Rank())
                .AddContextRankConfig(ContextRankConfigs.ClassLevel([CharacterClassRefs.WarpriestClass.ToString()]).WithBonusValueProgression(10))
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.HauntingMists.Reference.Get().Icon)
                .Configure();
        }
    }
}
