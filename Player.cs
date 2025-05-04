using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public class Player : Creature
    {
        public string Name { get; set; }
        public int Health { get; set; }

        private List<string> inventory = new List<string>();

        public Player(string name, int health)
        {
            Name = name;
            Health = health;
            //assigning health a specific value for initialization
            Health = 15;
        }

        public void PickUpItem(string item)
        {
            inventory.Add(item);
            Console.WriteLine($"{item} has been added to your inventory.\n");
        }

        public string InventoryContents()
        {
            if (inventory.Count == 0)
                return "Your inventory is empty.";
            return $"Your inventory contains: {string.Join(", ", inventory)}\n";
        }

        ///<summary> 
        ///Sorts the inventory alphabetically and returns the sorted list,
        ///uses LINQ and a lambda expression to sort the inventory
        ///</summary>
        public string SortedInventory()
        {
            if(inventory.Count != null)
            {
                IEnumerable<string> alphabeticalInventory = inventory.OrderBy(item => item);
                return $"Your inventory contains: {string.Join(", ", alphabeticalInventory)}\n";
            }
            else
            {
                return "Your inventory is empty.\n";
            }
        }

        public int PlayerHealth()
        {
            return Health;
        }

        public override void Attack(Creature target)
        {
            Console.WriteLine($"{Name} attacks {target.GetName()} for 10 damage!\n");
            target.AdjustHealth(-10);
            Console.WriteLine($"{target.GetName()} has {target.GetHealth()} health left.\n");
        }

        public override void Death()
        {
            Console.WriteLine($"{Name} has died! You Lose!!\n");
            Console.WriteLine("Press any key to exit the game");
            Console.ReadKey();
            Environment.Exit(0);
        }

        /// <summary>
        /// player health is adjusted by the amount of damage taken
        /// can be negative, resulting in a health increase (i.e. using a health potion)
        /// </summary>
        public override void AdjustHealth(int amount)
        {
            Health += amount;
            Console.WriteLine($"{Name} takes damage! Health is now {Health}.\n");
            if (Health <= 0)
            {
                Health = 0;
                Death();
            }
        }
        int GetHealth() => Health; //lambda expression for readability
    }
}