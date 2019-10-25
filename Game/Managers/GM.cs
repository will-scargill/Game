using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Objects
{
    static class GM // Game Manager
    {
        public static string Phase { get; set; }

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
