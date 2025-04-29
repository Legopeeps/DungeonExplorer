using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    /// <summary>
    /// this will be inherited by the Room class, and primarily act as a mangager for the map
    /// handling logic for where the player is and where they can go based on their current location
    /// </summary>
    abstract class GameMap
    {
        private string description;
        private List<string> items;
    }
}
