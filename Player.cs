using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    class Player : Creature
    {

        private List<string> inventory = new List<string>();

        /// <summary>
        /// Initializes the player with a name and health value
        /// </summary>
        /// <param name="name">The name of the player</param>
        /// <param name="health">The health the player has</param>
        public Player(string name, int health) 
        {
            Name = name;
            Health = health;
        }

        /// <summary>
        /// Method to pick up an item and add it to the player's inventory
        /// </summary>
        /// <param name="item">The item to be picked up</param>
        public void PickUpItem(string item)
        {
            inventory.Add(item); //appends the picked up item to the list
            Console.WriteLine($"{item} has been added to your inventory. \n"); //alerting the player when an item has been added to inventory
            InventoryContents();  //after picking up the item, outputs the total inventory to the user
        }

        /// <summary>
        /// Function which shows the contents of the player's inventory if they have any items 
        /// </summary>
        /// <returns>A string value describing what is in the inventory</returns>
        public string InventoryContents()
        {
            if (inventory.Count == 0) //if the inventory is empty
            {
                return "Your inventory is empty."; 
            }
            else
            {
                return $"Your inventory contains: {string.Join(", ", inventory)}"; //outputs the inventory list as a string, each item separated by a comma
            }
        }

        /// <summary>
        /// Displays the player's health
        /// </summary>
        public void PlayerHealth()
        {
            Console.WriteLine($"Your health is currently at {Health}."); //outputs the player's health
        }
    }
}