using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Game.Managers;

namespace Game.Phases.subPhases
{
    class subPhaseStatUpgrade
    {
        public static void Parse(string command)
        {
            switch (command)
            {
                case "strength":
                    Console.Clear(); 
                    GM.player.Strength += 1;
                    GM.UpgradesLeft -= 1;
                    CheckUpgradesLeft();
                    break;
                case "dexterity":
                    Console.Clear();
                    GM.player.Dexterity += 1;
                    GM.UpgradesLeft -= 1;
                    CheckUpgradesLeft();
                    break;
                case "intelligence":
                    Console.Clear();
                    GM.player.Intelligence += 1;
                    GM.player.Mana += 20;
                    GM.UpgradesLeft -= 1;
                    CheckUpgradesLeft();
                    break;
                case "constitution":
                    Console.Clear();
                    GM.player.Constitution += 1;
                    GM.player.Health += 10;
                    GM.UpgradesLeft -= 1;
                    CheckUpgradesLeft();
                    break;
                case "luck":
                    Console.Clear();
                    GM.player.Luck += 1;
                    GM.UpgradesLeft -= 1;
                    CheckUpgradesLeft();
                    break;
                case "help":
                    Console.Clear();
                    Console.WriteLine(@"
strength - Upgrades your strength stat
dexterity - Upgrades your dexterity stat
intelligence - Upgrades your intelligence stat
constitution - Upgrades your constitution stat
luck - Upgrades your luck stat");
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("\nType 'help' to view all commands");
                    break;
            }
        }

        private static void CheckUpgradesLeft()
        {
            if (GM.UpgradesLeft == 0)
            {
                GM.subPhase = "None";
            }
        }
    }
}
