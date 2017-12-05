using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllSharpmon.dll
{
    [Serializable]
    public class Attack
    {
        public string Name { get; set; }
        public int Damage { get; set; }
        public int BoostPower { get; set; }
        public int BoostDefense { get; set; }
        public int BoostDodge { get; set; }

        public Attack(string name, int? damage, int? boostPower, int? boostDefense, int? boostDodge)
        {
            Name = name;
            Damage = damage.Value;
            BoostPower = boostPower.Value;
            BoostDefense = boostDefense.Value;
            BoostDodge = boostDodge.Value;
        }
    }
}
