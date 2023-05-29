using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Labloader;
using Labloader.Core.API.Features;

namespace Labloader.Core.API.Permissions.Patches
{
    [HarmonyPatch(typeof(RConServer), nameof(RConServer.HasPermission))]
    internal class HasPermission
    {
        internal static bool Prefix(RConServer __instance, ref bool __result, ushort clientId, string permission)
        {
            if (clientId == 0 || string.IsNullOrEmpty(permission))
            {
                __result = true;
                return false;
            }
            string authUserId = NetworkManager.instance.connectedPlayers[clientId].authUserId;
            string text;
            ServerRoleInfo serverRoleInfo;
            if(NetworkManager.instance.connectedPlayers[clientId].authenticated && ServerConfig.instance.roles.UserIdRoles.TryGetValue(authUserId, out text))
            {
                __result = false;
                if (ServerConfig.instance.roles.Roles.TryGetValue(text, out serverRoleInfo))
                {
                    if(serverRoleInfo.Permissions.Contains(permission) || serverRoleInfo.Permissions.Contains("*"))
                    {
                        __result = true;
                        return false;
                    }
                }
            }
            return false;
        }
    }
}
