using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using GacetaSjf.Dao;
using MantesisVerIusCommonObjects.Dto;

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
