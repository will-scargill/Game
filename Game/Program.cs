using Game.Managers;
using Game.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
            DBM.SQLInitialise();

            GM.Menu();

            Console.WriteLine(@"
start - Starts the game
options - Opens the options menu
modules - Opens the modules menu
exit - Exits the game");

            while (GM.GameActive == true)
            {
                switch (GM.subPhase)
                {
                    case "Equipping":
                        Console.WriteLine("Which item would you like to equip?\n");
                        DM.ShowInventory(GM.player);
                        break;
                    case "SlotSelection":
                        Console.WriteLine("Which slot?\n");
                        Console.WriteLine(@"1/2/3" + "\n");
                        break;
                    case "Inspecting":
                        Console.WriteLine("Which item would you like to inspect?\n");
                        DM.ShowInventory(GM.player);
                        break;
                    case "Modules":
                        Console.WriteLine("\nWhat would you like to do?\n");
                        break;
                    case "LoadUnload":
                        Console.WriteLine("\nWhich module?\n");
                        break;
                    case "None":
                        Console.WriteLine("\nWhat would you like to do?\n");
                        break;
                    default:
                        Console.WriteLine("Error - Misspelt subPhase reference");
                        break;
                }
                string command = Console.ReadLine();
                GM.ProcCommand(command);
            }
        
        }
    }
}
