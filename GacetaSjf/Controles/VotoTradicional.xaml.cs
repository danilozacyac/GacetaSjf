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
    /// Lógica de interacción para VotoTradicional.xaml
    /// </summary>
    public partial class VotoTradicional : UserControl
    {
        ObservableCollection<Votos> listaVotos;
        Votos selectedVoto;

        private bool vaciarListado = true;

        public VotoTradicional()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            listaVotos = new VotosModel().GetVotos();
            GVotos.DataContext = listaVotos;
        }

        private void GEjecutoria_SelectionChanged(object sender, Telerik.Windows.Controls.SelectionChangeEventArgs e)
        {
            selectedVoto = GVotos.SelectedItem as Votos;
        }

        private void GEjecutoria_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            int index = listaVotos.IndexOf(selectedVoto);

            DetalleDoctos doctos = new DetalleDoctos(listaVotos.Cast<Documento>(), index);
            doctos.ShowDialog();
        }

        private void BtnSecuencial_Click(object sender, RoutedEventArgs e)
        {
            listaVotos = new VotosModel().GetVotos();
            GVotos.DataContext = listaVotos;
            vaciarListado = true;
        }

        private void BtnIncorpora_Click(object sender, RoutedEventArgs e)
        {
            if (vaciarListado)
            {
                listaVotos = new ObservableCollection<Votos>();
                GVotos.DataContext = listaVotos;
                vaciarListado = false;
            }

            int ius = Convert.ToInt32(TxtIus.Text);

            Votos ejecutoria = new VotosModel().GetVotos(ius);

            if (ejecutoria == null)
            {
                MessageBox.Show("El registro digital que ingresaste no existe, favor de verificar", "Atención:", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if (listaVotos.Contains(ejecutoria))
            {
                MessageBox.Show("El voto solicitado ya se encuentra dentro del listado", "Atención:", MessageBoxButton.OK, MessageBoxImage.Information);
                TxtIus.Text = String.Empty;
                return;
            }
            else
            {
                listaVotos.Add(ejecutoria);
                TxtIus.Text = String.Empty;
            }
        }
    }
}
