using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Game.Managers;

namespace Game.Phases
{
    class phaseMenu
    {
        public static void Parse(string command)
        {
            switch (command)
            {
                case "start":
                    Console.Clear();
                    GM.Init();
                    break;
                case "options":
                    Console.Clear();
                    GM.Menu();
                    Console.WriteLine("\nOpen options menu");
                    break;
                case "modules":
                    Console.Clear();
                    GM.subPhase = "Modules";
                    DM.DisplayModules();
                    break;
                case "help":
                    Console.Clear();
                    GM.Menu();
                    Console.WriteLine(@"
start - Starts the game
options - Opens the options menu
modules - Opens the modules menu
exit - Exits the game");
                    break;
                case "exit":
                    GM.GameActive = false;
                    break;
                default:
                    Console.Clear();
                    GM.Menu();
                    Console.WriteLine("\nType 'help' to view all commands");
                    break;
            }
        }
    }
}
