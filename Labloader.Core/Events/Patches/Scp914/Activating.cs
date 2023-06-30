using System;
using HarmonyLib;
using Labloader.Core.Events.EventArgs;
using RiptideNetworking;

namespace Labloader.Core.Events.Patches.Scp914
{
    [HarmonyPatch(typeof(SCP914), nameof(SCP914.Activate), new Type[] {typeof(ushort)})]
    internal class Activating
    {
        internal static bool Prefix(SCP914 __instance, ushort clientId)
        {
            var ev = new Scp914ActivatingEventArgs(API.Features.Player.Get(clientId), __instance.currentLevel);
            Events.OnScp914Activating(ev);

            return ev.IsAllowed;
        }
    }
}