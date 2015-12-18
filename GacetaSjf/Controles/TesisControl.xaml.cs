using GacetaSjf.Dao;
using MantesisVerIusCommonObjects.Dto;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for Tesis.xaml
    /// </summary>
    public partial class TesisControl : UserControl
    {
        public ObservableCollection<TesisDto> listaTesis;
        private Tomos selectedTomo;

        public TesisControl()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (listaTesis == null)
                listaTesis = new ObservableCollection<TesisDto>();

            GTesis.DataContext = listaTesis;

            CbxVolumen.DataContext = new Tomos().GetTomos();

        }

        private void CbxVolumen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedTomo = CbxVolumen.SelectedItem as Tomos;

            GTesis.DataContext = (from n in listaTesis
                                  where n.VolumenInt == selectedTomo.Volumen
                                  select n);
        }
    }
}
