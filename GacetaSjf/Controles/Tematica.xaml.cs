﻿using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using GacetaSjf.Dao;
using GacetaSjf.Model;
using MantesisVerIusCommonObjects.Dto;

namespace GacetaSjf.Controles
{
    /// <summary>
    /// Interaction logic for Tematica.xaml
    /// </summary>
    public partial class Tematica : UserControl
    {

        ObservableCollection<Temas> listaTematico;
        ObservableCollection<TesisDto> listaTesis;
        Temas selectedTema;
        TesisDto selectedTesis;

        public Tematica()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            listaTematico = new TemasModel().GetTemas(0);
            LstTematico.DataContext = listaTematico;
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

        private void LstTematico_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedTema = LstTematico.SelectedItem as Temas;
            listaTesis = new TesisSjfModel().GetTesis(selectedTema);

            GTesis.DataContext = listaTesis;
        }
    }
}
