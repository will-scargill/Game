using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Objects
{
    class Consumable
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public double Value { get; set; }
        public int Rarity { get; set; }

        public Consumable(string name, string type, double value, int rarity)
        {
            this.Name = name;
            this.Type = type;
            this.Value = value;
            this.Rarity = rarity;
        }
    }
}
