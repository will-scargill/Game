using Game.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Managers
{
    static class DM // Display Manager
    {
        public static void ShowStats(Player player)
        {
            Console.WriteLine("Health: " + player.CurrentHealth + "/" + player.Health);
            Console.WriteLine("Mana: " + player.CurrentMana + "/" + player.Mana);
            Console.WriteLine("Strength: " + player.Strength);
            Console.WriteLine("Intelligence: " + player.Intelligence);
            Console.WriteLine("Constitution: "+ player.Constitution);
            Console.WriteLine("Dexterity: " + player.Dexterity);
            Console.WriteLine("Luck: " + player.Luck);
        }

        public static void ShowInventory(Player player)
        {
            Console.WriteLine("---Your inventory---");
            foreach (object o in player.Inventory)
            {
                if (o is Weapon)
                {
                    Weapon otemp = (Weapon)o;
                    Console.WriteLine(" - " + otemp.Name);
                }
                if (o is Armour)
                {
                    Armour otemp = (Armour)o;
                    Console.WriteLine(" - " + otemp.Name);
                }
                if (o is Consumable)
                {
                    Consumable otemp = (Consumable)o;
                    Console.WriteLine(" - " + otemp.Name);
                }
                if (o is Item)
                {
                    Item otemp = (Item)o;
                    Console.WriteLine(" - " + otemp.Name);
                }

            }
            Console.WriteLine("\n");
        }

        public static void ShowBattleUI(Player player, object monster, bool isboss)
        {
            Console.WriteLine("HP: " + player.CurrentHealth + "/" + player.Health + " | Mana: " + player.CurrentMana + "/" + player.Mana + "\nCurrent weapon: " + player.EquippedWep.Name);
            Console.WriteLine("------------------------------------------");
            if (isboss == true)
            {
                Console.WriteLine("ehh its a boss lol");
            }
            else
            {
                Console.WriteLine("Enemy in room: " + ((Monster)monster).Name);
            }
        }

        public static void ShowBattleUITurn(Player player, object monster, int turn, bool isboss)
        {
            ShowBattleUI(player, monster, isboss);
            Console.WriteLine("------------------------------------------");
            if (turn == 0)
            {
                Console.WriteLine("It is your turn");
            }
            else if (turn == 1)
            {
                Console.WriteLine("It is the enemy's turn");
            }
            else
            {
                Console.WriteLine("Wait who's turn is it?");
            }
        }

        public static void Broke(string item)
        {
            if (item == "Weapon")
            {
                Console.WriteLine("\nYour weapon broke!");
            }
            if (item == "Armour")
            {
                Console.WriteLine("\nA piece of your armour broke!");
            }
        }

        public static void DisplayTreasure(List<object> treasure)
        {
            foreach(object t in treasure)
            {
                if (t.GetType() == typeof(Weapon))
                {
                    Console.WriteLine(((Weapon)(t)).Name);
                }
                else if (t.GetType() == typeof(Armour))
                {
                    Console.WriteLine(((Armour)(t)).Name);
                }
                else if (t.GetType() == typeof(Item))
                {
                    Console.WriteLine(((Item)(t)).Name);
                }
                else if (t.GetType() == typeof(Consumable))
                {
                    Console.WriteLine(((Consumable)(t)).Name);
                }
                else if (t.GetType() == typeof(Spell))
                {
                    Console.WriteLine(((Spell)(t)).Name);
                }
            }
        }

        public static void DisplayItemInfo(object item)
        {
            if (item.GetType() == typeof(Weapon))
            {
                
            }
            else if (item.GetType() == typeof(Armour))
            {
                
            }
            else if (item.GetType() == typeof(Item))
            {
                
            }
            else if (item.GetType() == typeof(Consumable))
            {
                
            }
            else if (item.GetType() == typeof(Spell))
            {
                
            }
        }

        public static void ShowEquipped(Player player)
        {
            try { Console.WriteLine("Weapon: " + player.EquippedWep.Name); }
            catch (NullReferenceException) { Console.WriteLine("Weapon: none"); }

            try { Console.WriteLine("Armour Slot One: " + player.ArmourSlotOne.Name); }
            catch (NullReferenceException) { Console.WriteLine("Armour Slot One: none"); }

            try { Console.WriteLine("Armour Slot Two: " + player.ArmourSlotTwo.Name); }
            catch (NullReferenceException) { Console.WriteLine("Armour Slot Two: none"); }

            try { Console.WriteLine("Armour Slot Three: " + player.ArmourSlotThree.Name); }
            catch (NullReferenceException) { Console.WriteLine("Armour Slot Three: none"); }

            try { Console.WriteLine("Item Slot One: " + player.ItemSlotOne.Name); }
            catch (NullReferenceException) { Console.WriteLine("Item Slot One: none"); }

            try { Console.WriteLine("Item Slot Two: " + player.ItemSlotTwo.Name); }
            catch (NullReferenceException) { Console.WriteLine("Item Slot Two: none"); }

            try { Console.WriteLine("Item Slot Three: " + player.ItemSlotThree.Name); }
            catch (NullReferenceException) { Console.WriteLine("Item Slot Three: none"); }  
        }

        public static void InspectItem(string item)
        {
            Console.Clear();
            foreach (Object o in GM.player.Inventory)
            {
                if (o.GetType() == typeof(Weapon))
                {
                    if (((Weapon)(o)).Name.ToLower() == item)
                    {
                        Console.WriteLine("Weapon Name: " + ((Weapon)(o)).Name);
                        Console.WriteLine("Weapon Type: " + ((Weapon)(o)).WeaponType);
                        Console.WriteLine("Damage Type: " + ((Weapon)(o)).DamageType);
                        Console.WriteLine("Damage: " + ((Weapon)(o)).Damage);
                        GM.subPhase = "None";
                    }
                }
                else if (o.GetType() == typeof(Armour))
                {
                    if (((Armour)(o)).Name.ToLower() == item)
                    {
                        Console.WriteLine("Armour Name: " + ((Armour)(o)).Name);
                        Console.WriteLine("Armour Type: " + ((Armour)(o)).ArmourType);
                        Console.WriteLine("Protection Type: " + ((Armour)(o)).ProtectionType);
                        Console.WriteLine("Protection: " + ((Armour)(o)).Protection);
                        GM.subPhase = "None";
                    }
                }
                else if (o.GetType() == typeof(Item))
                {
                    if (((Item)(o)).Name.ToLower() == item)
                    {
                        Console.WriteLine("Item Name: " + ((Item)(o)).Name);
                        Console.WriteLine("Positive Stat: " + ((Item)(o)).BuffStat);
                        Console.WriteLine("Value: " + ((Item)(o)).BuffValue);
                        Console.WriteLine("Negative Stat: " + ((Item)(o)).NerfStat);
                        Console.WriteLine("Value: " + ((Item)(o)).NerfValue);
                        GM.subPhase = "None";
                    }
                }
                else if (o.GetType() == typeof(Consumable))
                {
                    if (((Consumable)(o)).Name.ToLower() == item)
                    {
                        Console.WriteLine("Consumable Name: " + ((Consumable)(o)).Name);
                        Console.WriteLine("Consumable Type: " + ((Consumable)(o)).Type);
                        Console.WriteLine("Value: " + ((Consumable)(o)).Value);
                        GM.subPhase = "None";
                    }
                }
            }
        }

        public static void DisplayModules()
        {
            if (MM.Modules.Count == 0)
            {
                MM.GetModules();
            }
            foreach (string m in MM.Modules)
            {
                Console.WriteLine(m);
            }
        }
    }
}
