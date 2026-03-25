using HarmonyLib;
using Kingmaker.ElementsSystem;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Actions;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace LostChapters.Patches
{
    [HarmonyPatch(typeof(Demoralize), nameof(Demoralize.RunAction))]
    internal class FearsomenessPatch
    {
        static readonly MethodInfo ContextActionGetMeleeRange = AccessTools.Method(typeof(FearsomenessPatch), nameof(GetMeleeRange));

        static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            foreach (var instruction in instructions)
            {
                if (instruction.opcode == OpCodes.Ldc_R4)
                {
                    yield return new CodeInstruction(OpCodes.Ldarg_0);
                    yield return new CodeInstruction(OpCodes.Call, ContextActionGetMeleeRange);
                }
                else yield return instruction;
            }
        }

        static float GetMeleeRange(Demoralize demoralizeAction)
        {
            MechanicsContext mechanicsContext = ContextData<MechanicsContext.Data>.Current?.Context;
            UnitEntityData unitEntityData = mechanicsContext?.MaybeCaster;
            return unitEntityData.GetThreatHandMelee().Weapon.AttackRange.Meters + unitEntityData.View.Corpulence + demoralizeAction.Target.Unit.Corpulence;
        }
    }
}
