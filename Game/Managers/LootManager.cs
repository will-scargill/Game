using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Objects;

namespace Game.Managers
{
    static class LM // Loot Manager
    {
        /* Loot table rarity setup
         * 
         * Floor 1 - rarity range 100 to 80
         * Floor 2 - rarity range 100 to 70
         * Floor 3 - rarity range 100 to 60
         * Floor x - rarity range 100 to 80-(10 * x-1)
         * Until lowest point is 0 (100 to 0)
         * Floor 10 - rarity range 90 to 0
         * Floor 11 - rarity range 80 to 0
         * Floor 12 - rarity range 70 to 0
         * Floor y - rarity range (100-(10*y-9)
         */

        public static Weapon GenWeapon(int floornum)
        {
            Random random = new Random();
            int rarityOfItem;
            if (floornum < 10) { rarityOfItem = random.Next((80 - (floornum-1 * 10)), 100); }
            else { rarityOfItem = random.Next((80 - (floornum * 10)), (100 - (10 * (floornum-9)))); }

            Console.WriteLine(rarityOfItem);

            List<List<string>> data = DBM.SQLRaw("SELECT * FROM Weapons WHERE rarity >= " + rarityOfItem, "Weapons");
            int index = random.Next(data.Count);

            return new Weapon(data[index][1],
                Convert.ToInt32(data[index][2]),
                data[index][3],
                data[index][4],
                Convert.ToDouble(data[index][5]),
                Convert.ToInt32(data[index][6])
                );
        }

        public static Armour GenArmour(int floornum)
        {
            Random random = new Random();
            int rarityOfItem;
            if (floornum < 10) { rarityOfItem = random.Next((80 - (floornum - 1 * 10)), 100); }
            else { rarityOfItem = random.Next((80 - (floornum * 10)), (100 - (10 * (floornum - 9)))); }

            Console.WriteLine(rarityOfItem);

            List<List<string>> data = DBM.SQLRaw("SELECT * FROM Armours WHERE rarity >= " + rarityOfItem, "Armours");
            int index = random.Next(data.Count);

            return new Armour(data[index][1],
                Convert.ToInt32(data[index][2]),
                data[index][3],
                data[index][4],
                Convert.ToDouble(data[index][5]),
                Convert.ToInt32(data[index][6])
                );
        }
    }
}
