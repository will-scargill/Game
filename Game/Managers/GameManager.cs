using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Objects
{
    static class GM // Game Manager
    {
        public static bool GameActive = true;
        public static string Phase = null;

        public static void ProcCommand(string command)
        {
            command = command.ToLower();
            if (Phase == null)
            {
                if (command == "debug")
                {

                }
            }
            else if (Phase == "Menu")
            {
                switch (command)
                {
                    case "start":
                        Console.WriteLine("\nStart the game");
                        break;
                    case "options":
                        Console.WriteLine("\nOpen options menu");
                        break;
                    case "modules":
                        Console.WriteLine("\nOpen modules menu");
                        break;
                    case "help":
                        Console.WriteLine(@"
start - Starts the game
options - Opens the options menu
modules - Opens the modules menu
exit - Exits the game");
                        break;
                    case "exit":
                        GameActive = false;
                        break;
                    default:
                        Console.WriteLine("Type 'help' to view all commands");
                        break;
                }
            }
        }
      
        public static void Menu()
        {
            Phase = "Menu";
            Console.WriteLine(@"
______                                      _____                    _           
|  _  \                                    /  __ \                  | |          
| | | |_   _ _ __   __ _  ___  ___  _ __   | /  \/_ __ __ ___      _| | ___ _ __ 
| | | | | | | '_ \ / _` |/ _ \/ _ \| '_ \  | |   | '__/ _` \ \ /\ / / |/ _ \ '__|
| |/ /| |_| | | | | (_| |  __/ (_) | | | | | \__/\ | | (_| |\ V  V /| |  __/ |   
|___/  \__,_|_| |_|\__, |\___|\___/|_| |_|  \____/_|  \__,_| \_/\_/ |_|\___|_|   
                    __/ |                                                        
                   |___/                                                         ");
        }

        public static Player Init()
        {
            Phase = "Init";

            Random random = new Random();
            
            Player p = new Player(
                random.Next(90, 110),
                random.Next(45, 55),
                random.Next(3, 6),
                random.Next(3, 6),
                random.Next(3, 6),
                random.Next(3, 6),
                random.Next(3, 6)
                );

            return p;
        }

        public static void StartEquip(Player p)
        {
            Phase = "StartEquip";
        }

    }
}
