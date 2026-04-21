using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using Kingmaker.Blueprints.Classes.Spells;

namespace LostChapters.Modules.Custom.Archetypes.Demonologist;

internal class SummonDemonIAbility
{
    public static readonly string Guid = "{b1762048-bc0c-4e71-aa01-39d00c4726bb}";

    private static readonly string AbilityName = "SummonDemonIAbility";
    private static readonly string DisplayName = $"{AbilityName}.Name";
    private static readonly string Description = $"{AbilityName}.Description";

    //private static readonly Sprite Icon = $"{_Module.IconPath}/ .png";

    internal static void Configure()
    {
        AbilityConfigurator.New(AbilityName, Guid)
            .AddSpellComponent(SpellSchool.Conjuration)
            .AddSpellDescriptorComponent(SpellDescriptor.Summoning)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            //.AddFeatureTagsComponent()
            //.SetIcon(Icon)
            .Configure();
    }

    internal class SummonDemonIMajor
    {
        public static readonly string Guid = "{b1762048-bc0c-4e71-aa01-39d00c4726bb}";

        private static readonly string AbilityName = $"{SummonDemonIAbility.AbilityName}.Major";
        private static readonly string DisplayName = $"{AbilityName}.Name";
        private static readonly string Description = $"{AbilityName}.Description";

        internal static void Configure()
        {
            AbilityConfigurator.New(AbilityName, Guid)
                .AddSpellComponent(SpellSchool.Conjuration)
                .AddSpellDescriptorComponent(SpellDescriptor.Summoning)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                //.AddFeatureTagsComponent()
                //.SetIcon(Icon)
                .Configure();
        }
    }
}