using System;
using System.Runtime.InteropServices;

namespace DungeonExplorer
{
    internal class Game
    {
        private Player player;
        private Room currentRoom;

        public Game() //needs to be public to be accessed by the Program class
        {
            // Construct the player with a placeholder name which will be updated once the player input's their name,
            // also contains the player's health value
            player = new Player("PlayerName", 100);
            
            // Construct the room with the description of the room prebaked into the code,
            // later in development this will be randomised between multiple different rooms
            currentRoom = new Room("You are in a dark and dingy room, with seemingly no exits aside from a crumbly wall. There is a bomb on the floor, ready to be picked up.");
        }
        public void Start()
        {
            bool startLoop = true;
            while (startLoop)
            {
                Console.WriteLine("Welcome to the Dungeon Explorer!");
                Console.WriteLine("Would you like to play the game?\nType 1 to continue...\nType 2 to close the game...\n");

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
            //call StringValidation method to obtain the player's name and bring the variable back 
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
                    /*/
                     * Implementing the Move method later, assignment only needs one room and no movement
                     * case "move":
                        Move();
                        break; 
                    /*/
                    case "pick up":
                       // player.PickUpItem(item);
                        break;
                    case "inventory":
                        Inventory();
                        break;
                    case "health":
                        Health();
                        break;
                    case "location":
                       // Location();
                        break;
                    case "exit":
                        Exit();
                        break;
                    case "help":
                        Help();
                        break;
                    default:
                        Console.WriteLine("Invalid command. Type 'help' for a list of commands.");
                        break;
                }
            }
        }
        //string validation method to ensure that the player's name is not empty, otherwise player is prompted again
        //this has been made reusable for any string that the player can input within the game, that isn't caught by a switch case
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
        private void Help() //used to display the help menu
        {
            Console.WriteLine("Welcome to the Dungeon Explorer Help Menu!!");
            Console.WriteLine("You will always be in a room. You can move to another room by typing 'move'. [this will be implemented later, currently there is functionality for one room]");
            Console.WriteLine("You can pick up an item by typing 'pick up'.");
            Console.WriteLine("You can check your inventory by typing 'inventory'.");
            Console.WriteLine("You can check your health by typing 'health'.");
            Console.WriteLine("You can check your location by typing 'location'.");
            Console.WriteLine("You can exit the game by typing 'exit'.");
        }
        private void Exit() //used to exit the game
        {
            Console.WriteLine($"Thank you for playing the Dungeon Explorer, {player.Name}!\n" +
                $"Please press any key to exit the game.");
            Console.ReadKey();
            Environment.Exit(0);
        }
        private void Inventory()
        {
            Console.WriteLine(player.InventoryContents());
        }
        private void Health()
        {
            player.PlayerHealth();
        }
    }
}