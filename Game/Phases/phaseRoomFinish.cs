using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Game.Managers;


namespace Game.Phases
{
    class phaseRoomFinish
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
                case "next":
                    Console.Clear();
                    GM.RoomEnter();
                    break;
                case "equip":
                    Console.Clear();
                    GM.subPhase = "Equipping";
                    break;
                case "equipped":
                    Console.Clear();
                    DM.ShowEquipped(GM.player);
                    break;
                case "inspect":
                    Console.Clear();
                    GM.subPhase = "Inspecting";
                    break;
                case "check":
                    Console.Clear();
                    Console.WriteLine("\nFloor: " + GM.floor.ToString() + " | Room: " + GM.room.ToString());
                    break;
                case "help":
                    Console.Clear();
                    Console.WriteLine(@"
inventory - Displays your inventory
stats - Displays your stats
inspect - Checks the effects of an item
equip - Change your equipment
equipped - Check your equipped items
check - Checks the floor and room number
next - Move to the next room");
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("\nType 'help' to view all commands");
                    break;
            }
        }
    }
}
