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
            Player player = GM.Init();
            DM.ShowStats(player);

            LM.GenWeapon(1);

            Console.ReadKey();
        }
    }
}
