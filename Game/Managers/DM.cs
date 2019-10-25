using Game.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Managers
{
    static class DM // Display Manager
    {
        public static void ShowStats(Player player)
        {
            Console.WriteLine("Health: " + player.Health);
            Console.WriteLine("Mana: " + player.Mana);
            Console.WriteLine("Strength: " + player.Strength);
            Console.WriteLine("Intelligence: " + player.Intelligence);
            Console.WriteLine("Constitution: "+ player.Constitution);
            Console.WriteLine("Dexterity: " + player.Dexterity);
            Console.WriteLine("Luck: " + player.Luck);
        }
    }
}
