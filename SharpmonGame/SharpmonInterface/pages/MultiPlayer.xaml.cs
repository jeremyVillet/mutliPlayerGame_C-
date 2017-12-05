using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DllSharpmon.dll;
using System.Threading;
using System.IO;

namespace SharpmonInterface.pages
{
    /// <summary>
    /// Logique d'interaction pour MultiPlayer.xaml
    /// </summary>
    public partial class MultiPlayer : UserControl
    {
       
        private readonly CancellationTokenSource cts = new CancellationTokenSource();
        public ClientData clientData { get; set; }
        private string resultGame { get; set; }
       
        public MultiPlayer(ClientData _clientData)
        {
            InitializeComponent();
            clientData = (ClientData)_clientData.Clone();


            //string ipServer = File.ReadAllText("SharpmonGame/adressIp.txt");
            string ipServer = "10.10.16.155";


            ClientTCP.ConnectToServer(ipServer);

            view_button1Action.Content = clientData.CurrentSharpmon.Attacks[0].Name;
            view_button2Action.Content = clientData.CurrentSharpmon.Attacks[1].Name;

            Loaded += SyncronizeWihtServer;
        }
        private async void SyncronizeWihtServer(object sender, RoutedEventArgs routedEventArgs)
        {
            
           

            while (!cts.IsCancellationRequested ) // while infi fait de facon non blocante
            {
                int delay = 1000;
                await Task.Delay(delay);

                view_statutPlayer.Text = $"Statut : { clientData.StatutPlayer}";
                view_PlayerCo.Text = $"Joueurs connectés {clientData.PlayersConnected}";
                switch (clientData.StatutPlayer)
                {
                    case "attente d un joueur":
                        view_versusPlayer.Text = clientData.NamePlayer;
                        view_versusopponant.Text = "??";


                        break;
                    case "la partie commence":
                        view_versusopponant.Text = clientData.Opponent.NamePlayer;
                        delay = 500;
                        break;
                    case "joue durant ce tour":
                        if (clientData.ActionPlayer == 0)
                        {
                            ToggleInterfaceAttak(Visibility.Visible);
                            DisplayAndRefreshStatSharpmon();
                            view_rapportOpponant.Text = clientData.ReportFightOpponant;
                        }
                        break;
                    case "l'adversaire joue":
                        ToggleInterfaceAttak(Visibility.Hidden);
                        view_rapport.Text = clientData.ReportFight;
                        view_rapportOpponant.Text = clientData.ReportFightOpponant;
                        DisplayAndRefreshStatSharpmon();
                        break;
                }

                if (CheckGameFinished())
                {
                    break;
                }

                if (clientData.StatutPlayer!= "joue durant ce tour" || clientData.ActionPlayer != 0)
                {
                    Boolean connected;
                    byte[] clientDataRaw = Utils.ConvertObjToByte(clientData);
                    ClientTCP.SendDataToServer(clientDataRaw);            
                    clientData = ClientTCP.ReceivedDataToServer(clientData);
                    
                  
                    if (clientData.StatutPlayer== "erreur connection")
                    {
                        resultGame = "Le serveur de jeu rencontre actuellement des problème \n la partie à été annulée";
                        break;
                    }
                }
               
            }
            Switcher.Switch(new EndMultiplayerGame(resultGame, clientData));
        }

        private void ToggleInterfaceAttak(Visibility visibility)
        {
            view_blocAction.Visibility = visibility;
            view_titleAction.Visibility = visibility;
            view_button1Action.Visibility = visibility;
            view_button2Action.Visibility = visibility;
        }

        private void Action1Player_click(object sender, System.Windows.RoutedEventArgs e)
        {      
            clientData.ActionPlayer = 1;
            ToggleInterfaceAttak(Visibility.Hidden);
        }
        private void Action2Player_click(object sender, System.Windows.RoutedEventArgs e)
        {
            clientData.ActionPlayer = 2;
            ToggleInterfaceAttak(Visibility.Hidden);
        }

        private bool CheckGameFinished()
        {
            if (clientData.CurrentSharpmon.CurrentHP <= 0)
            {
                resultGame = "Vous avez perdu !" + clientData.Opponent.NamePlayer + "\n à gagné !";
                return true;
            }else if(clientData.Opponent!=null &&   clientData.Opponent.CurrentSharpmon.CurrentHP<0){
                resultGame = "Vous avez gagné !" + clientData.Opponent.NamePlayer + " \n à perdu !";
                return true;
            }
          
            return false;
        }

        private void DisplayAndRefreshStatSharpmon()
        {
            view_Stat_namePlayer.Text = clientData.CurrentSharpmon.Name;
            view_Stat_currentHpPlayer.Text =$"Vie  : {clientData.CurrentSharpmon.CurrentHP}";
            view_Stat_nameOpponent.Text = clientData.Opponent.CurrentSharpmon.Name; ;
            view_Stat_currentHpOpponnent.Text =$"Vie  : {clientData.Opponent.CurrentSharpmon.CurrentHP}";
        }

       
        

    }
}
