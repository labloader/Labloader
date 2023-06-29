using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labloader.Core.API.Features
{
    /// <summary>
    /// Wrapper for base game <see cref="NetworkPlayerInventory"/>
    /// </summary>
    public class Inventory
    {
        private static readonly Dictionary<NetworkPlayerInventory, Inventory> NetworkPlayerInventoryToInventory = new();

        /// <summary>
        /// Initializes a new <see cref="Inventory"/> from a <see cref="NetworkPlayerInventory"/>
        /// </summary>
        /// <param name="networkPlayerInventory"></param>
        public Inventory(NetworkPlayerInventory networkPlayerInventory)
        {
            Base = networkPlayerInventory;
            NetworkPlayerInventoryToInventory.Add(networkPlayerInventory, this);
        }

        /// <summary>
        /// The <see cref="NetworkPlayerInventory"/> of the <see cref="Inventory"/>
        /// </summary>
        public NetworkPlayerInventory Base;

        /// <summary>
        /// Gets a <see cref="List{T}"/> of <see cref="Item"/>s in an <see cref="Inventory"/>
        /// </summary>
        public IEnumerable<Item> Items
        {
            get
            {
                foreach (GameItem item in Base.InventoryItems) yield return Item.Get(item);
            }
        }

        /// <summary>
        /// Gets an existing <see cref="Inventory"/>. If it doesn't exist, creates a new one.
        /// </summary>
        /// <param name="networkPlayerInventory">The <see cref="NetworkPlayerInventory"/> to convert to an <see cref="Item"/></param>
        /// <returns><see cref="Inventory"/> wrapper for the given <see cref="NetworkPlayerInventory"/></returns>
        public static Inventory Get(NetworkPlayerInventory networkPlayerInventory)
        {
            if (networkPlayerInventory is null) return null;
            if (NetworkPlayerInventoryToInventory.TryGetValue(networkPlayerInventory, out Inventory inventory)) return inventory;

            return new Inventory(networkPlayerInventory);
        }
    }
}
