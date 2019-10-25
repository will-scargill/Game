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
        public int Mana { get; set; }
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
        public List<object> Inventory { get; set; }

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

        public Player(int hp, int mn, int str, int dex, int con, int luck, int inte)
        {
            this.Health = hp;
            this.Mana = mn;
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
            this.Inventory = null;
            
        }
    }
}
