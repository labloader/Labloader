using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Labloader.Core.API.Enums;

namespace Labloader.Core.API.Features
{
    /// <summary>
    /// Wrapper for <see cref="GameItem"/>
    /// </summary>
    public class Item
    {   
        private static Dictionary<GameItem, Item> GameItemToItem = new();
        
        /// <summary>
        /// Gets a list of all <see cref="Item"/>s
        /// </summary>
        public static IEnumerable<Item> ItemList => GameItemToItem.Values;

        /// <summary>
        /// Initializes a new <see cref="Item"/> from a given <see cref="GameItem"/>
        /// </summary>
        /// <param name="gameItem"></param>
        public Item(GameItem gameItem)
        {
            Base = gameItem;
            GameItemToItem.Add(gameItem, this);
        }

        /// <summary>
        /// The <see cref="GameItem"/> of the <see cref="Item"/>
        /// </summary>
        public GameItem Base { get; private set; }

        /// <summary>
        /// Gets the <see cref="GameItem.ItemName"/> of the Item
        /// </summary>
        public string Name => Base.ItemName;

        /// <summary>
        /// Gets the <see cref="ItemType"/> of the Item
        /// </summary>
        public ItemType Type => (ItemType)Base.itemType;

        /// <summary>
        /// Gets the <see cref="GameObject"/> of the Item
        /// </summary>
        public GameObject GameObject => Base.owner;

        /// <summary>
        /// Gets the <see cref="Transform"/> of the Item
        /// </summary>
        public Transform Transform => Base.transform;

        /// <summary>
        /// Indicates if this Item can be dragged
        /// </summary>
        public bool IsDraggable => Base.CanDrag;
        
        /// <summary>
        /// Indicates if this Item can be picked up
        /// </summary>
        public bool IsPickup => Base.IsPickup;

        /// <summary>
        /// Creates a new instance of an <see cref="Item"/> by creating a new <see cref="GameItem"/>
        /// </summary>
        /// <returns>New <see cref="Item"/> instance</returns>
        public static Item Create()
        {
            return new Item(new GameItem());
        }

        /// <summary>
        /// Gets an existing <see cref="Item"/>. If it doesn't exist, creates a new one.
        /// </summary>
        /// <param name="gameItem">The <see cref="GameItem"/> to convert to an <see cref="Item"/></param>
        /// <returns><see cref="Item"/> wrapper for the given <see cref="GameItem"/></returns>
        public static Item Get(GameItem gameItem)
        {
            if (gameItem is null) return null;
            if(GameItemToItem.TryGetValue(gameItem, out Item item)) return item;

            return new Item(gameItem);
        }

        /// <summary>
        /// Gets an existing <see cref="Item"/> from a <see cref="UnityEngine.GameObject"/>
        /// </summary>
        /// <param name="gameObject">The <see cref="GameObject"/> to get an <see cref="Item"/> from.</param>
        /// <returns><see cref="Item"/> wrapper for the given <see cref="GameObject"/></returns>
        public static Item Get(GameObject gameObject) => ItemList.FirstOrDefault(x => x.GameObject == gameObject);
    }
}