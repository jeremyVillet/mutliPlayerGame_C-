using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DllSharpmon.dll
{
    public class ItemPlayer
    {
        public string Name { get; private set; }     
        public int? Price { get; set; }
        public string Description { get; private set; }
        public int? AddHp { get; private set; }
        public int? AddLevel { get; private set; }
        public ItemPlayer(string name,int? price,string description,int? addHp,int? addLevel)
        {
            Name = name;
            Price = price;
            Description = description;
            AddHp = addHp;
            AddLevel = addLevel;
        }

    }
}
