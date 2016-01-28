using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using MantesisVerIusCommonObjects.Dto;
using GacetaSjf.Model;
using System.Windows.Input;
using GacetaSjf.Dao;
using GacetaSjf.Reportes;
using System.Collections.Generic;

namespace GacetaSjf.Controles.Indices
{
    /// <summary>
    /// Interaction logic for IndiceTesis.xaml
    /// </summary>
    public partial class IndiceTesis : UserControl
    {
        ObservableCollection<TesisDto> listaTesis;
        TesisDto selectedTesis;
        Materias selectedMateria;

        public IndiceTesis()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            CbxMaterias.DataContext = new MateriasModel().GetMaterias();
            listaTesis = new TesisSjfModel().GetTesisIndices();

            GTesis.DataContext = listaTesis;
        }

        private void GTesis_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void GTesis_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ObservableCollection<TesisDto> listaFiltrada = new ObservableCollection<TesisDto>( GTesis.Items.Cast<TesisDto>());

            int posActual = listaFiltrada.IndexOf(selectedTesis);

            UnaTesis showTesis = new UnaTesis(listaFiltrada, posActual);
            showTesis.ShowDialog();
        }

        private void GTesis_SelectionChanged(object sender, Telerik.Windows.Controls.SelectionChangeEventArgs e)
        {
            selectedTesis = GTesis.SelectedItem as TesisDto;
        }

        private void BtnPrint_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //ObservableCollection<TesisDto> queImprimir = GTesis.Items as ObservableCollection<TesisDto>;

            IEnumerable<TesisDto> tesisImprimir = GTesis.Items.Cast<TesisDto>();

            WordReports word = new WordReports(new ObservableCollection<TesisDto>(tesisImprimir));
            word.ListadoDeTesisIndice();
        }

        private void CbxMaterias_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedMateria = CbxMaterias.SelectedItem as Materias;

            if (selectedMateria.IdMateria == 99)
                GTesis.DataContext = listaTesis;
            else
                GTesis.DataContext = (from n in listaTesis
                                      where n.Materia1 == selectedMateria.IdMateria || n.Materia2 == selectedMateria.IdMateria
                                      || n.Materia3 == selectedMateria.IdMateria
                                      select n);
        }
    }
}