using HarmonyLib;
using Labloader.Core.Events.EventArgs;
using RiptideNetworking;
using System.Linq;
using UnityEngine;

namespace Labloader.Core.Events.Patches.Scp914
{
    // virtual is lazy
    [HarmonyPatch(typeof(SCP914), nameof(SCP914.switchOutItems))]
    internal class UpgradingItem
    {
        internal static bool Prefix(SCP914 __instance)
        {
            if (__instance.netObj.IsClient)
            {
                return false;
            }
            foreach (Grindable grindable in __instance.toGrind.Distinct<Grindable>().ToArray<Grindable>())
            {
                if (grindable != null)
                {
                    Debug.Log(grindable);
                    Vector3 position = __instance.input.InverseTransformPoint(grindable.transform.position);
                    position = __instance.output.TransformPoint(position);
                    try
                    {
                        var ev = new Scp914UpgradingItemEventArgs();
                        //Events.OnPlayerKicked(ev);
                        GameObject grindedVersion = grindable.getGrindedVersion(__instance.currentLevel);
                        if (grindedVersion != null)
                        {
                            UnityEngine.Object.Instantiate<GameObject>(grindedVersion, position, grindable.transform.rotation, grindable.transform.parent);
                            UnityEngine.Object.Destroy(grindable.gameObject);
                        }
                        else
                        {
                            grindable.transform.position = position;
                        }
                    }
                    catch
                    {
                        grindable.transform.position = position;
                    }
                }
            }
            __instance.toGrind.Clear();

            return false;
        }
    }
}