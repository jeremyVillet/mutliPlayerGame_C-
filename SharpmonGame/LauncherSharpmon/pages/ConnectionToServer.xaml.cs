using System;
using System.Collections.Generic;
using System.IO;
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

namespace LauncherSharpmon.pages
{
    /// <summary>
    /// Logique d'interaction pour ConnectionToServer.xaml
    /// </summary>
    public partial class ConnectionToServer : UserControl
    {
        private string lastIpKnown;
        public ConnectionToServer()
        {
            InitializeComponent();
            try
            {
                lastIpKnown = File.ReadAllText("SharpmonGame/adressIp.txt");
            }
            catch(FileNotFoundException e)
            {
                lastIpKnown = "255.255.255.255";
            }
            view_buttonLastConnection.Content = $"Se connecter au {lastIpKnown}";


        }

        private void click_connectToServer(object sender, System.Windows.RoutedEventArgs e)
        {
            Switcher.Switch(new Update(view_adresseIp.Text));
        }

        private void click_connectToLastServer(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new Update(lastIpKnown));
        }
    }
}
