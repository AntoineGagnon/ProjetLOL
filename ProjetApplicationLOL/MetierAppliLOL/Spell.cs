using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetierAppliLOL
{
    public struct Spell
    {
        public String Name;
        public String Description;
        public String IconPath;

        public Spell(String name, String description)
        {
            Name = name;
            Description = description;
            IconPath = "";
        }




    }
}
