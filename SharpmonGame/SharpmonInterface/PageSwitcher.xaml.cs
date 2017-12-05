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
using SharpmonInterface.pages;

namespace SharpmonInterface
{
    /// <summary>
    /// Logique d'interaction pour PageSwitcher.xaml
    /// </summary>
    public partial class PageSwitcher : Window
    {
        public PageSwitcher()
        {
           
            InitializeComponent();
            Switcher.pageSwitcher = this;
            Switcher.Switch(new PatchNotes());
        }

        public void Navigate(UserControl nextPage)
        {
            this.Content = nextPage;
        }

        public void Navigate(UserControl nextPage, object state)
        {
            this.Content = nextPage;
            ISwitchable s = nextPage as ISwitchable;

            if (s != null)
                s.UtilizeState(state);
            else
                throw new ArgumentException("Implement ISwitchable "
                  + nextPage.Name.ToString());
        }
    }
}
