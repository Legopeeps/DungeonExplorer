using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Room
    {
        private string description;
        private List<string> items;

        /// <summary>
        /// Initialises the Room with a description and a list of items
        /// </summary>
        /// <param name="description">The description of the room</param>
        /// <param name="items">The item(s) the room will have</param>
        public Room(string description, List<string> items)
        {
            this.description = description;
            this.items = items;
        }
        /// <summary>
        /// Gives a description of the room
        /// </summary>
        /// <returns>Either returns a description with the item(s) within, or the description without</returns>
        public string GetDescription()
        {
            //if there are no items in the room, the description will be different
            if (items.Count == 0)
            {
                description = "You are in a dark and dingy room, with seemingly no exits aside from a crumbly wall. The room is now empty. What will you do?";
            }
            else
            {
                description = "You are in a dark and dingy room, with seemingly no exits aside from a crumbly wall. There is a " + string.Join(", ", items) + " on the floor, ready to be picked up.";
            }

            return description;
        }

        /// <summary>
        /// Adds an item to the room
        /// </summary>
        /// <returns>The item in the room</returns>
        public List<string> GetItems()
        {
            return items;
        }

        /// <summary>
        /// Removes the item from the room when picked up by the player
        /// </summary>
        /// <param name="item">the item the player has the option of picking up</param>
        public void RemoveItem(string item) 
        {
            items.Remove(item);
        }
    }
}