using Game.Managers;
using System;
using System.Collections.Generic;
using System.Threading;

using Game.Objects;
using Game.Phases;
using Game.Phases.subPhases;

namespace Game.Managers
{
    static class GM // Game Manager
    {
        public static bool GameActive = true;
        public static string Phase = null;
        public static string subPhase = "None";
        public static string equipType = null;
        public static object equipObject = null;
        public static bool bossUsedSpecial = false;
        public static string loadUnload = null;
        public static int UpgradesLeft = 0;

        public static int floor = 2;
        public static int room = 0;

        public static Player player;
        public static Monster roomMonster;
        public static Boss floorBoss;

        public static void ProcCommand(string command)
        {
            command = command.ToLower();
            if (Phase == null)
            {
                if (command == "debug")
                {

                }
            }
            else if (subPhase == "Equipping")
            {
                subPhaseEquipping.Parse(command);
            }
            else if (subPhase == "SlotSelection")
            {
                subPhaseSlotSelection.Parse(command);
            }
            else if (subPhase == "Inspecting")
            {
                DM.InspectItem(command);
            }
            else if (subPhase == "Modules")
            {
                subPhaseModules.Parse(command);
            }
            else if (subPhase == "LoadUnload")
            {
                subPhaseLoadUnload.Parse(command);
            }
            else if (subPhase == "StatUpgrade")
            {
                subPhaseStatUpgrade.Parse(command);
            }
            else if (Phase == "Menu")
            {
                phaseMenu.Parse(command);
            }
            else if (Phase == "Init")
            {
                // 
            }
            else if (Phase == "RoomFinish")
            {
                phaseRoomFinish.Parse(command);
            }
            else if (Phase == "RoomEnter")
            {
                phaseRoomEnter.Parse(command);
            }
            else if (Phase == "CombatPlayerTurn")
            {
                phaseCombatPlayerTurn.Parse(command);
            }
            else if (Phase == "CombatEnemyTurn")
            {
                // hackerman
            }
        }
      
        public static void Menu()
        {
            Phase = "Menu";
            Console.WriteLine(@"
______                                      _____                    _           
|  _  \                                    /  __ \                  | |          
| | | |_   _ _ __   __ _  ___  ___  _ __   | /  \/_ __ __ ___      _| | ___ _ __ 
| | | | | | | '_ \ / _` |/ _ \/ _ \| '_ \  | |   | '__/ _` \ \ /\ / / |/ _ \ '__|
| |/ /| |_| | | | | (_| |  __/ (_) | | | | | \__/\ | | (_| |\ V  V /| |  __/ |   
|___/  \__,_|_| |_|\__, |\___|\___/|_| |_|  \____/_|  \__,_| \_/\_/ |_|\___|_|   
                    __/ |                                                        
                   |___/                                                         ");
        }

        public static void Init()
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

            player = p;

            Weapon startWeapon = LM.GenWeapon(1);
            Armour startArmour = LM.GenArmour(1);

            player.Inventory.Add(startWeapon);
            player.Inventory.Add(startArmour);

            player.EquipWeapon(startWeapon);
            player.EquipArmour(startArmour, 1);

            RoomFinish();          
        }

        public static void RoomFinish()
        {
            if (room == 6)
            {
                subPhase = "StatUpgrade";
                UpgradesLeft = 2;
            }
            Console.WriteLine("\nFloor: " + GM.floor.ToString() + " | Room: " + GM.room.ToString());
            Phase = "RoomFinish";
        }

        public static void RoomEnter()
        {
            Phase = "RoomEnter";
            room++;
            if (room == 8) // finished large treasure room after boss
            {
                room = 0;
                floor++;
                player.CurrentHealth = player.Health;
                player.CurrentMana = player.Mana;
            }
            if (room == 3 || room == 7) // treasure room
            {
                if (room == 3) // Regular treasure room
                {
                    List<object> treasure = LM.GenerateTreasure(2, floor, new Random());
                    foreach (object t in treasure)
                    {
                        player.Inventory.Add(t);
                    }
                    DM.DisplayTreasure(treasure);
                    RoomFinish();
                }
                else // Large treasure room
                {
                    List<object> treasure = LM.GenerateTreasure(4, floor, new Random());
                    foreach (object t in treasure)
                    {
                        player.Inventory.Add(t);
                    }
                    DM.DisplayTreasure(treasure);
                    RoomFinish();
                }
            }
            else if (room == 6) // boss room
            {
                floorBoss = EM.GetBossMonster(floor);

                if (player.Dexterity > floorBoss.Dexterity || player.Dexterity == floorBoss.Dexterity)
                {
                    CombatPlayerTurn();
                }
                else if (player.Dexterity < floorBoss.Dexterity)
                {
                    CombatEnemyTurn();
                }
            }
            else if (room == 0) // start of new floor
            {
                RoomFinish();
            }
            else // monster room
            {
                roomMonster = EM.GetMonster(floor);

                if (player.Dexterity > roomMonster.Dexterity || player.Dexterity == roomMonster.Dexterity)
                {
                    CombatPlayerTurn();
                }
                else if (player.Dexterity < roomMonster.Dexterity)
                {
                    CombatEnemyTurn();
                }
            }
        }

        public static void CombatPlayerTurn()
        {
            Console.Clear();
            Phase = "CombatPlayerTurn";
            if (room == 6) { DM.ShowBattleUITurn(player, floorBoss, 0, true); }
            else { DM.ShowBattleUITurn(player, roomMonster, 0, false); }
            
        }

        public static void CombatEnemyTurn()
        {
            Console.Clear();
            Phase = "CombatEnemyTurn";
            if (room == 6) { DM.ShowBattleUITurn(player, floorBoss, 1, true); }
            else { DM.ShowBattleUITurn(player, roomMonster, 1, false); }
            Thread.Sleep(2000);
            int damage;
            if (room == 6) { damage = EM.CalculateBossMonsterDamage(floorBoss, player); }
            else { damage = EM.CalculateMonsterDamage(roomMonster, player); }
            
            player.CurrentHealth -= damage;
            Console.Clear();
            Console.WriteLine("You took " + damage + " points of damage");
            Thread.Sleep(2000);
            if (EM.CheckGameOver(player))
            {
                GameOver();
            }
            else
            {
                CombatPlayerTurn();
            }
        }

        public static void GameOver()
        {
            Phase = "GameOver";
            Console.WriteLine("lmao you suck ass");
        }
    }
}
