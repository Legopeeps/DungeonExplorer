using System;
using System.Dynamic;

namespace DungeonExplorer
{
    class Monster : Creature
    {
        public int Damage { get; set; }

        public Monster(string name, int health, int damage)
        {
            Name = name;
            Health = health;
            Damage = damage;
        }

        public override void Attack(Creature target)
        {
            if (target is Player player)
            {
                Console.WriteLine($"{Name} attacks {player.GetName()} for {Damage} damage!");
                player.AdjustHealth(-Damage);
            }
            else
            {
                Console.WriteLine($"{Name} attacks, but nothing happens.");
            }
        }

        public override void Death()
        {
            Console.WriteLine($"{Name} has died!");
        }

        public override void AdjustHealth(int amount)
        {
            // when the code runs, the monster will take damage
            Health -= amount;
            if (Health <= 0)
            {
                Health = 0;
                Death();
            }
        }
    }
}

