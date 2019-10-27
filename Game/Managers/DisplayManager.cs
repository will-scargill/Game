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
        }

        public static void ShowBattleUI(Player player, Monster monster)
        {
            Console.WriteLine("HP: " + player.CurrentHealth + "/" + player.Health + " | Mana: " + player.CurrentMana + "/" + player.Mana + "\nCurrent weapon: " + player.EquippedWep.Name);
            Console.WriteLine("------------------------------------------");
            if (monster.IsBoss == true)
            {
                Console.WriteLine("ehh its a boss lol");
            }
            else
            {
                Console.WriteLine("Enemy in room: " + monster.Name);
            }
        }

        public static void ShowBattleUITurn(Player player, Monster monster, int turn)
        {
            ShowBattleUI(player, monster);
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
    }
}
