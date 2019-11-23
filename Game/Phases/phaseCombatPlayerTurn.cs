using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Game.Managers;
using Game.Objects;

namespace Game.Phases
{
    class phaseCombatPlayerTurn
    {
        public static void Parse(string command)
        {
            switch (command)
            {
                case "inventory":
                    Console.Clear();
                    DM.ShowInventory(GM.player);
                    break;
                case "stats":
                    Console.Clear();
                    DM.ShowStats(GM.player);
                    break;
                case "check":
                    Console.Clear();
                    if (GM.room == 6) { DM.ShowBattleUI(GM.player, GM.floorBoss, true); }
                    else { DM.ShowBattleUI(GM.player, GM.roomMonster, false); }

                    break;
                case "attack":
                    Console.Clear();
                    int damage = EM.CalculatePlayerMeleeDamage(GM.player);
                    if (GM.room == 6) { GM.floorBoss.CurrentHealth -= damage; }
                    else { GM.roomMonster.CurrentHealth -= damage; }

                    if (GM.room == 6) { Console.WriteLine("You dealt " + damage + " points of damage to the " + GM.floorBoss.Name); }
                    else { Console.WriteLine("You dealt " + damage + " points of damage to the " + GM.roomMonster.Name); }

                    if (GM.room == 6) { Console.WriteLine("DEBUG: current monster hp: " + GM.floorBoss.CurrentHealth); }
                    else { Console.WriteLine("DEBUG: current monster hp: " + GM.roomMonster.CurrentHealth); }
                    

                    Thread.Sleep(2000);

                    if (GM.room != 6 && EM.CheckMonsterDeath(GM.roomMonster))
                    {
                        Console.Clear();
                        Console.WriteLine("The " + GM.roomMonster.Name + " was defeated!");
                        GM.player.Gold += EM.GetGold(GM.roomMonster);
                        Thread.Sleep(2000);
                        GM.RoomFinish();
                    }
                    else if (GM.room == 6 && EM.CheckBossDeath(GM.floorBoss))
                    {
                        Console.Clear();
                        Console.WriteLine("The " + GM.floorBoss.Name + " was defeated!");
                        GM.player.Gold += 200;
                        Thread.Sleep(2000);
                        GM.RoomFinish();
                    }
                    else
                    {
                        GM.CombatEnemyTurn();
                    }
                    break;
                case "help":
                    Console.Clear();
                    Console.WriteLine(@"
inventory - Displays your inventory
stats - Displays your stats
check - Shows the monster and other battle information
attack - Attack using your weapon
magic - Use a spell
item - Use an item from your inventory");
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("\nType 'help' to view all commands");
                    break;
            }
        }
    }
}
