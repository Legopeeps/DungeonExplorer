using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace DungeonExplorer
{
    /// <summary>
    /// this class will be inherited by the Player and Monster classes
    /// </summary>
    abstract class Creature
    {
        protected string Name { get; set; }
        protected int Health { get; set; }
    }
}
