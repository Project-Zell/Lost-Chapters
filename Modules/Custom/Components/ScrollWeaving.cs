using BlueprintCore.Blueprints.References;
using Kingmaker.Blueprints.Items.Equipment;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Parts;

namespace LostChapters.Modules.Custom.Components
{
    internal class ScrollWeaving : UnitFactComponentDelegate
    {
        public override void OnTurnOn()
        {
            var bonus = Owner.Progression.GetClassLevel(CharacterClassRefs.CavalierClass.Reference) / 2;
            Owner.Ensure<UnitPartItemCasterLevelBonus>().AddEntry(bonus, UsableItemType.Scroll, Fact);
        }

        public override void OnTurnOff()
        {
            Owner.Get<UnitPartItemCasterLevelBonus>()?.RemoveEntry(Fact);
        }
    }
}
