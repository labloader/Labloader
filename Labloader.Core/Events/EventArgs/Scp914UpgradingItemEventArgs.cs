using Labloader.Core.API.Enums;
using Labloader.Core.API.Features;

namespace Labloader.Core.Events.EventArgs
{
    /// <summary>
    /// Called when <see cref="SCP914"/> is changing an <see cref="API.Features.Item"/>
    /// </summary>
    public class Scp914UpgradingItemEventArgs : System.EventArgs
    {
        /// <summary>
        /// The <see cref="API.Features.Item"/> to be upgraded
        /// </summary>
        public Item Item { get; }
        
        /// <summary>
        /// The <see cref="ItemType"/> that will be created
        /// </summary>
        public Item NewItem { get; }
        
        /// <summary>
        /// The <see cref="SCP914.Level914"/> setting to be applied
        /// </summary>
        public SCP914.Level914 Dial { get; }

        /// <summary>
        /// Whether or not this event is allowed
        /// </summary>
        public bool IsAllowed { get; set; } = true;

        /// <summary>
        /// The <see cref="System.EventArgs"/> for <see cref="SCP914.switchOutItems"/>
        /// </summary>
        /// <param name="grindable"></param>
        /// <param name="dial"></param>
        public Scp914UpgradingItemEventArgs(Grindable grindable, SCP914.Level914 dial)
        {
            Item = Item.Get(grindable.gameObject.GetComponent<GameItem>());
            NewItem = Item.Get(grindable.getGrindedVersion(dial).GetComponent<GameItem>());
            Dial = dial;
        }
    }
}