using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DungeonExplorer
{
    internal class Game
    {
        private Player player;
        private GameMap gameMap;

        /// constructor for initializing the game with a player and a map
        public Game()
        {
            player = new Player("PlayerName", 100);
            gameMap = new GameMapImplementation();
        }

        /// <summary>
        /// main method to start the game
        /// </summary>
        public void Start()
        {
            bool startLoop = true;
            while (startLoop)
            {
                Console.WriteLine("Welcome to the Dungeon Explorer!");
                Console.WriteLine("Would you like to play the game?\nType '1' to continue...\nType '2' to close the game...\n");

                switch (Console.ReadLine().ToLower())
                {
                    case "1":
                        Console.WriteLine("You have chosen to continue playing the game.");
                        GameLoop();
                        startLoop = false;
                        break;
                    case "2":
                        Console.WriteLine("You have chosen to exit the game.");
                        startLoop = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please choose 1 to continue or 2 to exit.");
                        break;
                }
            }
        }

        
        private void GameLoop()
        {
            Console.WriteLine("Please enter your name:");
            player.Name = StringValidation();
            Console.WriteLine($"Welcome, {player.Name}!");

            bool gameLoop = true;
            while (gameLoop)
            {
                Console.WriteLine("What would you like to do? You can type 'help' for more info");

                string input = Console.ReadLine().ToLower();
                switch (input)
                {
                    case "move":
                        Move();
                        break;
                    case "pick up":
                        PickUpItem();
                        break;
                    case "inventory":
                        Inventory();
                        break;
                    case "health":
                        Health();
                        break;
                    case "location":
                        Location();
                        break;
                    case "exit":
                        gameLoop = false;
                        Exit();
                        break;
                    case "check stats":
                        Console.WriteLine($"Your name is {player.Name}.");
                        Console.WriteLine($"Your health is {player.Health}.");
                        break;
                    case "use Potion":
                        if (player.InventoryContents().Contains("healing potion"))
                        {
                            player.AdjustHealth(20);
                            Console.WriteLine("You used a Healing Potion. Health increased by 20.");
                        }
                        else
                        {
                            Console.WriteLine("You don't have a Healing Potion in your inventory.");
                        }
                        break;
                    case "display available locations":
                        gameMap.CurrentRoom.DisplayAvailableDirections();
                        break;
                    case "sort inventory":
                        SortInventory();
                        break;
                    case "attack":
                        Attack();
                        break;
                    case "help":
                        Help();
                        break;
                    case "clear console":
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Invalid command. Type 'help' for a list of commands.");
                        break;
                }
            }
        }

        private string StringValidation()
        {
            bool isValidated = false;
            string result = "";
            while (!isValidated)
            {
                result = Console.ReadLine();
                if (string.IsNullOrEmpty(result))
                {
                    Console.WriteLine("Invalid input. Please try again.");
                }
                else
                {
                    isValidated = true;
                }
            }
            return result;
        }

        private void Help()
        {
            Console.WriteLine("\n\n\t\tWelcome to the Dungeon Explorer Help Menu!!");
            Console.WriteLine("You will always be in a room. You can move to another room by typing 'Move'.");
            Console.WriteLine("You can pick up an item by typing 'Pick Up'.");
            Console.WriteLine("You can check your inventory by typing 'Inventory'.");
            Console.WriteLine("You can check your health by typing 'Health'.");
            Console.WriteLine("You can check your location by typing 'Location'.");
            Console.WriteLine("If there is an enemy, you can attack by typing 'attack'.");
            Console.WriteLine("You can check your stats by typing 'Check Stats'.");
            Console.WriteLine("You can use a healing potion by typing 'Use Potion'.");
            Console.WriteLine("You can check the available locations by typing 'Display Available Locations'.");
            Console.WriteLine("You can clear the console by typing 'Clear Console'.");
            Console.WriteLine("You can exit the game by typing 'Exit'.\n\n");
        }

        private void Inventory()
        {
            Console.WriteLine(player.InventoryContents());
        }

        private void Health()
        {
            Console.WriteLine($"You have {player.PlayerHealth()} health remaining.\n");
        }

        private void Location()
        {
            Console.WriteLine(gameMap.CurrentRoom.GetDescription());
        }

        private void Move()
        {
            Console.WriteLine("Which direction would you like to move? (Centre, Left, Right)");

            string directionInput = Console.ReadLine().ToLower();
            GameMap.Direction direction;

            if (Enum.TryParse(directionInput, true, out direction))
            {
                if (gameMap.Move(direction))
                {
                    Console.WriteLine($"You move to the {direction} room.");
                    Location();
                }
                else
                {
                    Console.WriteLine("You can't move in that direction.");
                }
            }
            else
            {
                Console.WriteLine("Invalid direction. Please type 'centre', 'left', or 'right... maybe you can find a secret?");
            }
        }

        private void PickUpItem()
        {
            Console.WriteLine("What would you like to pick up?");
            string item = Console.ReadLine();

            if (gameMap.CurrentRoom.GetItems().Contains(item))
            {
                player.PickUpItem(item);
                gameMap.CurrentRoom.RemoveItem(item);
                Location();
            }
            else
            {
                Console.WriteLine("That item is not in the room.");
            }
        }

        private void Attack()
        {
            Creature creature = gameMap.CurrentRoom.creature;

            if (creature != null)
            {
                Console.WriteLine("You attack the creature!");
                player.Attack(creature);

                if (creature is Monster monster && monster.Health > 0)
                {
                    Console.WriteLine("The creature fights back!");
                    monster.Attack(player);
                }
                else
                {
                    Console.WriteLine("The creature has been defeated!");
                }
            }
            else
            {
                Console.WriteLine("There is no creature to attack.");
            }
        }

        //utilizing LINQ to sort the inventory
        private void SortInventory()
        {
            Console.WriteLine("Inventory before sort:");
            Console.WriteLine(player.InventoryContents());
            Console.WriteLine("Inventory after sort:");
            Console.WriteLine(player.SortedInventory());
        }

        private void Exit()
        {
            Console.WriteLine($"Thank you for playing the Dungeon Explorer, {player.Name}!\n" +
                "Please press any key to exit the game.");
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
    class GameMapImplementation : GameMap
    {
        public GameMapImplementation() : base() { }
    }
}