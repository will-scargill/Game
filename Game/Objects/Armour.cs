using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Objects
{
    class Armour
    {
        public string Name { get; set; }
        public int Durability { get; set; }
        public string ArmourType { get; set; }
        public string ProtectionType { get; set; }
        public double Protection { get; set; }
        public int Rarity { get; set; }

        public Armour(string name, int d, string atype, string ptype, double proc, int rarity)
        {
            this.Name = name;
            this.Durability = d;
            this.ArmourType = atype;
            this.ProtectionType = ptype;
            this.Protection = proc;
            this.Rarity = rarity;
        }
    }
}
