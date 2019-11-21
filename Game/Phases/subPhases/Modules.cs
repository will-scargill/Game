using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Game.Managers;
using Game.Objects;

namespace Game.Phases.subPhases
{
    class subPhaseModules
    {
        public static void Parse(string command)
        {
            switch (command)
            {
                case "load":
                    Console.Clear();
                    Console.WriteLine("\nWhich module would you like to load?");
                    GM.loadUnload = "load";
                    GM.subPhase = "LoadUnload";
                    break;
                case "unload":
                    Console.Clear();
                    Console.WriteLine("\nWhich module would you like to unload?");
                    GM.loadUnload = "unload";
                    GM.subPhase = "LoadUnload";
                    break;
                case "modules":
                    Console.Clear();
                    DM.DisplayModules();
                    break;
                case "help":
                    Console.Clear();
                    Console.WriteLine(@"
load - Load a module
unload - Unloads a module
modules - Show modules
return - Returns to the menu");
                    break;
                case "return":
                    Console.Clear();
                    GM.Menu();
                    GM.subPhase = "None";
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("\nType 'help' to view all commands");
                    break;
            }
        }
    }
}
