using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using GacetaSjf.Dao;
using GacetaSjf.Model;

namespace GacetaSjf.Controles
{
    /// <summary>
    /// Interaction logic for EjecTradicional.xaml
    /// </summary>
    public partial class EjecTradicional : UserControl
    {

        ObservableCollection<Ejecutoria> listaEjecutorias;
        Ejecutoria selectedEjecutoria;

        private bool vaciarListado = true;

        public EjecTradicional()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            listaEjecutorias = new EjecutoriaModel().GetEjecutoria();
            GEjecutoria.DataContext = listaEjecutorias;
        }

        private void GEjecutoria_SelectionChanged(object sender, Telerik.Windows.Controls.SelectionChangeEventArgs e)
        {
            selectedEjecutoria = GEjecutoria.SelectedItem as Ejecutoria;
        }

        private void GEjecutoria_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            int index = listaEjecutorias.IndexOf(selectedEjecutoria);


            DetalleDoctos doctos = new DetalleDoctos(listaEjecutorias.Cast<Documento>(), index);
            doctos.ShowDialog();
        }

        private void BtnSecuencial_Click(object sender, RoutedEventArgs e)
        {
            listaEjecutorias = new EjecutoriaModel().GetEjecutoria();
            GEjecutoria.DataContext = listaEjecutorias;
            vaciarListado = true;
        }

        private void BtnIncorpora_Click(object sender, RoutedEventArgs e)
        {
            if (vaciarListado)
            {
                listaEjecutorias = new ObservableCollection<Ejecutoria>();
                GEjecutoria.DataContext = listaEjecutorias;
                vaciarListado = false;
            }

            int ius = Convert.ToInt32(TxtIus.Text);

            Ejecutoria ejecutoria = new EjecutoriaModel().GetEjecutoria(ius);

            if (ejecutoria == null)
            {
                MessageBox.Show("El registro digital que ingresaste no existe, favor de verificar", "Atención:", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if (listaEjecutorias.Contains(ejecutoria))
            {
                MessageBox.Show("La ejecutoria solicitada ya se encuentra dentro del listado", "Atención:", MessageBoxButton.OK, MessageBoxImage.Information);
                TxtIus.Text = String.Empty;
                return;
            }
            else
            {
                listaEjecutorias.Add(ejecutoria);
                TxtIus.Text = String.Empty;
            }
        }
    }
}
