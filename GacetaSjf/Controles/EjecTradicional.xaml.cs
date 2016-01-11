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


            DetalleDoctos doctos = new DetalleDoctos(listaEjecutorias.Cast<Votos>() ,index);
            doctos.ShowDialog();
        }
    }
}
