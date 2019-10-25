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
            //DBM.SQLInitialise();
            //Player player = GM.Init();
            //DM.ShowStats(player);

            //Weapon startingWep = LM.GenWeapon(1);
            //Console.WriteLine("Starting weapon : " + startingWep.Name);

            //Armour startingArm = LM.GenArmour(1);
            //Console.WriteLine("Starting armour : " + startingArm.Name);

            GM.Menu();

            while (GM.GameActive == true)
            {
                Console.WriteLine("\nWhat would you like to do? \n");
                GM.ProcCommand(Console.ReadLine());
            }
        
        }
    }
}
