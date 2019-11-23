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
                    case "StatUpgrade":
                        Console.WriteLine("\nWhat stat would you like to upgrade?\n");
                        break;
                    case "None":
                        if (GM.player != null && GM.Phase == "RoomFinish")
                        {
                            Console.WriteLine("\nFloor: " + GM.floor.ToString() + " | Room: " + GM.room.ToString());
                        }
                        Console.WriteLine("\nWhat would you like to do?\n");
                        break;
                    default:
                        Console.WriteLine("Error - Misspelt subPhase reference");
                        break;
                }
                string command = Console.ReadLine();
                switch (command)
                {
                    case "debug_restart":
                        Console.Clear();
                        GM.Init();
                        break;
                    case "debug_kill":
                        try { GM.roomMonster.Health = 0; }
                        catch (System.NullReferenceException) { }
                        try { GM.floorBoss.Health = 0; }
                        catch (System.NullReferenceException) { }
                        break;
                    case "debug_op":
                        GM.player.Inventory.Add(new Weapon(
                            "Debug Weapon",
                            "Piercing",
                            "Physical",
                            99999,
                            0));
                        GM.player.Inventory.Add(new Armour(
                            "Debug Armour",
                            "Chestplate",
                            "Physical",
                            99999,
                            0));
                        break;
                    case "debug_stat":
                        GM.player.Intelligence = 99;
                        GM.player.Mana += 2475;
                        GM.player.CurrentMana += 2475;
                        GM.player.Strength = 99;
                        GM.player.Constitution = 99;
                        GM.player.Health += 990;
                        GM.player.CurrentHealth += 990;
                        GM.player.Dexterity = 99;
                        GM.player.Luck = 99;
                        break;
                    default:
                        GM.ProcCommand(command);
                        break;
                }
            }
        }
    }
}
