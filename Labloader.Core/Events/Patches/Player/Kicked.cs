using HarmonyLib;
using Labloader.Core.Events.EventArgs;
using Labloader.Core.API.Enums;
using Labloader.Core.API.Features;

namespace Labloader.Core.Events.Patches.Player
{
    [HarmonyPatch(typeof(NetworkManager), nameof(NetworkManager.Kick), typeof(ushort))]
    internal class Kicked
    {
        internal static bool Prefix(NetworkManager __instance, ushort clientId)
        {
            var ev = new PlayerKickedEventArgs(API.Features.Player.Get(clientId), null);
            Events.OnPlayerKicked(ev);

            return ev.IsAllowed;
        }
    }
    [HarmonyPatch(typeof(NetworkManager), nameof(NetworkManager.Kick), typeof(ushort), typeof(string))]
    internal class KickedReason
    {
        internal static bool Prefix(NetworkManager __instance, ushort clientId, string reason)
        {
            var ev = new PlayerKickedEventArgs(API.Features.Player.Get(clientId), reason);
            Events.OnPlayerKicked(ev);

            return ev.IsAllowed;
        }
    }
}
