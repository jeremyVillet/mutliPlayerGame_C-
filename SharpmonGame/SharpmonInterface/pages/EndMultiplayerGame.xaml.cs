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

namespace SharpmonInterface.pages
{
    /// <summary>
    /// Logique d'interaction pour EndMultiplayerGame.xaml
    /// </summary>
    public partial class EndMultiplayerGame : UserControl
    {
        private ClientData _clientData;
        public EndMultiplayerGame(string result,ClientData clientData)
        {
            InitializeComponent();
            _clientData = clientData;
            view_scoreFinal.Text = result;
        }

        private void ReturnMainMenu_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (_clientData != null)
            {
                _clientData.Opponent = null;
                _clientData.CurrentSharpmon.CurrentHP = _clientData.CurrentSharpmon.MaxHP;
                _clientData.StatutPlayer = "entre dans le salon";
            }
           
            Switcher.Switch(new MainMenu(_clientData));
        }
    }
}
