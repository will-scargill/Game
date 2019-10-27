using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Objects
{
    class Item
    {
        public string Name { get; set; }
        public string BuffStat { get; set; }
        public int BuffValue { get; set; }
        public string NerfStat { get; set; }
        public int NerfValue { get; set; }
        public int Rarity { get; set; }

        public Item(string name, string bstat, int bvalue, string nstat, int nvalue, int rarity)
        {
            this.Name = name;
            this.BuffStat = bstat;
            this.BuffValue = bvalue;
            this.NerfStat = nstat;
            this.NerfValue = nvalue;
            this.Rarity = rarity;
        }
    }
}
