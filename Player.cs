using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Player
    {
        public string Name { get; set; }
        public int Health {get; set; }
        private List<string> inventory = new List<string>();

        public Player(string name, int health) //needs to be public to be accessed by the game class
        {
            Name = name;
            Health = health;
        }
        public void PickUpItem(string item)
        {
            inventory.Add(item); //appends the picked up item to the list
            Console.WriteLine($"{item} has been added to your inventory. \n"); //alerting the player when an item has been added to inventory
            InventoryContents();  //after picking up the item, outputs the total inventory to the user
        }
        public string InventoryContents()
        {
            return string.Join(", ", inventory); //returns the list as a string, each item separated by a comma
        }
        public void PlayerHealth()
        {
            Console.WriteLine($"Your health is currently at {Health}."); //outputs the player's health
        }
    }
}