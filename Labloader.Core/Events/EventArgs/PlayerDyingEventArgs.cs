using Labloader.Core.API.Features;

namespace Labloader.Core.Events.EventArgs
{
    public class PlayerDyingEventArgs : System.EventArgs
    {
        public Player Attacker { get; }
        
        public Player Target { get; }

        public string Message { get; set; }

        public bool IsAllowed { get; set; } = true;

        public PlayerDyingEventArgs(Player attacker, Player target, string message)
        {
            Attacker = attacker;
            Target = target;
            Message = message;
        }
    }
}