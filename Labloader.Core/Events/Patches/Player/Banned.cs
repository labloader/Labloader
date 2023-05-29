using HarmonyLib;
using Labloader.Core.Events.EventArgs;
using Labloader.Core.API.Enums;
using System.Net;
using RiptideNetworking.Transports;
using RiptideNetworking.Transports.RudpTransport;
using System.Linq;

namespace Labloader.Core.Events.Patches.Player
{
    [HarmonyPatch(typeof(NetworkManager), nameof(NetworkManager.BanIP))]
    internal class BannedIP
    {
        internal static bool Prefix(NetworkManager __instance, IPAddress address, string reason)
        {
            var ev = new PlayerBannedEventArgs(BanType.IP, address, null, reason);
            Events.OnPlayerBanned(ev);

            return ev.IsAllowed;
        }
    }
    [HarmonyPatch(typeof(NetworkManager), nameof(NetworkManager.BanUserId))]
    internal class BannedUserId
    {
        internal static bool Prefix(NetworkManager __instance, string userId, string reason)
        {
            var ev = new PlayerBannedEventArgs(BanType.UserId, null, userId, reason);
            Events.OnPlayerBanned(ev);

            return ev.IsAllowed;
        }
    }
}
