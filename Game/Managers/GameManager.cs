using Game.Managers;
using System;
using System.Threading;

namespace Game.Objects
{
    static class GM // Game Manager
    {
        public static bool GameActive = true;
        public static string Phase = null;

        public static int floor = 1;
        public static int room = 0;

        public static Player player;
        public static Monster roomMonster;

        public static void ProcCommand(string command)
        {
            command = command.ToLower();
            if (Phase == null)
            {
                if (command == "debug")
                {

                }
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
                        Menu();
                        Console.WriteLine("\nOpen modules menu");
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
                    case "help":
                        Console.Clear();
                        Console.WriteLine(@"
inventory - Displays your inventory
stats - Displays your stats
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
                // lol idk you shouldnt be here
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
                        DM.ShowBattleUI(player, roomMonster);
                        break;
                    case "attack":
                        Console.Clear();
                        int damage = EM.CalculatePlayerMeleeDamage(player);
                        roomMonster.CurrentHealth -= damage;
                        Console.WriteLine("You dealt " + damage + " points of damage to the " + roomMonster.Name);
                        player.EquippedWep.Durability -= 1;

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
            if (room == 7) // finished large treasure room after boss
            {
                room = 0;
                floor++;
            }
            else if (room == 3 || room == 6) // treasure room
            {
                
            }
            else if (room == 5) // boss room
            {
                
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
            DM.ShowBattleUITurn(player, roomMonster, 0);
        }

        public static void CombatEnemyTurn()
        {
            Console.Clear();
            Phase = "CombatEnemyTurn";
            DM.ShowBattleUITurn(player, roomMonster, 1);
            Thread.Sleep(2000);
            int damage = EM.CalculateMonsterDamage(roomMonster, player);
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
