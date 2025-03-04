using System;

namespace DungeonExplorer
{
    internal class Game
    {
        private Player player;
        private Room currentRoom;

        public Game()
        {
            // Initialize the game with one room and one player
            Player player = new Player("PlayerName", 100);
        }
        public void Start()
        {
            bool playing = true;
            while (playing)
            {
                // Code your playing logic here
            }
        }
    }
}