using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Objects
{
    class Spell
    {
        public string Name { get; set; }
        public int ManaCost { get; set; }
        public string MagicType { get; set; }
        public string DamageType { get; set; }
        public double Damage { get; set; }
        public int Rarity { get; set; }

        public Spell(string name, int mc, string mtype, string dtype, double damage, int r)
        {
            this.Name = name;
            this.ManaCost = mc;
            this.MagicType = mtype;
            this.DamageType = dtype;
            this.Damage = damage;
            this.Rarity = r;
        }
    }
}
