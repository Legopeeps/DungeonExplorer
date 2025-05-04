using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    /// <summary>
    /// ICreature interface forces the inheriting classes to implement the 
    /// Attack and DamageAndDeath methods as a template.
    /// </summary>
    public interface ICreature
    {
        void Attack(Creature target);
        void Death();
    }

    /// <summary>
    /// Base class for all creatures. Provides name and health properties.
    /// Enforces method implementation for attacking and taking damage.
    /// </summary>
    public abstract class Creature : ICreature
    {
        protected string Name { get; set; }
        public int Health { get; set; }
        public string GetName() => Name;
        public int GetHealth() => Health;

        public abstract void Attack(Creature target);
        public abstract void AdjustHealth(int amount);
        public abstract void Death();
    }
}
