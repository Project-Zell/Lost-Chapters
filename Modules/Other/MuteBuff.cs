using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;

namespace LostChapters.Modules.Other;

internal class MuteBuff
{
    public static readonly string Guid = "{82022c24-94b6-4959-9216-bd8ca83c18cb}";

    private static readonly string BuffName = "MuteBuff";
    private static readonly string DisplayName = $"{BuffName}.Name";
    private static readonly string Description = $"{BuffName}.Description";

    //private static readonly Sprite Icon = $"{_Module.IconPath}/ .png";

    internal static void Configure()
    {
        BuffConfigurator.New(BuffName, Guid)
            .AddForbidSpellCasting()
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            //.SetIcon(Icon)
            .Configure();
    }
}
