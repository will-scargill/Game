using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Game.Managers;

namespace Game.Phases
{
    class phaseRoomEnter
    {
        public static void Parse(string command)
        {
            switch (command)
            {
                case "inventory":
                    Console.Clear();
                    DM.ShowInventory(GM.player);
                    break;
                case "stats":
                    Console.Clear();
                    DM.ShowStats(GM.player);
                    break;
                case "help":
                    Console.Clear();
                    Console.WriteLine(@"
inventory - Displays your inventory
stats - Displays your stats
check - Shows the monster and other battle information
attack - Attack using your weapon
magic - Use a spell
item - Use an item from your inventory");
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("\nType 'help' to view all commands");
                    break;
            }
        }
    }
}
