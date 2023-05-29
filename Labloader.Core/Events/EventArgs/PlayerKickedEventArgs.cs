using Labloader.Core.API.Enums;
using Labloader.Core.API.Features;
using System.Net;

namespace Labloader.Core.Events.EventArgs
{
    public class PlayerKickedEventArgs : System.EventArgs
    {
        public Player Player { get; }
        public string Reason { get; set; }
        public bool IsAllowed { get; set; } = true;

        public PlayerKickedEventArgs(Player player, string reason)
        { 
            Player = player;
            Reason = reason;
        }
    }
}