using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Objects
{
    class Weapon
    {
        public string Name { get; set; }
        public int Durability { get; set; }
        public string WeaponType { get; set; }
        public string DamageType { get; set; }
        public double Damage { get; set; }
        public int Rarity { get; set; }

        public Weapon(string name, int d, string wtype, string dtype, double damage, int rarity)
        {
            this.Name = name;
            this.Durability = d;
            this.WeaponType = wtype;
            this.DamageType = dtype;
            this.Damage = damage;
            this.Rarity = rarity;
        }
    }
}
