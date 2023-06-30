using System;
using HarmonyLib;
using Labloader.Core.Events.EventArgs;
using UnityEngine;

namespace Labloader.Core.Events.Patches.Player
{
    [HarmonyPatch(typeof(Health), nameof(Health.Damage), new Type[] { typeof(float), 
        typeof(string), typeof(IKiller), typeof(float), typeof(float), typeof(Vector3) })]
    internal class Damaging
    {
        // float amount, string message = null, IKiller killer = null, float bloodLossAmount = 0f,
        // float bloodLossRate = 2.5f, Vector3 direction = default(Vector3)
        internal static bool Prefix(Health __instance, ref float amount, ref string message, IKiller killer,
            ref float bloodLossAmount, ref float bloodLossRate, Vector3 direction)
        {
            var ev = new PlayerDamagingEventArgs(API.Features.Player.Get(killer?.gameObject),
                API.Features.Player.Get(__instance.gameObject), amount, message, 
                bloodLossAmount, bloodLossRate, direction);
            Events.OnPlayerDamaging(ev);

            amount = ev.Damage;
            message = ev.Message;
            bloodLossAmount = ev.BloodLossAmount;
            bloodLossRate = ev.BloodLossRate;

            return ev.IsAllowed;
        }
    }
}