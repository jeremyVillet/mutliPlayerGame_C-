using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DllSharpmon.dll
{
    public class Player
    {
        public string Name { get; set; }
        public List<Sharpmon> SharpmonsPlayer { get; set; }
        public Sharpmon CurrentSharpmon { get; set; }
        public int SharpDollars { get; set; }
        public List<ItemPlayer> ItemsPlayer { get; set; }

        public Player(string name, List<Sharpmon> sharpmonsPlayer, Sharpmon currentSharpmon,int sharpDollars, List<ItemPlayer> itemsPlayer)
        {
            Name = name;
            SharpmonsPlayer = sharpmonsPlayer;
            CurrentSharpmon = currentSharpmon;
            SharpDollars = sharpDollars;
            ItemsPlayer = itemsPlayer;
        }


    }
}
