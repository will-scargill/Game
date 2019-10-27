using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Objects
{
    class Player
    {
        public int Health { get; set; }
        public int XP { get; set; }
        public int CurrentHealth { get; set; }
        public int Mana { get; set; }
        public int CurrentMana { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Luck { get; set; }
        public int Intelligence { get; set; }
        public Weapon EquippedWep { get; set; }
        public string Magic { get; set; }
        public Armour ArmourSlotOne { get; set; }
        public Armour ArmourSlotTwo { get; set; }
        public Armour ArmourSlotThree { get; set; }
        public Item ItemSlotOne { get; set; }
        public Item ItemSlotTwo { get; set; }
        public Item ItemSlotThree { get; set; }
        public List<object> Inventory { get; set; }
        public int Gold { get; set; }

        public bool EquipWeapon(Weapon w)
        {
            if (this.Inventory.Contains(w))
            {
                this.EquippedWep = w;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool EquipArmour(Armour a, int slot)
        {
            if (this.Inventory.Contains(a))
            {
                switch (slot)
                {
                    case 1:
                        this.ArmourSlotOne = a;
                        return true;
                    case 2:
                        this.ArmourSlotTwo = a;
                        return true;
                    case 3:
                        this.ArmourSlotThree = a;
                        return true;
                    default:
                        return false;
                }
            }
            else
            {
                return false;
            }
        }

        public void UseConsumable(Consumable c)
        {
            if (this.Inventory.Contains(c))
            {
                switch (c.Type)
                {
                    case "H":
                        break;

                }
            }
        }

        public bool EquipItem(Item i, int slot)
        {
            if (this.Inventory.Contains(i))
            {
                switch (slot)
                {
                    case 1:
                        this.ItemSlotOne = i;
                        return true;
                    case 2:
                        this.ItemSlotTwo = i;
                        return true;
                    case 3:
                        this.ItemSlotThree = i;
                        return true;
                    default:
                        return false;
                }
            }
            else
            {
                return false;
            }
        }

        public Player(int hp, int mn, int str, int dex, int con, int luck, int inte)
        {
            this.Health = hp;
            this.XP = 0;
            this.CurrentHealth = hp;
            this.Mana = mn;
            this.CurrentMana = mn;
            this.Strength = str;
            this.Dexterity = dex;
            this.Constitution = con;
            this.Luck = luck;
            this.Intelligence = inte;
            this.EquippedWep = null;
            this.Magic = null;
            this.ArmourSlotOne = null;
            this.ArmourSlotTwo = null;
            this.ArmourSlotThree = null;
            this.ItemSlotOne = null;
            this.ItemSlotTwo = null;
            this.ItemSlotThree = null;
            this.Inventory = new List<object>();
            this.Gold = 0;
        }
    }
}
