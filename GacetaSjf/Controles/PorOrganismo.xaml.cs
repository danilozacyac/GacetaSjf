using GacetaSjf.Model;
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

namespace GacetaSjf.Controles
{
    /// <summary>
    /// Interaction logic for PorOrganismo.xaml
    /// </summary>
    public partial class PorOrganismo : UserControl
    {
        public PorOrganismo()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            TreeOrganismos.DataContext = new OrganismosModel().GetOrganismosTree(10);
        }
    }
}
