using Game.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Managers
{
    static class IvM
    {
        public static string IsInputItem(string input)
        {
            foreach (Object o in GM.player.Inventory)
            {
                if (o.GetType() == typeof(Weapon))
                {
                    if (((Weapon)(o)).Name.ToLower() == input)
                    {
                        GM.player.EquippedWep = (Weapon)(o);
                        return "Weapon";
                    }
                }
                else if (o.GetType() == typeof(Armour))
                {
                    if (((Armour)(o)).Name.ToLower() == input)
                    {
                        GM.subPhase = "SlotSelection";
                        GM.equipType = "Armour";
                        GM.equipObject = o;
                        return "Armour";
                    }
                }
                else if (o.GetType() == typeof(Item))
                {
                    if (((Item)(o)).Name.ToLower() == input)
                    {
                        GM.subPhase = "SlotSelection";
                        GM.equipType = "Item";
                        GM.equipObject = o;
                        return "Item";
                    }
                }
            }
            return "None";
        }
      

        public static void CheckAlreadyEquipped(object o, string type)
        {
            if (type == "Armour")
            {
                Armour armour = (Armour)(o);
                if (GM.player.ArmourSlotOne == armour) { GM.player.ArmourSlotOne = null; }
                if (GM.player.ArmourSlotTwo == armour) { GM.player.ArmourSlotTwo = null; }
                if (GM.player.ArmourSlotThree == armour) { GM.player.ArmourSlotThree = null; }
            }
            else if (type == "Item")
            {
                Item item = (Item)(o);
                if (GM.player.ItemSlotOne == item) { GM.player.ItemSlotOne = null; }
                if (GM.player.ItemSlotTwo == item) { GM.player.ItemSlotTwo = null; }
                if (GM.player.ItemSlotThree == item) { GM.player.ItemSlotThree = null; }
            }
        }

        public static void CheckItemEffects(string equip, Item item)
        {
            if (equip == "Equipped")
            {
                switch (item.BuffStat)
                {
                    case "Strength":
                        GM.player.Strength += item.BuffValue;
                        break;
                    case "Intelligence":
                        GM.player.Intelligence += item.BuffValue;
                        break;
                    case "Dexterity":
                        GM.player.Dexterity += item.BuffValue;
                        break;
                    case "Constitution":
                        GM.player.Constitution += item.BuffValue;
                        break;
                    case "Luck":
                        GM.player.Luck += item.BuffValue;
                        break;
                }

                switch (item.NerfStat)
                {
                    case "Strength":
                        GM.player.Strength -= item.NerfValue;
                        break;
                    case "Intelligence":
                        GM.player.Intelligence -= item.NerfValue;
                        break;
                    case "Dexterity":
                        GM.player.Dexterity -= item.NerfValue;
                        break;
                    case "Constitution":
                        GM.player.Constitution -= item.NerfValue;
                        break;
                    case "Luck":
                        GM.player.Luck -= item.NerfValue;
                        break;
                }
            }
            else if (equip == "Unequipped")
            {
                switch (item.BuffStat)
                {
                    case "Strength":
                        GM.player.Strength -= item.BuffValue;
                        break;
                    case "Intelligence":
                        GM.player.Intelligence -= item.BuffValue;
                        break;
                    case "Dexterity":
                        GM.player.Dexterity -= item.BuffValue;
                        break;
                    case "Constitution":
                        GM.player.Constitution -= item.BuffValue;
                        break;
                    case "Luck":
                        GM.player.Luck -= item.BuffValue;
                        break;
                }

                switch (item.NerfStat)
                {
                    case "Strength":
                        GM.player.Strength += item.NerfValue;
                        break;
                    case "Intelligence":
                        GM.player.Intelligence += item.NerfValue;
                        break;
                    case "Dexterity":
                        GM.player.Dexterity += item.NerfValue;
                        break;
                    case "Constitution":
                        GM.player.Constitution += item.NerfValue;
                        break;
                    case "Luck":
                        GM.player.Luck += item.NerfValue;
                        break;
                }
            }
        }
    }
}
