using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using GacetaSjf.Singletons;

namespace GacetaSjf.Controles
{
    /// <summary>
    /// Interaction logic for MesPdf.xaml
    /// </summary>
    public partial class MesPdf : UserControl
    {
        public MesPdf()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Enero.DataContext = TomosSingleton.Tomos[0];
            Febrero.DataContext = TomosSingleton.Tomos[1];
            Marzo.DataContext = TomosSingleton.Tomos[2];
            Abril.DataContext = TomosSingleton.Tomos[3];
            Mayo.DataContext = TomosSingleton.Tomos[4];
            Junio.DataContext = TomosSingleton.Tomos[5];
            Julio.DataContext = TomosSingleton.Tomos[6];
            Agosto.DataContext = TomosSingleton.Tomos[7];
            Septiembre.DataContext = TomosSingleton.Tomos[8];
            Octubre.DataContext = TomosSingleton.Tomos[9];
            Noviembre.DataContext = TomosSingleton.Tomos[10];
            Diciembre.DataContext = TomosSingleton.Tomos[11];
        }
    }
}
