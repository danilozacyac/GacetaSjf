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

            DetalleDoctos doctos = new DetalleDoctos(listaVotos.Cast<Votos>(), index);
            doctos.ShowDialog();
        }
    }
}
