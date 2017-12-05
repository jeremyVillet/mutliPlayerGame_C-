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
    /// Logique d'interaction pour CreatePlayer.xaml
    /// </summary>
    public partial class CreatePlayer : UserControl
    {
        private List<Sharpmon> sharpmonsExisting = new List<Sharpmon>();
        private List<ItemPlayer> itemPlayerExisting = new List<ItemPlayer>();

        private Random aleatoire = new Random();
        private Sharpmon sharpmonSelected;
         
        public CreatePlayer(List<Sharpmon> _sharpmonsExisting, List<ItemPlayer> _itemPlayerExisting)
        {
            InitializeComponent();
            sharpmonsExisting = _sharpmonsExisting;
            itemPlayerExisting= _itemPlayerExisting;
             sharpmonSelected = sharpmonsExisting[aleatoire.Next(0, 7)];
            view_sharpmonSeleced.Text = $"Sharpmon attribué : {sharpmonSelected.Name} ";


        }
        private void StartGame_Click(object sender, RoutedEventArgs e)
        {
            if (view_namePlayer.Text != null && view_namePlayer.Text != "" && view_namePlayer.Text.Count()<30)
            {

                Player player = new Player(view_namePlayer.Text, new List<Sharpmon>() { sharpmonsExisting[0] }, sharpmonSelected, 1500, new List<ItemPlayer>() { itemPlayerExisting[0], itemPlayerExisting[0] });

                Switcher.Switch(new MainMenu(player,sharpmonsExisting,itemPlayerExisting));
            }
            else
            {
                view_errorName.Text = "* Veuillez entrer un nom valide";
            }
           
        }
    }
}
