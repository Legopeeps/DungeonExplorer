using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    internal class Program
    {
        /// <summary>
        /// main calls the game class and allows the game to start
        /// </summary>
        /// <param name="args">Default when main is created</param>
        static void Main(string[] args)
        {
            Game game = new Game();
            game.Start();
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}
