using Game.Managers;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Game.Objects
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

        public static int floor = 1;
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
                switch (command)
                {
                    case "cancel":
                        subPhase = "None";
                        break;
                    case "inventory":
                        Console.Clear();
                        DM.ShowInventory(player);
                        break;
                    case "stats":
                        Console.Clear();
                        DM.ShowStats(player);
                        break;
                    case "help":
                        Console.Clear();
                        Console.WriteLine(@"
cancel - Stops equiping
inventory - Displays your inventory
stats - Displays your stats
next - Move to the next room");
                        break;
                    default:
                        Console.Clear();

                        string isItem = IvM.IsInputItem(command);
                        if (isItem == "None")
                        {
                            Console.Clear();
                            Console.WriteLine("\nType 'help' to view all commands");
                        }
                        else if (isItem == "Armour" || isItem == "Item")
                        {
                            subPhase = "SlotSelection";
                        }
                        else
                        {
                            subPhase = "None";
                        }
                        break;

                }
            }
            else if (subPhase == "SlotSelection")
            {
                switch (command)
                {
                    case "1":
                        if (equipType == "Armour")
                        {
                            IvM.CheckAlreadyEquipped(equipObject, "Armour");
                            player.ArmourSlotOne = (Armour)(equipObject);
                            subPhase = "None";
                            Console.Clear();
                        }
                        else if (equipType == "Item")
                        {
                            IvM.CheckAlreadyEquipped(equipObject, "Item");
                            player.ItemSlotOne = (Item)(equipObject);
                            subPhase = "None";
                            Console.Clear();
                        }
                        break;
                    case "2":
                        if (equipType == "Armour")
                        {
                            IvM.CheckAlreadyEquipped(equipObject, "Armour");
                            player.ArmourSlotTwo = (Armour)(equipObject);
                            subPhase = "None";
                            Console.Clear();
                        }
                        else if (equipType == "Item")
                        {
                            IvM.CheckAlreadyEquipped(equipObject, "Item");
                            player.ItemSlotTwo = (Item)(equipObject);
                            subPhase = "None";
                            Console.Clear();
                        }
                        break;
                    case "3":
                        if (equipType == "Armour")
                        {
                            IvM.CheckAlreadyEquipped(equipObject, "Armour");
                            player.ArmourSlotThree = (Armour)(equipObject);
                            subPhase = "None";
                            Console.Clear();
                        }
                        else if (equipType == "Item")
                        {
                            IvM.CheckAlreadyEquipped(equipObject, "Item");
                            player.ItemSlotThree = (Item)(equipObject);
                            subPhase = "None";
                            Console.Clear();
                        }
                        break;
                    default:
                        Console.Clear();
                        subPhase = "Equipping";
                        break;
                }
            }
            else if (subPhase == "Inspecting")
            {
                DM.InspectItem(command);
            }
            else if (subPhase == "Modules")
            {
                switch (command)
                {
                    case "load":
                        Console.Clear();
                        Console.WriteLine("\nWhich module would you like to load?");
                        loadUnload = "load";
                        subPhase = "LoadUnload";
                        break;
                    case "unload":
                        Console.Clear();
                        Console.WriteLine("\nWhich module would you like to unload?");
                        loadUnload = "unload";
                        subPhase = "LoadUnload";
                        break;
                    case "modules":
                        Console.Clear();
                        DM.DisplayModules();
                        break;
                    case "help":
                        Console.Clear();
                        Console.WriteLine(@"
load - Load a module
unload - Unloads a module
modules - Show modules
return - Exits the game");
                        break;
                    case "return":
                        Console.Clear();
                        Menu();
                        subPhase = "None";
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("\nType 'help' to view all commands");
                        break;
                }
            }
            else if (subPhase == "LoadUnload")
            {
                Console.Clear();
                if (loadUnload == "load")
                    MM.LoadModule(command);
                else if (loadUnload == "unload")
                    MM.UnloadModule(command);
                subPhase = "Modules";
            }
            else if (Phase == "Menu")
            {
                switch (command)
                {
                    case "start":
                        Console.Clear();
                        Init();
                        break;
                    case "options":
                        Console.Clear();
                        Menu();
                        Console.WriteLine("\nOpen options menu");
                        break;
                    case "modules":
                        Console.Clear();
                        subPhase = "Modules";
                        DM.DisplayModules();
                        break;
                    case "help":
                        Console.Clear();
                        Menu();
                        Console.WriteLine(@"
start - Starts the game
options - Opens the options menu
modules - Opens the modules menu
exit - Exits the game");
                        break;
                    case "exit":
                        GameActive = false;
                        break;
                    default:
                        Console.Clear();
                        Menu();
                        Console.WriteLine("\nType 'help' to view all commands");
                        break;
                }
            }
            else if (Phase == "Init")
            {

            }
            else if (Phase == "RoomFinish")
            {
                switch (command)
                {
                    case "inventory":
                        Console.Clear();
                        DM.ShowInventory(player);
                        break;
                    case "stats":
                        Console.Clear();
                        DM.ShowStats(player);
                        break;
                    case "next":
                        Console.Clear();
                        RoomEnter();
                        break;
                    case "equip":
                        Console.Clear();
                        subPhase = "Equipping";
                        break;
                    case "equipped":
                        Console.Clear();
                        DM.ShowEquipped(player);
                        break;
                    case "inspect":
                        Console.Clear();
                        subPhase = "Inspecting";
                        break;
                    case "help":
                        Console.Clear();
                        Console.WriteLine(@"
inventory - Displays your inventory
stats - Displays your stats
inspect - Checks the effects of an item
equip - Change your equipment
equipped - Check your equipped items
next - Move to the next room");
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("\nType 'help' to view all commands");
                        break;
                }
            }
            else if (Phase == "RoomEnter")
            {
                switch (command)
                {
                    case "inventory":
                        Console.Clear();
                        DM.ShowInventory(player);
                        break;
                    case "stats":
                        Console.Clear();
                        DM.ShowStats(player);
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
            else if (Phase == "CombatPlayerTurn")
            {
                switch (command)
                {
                    case "inventory":
                        Console.Clear();
                        DM.ShowInventory(player);
                        break;
                    case "stats":
                        Console.Clear();
                        DM.ShowStats(player);
                        break;
                    case "check":
                        Console.Clear();
                        if (room == 6) { DM.ShowBattleUI(player, floorBoss, true); }
                        else { DM.ShowBattleUI(player, roomMonster, false); }

                        break;
                    case "attack":
                        Console.Clear();
                        int damage = EM.CalculatePlayerMeleeDamage(player);
                        roomMonster.CurrentHealth -= damage;
                        Console.WriteLine("You dealt " + damage + " points of damage to the " + roomMonster.Name);
                        // player.EquippedWep.Durability -= 1;

                        Console.WriteLine("DEBUG: current monster hp: " + roomMonster.CurrentHealth);

                        Thread.Sleep(2000);

                        if (EM.CheckMonsterDeath(roomMonster))
                        {
                            Console.Clear();
                            Console.WriteLine("The " + roomMonster.Name + " was defeated!");
                            player.Gold += EM.GetGold(roomMonster);
                            Thread.Sleep(2000);
                            RoomFinish();
                        }
                        else
                        {
                            CombatEnemyTurn();
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
            }
            else if (room == 3 || room == 7) // treasure room
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
            if (room == 6) { DM.ShowBattleUITurn(player, roomMonster, 0, true); }
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
