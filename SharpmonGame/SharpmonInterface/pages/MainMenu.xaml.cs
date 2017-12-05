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
    /// Logique d'interaction pour MainMenu.xaml
    /// </summary>
    public partial class MainMenu : UserControl
    {

        private  ClientData _clientData;
        public  Player _player { get; set; }
        public MainMenu(Player player , List<Sharpmon> sharpmonsExisting, List<ItemPlayer> itemPlayerExisting)
        {
            InitializeComponent();
            _player = player;
            view_namePlayer.Text =  player.Name + " que voulez vous faire ? ";
        }
        public MainMenu(ClientData clientData)
        {
            InitializeComponent();
            view_namePlayer.Text = clientData.NamePlayer + " que voulez vous faire ? ";
            _clientData = (ClientData)clientData.Clone();
        }
        private void MultiPlayer_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (_clientData == null)
            {
                _clientData = new ClientData(Guid.NewGuid().ToString(), _player.Name, _player.CurrentSharpmon);
            }
            Switcher.Switch(new MultiPlayer(_clientData));
        }
    }
}
