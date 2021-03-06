﻿using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using GacetaSjf.Dao;
using GacetaSjf.Model;
using GacetaSjf.Singletons;
using MantesisVerIusCommonObjects.Dto;
using GacetaSjf.Reportes;
using System.Collections.Generic;

namespace GacetaSjf.Controles
{
    /// <summary>
    /// Interaction logic for Tradicional.xaml
    /// </summary>
    public partial class Tradicional : UserControl
    {
        public ObservableCollection<TesisDto> listaTesis;
        private Tomos selectedTomo;
        private TesisDto selectedTesis;
        private DatosCompartidos selectedInstancia;

        private bool vaciarListado = true;

        public Tradicional()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            listaTesis = new TesisSjfModel().GetTesis();

            GTesis.DataContext = listaTesis;
            CbxVolumen.DataContext = new Tomos().GetTomos();

            CbxInstancia.DataContext = CompartidosSingleton.InstanciasTesis;

        }

        private void CbxVolumen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedTomo = CbxVolumen.SelectedItem as Tomos;

            GTesis.DataContext = (from n in listaTesis
                                  where n.VolumenInt == selectedTomo.Volumen
                                  select n);
        }

        private void BtnIncorpora_Click(object sender, RoutedEventArgs e)
        {
            if (vaciarListado)
            {
                listaTesis = new ObservableCollection<TesisDto>();
                GTesis.DataContext = listaTesis;
                vaciarListado = false;
            }

            int ius = Convert.ToInt32(TxtIus.Text);

            TesisDto tesis = new TesisSjfModel().GetTesis(ius);

            if (tesis == null)
            {
                MessageBox.Show("El número de tesis que ingresaste no existe, favor de verificar", "Atención:", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if (listaTesis.Contains(tesis))
            {
                MessageBox.Show("La tesis solicitada ya se encuentra dentro del listado", "Atención:", MessageBoxButton.OK, MessageBoxImage.Information);
                TxtIus.Text = String.Empty;
                return;
            }
            else
            {
                listaTesis.Add(tesis);
                TxtIus.Text = String.Empty;
            }

            
        }

        private void BtnSecuencial_Click(object sender, RoutedEventArgs e)
        {
            listaTesis = new TesisSjfModel().GetTesis();

            GTesis.DataContext = listaTesis;
            vaciarListado = true;
        }

        private void GTesis_SelectionChanged(object sender, Telerik.Windows.Controls.SelectionChangeEventArgs e)
        {
            selectedTesis = GTesis.SelectedItem as TesisDto;
        }

        private void GTesis_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            ObservableCollection<TesisDto> listaFiltrada = new ObservableCollection<TesisDto>(GTesis.Items.Cast<TesisDto>());

            int posActual = listaFiltrada.IndexOf(selectedTesis);

            UnaTesis showTesis = new UnaTesis(listaFiltrada, posActual);
            showTesis.ShowDialog();
           
        }

        private void CbxInstancia_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedInstancia = CbxInstancia.SelectedItem as DatosCompartidos;

            if (selectedTomo != null)
            {
                GTesis.DataContext = (from n in listaTesis
                                      where n.VolumenInt == selectedTomo.Volumen && n.Sala == selectedInstancia.IdElemento
                                      select n);
            }
            else
            {
                GTesis.DataContext = (from n in listaTesis
                                      where n.Sala == selectedInstancia.IdElemento
                                      select n);
            }


        }

        private void BtnPrint_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            IEnumerable<TesisDto> tesisImprimir = GTesis.Items.Cast<TesisDto>();

            WordReports word = new WordReports(new ObservableCollection<TesisDto>(tesisImprimir));
            word.ListadoDeTesisTabla();
        }

        private void SearchTextBox_Search(object sender, RoutedEventArgs e)
        {
            String tempString = ((TextBox)sender).Text.ToUpper().Trim();

            if (!String.IsNullOrEmpty(tempString))
            {
                var temporal = (from n in listaTesis
                                where n.Rubro.ToUpper().Contains(tempString) || n.Tesis.ToUpper().Contains(tempString) || n.Texto.ToUpper().Contains(tempString) || n.Precedentes.ToUpper().Contains(tempString)
                                select n).ToList();
                GTesis.DataContext = temporal;
            }
            else
            {
                GTesis.DataContext = listaTesis;
            }
        }

        private void BtnBusqueda_Click(object sender, RoutedEventArgs e)
        {
            Busqueda buscar = new Busqueda();
            buscar.ShowDialog();
        }
    }
}
