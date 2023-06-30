using System;
using HarmonyLib;
using UnityEngine;
using Labloader.Core.Events.EventArgs;

namespace Labloader.Core.Events.Patches.Player
{
    [HarmonyPatch(typeof(Health), nameof(Health.Kill), new Type[] { typeof(string), typeof(IKiller), typeof(Vector3) })]
    internal class Dying
    {
        internal static bool Prefix(Health __instance, ref string message, IKiller killer, Vector3 direction)
        {
            var ev = new PlayerDyingEventArgs(API.Features.Player.Get(killer?.gameObject),
                API.Features.Player.Get(__instance.gameObject), message);
            Events.OnPlayerDying(ev);

            return ev.IsAllowed;
        }
    }
}