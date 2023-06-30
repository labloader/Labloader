using JetBrains.Annotations;
using Labloader.Core.API.Features;
using UnityEngine;

namespace Labloader.Core.Events.EventArgs
{
    public class PlayerDamagingEventArgs : System.EventArgs
    {
        [CanBeNull]
        public Player Attacker { get; }
        
        public Player Target { get; }
        
        public float Damage { get; set; }

        public string Message { get; set; }

        public float BloodLossAmount { get; set; }

        public float BloodLossRate { get; set; }

        public Vector3 Direction { get; set; }

        public bool IsAllowed { get; set; } = true;
        
        internal PlayerDamagingEventArgs(Player attacker, Player target, float damage, 
            string message, float bloodLossAmount, float bloodLossRate, Vector3 direction)
        {
            Attacker = attacker;
            Target = target;
            Damage = damage;
            Message = message;
            BloodLossAmount = bloodLossAmount;
            BloodLossRate = bloodLossRate;
            Direction = direction;
        }
    }
}