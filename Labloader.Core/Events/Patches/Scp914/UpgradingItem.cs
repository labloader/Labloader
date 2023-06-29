using HarmonyLib;
using System.Collections.Generic;
using Labloader.Core.Events.EventArgs;
using RiptideNetworking;
using System.Linq;
using UnityEngine;
using System.Reflection;
using System.Reflection.Emit;
using UnityEngine.Pool;
using static HarmonyLib.AccessTools;

namespace Labloader.Core.Events.Patches.Scp914
{
    // virtual is lazy
    [HarmonyPatch(typeof(SCP914), nameof(SCP914.switchOutItems))]
    internal class UpgradingItem
    {
        private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions, ILGenerator generator)
        {
            List<CodeInstruction> newInstructions = instructions.ToList();

            // IL_0031
            // void [UnityEngine.CoreModule]UnityEngine.Debug::Log(object)
            int index = newInstructions.FindIndex(instruction =>
            instruction.opcode == OpCodes.Call && (MethodInfo)instruction.operand ==
            Method(typeof(Debug), nameof(Debug.Log)));
            // IL_0030
            // ldloc.2
            int offset = -1;

            newInstructions.InsertRange(index+offset)
        }
    }
}