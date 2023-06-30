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

            // SHOULD BE IL_0028
            // ldelem.ref
            int index = newInstructions.FindIndex(instruction =>
            instruction.opcode == OpCodes.Ldelem_Ref);
            // IL_0030
            // ldloc.2
            int offset = 4;

            LocalBuilder ev = generator.DeclareLocal(typeof(Scp914UpgradingItemEventArgs));
            Label returnLabel = generator.DefineLabel();

            newInstructions.InsertRange(index + offset, new CodeInstruction[]
            {
                // grindable
                new(OpCodes.Ldloc_2),

                // currentLevel
                new(OpCodes.Ldarg_0),
                new(OpCodes.Ldfld, Field(typeof(SCP914), nameof(SCP914.currentLevel))),
                
                // Scp914UpgradingItemEventArgs ev = new(grindable, this.currentLevel)
                new(OpCodes.Newobj, GetDeclaredConstructors(typeof(Scp914UpgradingItemEventArgs))[0]),

                new(OpCodes.Dup),
                new(OpCodes.Dup),
                new(OpCodes.Stloc_S, ev.LocalIndex),

                // Events.OnScp914UpgradingItem(ev)
                new(OpCodes.Call, Method(typeof(Events), nameof(Events.OnScp914UpgradingItem))),

                // if (!ev.IsAllowed)
                //    continue;
                new(OpCodes.Callvirt, PropertyGetter(typeof(Scp914UpgradingItemEventArgs), nameof(Scp914UpgradingItemEventArgs.IsAllowed))),
                new(OpCodes.Brfalse_S, returnLabel),

                new(OpCodes.Ldloc_2),
            });
            // SHOULD BE IL_00C3
            // IL_00C3: blt       IL_0026
            int loopEndIndex = newInstructions.FindLastIndex(instruction =>
            instruction.opcode == OpCodes.Blt);
            // IL_00BB: ldloc.1
            int loopEndIndexOffset = -8;

            loopEndIndex += loopEndIndexOffset;

            newInstructions[loopEndIndex].labels.Add(returnLabel);

            for (int z = 0; z < newInstructions.Count; z++)
                yield return newInstructions[z];
        }
    }
}