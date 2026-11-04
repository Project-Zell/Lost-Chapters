using BlueprintCore.Blueprints.Configurators.UnitLogic.Properties;

namespace LostChapters.Modules.Other;

internal class NullProperty
{
    public static readonly string Guid = "{36ed99ab-3f2a-44f4-a93c-1d3f1e81542c}";

    private static readonly string PropertyName = "NullProperty";

    internal static void Configure()
    {
        UnitPropertyConfigurator.New(PropertyName, Guid)
            .Configure();
    }
}