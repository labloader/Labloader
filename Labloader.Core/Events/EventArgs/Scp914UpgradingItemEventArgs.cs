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
        public ItemType NewItemType { get; set; }
        
        public Scp914Dial Dial { get; }

        public bool IsAllowed { get; set; } = true;

        public Scp914UpgradingItemEventArgs(Item item, ItemType newType, Scp914Dial dial)
        {
            Item = item;
            NewItemType = newType;
            Dial = dial;
        }
    }
}