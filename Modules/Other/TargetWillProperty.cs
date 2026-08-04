using BlueprintCore.Blueprints.Configurators.UnitLogic.Properties;
using Kingmaker.EntitySystem.Stats;

namespace LostChapters.Modules.Other;

internal class TargetWillProperty
{
    public static readonly string Guid = "{2c2df46a-badf-4119-bdff-ba43c7202ec4}";

    private static readonly string PropertyName = "TargetWIllPropety";

    internal static void Configure()
    {
        UnitPropertyConfigurator.New(PropertyName, Guid)
                .AddSkillValueGetter(skill: StatType.SaveWill)
                .Configure();
    }
}
