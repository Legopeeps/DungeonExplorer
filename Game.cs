using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace DungeonExplorer
{
    internal class Game
    {
        private Player player;
        private Room currentRoom;

        /// <summary>
        /// Constructor for the Game class, initialises the player and the room
        /// </summary>
        public Game() 
        {
            // Construct the player with a placeholder name which will be updated once the player input's their name,
            // also contains the player's health value
            player = new Player("PlayerName", 100);

            // Construct the room with the description of the room prebaked into the code,
            // later in development this will be randomised between multiple different rooms
            currentRoom = new Room("You are in a dark and dingy room, with seemingly no exits aside from a crumbly wall. There is a bomb on the floor, ready to be picked up.", new List<string> { "bomb" });
        }

        /// <summary>
        /// Start method to begin the game, was used more as a debug tool to ensure the game was working as intended
        /// however later decided that it also works as a menu for the game
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
        /// <summary>
        /// GameLoop method to run the game, contains the main functionality of the game
        /// </summary>
        private void GameLoop()
        {
            //call StringValidation method to obtain the player's name and bring the variable back 
            Console.WriteLine("Please enter your name:");
            player.Name = StringValidation();
            Console.WriteLine($"Welcome, {player.Name}!");

            //game loop to keep the game running until the player decides to exit
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
                        Console.WriteLine("What would you like to pick up?");
                        string item = Console.ReadLine();
                        if (currentRoom.GetItems().Contains(item))
                        {
                            player.PickUpItem(item);
                            currentRoom.GetItems().Remove(item);
                            Location();
                        }
                        else
                        {
                            Console.WriteLine("That item is not in the room.");
                        }
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
                    case "help":
                        Help();
                        break;
                    default:
                        Console.WriteLine("Invalid command. Type 'help' for a list of commands.");
                        break;
                }
            }
        }
        
        /// <summary>
        /// StringValidation method to ensure that the player's name is not empty, otherwise player is prompted again
        /// This has been made reusable for any string that the player can input within the game, that isn't caught by a switch case
        /// </summary>
        /// <returns>The string the user inputs, i.e. when the name is passed through, the name will be returned if valid</returns>
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

        /// <summary>
        /// used to display the help menu
        /// </summary>
        private void Help() 
        {
            Console.WriteLine("Welcome to the Dungeon Explorer Help Menu!!");
            Console.WriteLine("You will always be in a room. You can move to another room by typing 'move'. [this will be implemented later, currently there is functionality for one room]");
            Console.WriteLine("You can pick up an item by typing 'pick up'.");
            Console.WriteLine("You can check your inventory by typing 'inventory'.");
            Console.WriteLine("You can check your health by typing 'health'.");
            Console.WriteLine("You can check your location by typing 'location'.");
            Console.WriteLine("You can exit the game by typing 'exit'.");
        }

        /// <summary>
        /// Shows the player's inventory
        /// </summary>
        private void Inventory()
        {
            Console.WriteLine(player.InventoryContents());
        }

        /// <summary>
        /// Shows the player's health
        /// </summary>
        private void Health()
        {
            player.PlayerHealth();
        }

        /// <summary>
        /// Shows the player's location within the room
        /// </summary>
        private void Location()
        {
            Console.WriteLine(currentRoom.GetDescription());
        }

        /// <summary>
        /// Method to explicitly exit the game
        /// </summary>
        private void Exit() //used to exit the game
        {
            Console.WriteLine($"Thank you for playing the Dungeon Explorer, {player.Name}!\n" +
                $"Please press any key to exit the game.");
            Console.ReadKey();
            Environment.Exit(0);
        }

    }
}