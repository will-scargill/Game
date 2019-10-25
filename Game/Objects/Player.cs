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
        public string Inventory { get; set; }

        public void EquipWeapon()

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
