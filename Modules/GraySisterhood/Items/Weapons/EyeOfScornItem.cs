using BlueprintCore.Blueprints.Configurators.Items.Ecnchantments;
using BlueprintCore.Blueprints.Configurators.Items.Weapons;
using BlueprintCore.Blueprints.References;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.Enums;
using Kingmaker.ResourceLinks;
using LostChapters.Enchantment;
using UnityEngine;

namespace LostChapters.Modules.GraySisterhood.Items.Weapons;

internal class EyeOfScornItem
{
    public static readonly string Guid = "{eb96c83f-805e-413e-9129-d9975bf84807}";

    private static readonly string ItemName = "EyeOfScornItem";
    private static readonly string DisplayName = "EyeOfScornItem.Name";
    private static readonly string Description = "EyeOfScornItem.Description";

    //icon and model and cost
    private static readonly Sprite Icon = ItemWeaponRefs.DLC5_SwordOfSithhudItem.Reference.Get().Icon;

    internal static void Configure()
    {
        Enchantment.Configure();

        var visualParameters = new WeaponVisualParameters()
        {
            //m_WeaponModel = new PrefabLink() { AssetId = "31ea6435ed756324c97669c6ab3bfa9d" },
            m_WeaponModel = new PrefabLink() { AssetId = "e682d7034e7c67e4ebe693471b85352b" },
            //m_WeaponSheathModelOverride = new PrefabLink { AssetId = "31e55aa857a8952438516de82787c362" }
        };

        ItemWeaponConfigurator.New(ItemName, Guid)
            .SetCost(cost: 8500)
            .SetCR(cR: 6)
            .SetVisualParameters(visualParameters)
            .SetType(WeaponTypeRefs.Longsword.ToString())
            .SetSize(Size.Medium)
            .SetEnchantments(enchantments: [
                BenevolentWeaponEnchantment.Reference,
                WeaponEnchantmentRefs.Heartseeker.ToString(),
                WeaponEnchantmentRefs.BleedConst1d4.ToString(),
                WeaponEnchantmentRefs.Enhancement5.ToString(),
                Enchantment.Guid])
            .SetDisplayNameText(DisplayName)
            .SetIcon(Icon)
            .Configure();
    }

    internal class Enchantment
    {
        public static readonly string Guid = "{148e3f96-53ee-4f1a-96bd-863eb815eedd}";

        private static readonly string EnchantmentName = "EyeOfScornEnchantment";

        internal static void Configure()
        {
            WeaponEnchantmentConfigurator.New(EnchantmentName, Guid)
                .AddUnitFeatureEquipment(BuffRefs.EcholocationBuff.ToString())
                .Configure();
        }
    }
}
