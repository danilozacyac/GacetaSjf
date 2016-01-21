using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using MantesisVerIusCommonObjects.Dto;
using GacetaSjf.Model;
using System.Windows.Input;

namespace GacetaSjf.Controles.Indices
{
    /// <summary>
    /// Interaction logic for IndiceTesis.xaml
    /// </summary>
    public partial class IndiceTesis : UserControl
    {
        ObservableCollection<TesisDto> listaTesis;
        TesisDto selectedTesis;

        public IndiceTesis()
        {
            InitializeComponent();
        }

        private void GTesis_Loaded(object sender, RoutedEventArgs e)
        {
            listaTesis = new TesisSjfModel().GetTesisIndices();

            GTesis.DataContext = listaTesis;
        }

        private void GTesis_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            int posActual = listaTesis.IndexOf(selectedTesis);

            UnaTesis showTesis = new UnaTesis(listaTesis, posActual);
            showTesis.ShowDialog();
        }

        private void GTesis_SelectionChanged(object sender, Telerik.Windows.Controls.SelectionChangeEventArgs e)
        {
            selectedTesis = GTesis.SelectedItem as TesisDto;
        }
    }
}
