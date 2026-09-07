using BlueprintCore.Blueprints.Configurators.UnitLogic.Properties;
using Kingmaker.UnitLogic.Mechanics.Properties;

namespace LostChapters.Modules.Other;

internal class TargetLevelProperty
{
    public static readonly string Guid = "{89a64cf7-dc48-486c-bb55-be39a798bbb4}";

    private static readonly string PropertyName = "TargetLevelProperty";

    internal static void Configure()
    {
        UnitPropertyConfigurator.New(PropertyName, Guid)
            .AddSimplePropertyGetter(UnitProperty.Level)
            .Configure();
    }
}
