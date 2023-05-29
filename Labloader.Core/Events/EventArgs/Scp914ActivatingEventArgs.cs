using Labloader.Core.API.Enums;
using Labloader.Core.API.Features;

namespace Labloader.Core.Events.EventArgs
{
    /// <summary>
    /// Called when
    /// </summary>
    public class Scp914ActivatingEventArgs : System.EventArgs
    {
        public Player Player { get; }
        
        public SCP914.Level914 KnobLevel { get; }

        public bool IsAllowed { get; set; } = true;

        public Scp914ActivatingEventArgs(Player player, SCP914.Level914 knobLevel)
        {
            Player = player;
            KnobLevel = knobLevel;
        }
    }
}