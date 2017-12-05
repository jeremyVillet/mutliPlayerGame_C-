using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllSharpmon.dll
{
    [Serializable]
     public class Sharpmon : ICloneable
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public int Experience { get; set; }
        public double CurrentHP { get; set; }
        public double MaxHP { get; set; }
        public double CurrentPower { get; set; }
        public double BasePower { get; set; }
        public double CurrentDefense { get; set; }
        public double BaseDefense { get; set; }
        public double CurrentDodge { get; set; }
        public double BaseDodge { get; set; }
        public double CurrentAccuracy { get; set; }
        public double BaseAccuracy { get; set; }
        public double Speed { get; set; }
        public List<Attack> Attacks { get; set; }

        public Sharpmon(string name, double? maxHP, double? basePower, double? baseDefense, double? baseDodge, double? baseAccuracy, double? speed, List<Attack> attacks)
        {
            Name = name;
            Level = 1;
            Experience = 0;
            CurrentHP = (double)maxHP.Value;
            MaxHP = (double)maxHP.Value;
            CurrentPower = (double)basePower.Value;
            BasePower = (double)basePower.Value;
            CurrentDefense = (double)baseDefense.Value;
            BaseDefense = (double)baseDefense.Value;
            CurrentDodge = (double)baseDodge.Value;
            BaseDodge = (double)baseDodge.Value;
            CurrentAccuracy = (double)baseAccuracy.Value;
            BaseAccuracy = (double)baseAccuracy.Value;
            Speed = (double)speed.Value;
            Attacks = attacks;
        }

        public void SharpmonAttack(Attack sharpmonAttacks, Sharpmon targetSharpmon)
        {

            double attackSuccess = this.CurrentAccuracy / (this.CurrentAccuracy + targetSharpmon.CurrentDodge) + 0.1;

            Random rand = new Random();
            if (rand.NextDouble() > attackSuccess)
            {
                if (sharpmonAttacks.Damage != 0)
                {
                    double damage = (this.CurrentPower / sharpmonAttacks.Damage * targetSharpmon.CurrentDefense) * 10;
                    this.CurrentHP -= damage;
                    Console.WriteLine("{0} à atteint {1} et à infligé {2} points de dommages à  : {3}  ", sharpmonAttacks.Name , targetSharpmon.Name , damage ,targetSharpmon.Name);
                }
                else if (sharpmonAttacks.BoostPower != 0)
                {
                    this.CurrentPower += sharpmonAttacks.BoostPower;
                    Console.WriteLine(this.Name + " à reussi sa canalisation,  puissance boostée de  " + sharpmonAttacks.BoostPower + " points  ");
                }
                else if (sharpmonAttacks.BoostDefense != 0)
                {
                    this.CurrentDefense += sharpmonAttacks.BoostDefense;
                    Console.WriteLine(this.Name + " à reussi sa canalisation, défense boostée de  " + sharpmonAttacks.BoostDefense + " points   ");
                }
                else
                {
                    this.CurrentDodge += sharpmonAttacks.BoostDodge;
                    Console.WriteLine(this.Name + " à reussi sa canalisation,  esquive boostée de  " + sharpmonAttacks.BoostDodge + " points ");
                }
            }
            else
            {
                Console.WriteLine(sharpmonAttacks.Name + " à lamentablement échoué");
            }
            Console.WriteLine("Stat de " + this.Name + " :\n " + this.CurrentHP + " point de vie \n" + this.CurrentPower + " point de puissance \n" + this.CurrentDefense + " point de defense \n" + this.CurrentDodge + " point d'esquive  \n ##############################################################\n");
        }
        public string SharpmonAttackOnMulti(Attack sharpmonAttacks, Sharpmon targetSharpmon)
        {
             string reportFight;

            double attackSuccess = this.CurrentAccuracy / (this.CurrentAccuracy + targetSharpmon.CurrentDodge) + 0.1;

            Random rand = new Random();
            if (rand.NextDouble() > attackSuccess)
            {
                if (sharpmonAttacks.Damage != 0)
                {
                    double damage = (this.CurrentPower / sharpmonAttacks.Damage * targetSharpmon.CurrentDefense) * 10;
                    targetSharpmon.CurrentHP -= damage;
                    reportFight =$"L'attaque {sharpmonAttacks.Name}  à atteint sa cible avec succés et à infligé { damage } points de dommages à { targetSharpmon.Name}";                 
                }
                else if (sharpmonAttacks.BoostPower != 0)
                {
                    this.CurrentPower += sharpmonAttacks.BoostPower;
                    reportFight =$"L'inquentation {sharpmonAttacks.Name} à reussi sa canalisation,  puissance boostée de  { sharpmonAttacks.BoostPower} points";
                }
                else if (sharpmonAttacks.BoostDefense != 0)
                {
                    this.CurrentDefense += sharpmonAttacks.BoostDefense;
                    reportFight = $"L'inquentation {sharpmonAttacks.Name} à reussi sa canalisation, défense boostée de { sharpmonAttacks.BoostDefense } points   ";
                }
                else
                {
                    this.CurrentDodge += sharpmonAttacks.BoostDodge;
                    reportFight = $"L'inquentation {sharpmonAttacks.Name}  à reussi sa canalisation,  esquive boostée de  { sharpmonAttacks.BoostDodge } points ";
                }
            }
            else
            {
                reportFight = $"L'inquentation {sharpmonAttacks.Name} à lamentablement échoué";
            }
            reportFight +=$"\n Stat de { this.Name} :\n  {this.CurrentHP}  points de vie \n  {this.CurrentPower} points de puissance \n { this.CurrentDefense} points de defense \n { this.CurrentDodge } points d'esquive  \n ";

            return reportFight;
        }

        public object Clone()
        {
            return new Sharpmon(this.Name, this.MaxHP, this.BasePower, this.BaseDefense, this.BaseDodge, this.BaseAccuracy, this.Speed, this.Attacks);
        }
    }
}
