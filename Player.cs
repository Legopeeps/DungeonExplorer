using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Player
    {
        public string Name { get; set; }
        public int Health {get; set; }
        private List<string> inventory = new List<string>();

        public Player(string name, int health) 
        {
            Name = name;
            Health = health;
        }
        public void PickUpItem(string item)
        {
            inventory.Add(item); //appends the picked up item to the list
            InventoryContents();  //after picking up the item, outputs the total inventory to the user
        }
        public string InventoryContents()
        {
            return string.Join(", ", inventory); //returns the list as a string, each item separated by a comma
        }
    }
}