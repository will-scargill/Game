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
                Console.WriteLine("\nWhat would you like to do? \n");
                GM.ProcCommand(Console.ReadLine());
            }
        
        }
    }
}
