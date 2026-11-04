using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using LostChapters.Components;

namespace LostChapters.Modules.Custom.Archetypes.Deacon;

internal class FogOfWarFeature
{
    public static readonly string Guid = "{4affa256-fe69-4601-98d9-b44a7f84ed65}";

    private static readonly string BaseName = "FogOfWar";

    private static readonly string FeatureName = $"{BaseName}Feature";
    private static readonly string DisplayName = $"{FeatureName}.Name";
    private static readonly string Description = $"{FeatureName}.Description";

    internal static void Configure()
    {
        Buff.Configure();

        FeatureConfigurator.New(FeatureName, Guid)
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .Configure();

        var condition = ConditionsBuilder.New().IsAlly().CasterHasFact(Guid);

        AbilityAreaEffectConfigurator.For(CenserBurnerFeature.AbilityArea.Guid)
            .AddAbilityAreaEffectBuff(buff: Buff.Guid, condition: condition)
            .Configure();
    }

    internal class Buff
    {
        public static readonly string Guid = "{93993916-5b4f-4a44-acdb-fef386086173}";

        private static readonly string BuffName = $"{BaseName}Buff";

        internal static void Configure()
        {
            BuffConfigurator.New(BuffName, Guid)
                .AddComponent<AddBonusToBaseAttackUpToCharacterLevel>()
                .AddWeaponSizeChange(sizeCategoryChange: 1)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }
}