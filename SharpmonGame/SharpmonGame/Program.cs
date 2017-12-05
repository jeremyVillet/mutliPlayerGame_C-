using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DllSharpmon.dll;


namespace SharpmonGame
{
    class Program
    {

        static void Main(string[] args)
        {

            //            Console.WriteLine("############### Sharpmon Game ###############\n");
            //            Console.Title = "Sharpmon Game";
            //            bool playerIsPlaying = true;
            //            bool validCommand;


            //            // On crée les objets items et sharpmon a partir des données de la DB , les listes  represente tous les sharpmon/item existant dans le jeu      
            //            List<Sharpmon> sharpmonsExisting = new List<Sharpmon>(InitializeGame.GenerateSharpmons());
            //            List<ItemPlayer> itemPlayerExisting = new List<ItemPlayer>(InitializeGame.GenerateItemsPlayer());

            //            Console.WriteLine("Please choose a name :");
            //            Random aleatoire = new Random();
            //            Player player = new Player(Console.ReadLine(),new List<Sharpmon>() { sharpmonsExisting[0]}, sharpmonsExisting[aleatoire.Next(0, 3)],1500,new List<ItemPlayer>() { itemPlayerExisting [0], itemPlayerExisting[0] });
            //            Console.WriteLine("\nHello "+player.Name+"\nWelcome in Sharpmon world !\n");


            //            // Gestion partie

            //            while (playerIsPlaying)
            //            {

            //                do
            //                {
            //                    Console.Write("Where do you want to go ? \n0: Into the wild \n1: In the shop \n2: In the Sarpmon Center \n3:Exit game\n4: Multiplayer game\n");
            //                    ConsoleKeyInfo actionKey = Console.ReadKey(true);
            //                    validCommand = true;
            //                    switch (actionKey.Key)
            //                    {
            //                        case ConsoleKey.D0:
            //                        case ConsoleKey.NumPad0:
            //                            Sharpmon enemy = (Sharpmon)sharpmonsExisting[2].Clone();
            //                            bool isFighting = true;
            //                            Console.WriteLine(enemy.Name + " vous attaques ! " + player.CurrentSharpmon.Name + " entre en scéne ");

            //                            while(isFighting)
            //                            {
            //                                Console.Write("What do you want to do ? \n0: Attack \n1: Run away\n\n");
            //                                ConsoleKeyInfo actionFightKey = Console.ReadKey(true);
            //                                switch (actionFightKey.Key)
            //                                {
            //                                    case ConsoleKey.D0:
            //                                    case ConsoleKey.NumPad0:
            //                                        player.CurrentSharpmon.SharpmonAttack(player.CurrentSharpmon.Attacks[0], enemy);

            //                                        Console.WriteLine("C'est le tour de " + enemy.Name + " de vous attaquer ");
            //                                        enemy.SharpmonAttack(enemy.Attacks[0], player.CurrentSharpmon);
            //                                        break;

            //                                    case ConsoleKey.D1:
            //                                    case ConsoleKey.NumPad1:
            //                                        Console.WriteLine("Vous fuyez le combat misérablement ");
            //                                        isFighting = false;
            //                                        break;
            //                                }
            //                                if(enemy.CurrentHP <= 0)
            //                                {
            //                                    isFighting = false;
            //                                    Console.WriteLine(enemy.Name +" à battu votre sharpmon  " +player.CurrentSharpmon.Name);
            //                                }
            //                                else if (player.CurrentSharpmon.CurrentHP<=0)
            //                                {
            //                                    isFighting = false;
            //                                    player.CurrentSharpmon.Experience += 10;
            //                                    Console.WriteLine( player.CurrentSharpmon.Name +" a gagner contre "+ enemy.Name +"\n Vous gagné 10 points d'experiences , vous avez désormais "+player.CurrentSharpmon.Experience +" points d'experiences\n" );
            //                                }


            //                            }

            //                            break;

            //                        case ConsoleKey.D1:
            //                        case ConsoleKey.NumPad1:



            //                            break;

            //                        case ConsoleKey.D2:
            //                        case ConsoleKey.NumPad2:

            //                            break;
            //                        case ConsoleKey.D3:
            //                        case ConsoleKey.NumPad3:
            //                            playerIsPlaying = false;
            //                            Console.WriteLine("See you soon " + player.Name + " :-)");
            //                            break;

            //                        case ConsoleKey.D4:
            //                        case ConsoleKey.NumPad4:
            //                            bool multiplayerGame = true;
            //                            Console.Clear();
            //                            Console.WriteLine("Debut de la partie multijoueur ....\n\n");
            //                            ClientData clientData = new ClientData(Guid.NewGuid().ToString(),player.Name,player.CurrentSharpmon);
            //                            ClientTCP.ConnectToServer("192.168.1.46");




            //                            while (multiplayerGame)
            //                            {
            //                                Console.Clear();
            //                                Console.WriteLine("Status : {0}", clientData.StatutPlayer);

            //                                switch (clientData.StatutPlayer)
            //                                {
            //                                    case "la partie commence": // Un adversaire à été trouvé , la partie commence
            //                                        Console.WriteLine("{0} Your oppenent is  : {1} \n Prepare you for the fight ! \n ", clientData.NamePlayer, clientData.Opponent.NamePlayer);
            //                                        break;

            //                                    case "joue durant ce tour":
            //                                        Console.WriteLine("You have to play ! Please , choice an action : \n Press 1 to attack  ");
            //                                        ConsoleKeyInfo actionPlayerKey = Console.ReadKey(true);
            //                                        do
            //                                        {
            //                                            switch (actionPlayerKey.Key)
            //                                            {
            //                                                case ConsoleKey.D1:
            //                                                case ConsoleKey.NumPad1:                                      
            //                                                    clientData.ActionPlayer = 1;
            //                                                    validCommand = true;
            //                                                    break;

            //                                                //case ConsoleKey.D2:
            //                                                //case ConsoleKey.NumPad2:
            //                                                //    clientData.ActionPlayer = 2;
            //                                                //    validCommand = true;
            //                                                //    break;

            //                                                default:
            //                                                    validCommand = false;
            //                                                    break;
            //                                            }
            //                                        } while (!validCommand);


            //                                        break;

            //                                    case "l'adversaire joue":
            //                                        Console.WriteLine("Rapport du combat : \n {0}  ", clientData.ReportFight);
            //                                        Console.WriteLine("Your oppenant {0} is playing ..",clientData.Opponent.NamePlayer);
            //                                        break;
            //                                    //case "Prepare next Round":
            //                                    //    if (clientData.ReportFight != null)
            //                                    //    {
            //                                    //        Console.WriteLine("Rapport du combat : \n {0} \n Apuyez sur la touche Entrée pour continuer ", clientData.ReportFight);
            //                                    //        Console.ReadLine();

            //                                    //    }
            //                                    //    break;
            //                                }


            //                                byte[] clientDataRaw=Utils.ConvertObjToByte(clientData);

            //                                ClientTCP.SendDataToServer(clientDataRaw);
            //                                clientData= ClientTCP.ReceivedDataToServer();



            //                            }
            //                            ClientTCP.CloseConnection();


            //                            break;


            //                        default:
            //                            validCommand = false;
            //                            break;
            //                    }

            //                } while (!validCommand);


            //            }


        }


    }
    }
