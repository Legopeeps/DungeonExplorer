using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    class Room
    {
        private string description;
        private List<string> items;
        private Dictionary<GameMap.Direction, Room> connectedRooms;
        public Creature creature { get; set; }
        public Monster monster { get; set; }

        /// Constructor for initializing room with description and items
        public Room(string description, List<string> items)
        {
            this.description = description;
            this.items = items;
            connectedRooms = new Dictionary<GameMap.Direction, Room>();
        }

        /// Property to get the room description
        ///<returns>the entire room description with all variables (making up the full description) concatenated </returns>
        public string GetDescription()
        {
            string baseDescription = "You are in a dark and dingy room, with seemingly no exits aside from a crumbly wall.";

            string itemDescription = items.Count == 0
                ? " The room is now empty."
                : $" There {(items.Count > 1 ? "are" : "is")} {string.Join(", ", items)} on the floor, ready to be picked up.";

            string creatureDescription = (creature != null && creature is Monster monster)
                ? $" A {monster.GetName()} is here, lying dormant staring at you, do you attack?"
                : "\n";

            return baseDescription + itemDescription + creatureDescription;
        }

        public void AddItem(string item)
        {
            items.Add(item);
        }

        public void RemoveItem(string item)
        {
            if (items.Contains(item))
            {
                items.Remove(item);
                Console.WriteLine($"{item} has been removed from the room.\n");
            }
            else
            {
                Console.WriteLine($"{item} is not in this room.\n");
            }
        }

        public void DisplayAvailableDirections()
        {
            Console.WriteLine("You can go to the following directions:");
            foreach (var direction in connectedRooms.Keys)
            {
                Console.WriteLine($"- {direction}\n");
            }
           
        }
        // Method to retrieve items in the room
        public List<string> GetItems()
        {
            return items;
        }

        public void ConnectRoom(GameMap.Direction direction, Room room)
        {
            connectedRooms[direction] = room;
        }

        public Room GetConnectedRoom(GameMap.Direction direction)
        {
            return connectedRooms.ContainsKey(direction) ? connectedRooms[direction] : null;
        }

    }
}