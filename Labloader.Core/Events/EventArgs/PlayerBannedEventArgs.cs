using Labloader.Core.API.Enums;
using Labloader.Core.API.Features;
using System.Net;

namespace Labloader.Core.Events.EventArgs
{
    public class PlayerBannedEventArgs : System.EventArgs
    {
        public BanType Type { get; }
        public IPAddress IPAddress { get; }
        public string UserID { get; }
        public string Reason { get; set; }
        public bool IsAllowed { get; set; } = true;

        public PlayerBannedEventArgs(BanType type, IPAddress ipaddress, string userid, string reason)
        {
            Type = type;
            IPAddress = ipaddress;
            UserID = userid;
            Reason = reason;
        }
    }
}