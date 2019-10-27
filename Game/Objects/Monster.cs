using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Objects
{
    class Monster
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int CurrentHealth { get; set; }
        public int Mana { get; set; }
        public int CurrentMana { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Luck { get; set; }
        public int Intelligence { get; set; }
        public string WeaponType { get; set; }
        public string DamageType { get; set; }
        public double Damage { get; set; }

        public bool IsBoss { get; set; }
        public int Rarity { get; set; }


        public Monster(string name, int hp, int mn, int str, int dex, int con, int luck, int inte, string wtype, string dtype, double d, bool ib, int r)
        {
            this.Name = name;
            this.Health = hp;
            this.CurrentHealth = hp;
            this.Mana = mn;
            this.CurrentMana = mn;
            this.Strength = str;
            this.Dexterity = dex;
            this.Constitution = con;
            this.Luck = luck;
            this.Intelligence = inte;
            this.WeaponType = wtype;
            this.DamageType = dtype;
            this.Damage = d;
            this.IsBoss = ib;
            this.Rarity = r;
        }
    }
}
