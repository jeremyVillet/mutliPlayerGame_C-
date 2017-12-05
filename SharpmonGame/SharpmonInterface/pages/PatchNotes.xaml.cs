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
using SharpmonInterface;
using DllSharpmon.dll;

namespace SharpmonInterface.pages
{
    /// <summary>
    /// Logique d'interaction pour PatchNotes.xaml
    /// </summary>
    public partial class PatchNotes : UserControl
    {
        private List<Sharpmon> sharpmonsExisting = new List<Sharpmon>();
        private List<ItemPlayer> itemPlayerExisting = new List<ItemPlayer>();
        public PatchNotes()
        {
            InitializeComponent();

            // On crée les objets items et sharpmon a partir des données de la DB , les listes  represente tous les sharpmon/item existant dans le jeu      
            sharpmonsExisting = new List<Sharpmon>(InitializeGameForInterface.GenerateSharpmons());
            itemPlayerExisting = new List<ItemPlayer>(InitializeGameForInterface.GenerateItemsPlayer());
        }

        private void Click_next(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new CreatePlayer(sharpmonsExisting,itemPlayerExisting));
        }
    }
}
