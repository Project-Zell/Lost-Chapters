using BlueprintCore.Blueprints.Configurators.Items.Armors;
using BlueprintCore.Blueprints.Configurators.Items.Ecnchantments;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;

namespace LostChapters.Modules.GraySisterhood.Items.Armors
{
    internal class GrayMaidenItemSet
    {
        internal static void Configure()
        {
            GrayMaidenPlatePlus2Item.Configure();
            GrayMaidenPlatePlus3Item.Configure();
            GrayMaidenPlatePlus5Item.Configure();

            MaidensPanoplyItem.Configure();
            MaidensAegisItem.Configure();
            ErinyesCompanyCloakItem.Configure();
        }

        internal class GrayMaidenPlatePlus2Item
        {
            public static readonly string Guid = "{98cea862-5b3d-4e90-bbeb-d428c252f10e}";

            private static readonly string ItemName = "GrayMaidenPlatePlus2Item";
            private static readonly string DisplayName = "GrayMaidenPlatePlus2Item.Name";

            internal static void Configure()
            {
                ItemArmorConfigurator.New(ItemName, Guid)
                    .CopyFrom(ItemArmorRefs.PerfectStormItem)
                    .AddEquipmentRestrictionClass(CharacterClassRefs.DragonClass.ToString(), not: true)
                    .SetCost(1)
                    .SetEnchantments(enchantments: [
                        ArmorEnchantmentRefs.ArmorEnhancementBonus2.ToString()])
                    .SetDisplayNameText(DisplayName)
                    .Configure();
            }
        }

        internal class GrayMaidenPlatePlus3Item
        {
            public static readonly string Guid = "{70172e2e-99be-4662-bb34-04794942df1e}";

            private static readonly string ItemName = "GrayMaidenPlatePlus3Item";
            private static readonly string DisplayName = "GrayMaidenPlatePlus3Item.Name";

            internal static void Configure()
            {
                ItemArmorConfigurator.New(ItemName, Guid)
                    .CopyFrom(ItemArmorRefs.PerfectStormItem)
                    .AddEquipmentRestrictionClass(CharacterClassRefs.DragonClass.ToString(), not: true)
                    .SetCost(1)
                    .SetEnchantments(enchantments: [
                        ArmorEnchantmentRefs.ArmorEnhancementBonus3.ToString()])
                    .SetDisplayNameText(DisplayName)
                    .Configure();
            }
        }

        internal class GrayMaidenPlatePlus5Item
        {
            public static readonly string Guid = "{43f94635-5d96-44bf-bc70-d790cf5150ab}";

            private static readonly string ItemName = "GrayMaidenPlatePlus5Item";
            private static readonly string DisplayName = "GrayMaidenPlatePlus5Item.Name";

            internal static void Configure()
            {
                ItemArmorConfigurator.New(ItemName, Guid)
                    .CopyFrom(ItemArmorRefs.PerfectStormItem)
                    .AddEquipmentRestrictionClass(CharacterClassRefs.DragonClass.ToString(), not: true)
                    .SetCost(1)
                    .SetEnchantments(enchantments: [
                        ArmorEnchantmentRefs.ArmorEnhancementBonus5.ToString()])
                    .SetDisplayNameText(DisplayName)
                    .Configure();
            }
        }

        internal class MaidensPanoplyItem
        {
            public static readonly string Guid = "{e0ee96bf-eace-436b-b055-d9d4231fa82b}";

            private static readonly string ItemName = "MaidensPanoplyItem";
            private static readonly string DisplayName = "MaidensPanoplyItem.Name";

            //This set of +3 Gray Maiden plate creates a mental link between the wearer and her allies.
            //The wearer can telepathically communicate with allies within 30 feet (although this communication is one-way,
            //unless an ally also has telepathy). If an ally within 30 feet is aware of a threat, the wearer of this armor is aware as well,
            //and the wearer is never flat-footed unless all allies within 30 feet are also flat-footed. In addition,
            //if the wearer of a maiden’s panoply also wields a maiden’s aegis, activating that shield’s ability does not
            //reduce the maiden’s aegis’s enhancement bonus, and the bonus it grants increases to +2.

            //Gain Flat Foot immunity, if wear Aegis negate the penalty and icrease bonys by +2

            internal static void Configure()
            {
                ItemArmorConfigurator.New(ItemName, Guid)
                    .CopyFrom(ItemArmorRefs.PerfectStormItem)
                    .AddEquipmentRestrictionClass(CharacterClassRefs.DragonClass.ToString(), not: true)
                    .SetCost(1)
                    .SetEnchantments(enchantments: [
                        ArmorEnchantmentRefs.ArmorEnhancementBonus3.ToString()])
                    .SetDisplayNameText(DisplayName)
                    .Configure();
            }

            internal class Enchantment
            {
                public static readonly string Guid = "";

                private static readonly string EnchantmentName = "HeralOfWinterItem.EnchantmentName";



                internal static void Configure()
                {
                    Buff.Configure();

                    WeaponEnchantmentConfigurator.New(EnchantmentName, Guid)
                        .AddUnitFactEquipment(blueprint: Buff.Guid)
                        .Configure();
                }
            }
            
            internal class Buff
            {
                public static readonly string Guid = "";

                private static readonly string BuffName    = "MaidensPanoplyItem.Buff";
                private static readonly string DisplayName = "MaidensPanoplyItem.Buff.Name";
                private static readonly string Description = "MaidensPanoplyItem.Buff.Description";

                internal static void Configure()
                {
                    BuffConfigurator.New(Guid, BuffName)
                        .AddFlatFootedIgnore(type: Kingmaker.Designers.Mechanics.Facts.FlatFootedIgnoreType.UncannyDodge)
                        .SetDisplayName(DisplayName)
                        .SetDescription(Description)
                        //.SetIcon(Icon)
                        .Configure();
                }
            }

        }

        internal class MaidensAegisItem
        {
            public static readonly string Guid = "{3bfbe175-3df8-4091-b4d9-cb2bfa0d046a}";

            private static readonly string ItemName = "MaidensAegisItem";
            private static readonly string DisplayName = "MaidensAegisItem.Name";

            //These +2 heavy steel shields were often issued to Gray Maiden unit leaders, and many still carry them today.
            //Once per day as a swift action, the wielder of a maiden’s aegis can reduce the enhancement
            //bonus of the shield to +1 to grant a +1 enhancement bonus to up to four other shields within a 30-foot radius.
            //This effect persists for 10 minutes, but it ends for any individual shield that moves more than 30 feet from the
            //maiden’s aegis that granted the bonus.

            //Take -2 to give all other shields in 30m radius +2

            internal static void Configure()
            { 
            
            }
        }

        internal class ErinyesCompanyCloakItem
        {
            //This crimson cloak is trimmed with feathers taken from erinyes devils.
            //Three times per day on command, the cloak transforms into a pair of black-feathered wings that grant the wearer a fly speed
            //of 30 feet (average maneuverability) for 10 minutes. If the wearer is wearing Gray Maiden plate,
            //its armor check penalty does not apply to the wearer’s Fly checks. In addition,
            //the wearer gains a +2 resistance bonus on all saving throws.

            //+2 cap, can activate three times per day to gain wings gor 10 min, if wearing Maiden Armor - 

            internal static void Configure()
            {

            }
        }

        internal class GrayMaidenPlateBuff
        {
            public static readonly string Guid = "{d6e32a98-4d5a-43db-93e1-d2ed6645d81b}";

            private static readonly string BuffName = "GrayMaidenPlateBuff";
            private static readonly string DisplayName = "GrayMaidenPlateBuff.Name";

            public void Configure()
            {
                BuffConfigurator.New(BuffName, Guid)
                    .Configure();
            }
            //If have Gray Maiden Initiate do something
        }
    }
}
