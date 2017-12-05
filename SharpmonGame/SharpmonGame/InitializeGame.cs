using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DllSharpmon.dll;

namespace SharpmonGame
{
     public class InitializeGame
    {
        public static List<Sharpmon> GenerateSharpmons()
        {
            List<Sharpmon> listSharpmons = new List<Sharpmon>();


            using (var entitie = new DBSharpmonGameEntities())
            {
                foreach (var sharpmonDB in entitie.DB_Sharpmons)
                {
                    List<Attack> listAttack = new List<Attack>();
                    foreach(var attackDB in entitie.DB_Attacks.Where(attack=>attack.sharpmonOwner== sharpmonDB.nom))
                    {
                        listAttack.Add(new Attack(attackDB.name, attackDB.damage, attackDB.boostPower, attackDB.boostDefense,attackDB.boostDodge));
                    }
                    listSharpmons.Add(new Sharpmon(sharpmonDB.nom,sharpmonDB.HP,sharpmonDB.power,sharpmonDB.defense,sharpmonDB.dodge,sharpmonDB.accuracy,sharpmonDB.speed, listAttack));
               
                }

            }

            return listSharpmons;
        }

        public static List<ItemPlayer> GenerateItemsPlayer()
        {
            List<ItemPlayer> listItemsPlayer = new List<ItemPlayer>();

            using(var entitie=new DBSharpmonGameEntities())
            {
                foreach(var itemPlayerDB in entitie.DB_ItemsPlayer)
                {
                    listItemsPlayer.Add(new ItemPlayer(itemPlayerDB.Name, itemPlayerDB.Price, itemPlayerDB.Description, itemPlayerDB.AddHp, itemPlayerDB.AddHp));
                }
            }
            return listItemsPlayer;

        }


    }
}
