using System.Reflection;
using Labloader.Core.API.Features;
using Labloader.Core.Events.EventArgs;

namespace Labloader.Core.Events
{
    public static class Events
    {
        internal static EventInfo GetEvent(EventType eventType)
        {
            return typeof(Events).GetEvent(eventType.ToString(), BindingFlags.Public | BindingFlags.Static);
        }

        public delegate void EventHandler<in T>(T ev)
            where T : System.EventArgs;

        public delegate void EventHandler();

        public static event EventHandler<PlayerJoinedEventArgs> PlayerJoined;
        internal static void OnPlayerJoined(PlayerJoinedEventArgs ev)
        {
            API.Features.Player.UpdateList();
            PlayerJoined?.Invoke(ev);
        }

        public static event EventHandler<PlayerLeftEventArgs> PlayerLeft;
        internal static void OnPlayerLeft(PlayerLeftEventArgs ev)
        {
            API.Features.Player.UpdateList();
            PlayerLeft?.Invoke(ev);
        }

        public static event EventHandler<PlayerDyingEventArgs> PlayerDying;
        internal static void OnPlayerDying(PlayerDyingEventArgs ev) => PlayerDying?.Invoke(ev);

        public static event EventHandler<PlayerBannedEventArgs> PlayerBanned;
        internal static void OnPlayerBanned(PlayerBannedEventArgs ev) => PlayerBanned?.Invoke(ev);
        public static event EventHandler<PlayerKickedEventArgs> PlayerKicked;
        internal static void OnPlayerKicked(PlayerKickedEventArgs ev) => PlayerKicked?.Invoke(ev);

        public static event EventHandler<PlayerExecutingCommandEventArgs> PlayerExecutingCommand;
        internal static void OnPlayerExecutingCommand(PlayerExecutingCommandEventArgs ev) => PlayerExecutingCommand?.Invoke(ev);
        
        public static event EventHandler<PlayerPickingUpItemEventArgs> PlayerPickingUpItem;
        internal static void OnPlayerPickingUpItem(PlayerPickingUpItemEventArgs ev) => PlayerPickingUpItem?.Invoke(ev);
        
        public static event EventHandler<PlayerDroppingItemEventArgs> PlayerDroppingItem;
        internal static void OnPlayerDroppingItem(PlayerDroppingItemEventArgs ev) => PlayerDroppingItem?.Invoke(ev);
        
        public static event EventHandler<PlayerShootingGunEventArgs> PlayerShootingGun;
        internal static void OnPlayerShootIngGun(PlayerShootingGunEventArgs ev) => PlayerShootingGun?.Invoke(ev);
        
        public static event EventHandler<PlayerDamagingEventArgs> PlayerDamaging;
        internal static void OnPlayerDamaging(PlayerDamagingEventArgs ev) => PlayerDamaging?.Invoke(ev);
        
        public static event EventHandler<PlayerReloadingGunEventArgs> PlayerReloadingGun;
        internal static void OnPlayerReloadingGun(PlayerReloadingGunEventArgs ev) => PlayerReloadingGun?.Invoke(ev);
        
        public static event EventHandler<PlayerEnterPocketDimensionEventArgs> PlayerEnterPocketDimension;
        internal static void OnPlayerEnterPocketDimension(PlayerEnterPocketDimensionEventArgs ev) => PlayerEnterPocketDimension?.Invoke(ev);
        
        public static event EventHandler<PlayerExitPocketDimensionEventArgs> PlayerExitPocketDimension;
        internal static void OnPlayerExitPocketDimension(PlayerExitPocketDimensionEventArgs ev) => PlayerExitPocketDimension?.Invoke(ev);
        
        public static event EventHandler<Scp914ActivatingEventArgs> Scp914Activating;
        internal static void OnScp914Activating(Scp914ActivatingEventArgs ev)
        {
            Log.Debug($"{ev.Player.Name} activated SCP 914 (Knob set to {ev.KnobLevel})");
            Scp914Activating?.Invoke(ev);
        }

        public static event EventHandler<Scp914UpgradingItemEventArgs> Scp914UpgradingItem;
        internal static void OnScp914UpgradingItem(Scp914UpgradingItemEventArgs ev)
        {
            UnityEngine.Object.Instantiate(grindedVersion, position, grindable.transform.rotation, grindable.transform.parent);
            ev.NewItem = Item.Get(new GameItem());
            Log.Debug($"SCP914: {ev.Item.Name} is going to be upgraded to {ev.NewItem.Name} (Dial Setting: {ev.Dial})");
            Scp914UpgradingItem?.Invoke(ev);
        }

        public static event EventHandler<Scp914UpgradingPlayerEventArgs> Scp914UpgradingPlayer;
        internal static void OnScp914UpgradingPlayer(Scp914UpgradingPlayerEventArgs ev) => Scp914UpgradingPlayer?.Invoke(ev);
    }
}