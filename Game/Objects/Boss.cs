using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Objects
{
    class Boss
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int CurrentHealth { get; set; }
        public int Mana { get; set; }
        public string Type { get; set; }
        public int CurrentMana { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Luck { get; set; }
        public int Intelligence { get; set; }
        public string WeaponType { get; set; }
        public string DamageType { get; set; }
        public double Damage { get; set; }
        public string SpecialType { get; set; }
        public int SpecialValue { get; set; }
        public int SpecialCost { get; set; }
        public int Rarity { get; set; }


        public Boss(string name, int hp, int mn, string type, int str, int dex, int con, int luck, int inte, string wtype, string dtype, double d, string stype, int svalue, int scost, int r)
        {
            this.Name = name;
            this.Health = hp;
            this.CurrentHealth = hp;
            this.Mana = mn;
            this.Type = type;
            this.CurrentMana = mn;
            this.Strength = str;
            this.Dexterity = dex;
            this.Constitution = con;
            this.Luck = luck;
            this.Intelligence = inte;
            this.WeaponType = wtype;
            this.DamageType = dtype;
            this.Damage = d;
            this.SpecialType = stype;
            this.SpecialValue = svalue;
            this.SpecialCost = scost;
            this.Rarity = r;
        }
    }
}
