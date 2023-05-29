using HarmonyLib;
using Labloader.Core.Events.EventArgs;
using RiptideNetworking;

namespace Labloader.Core.Events.Patches.Scp914
{
	// wont be updated until virtual updates SCP914.Activate()
   // [HarmonyPatch(typeof(SCP914), nameof(SCP914.Handle914Data))]
   // internal class Activating
   // {
   //     internal static bool Prefix(SCP914 __instance, ushort clientId, Message message)
   //     {
			//uint @uint = message.GetUInt();
			//NetworkObject networkObject;
			//SCP914 scp;
			//if (NetworkObject.NetObjects.TryGetValue(@uint, out networkObject) && networkObject.TryGetComponent<SCP914>(out scp))
			//{
			//	if (message.GetBool())
			//	{
			//		var ev = new Scp914ActivatingEventArgs(API.Features.Player.Get(clientId), __instance.currentLevel);
			//		Events.OnScp914Activating(ev);
			//		//if(ev.IsAllowed)
			//		scp.Activate();
			//		return false;
			//	}
			//	scp.SetLevel((SCP914.Level914)message.GetByte());
			//	scp.Snap();
			//	scp.IsDirty = true;
			//}
   //         return false;
   //     }
   // }
}