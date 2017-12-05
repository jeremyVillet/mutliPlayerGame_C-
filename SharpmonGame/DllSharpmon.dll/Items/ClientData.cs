using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllSharpmon.dll
{
    [Serializable]
    public class ClientData : ICloneable
    {
        public string IdPlayer { get; set; }
        public string NamePlayer { get; set; }
        public string StatutPlayer { get; set; }
        public int ActionPlayer { get; set; }
        public string ReportFight { get; set; }
        public string ReportFightOpponant { get; set; }

        public Sharpmon CurrentSharpmon { get; set; }
        public ClientData Opponent { get; set; }

        public int PlayersConnected { get; set; }

        public ClientData(string idPlayer, string namePlayer, Sharpmon currentSharpmon, ClientData opponant = null, int actionPlayer = 0)
        {
            IdPlayer = idPlayer;
            StatutPlayer = "entre dans le salon";
            ActionPlayer = actionPlayer;
            ReportFight = null;
            ReportFightOpponant = null;
           NamePlayer = namePlayer;
            CurrentSharpmon = currentSharpmon;
            Opponent = opponant;
            PlayersConnected = 0;
        }
        public void ManageQueue(List<ClientData> playersConnected)
        {
            if (playersConnected.Count >= 2)
            {
                // cas ou un adversaire a deja été attribué au joueur
                foreach (ClientData _playerWaiting in playersConnected.Where(_playerWaiting => _playerWaiting.Opponent != null && _playerWaiting.Opponent.IdPlayer == this.IdPlayer))
                {
                    this.Opponent = new ClientData(_playerWaiting.IdPlayer, _playerWaiting.NamePlayer, _playerWaiting.CurrentSharpmon);
                }

                if (this.Opponent == null) // cas ou adversaire pas encore attribué au joueur
                {
                    foreach (ClientData _playerWaiting in playersConnected.Where(_playerWaiting => _playerWaiting.IdPlayer != this.IdPlayer && _playerWaiting.Opponent == null))
                    {
                        this.Opponent = new ClientData(_playerWaiting.IdPlayer, _playerWaiting.NamePlayer, _playerWaiting.CurrentSharpmon);
                        _playerWaiting.Opponent = new ClientData(this.IdPlayer, this.NamePlayer, this.CurrentSharpmon);
                    }
                }

                if (this.Opponent != null)
                {
                    this.StatutPlayer = "la partie commence";
                }
            }
        }

        // Determine qui commence la partie , qui joue en deuxième
        public void InitializeGame(List<ClientData> playersConnected)
        {
            foreach (ClientData player in playersConnected)
            {

                if (this.Opponent.IdPlayer == player.IdPlayer && player.StatutPlayer == "la partie commence")
                {
                    this.StatutPlayer = "joue durant ce tour";
                    player.StatutPlayer = "l'adversaire joue";
                }
                else if (this.Opponent.IdPlayer == player.IdPlayer && player.StatutPlayer == "joue durant ce tour")
                {
                    this.StatutPlayer = "l'adversaire joue";
                }
                else if (this.Opponent.IdPlayer == player.IdPlayer && player.StatutPlayer == "l'adversaire joue")
                {
                    this.StatutPlayer = "joue durant ce tour";
                }
            }
        }

        public void IsPlaying(List<ClientData> playersConnected)
        {
            if (this.ActionPlayer != 0)
            {
                foreach (ClientData _oppenant in playersConnected.Where(_oppenant => _oppenant.IdPlayer == this.Opponent.IdPlayer))
                {

                    string reportFight = this.CurrentSharpmon.SharpmonAttackOnMulti(this.CurrentSharpmon.Attacks[this.ActionPlayer-1], _oppenant.CurrentSharpmon);
                    this.ReportFight = reportFight;
                    _oppenant.ReportFightOpponant = reportFight;
                    this.StatutPlayer = "l'adversaire joue";                 
                    _oppenant.StatutPlayer = "joue durant ce tour";
                    this.ActionPlayer = 0;

                }
            }

        }


        public object Clone()
        {
            return new ClientData(this.IdPlayer, this.NamePlayer, this.CurrentSharpmon, this.Opponent);
        }
    }
}
