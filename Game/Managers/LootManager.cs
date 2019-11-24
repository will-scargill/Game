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

        private static List<object> treasure = new List<object>();

        private static int breakoutCounter = 0;

        public static Weapon GenWeapon(int floornum)
        {
            Random random = new Random();
            int rarityOfItem;
            if (floornum < 10) { rarityOfItem = random.Next((80 - (floornum-1 * 10)), 100); }
            else { rarityOfItem = random.Next((80 - (floornum * 10)), (100 - (10 * (floornum-9)))); }

            List<List<string>> data = DBM.SQLRaw("SELECT * FROM Weapons WHERE rarity >= " + rarityOfItem + " ORDER BY rarity ASC", "Weapons");
            int index = random.Next(data.Count);

            return new Weapon(data[index][1],
                data[index][2],
                data[index][3],
                Convert.ToDouble(data[index][4]),
                Convert.ToInt32(data[index][5])
                );
        }

        public static Armour GenArmour(int floornum)
        {
            Random random = new Random();
            int rarityOfItem;
            if (floornum < 10) { rarityOfItem = random.Next((80 - (floornum - 1 * 10)), 100); }
            else { rarityOfItem = random.Next((80 - (floornum * 10)), (100 - (10 * (floornum - 9)))); }

            List<List<string>> data = DBM.SQLRaw("SELECT * FROM Armours WHERE rarity >= " + rarityOfItem, "Armours");
            int index = random.Next(data.Count);

            return new Armour(data[index][1],
                data[index][2],
                data[index][3],
                Convert.ToDouble(data[index][4]),
                Convert.ToInt32(data[index][5])
                );
        }

        public static Consumable GenConsumable(int floornum)
        {
            Random random = new Random();
            int rarityOfItem;
            if (floornum < 10) { rarityOfItem = random.Next((80 - (floornum - 1 * 10)), 100); }
            else { rarityOfItem = random.Next((80 - (floornum * 10)), (100 - (10 * (floornum - 9)))); }

            List<List<string>> data = DBM.SQLRaw("SELECT * FROM Consumables WHERE rarity >= " + rarityOfItem, "Consumables");
            int index = random.Next(data.Count);

            return new Consumable(data[index][1],
                data[index][2],
                Convert.ToDouble(data[index][3]),
                Convert.ToInt32(data[index][4])
                );
        }

        public static Item GenItem(int floornum)
        {
            Random random = new Random();
            int rarityOfItem;
            if (floornum < 10) { rarityOfItem = random.Next((80 - (floornum - 1 * 10)), 100); }
            else { rarityOfItem = random.Next((80 - (floornum * 10)), (100 - (10 * (floornum - 9)))); }

            List<List<string>> data = DBM.SQLRaw("SELECT * FROM Items WHERE rarity >= " + rarityOfItem, "Items");
            int index = random.Next(data.Count);

            return new Item(data[index][1],
                data[index][2],
                Convert.ToInt32(data[index][3]),
                data[index][4],
                Convert.ToInt32(data[index][5]),
                Convert.ToInt32(data[index][6])
                );
        }

        public static Spell GenSpell(int floornum)
        {
            Random random = new Random();
            int rarityOfItem;
            if (floornum < 10) { rarityOfItem = random.Next((80 - (floornum - 1 * 10)), 100); }
            else { rarityOfItem = random.Next((80 - (floornum * 10)), (100 - (10 * (floornum - 9)))); }

            List<List<string>> data = DBM.SQLRaw("SELECT * FROM Spells WHERE rarity >= " + rarityOfItem, "Spells");
            int index = random.Next(data.Count);

            return new Spell(data[index][1],
                Convert.ToInt32(data[index][2]),
                data[index][3],
                data[index][4],
                Convert.ToDouble(data[index][5]),
                Convert.ToInt32(data[index][6])
                );
        }

        public static List<object> GenerateTreasure(int amountOfTreasure, int floornum, Random random)
        {
            treasure = new List<object>();
            for (int i = 1; i <= amountOfTreasure; i++)
            {              
                int typeOfTreasure = random.Next(1, 5); // disabling spells for now until i work on magic system
                //int typeOfTreasure = 2;
                switch (typeOfTreasure)
                {
                    case 1:
                        Weapon weapon = GenWeapon(floornum);
                        while (CheckDuplicate(weapon, "Weapon") == false)
                        {
                            weapon = GenWeapon(floornum);
                            breakoutCounter++;
                            if (breakoutCounter >= 5)
                            {
                                treasure.Add(GenConsumable(floornum));
                                Console.WriteLine("Duplicate weapon breakout");
                                break;
                            }
                        }
                        if (breakoutCounter >= 5) { breakoutCounter = 0; }
                        else
                        {
                            treasure.Add(weapon);
                            breakoutCounter = 0;
                        }
                        
                        break;
                    case 2:
                        Armour armour = GenArmour(floornum);
                        while (CheckDuplicate(armour, "Armour") == false)
                        {
                            armour = GenArmour(floornum);
                            breakoutCounter++;
                            if (breakoutCounter >= 5)
                            {
                                treasure.Add(GenConsumable(floornum));
                                Console.WriteLine("Duplicate armour breakout");
                                break;
                            }
                        }
                        if (breakoutCounter >= 5) { breakoutCounter = 0; }
                        else
                        {
                            treasure.Add(armour);
                            breakoutCounter = 0;
                        }

                        break;
                    case 3:
                        treasure.Add(GenConsumable(floornum));
                        break;
                    case 4:
                        Item item = GenItem(floornum);
                        while (CheckDuplicate(item, "Item") == false)
                        {
                            item = GenItem(floornum);
                            breakoutCounter++;
                            if (breakoutCounter >= 5)
                            {
                                treasure.Add(GenConsumable(floornum));
                                Console.WriteLine("Duplicate item breakout");
                                break;
                            }
                        }
                        if (breakoutCounter >= 5) { breakoutCounter = 0; }
                        else
                        {
                            treasure.Add(item);
                            breakoutCounter = 0;
                        }
                        break;
                    case 5:
                        treasure.Add(GenSpell(floornum));
                        break;

                }
            }

            return treasure;
        }

        public static bool CheckDuplicate(object item, string type)
        {
            if (type == "Weapon")
            {
                foreach (object o in treasure)
                {
                    if (o.GetType() == typeof(Weapon))
                    {
                        if (((Weapon)(o)).Name == ((Weapon)(item)).Name)
                        {
                            return false; // is a dupe
                        }
                    }
                }
                foreach (object o in GM.player.Inventory)
                {
                    if (o.GetType() == typeof(Weapon))
                    {
                        if (((Weapon)(o)).Name == ((Weapon)(item)).Name)
                        {
                            return false; // is a dupe
                        }
                    }
                }
                return true; // is unique
            }
            else if (type == "Armour")
            {
                foreach (object o in treasure)
                {
                    if (o.GetType() == typeof(Armour))
                    {
                        if (((Armour)(o)).Name == ((Armour)(item)).Name)
                        {
                            return false; // is a dupe
                        }
                    }
                }
                foreach (object o in GM.player.Inventory)
                {
                    if (o.GetType() == typeof(Armour))
                    {
                        if (((Armour)(o)).Name == ((Armour)(item)).Name)
                        {
                            return false; // is a dupe
                        }
                    }
                }
                return true; // is unique
            }
            else if (type == "Item")
            {
                foreach (object o in treasure)
                {
                    if (o.GetType() == typeof(Item))
                    {
                        if (((Item)(o)).Name == ((Item)(item)).Name)
                        {
                            return false; // is a dupe
                        }
                    }
                }
                foreach (object o in GM.player.Inventory)
                {
                    if (o.GetType() == typeof(Item))
                    {
                        if (((Item)(o)).Name == ((Item)(item)).Name)
                        {
                            return false; // is a dupe
                        }
                    }
                }
                return true; // is unique
            }
            else if (type == "Spell")
            {
                return true; // is unique
            }
            else
            {
                return true; // is unique
            }
        }
    }
}
