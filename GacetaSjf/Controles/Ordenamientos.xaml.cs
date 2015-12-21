using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using GacetaSjf.Dao;
using MantesisVerIusCommonObjects.Dto;
using GacetaSjf.Model;

namespace GacetaSjf.Controles
{
    /// <summary>
    /// Interaction logic for Ordenamientos.xaml
    /// </summary>
    public partial class Ordenamientos : UserControl
    {

        ObservableCollection<Temas> listaOrdenamientos;
        ObservableCollection<TesisDto> listaTesis;

        Temas selectedTema;
        TesisDto selectedTesis;

        public Ordenamientos()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            listaOrdenamientos = new TemasModel().GetTemas(1);

            GOrdenamientos.DataContext = listaOrdenamientos;

            
        }

        private void GOrdenamientos_SelectionChanged(object sender, Telerik.Windows.Controls.SelectionChangeEventArgs e)
        {
            selectedTema = GOrdenamientos.SelectedItem as Temas;

            listaTesis = new TesisSjfModel().GetTesis(selectedTema);

            GTesis.DataContext = listaTesis;
        }

        private void GTesis_SelectionChanged(object sender, Telerik.Windows.Controls.SelectionChangeEventArgs e)
        {
            selectedTesis = GTesis.SelectedItem as TesisDto;
        }

        private void GTesis_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            int index = listaTesis.IndexOf(selectedTesis);

            UnaTesis showTesis = new UnaTesis(listaTesis, index);
            showTesis.ShowDialog();
        }
    }
}
