using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Game.Managers;
using Game.Objects;

namespace Game.Phases.subPhases
{
    class subPhaseSlotSelection
    {
        public static void Parse(string command)
        {
            switch (command)
            {
                case "1":
                    if (GM.equipType == "Armour")
                    {
                        IvM.CheckAlreadyEquipped(GM.equipObject, "Armour");
                        GM.player.ArmourSlotOne = (Armour)(GM.equipObject);
                        GM.subPhase = "None";
                        Console.Clear();
                    }
                    else if (GM.equipType == "Item")
                    {
                        IvM.CheckAlreadyEquipped(GM.equipObject, "Item");
                        GM.player.ItemSlotOne = (Item)(GM.equipObject);
                        IvM.CheckItemEffects("Equipped", ((Item)(GM.equipObject)));
                        GM.subPhase = "None";
                        Console.Clear();
                    }
                    break;
                case "2":
                    if (GM.equipType == "Armour")
                    {
                        IvM.CheckAlreadyEquipped(GM.equipObject, "Armour");
                        GM.player.ArmourSlotTwo = (Armour)(GM.equipObject);
                        GM.subPhase = "None";
                        Console.Clear();
                    }
                    else if (GM.equipType == "Item")
                    {
                        IvM.CheckAlreadyEquipped(GM.equipObject, "Item");
                        GM.player.ItemSlotTwo = (Item)(GM.equipObject);
                        IvM.CheckItemEffects("Equipped", ((Item)(GM.equipObject)));
                        GM.subPhase = "None";
                        Console.Clear();
                    }
                    break;
                case "3":
                    if (GM.equipType == "Armour")
                    {
                        IvM.CheckAlreadyEquipped(GM.equipObject, "Armour");
                        GM.player.ArmourSlotThree = (Armour)(GM.equipObject);
                        GM.subPhase = "None";
                        Console.Clear();
                    }
                    else if (GM.equipType == "Item")
                    {
                        IvM.CheckAlreadyEquipped(GM.equipObject, "Item");
                        GM.player.ItemSlotThree = (Item)(GM.equipObject);
                        IvM.CheckItemEffects("Equipped", ((Item)(GM.equipObject)));
                        GM.subPhase = "None";
                        Console.Clear();
                    }
                    break;
                default:
                    Console.Clear();
                    GM.subPhase = "Equipping";
                    break;
            }
        }
    }
}
