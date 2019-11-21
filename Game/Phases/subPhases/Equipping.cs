using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Game.Managers;

namespace Game.Phases.subPhases
{
    class subPhaseEquipping
    {
        public static void Parse(string command)
        {
            switch (command)
            {
                case "cancel":
                    GM.subPhase = "None";
                    break;
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
cancel - Stops equiping
inventory - Displays your inventory
stats - Displays your stats
next - Move to the next room");
                    break;
                default:
                    Console.Clear();

                    string isItem = IvM.IsInputItem(command);
                    if (isItem == "None")
                    {
                        Console.Clear();
                        Console.WriteLine("\nType 'help' to view all commands");
                    }
                    else if (isItem == "Armour" || isItem == "Item")
                    {
                        GM.subPhase = "SlotSelection";
                    }
                    else
                    {
                        GM.subPhase = "None";
                    }
                    break;

            }
        }
    }
}
